using CadastroProdutos.Context;
using CadastroProdutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProdutos.Repositories
{
    public class CategoriaRepository
    {
        public CadastroContext db = new CadastroContext();

        public void Insert(Categoria categoria)
        {
            db.Categorias.Add(categoria);
            db.SaveChanges();
        }

        public void Update(Categoria categoria)
        {
            var c = db.Categorias.First(s => s.Codigo == categoria.Codigo);
            c.Nome = categoria.Nome;
            c.Status = categoria.Status;
            db.SaveChanges();
        }

        public List<Categoria> GetAll()
        {
            return db.Categorias.Where(s => s.Status).ToList();
        }

        public Categoria Get(int codigo)
        {
            return db.Categorias.First(s => s.Codigo == codigo);
        }

        public void Delete(int codigo)
        {
            var c = db.Categorias.First(s => s.Codigo == codigo && s.Status);
            c.Status = false;
            db.SaveChanges();
        }

        public bool Exists(int codigo)
        {
            return db.Categorias.Any(s => s.Codigo == codigo && s.Status);
        }
    }
}
