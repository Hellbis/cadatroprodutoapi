using CadastroProdutos.RabbiMQ;
using CadastroProdutos.Repositories;

namespace CadastroProdutos.Services.CategoriaServices
{
    public class DeleteService
    {
        public void Execute(int codigo)
        {
            new CategoriaRepository().Delete(codigo);
            ConnectionCategoria.SendDelete(codigo);
        }
    }
}
