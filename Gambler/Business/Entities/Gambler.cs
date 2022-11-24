namespace Gambler.PoC.Business.Entities
{
    public class Gambler
    {
        public int Id { get; set; }
        public Guid UniquieIdentity { get; private set; } = Guid.NewGuid();
        public string Username { get; set; } = string.Empty;
        public int Score { get; set; }
    }
}
