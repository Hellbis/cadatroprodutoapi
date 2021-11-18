using CadastroProdutos.RabbiMQ;
using CadastroProdutos.Repositories;

namespace CadastroProdutos.Services.ProdutoServices
{
    public class DeleteService
    {
        public void Execute(int codigo)
        {
            new ProdutoRepository().Delete(codigo);
            ConnectionProduto.SendDelete(codigo);
        }
    }
}
