using System.ComponentModel;

namespace CadastroProdutos.Enums
{
    public enum Tipo
    {
        [Description("Produto Acabado")]
        produtoAcabado = 0,
        [Description("Matéria Prima")]
        materiaPrima  = 1
    }
}
