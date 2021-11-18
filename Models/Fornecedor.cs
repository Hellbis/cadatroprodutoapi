using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProdutos.Models
{
    public class Fornecedor
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
    }
}
