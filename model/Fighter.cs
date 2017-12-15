using System.ComponentModel.DataAnnotations.Schema;

namespace fantasyapicsharp.model
{
    [Table("lutador")]
    public class Fighter
    {
        [Column("id")]
        public int id {get; set;}
        [Column("nome")]
        public string name {get; set;}
        [Column("photo")]
        public string photo {get; set;}
    }
}