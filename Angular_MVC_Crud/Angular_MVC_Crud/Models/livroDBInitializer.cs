using System.Collections.Generic;
using System.Data.Entity;

namespace Angular_MVC_Crud.Models
{
    public class livroDBInitializer : CreateDatabaseIfNotExists<livroContexto>
    {
        protected override void Seed(livroContexto context)
        {
            IList<Livro> dados = new List<Livro>();

            base.Seed(context);
        }
    }
}