namespace Gambler.PoC.Services
{
    using Gambler.PoC.Data;
    using Gambler.PoC.Business.Entities;
    using Gambler.PoC.Models;

    public interface IGamblerService
    {
        Gambler Register(Gambler entity);
        Response<GamblerDTO> Bet(int id, int value);
        int Lottery(int id);

        int Score(int id);
        IEnumerable<Gambler> GetTop10Gamblers();
    }

    public class GamblerService : IGamblerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GamblerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Response<GamblerDTO> Bet(int id, int value)
        {
            var response = new Response<GamblerDTO>();

            var entity = _unitOfWork.Gamblers.Get(id);

            if (entity == null)
                throw new Exception("Unknown gambler");

            if (value > entity.Score)
                throw new Exception("You cannot bet more than you have...");

            // Implement really smart algorithm with 50%-ish win chance unless betting cool numbers
            var factor = 1.0;

            if (value == 69 || value == 420)
                factor = 1.2;

            if (Random.Shared.Next(0, 99) < (50 * factor))
            {
                // Win
                entity.Score += value;
                response.Success = true;
                response.Message = string.Format("Gambler won {0}!", value);
            }
            else
            {
                // Loss
                entity.Score -= value;
                response.Success = true;
                response.Message = string.Format("Gambler lost {0}!", value);
            }

            _unitOfWork.Complete();

            response.Entity = new GamblerDTO() { Username = entity.Username, Score = entity.Score };

            return response;
        }

        public int Lottery(int id)
        {
            var entity = _unitOfWork.Gamblers.Get(id);

            if (entity == null)
                throw new Exception("Unknown gambler");

            // Implement really smart algorithm with a very low win chance
            if (Random.Shared.Next(0, 10000) <= 10)
            {
                // Win
                entity.Score += 1000000;
            }

            _unitOfWork.Complete();

            return entity.Score;
        }

        public IEnumerable<Gambler> GetTop10Gamblers()
        {
            return _unitOfWork.Gamblers.GetTop10Gamblers();
        }

        public Gambler Register(Gambler entity)
        {
            // default values
            entity.Score = 1000;

            _unitOfWork.Gamblers.Add(entity);
            _unitOfWork.Complete();

            return entity;
        }

        public int Score(int id)
        {
            var entity = _unitOfWork.Gamblers.Get(id);

            if (entity == null)
                throw new Exception("Unknown gambler");

            return entity.Score;
        }
    }
}
