using CadastroProdutos.Repositories;

namespace CadastroProdutos.Services.FornecedorServices
{
    public class DeleteService
    {
        public void Execute(int codigo)
        {
            new FornecedorRepository().Delete(codigo);
        }
    }
}
