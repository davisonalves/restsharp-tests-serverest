namespace restsharp_tests_serverest.App.Model.Product
{
    public class ProductResponseBody
    {
        public int Quantidade { get; set; }
        public List<Produto> Produtos { get; set; }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public int Preco { get; set; }
        public string Descricao { get; set; }
        public int QUantidade { get; set; }
        public string _id { get; set; }
        public string? Message { get; set; }
    }
}
