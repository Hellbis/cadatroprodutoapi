using CadastroProdutos.Models;
using CadastroProdutos.Repositories;

namespace CadastroProdutos.Services.ProdutoServices
{
    public class GetService
    {
        public Produto Execute(int codigo)
        {
            return new ProdutoRepository().Get(codigo);
        }
    }
}
