using System.ComponentModel.DataAnnotations;

namespace CadastroProdutos.Models
{
    public class Categoria
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
    }
}
