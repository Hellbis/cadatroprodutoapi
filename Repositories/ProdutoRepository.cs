using CadastroProdutos.Context;
using CadastroProdutos.Models;
using System.Collections.Generic;
using System.Linq;

namespace CadastroProdutos.Repositories
{
    public class ProdutoRepository
    {
        public CadastroContext db = new CadastroContext();

        public void Insert(Produto produto)
        {
            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        public void Update(Produto produto)
        {
            var p = db.Produtos.First(s => s.Codigo == produto.Codigo);
            p.Descricao = produto.Descricao;
            p.CodigoCategoria = produto.CodigoCategoria;
            p.Tipo = produto.Tipo;
            p.PrecoCusto = produto.PrecoCusto;
            p.PrecoVenda = produto.PrecoVenda;
            p.CodigoFornecedor = produto.CodigoFornecedor;
            db.SaveChanges();
        }

        public List<Produto> GetAll()
        {
            return db.Produtos.ToList();
        }

        public Produto Get(int codigo)
        {
            return db.Produtos.First(s => s.Codigo == codigo);
        }

        public void Delete(int codigo)
        {
            var p = db.Produtos.First(s => s.Codigo == codigo);
            db.Produtos.Remove(p);
            db.SaveChanges();
        }
    }
}
