namespace CadastroProdutos.Dto
{
    public class ProdutoDto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public int CodigoCategoria { get; set; }
        public string NomeFornecedor { get; set; }
        public double PrecoVenda { get; set; }
    }
}