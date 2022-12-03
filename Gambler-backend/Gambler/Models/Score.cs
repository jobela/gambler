namespace Gambler.PoC.Models
{
    public class Score
    {
        public string Nickname { get; set; } = string.Empty;
        public int Points { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime LatestBet { get; set; }
        public int Highscore { get; set; }
        public int NumberOfBets { get; set; }
    }
}
