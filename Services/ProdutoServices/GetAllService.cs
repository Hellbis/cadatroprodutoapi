﻿using CadastroProdutos.Models;
using CadastroProdutos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProdutos.Services.ProdutoServices
{
    public class GetAllService
    {
        public List<Produto> Execute()
        {
            return new ProdutoRepository().GetAll();
        }
    }
}
