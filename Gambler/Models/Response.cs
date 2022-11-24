namespace Gambler.PoC.Models
{
    public class Response<TEntity> where TEntity : class
    {
        public TEntity Entity { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
