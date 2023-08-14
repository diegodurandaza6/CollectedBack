using System.ComponentModel.DataAnnotations.Schema;

namespace Collected.AdapterOutRepository.SqlServerDB.Entities
{
    [Table("control_consolidado_recaudos", Schema = "diego")]
    public class ControlDate
    {
        public int? Id { get; set; }
        public DateTime fecha { get; set; }
        public DateTime ultima_ejecucion { get; set; }
    }
}
