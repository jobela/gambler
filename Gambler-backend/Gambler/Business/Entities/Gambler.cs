namespace Gambler.PoC.Business.Entities
{
    public class Gambler
    {
        public int Id { get; set; }
        public Guid UniquieIdentity { get; private set; } = Guid.NewGuid();
        public DateTime Created { get; set; } = DateTime.Now;
        public string Nickname { get; set; } = string.Empty;
        public int Score { get; set; } = 0;
        public int Highscore { get; set; }
        public int NumberOfBets { get; set; }
        public DateTime LatestBet { get; set; } = DateTime.MinValue;
    }
}
