using CadastroProdutos.Models;
using CadastroProdutos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProdutos.Services.CategoriaServices
{
    public class GetAllService
    {
        public List<Categoria> Execute()
        {
            return new CategoriaRepository().GetAll();
        }
    }
}
