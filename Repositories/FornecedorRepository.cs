using CadastroProdutos.Context;
using CadastroProdutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProdutos.Repositories
{
    public class FornecedorRepository
    {
        public CadastroContext db = new CadastroContext();

        public void Insert(Fornecedor fornecedor)
        {
            db.Fornecedores.Add(fornecedor);
            db.SaveChanges();
        }

        public void Update(Fornecedor fornecedor)
        {
            var f = db.Fornecedores.First(s => s.Codigo == fornecedor.Codigo);
            f.Nome = fornecedor.Nome;
            f.Status = fornecedor.Status;
            db.SaveChanges();
        }

        public List<Fornecedor> GetAll()
        {
            return db.Fornecedores.Where(s => s.Status).ToList();
        }

        public Fornecedor Get(int codigo)
        {
            return db.Fornecedores.First(s => s.Codigo == codigo);
        }

        public void Delete(int codigo)
        {
            var f = db.Fornecedores.First(s => s.Codigo == codigo && s.Status);
            f.Status = false;
            db.SaveChanges();
        }

        public bool Exists(int codigo)
        {
            return db.Fornecedores.Any(s => s.Codigo == codigo && s.Status);
        }
    }
}
