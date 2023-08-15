using System.ComponentModel.DataAnnotations.Schema;

namespace Collected.AdapterOutRepository.SqlServerDB.Entities
{
    [Table("JwtAuth", Schema = "diego")]
    public class JwtAuth
    {
        public int? Id { get; set; }
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
