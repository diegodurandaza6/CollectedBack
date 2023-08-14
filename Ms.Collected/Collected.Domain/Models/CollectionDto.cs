namespace Collected.Domain.Models
{
    public class CollectionDto
    {
        public int? Id { get; set; }
        public string? Station { get; set; }
        public string? Way { get; set; }
        public byte? Hour { get; set; }
        public string? Category { get; set; }
        public int? Amount { get; set; }
        public decimal? TabulatedValue { get; set; }
        public string Date { get; set; }
    };
}
