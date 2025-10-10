using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI.Model
{
    [Table("person")]
    public class Person
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Endereco { get; set; }
        public required string Genero { get; set; }
    }
}
