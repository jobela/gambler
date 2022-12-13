namespace Gambler.PoC.Services
{
    using Gambler.PoC.Data;
    using Gambler.PoC.Business.Entities;
    using Gambler.PoC.Models;
    using System.Web.Http;

    public interface IGamblerService
    {
        Gambler Register(string nickname);
        Score Bet(Guid id, int value);
        Score Lottery(Guid id);
        Score Score(Guid id);
        IEnumerable<Score> GetTopGamblers();
    }

    public class GamblerService : IGamblerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _maxBetsPerDay = 500;

        public GamblerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Score Bet(Guid id, int value)
        {
            var response = new Score();

            var entity = _unitOfWork.Gamblers
                .Find(g => g.UniquieIdentity == id)
                .FirstOrDefault();

            if (entity == null)
                throw new BadHttpRequestException("Unknown gambler");

            if (value < 0)
                throw new BadHttpRequestException("You cannot bet a negative number...");

            if (value > entity.Score)
                throw new BadHttpRequestException("You cannot bet more than you have...");

            if(entity.LatestBet.Date == DateTime.Now.Date && entity.NumberOfBets >= _maxBetsPerDay)
                throw new ThrottlingException("You have reached your treshold for number of bets pr. day...");

            // Implement really smart algorithm with 50%-ish win chance unless betting cool numbers
            var factor = 1.0;

            if (value == 69 || value == 420 || value == 666 || value == 1337)
                factor = 1.1;

            if (Random.Shared.Next(1, 100) < (51 * factor))
            {
                // Win
                entity.Score += value;
                response.Message = string.Format("Gambler won {0}!", value);
            }
            else
            {
                // Loss
                entity.Score -= value;
                response.Message = string.Format("Gambler lost {0}!", value);
            }

            // Reset counter if new date
            if(entity.LatestBet.Date != DateTime.Now.Date)
                entity.NumberOfBets = 1;
            else
                entity.NumberOfBets += 1;

            entity.LatestBet = DateTime.Now;

            // Update highscore
            entity.Highscore = entity.Score > entity.Highscore ? entity.Score : entity.Highscore;

            // Set the reponse
            response.Nickname = entity.Nickname;
            response.Points = entity.Score;
            response.NumberOfBets = entity.NumberOfBets;
            response.LatestBet = entity.LatestBet;
            response.Highscore = entity.Highscore;

            // If you are terrible at betting we will always help you out
            if (entity.Score < 100)
            { 
                entity.Score = 100;
                response.Points = entity.Score;
                response.Message = response.Message + " Value reset to 100!";
            }

            _unitOfWork.Complete();

            return response;
        }

        public Score Lottery(Guid id)
        {
            var response = new Score();
            
            var entity = _unitOfWork.Gamblers
                .Find(g => g.UniquieIdentity == id)
                .FirstOrDefault();

            if (entity == null)
                throw new Exception("Unknown gambler");

            // Implement really smart algorithm with a very low win chance
            if (Random.Shared.Next(0, 10000) <= 10)
            {
                // Win
                entity.Score += 100000;
                response.Message = string.Format("Gambler won the lottery!");

            }
            else
            {
                // Loose
                entity.Score -= 100;
                response.Message = string.Format("Sorry, no lottery for you! We took 100 points from your account");
            }

            response.Nickname = entity.Nickname;
            response.Points = entity.Score;

            _unitOfWork.Complete();

            return response;
        }

        public IEnumerable<Score> GetTopGamblers()
        {
            return _unitOfWork.Gamblers.GetTopGamblers()
                .Select(g => new Score() 
                {   Nickname = g.Nickname, 
                    Points = g.Score,
                    Highscore = g.Highscore,
                    LatestBet = g.LatestBet,
                    NumberOfBets = g.LatestBet.Date == DateTime.Now.Date? g.NumberOfBets : 0,
                });
        }

        public Gambler Register(string nickname)
        {
            var entity = new Gambler();

            entity.Nickname = nickname;
            
            // default values
            entity.Score = 1000;
            entity.Created = DateTime.Now;

            _unitOfWork.Gamblers.Add(entity);
            _unitOfWork.Complete();

            return entity;
        }

        public Score Score(Guid id)
        {
            var entity = _unitOfWork.Gamblers
                .Find(g => g.UniquieIdentity == id)
                .FirstOrDefault();

            if (entity == null)
                throw new BadHttpRequestException("Unknown gambler");

            var response = new Score()
            {
                Nickname = entity.Nickname,
                Points = entity.Score,
                Highscore = entity.Highscore,
                LatestBet = entity.LatestBet,
                NumberOfBets = entity.LatestBet.Date == DateTime.Now.Date ? entity.NumberOfBets : 0,
                Message = "Current score for user"
            };

            return response;
        }
    }
}
