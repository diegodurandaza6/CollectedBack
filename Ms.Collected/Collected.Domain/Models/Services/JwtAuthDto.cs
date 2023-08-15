namespace Collected.Domain.Models.Services
{
    public class JwtAuthDto
    {
        public int? Id { get; set; }
        public string token { get; set; }
        public DateTime expiration { get; set; }
}
}
