using CadastroProdutos.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroProdutos.Models
{
    public class Produto
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
        public int CodigoCategoria { get; set; }
        public int CodigoFornecedor { get; set; }
        public Tipo Tipo { get; set; }
        public double PrecoCusto { get; set; }
        public double PrecoVenda { get; set; }
    }
}
