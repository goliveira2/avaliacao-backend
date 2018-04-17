using System.Data.Entity;

namespace Angular_MVC_Crud.Models
{
    public class livroContexto : DbContext
    {
        public livroContexto()
            : base("name=LivrariaConnectionString")
        {
            Database.SetInitializer<livroContexto>(new livroDBInitializer());
        }

        public DbSet<Livro> livro { get; set; }
    }
}