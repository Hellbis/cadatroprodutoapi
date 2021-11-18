using CadastroProdutos.Models;
using CadastroProdutos.Repositories;

namespace CadastroProdutos.Services.FornecedorServices
{
    public class UpdateService
    {
        public void Execute(Fornecedor fornecedor)
        {
            new FornecedorRepository().Update(fornecedor);
        }
    }
}
