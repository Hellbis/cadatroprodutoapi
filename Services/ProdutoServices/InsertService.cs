using CadastroProdutos.Dto;
using CadastroProdutos.Enums;
using CadastroProdutos.Models;
using CadastroProdutos.RabbiMQ;
using CadastroProdutos.Repositories;
using System;

namespace CadastroProdutos.Services.ProdutoServices
{
    public class InsertService
    {
        public void Execute(Produto produto)
        {
            var categoriaRepository = new CategoriaRepository();
            var fornecedorRepository = new FornecedorRepository();

            if (produto.CodigoCategoria == 0 || !categoriaRepository.Exists(produto.CodigoCategoria))
                throw new Exception("Categoria inválida.");

            if (produto.CodigoFornecedor == 0 || !fornecedorRepository.Exists(produto.CodigoFornecedor))
                throw new Exception("Fornecedor inválido.");

            if (Tipo.materiaPrima != produto.Tipo && Tipo.produtoAcabado != produto.Tipo)
                throw new Exception("Tipo inválido.");

            new ProdutoRepository().Insert(produto);
            if(produto.Tipo == Tipo.produtoAcabado)
            {
                var produtoDto = new ProdutoDto()
                {
                    Codigo = produto.Codigo,
                    Descricao = produto.Descricao,
                    CodigoCategoria = produto.CodigoCategoria,
                    PrecoVenda = produto.PrecoVenda,
                    NomeFornecedor = fornecedorRepository.Get(produto.CodigoFornecedor).Nome
                };
                ConnectionProduto.SendNew(produtoDto);
            }
        }
    }
}
