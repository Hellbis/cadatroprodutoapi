using CadastroProdutos.Models;
using CadastroProdutos.Repositories;

namespace CadastroProdutos.Services.FornecedorServices
{
    public class GetService
    {
        public Fornecedor Execute(int codigo)
        {
            return new FornecedorRepository().Get(codigo);
        }
    }
}
