using CadastroProdutos.Context;
using CadastroProdutos.Models;
using CadastroProdutos.Repositories;
using System.Collections.Generic;

namespace CadastroProdutos.Services.FornecedorServices
{
    public class GetAllService
    {
        public List<Fornecedor> Execute()
        {
            return new FornecedorRepository().GetAll();
        }
    }
}
