using CadastroProdutos.Models;
using CadastroProdutos.RabbiMQ;
using CadastroProdutos.Repositories;

namespace CadastroProdutos.Services.CategoriaServices
{
    public class UpdateService
    {
        public void Execute(Categoria categoria)
        {
            new CategoriaRepository().Update(categoria);
            ConnectionCategoria.SendUpdate(categoria);
        }
    }
}
