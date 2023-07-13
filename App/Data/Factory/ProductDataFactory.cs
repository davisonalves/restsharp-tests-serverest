using Bogus;
using restsharp_tests_serverest.App.Model.Product;

namespace restsharp_tests_serverest.App.Data.Factory
{
    public class ProductDataFactory
    {

        private Faker faker = new Faker();

        public ProductRequestBody ValidBody()
        {
            ProductRequestBody productRequestBody = new ProductRequestBody
            {
                Nome = faker.Commerce.ProductName(),
                Preco = faker.Random.Number(10, 100),
                Descricao = faker.Commerce.ProductDescription(),
                Quantidade = faker.Random.Number(1, 10)
            };

            return productRequestBody;
        }
    }
}
