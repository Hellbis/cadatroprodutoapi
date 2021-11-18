using CadastroProdutos.Models;
using CadastroProdutos.Repositories;

namespace CadastroProdutos.Services.FornecedorServices
{
    public class InsertService
    {
        public void Execute(Fornecedor fornecedor)
        {
            new FornecedorRepository().Insert(fornecedor);
        }
    }
}
