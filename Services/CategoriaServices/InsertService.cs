using CadastroProdutos.Models;
using CadastroProdutos.RabbiMQ;
using CadastroProdutos.Repositories;

namespace CadastroProdutos.Services.CategoriaServices
{
    public class InsertService
    {
        public void Execute(Categoria categoria)
        {
            new CategoriaRepository().Insert(categoria);
            ConnectionCategoria.SendNew(categoria);
        }
    }
}
