using System.ComponentModel.DataAnnotations.Schema;

namespace Collected.AdapterOutRepository.SqlServerDB.Entities
{
    [Table("recaudos", Schema = "diego")]
    public class Recaudos
    {
        public int? Id { get; set; }
        public string? Estacion { get; set; }
        public string? Sentido { get; set; }
        public byte? Hora { get; set; }
        public string? Categoria { get; set; }
        public int? Cantidad { get; set; }
        public decimal? ValorTabulado { get; set; }
        public DateTime Fecha { get; set; }

    }
}
