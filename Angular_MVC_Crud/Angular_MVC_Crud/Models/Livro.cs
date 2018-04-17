using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Angular_MVC_Crud.Models
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
    }
}