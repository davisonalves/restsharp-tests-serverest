using RestSharp;
using restsharp_tests_serverest.App.Data.Factory;
using restsharp_tests_serverest.App.Model.Product;

namespace restsharp_tests_serverest.App.Helper
{
    public class ProductHelper
    {
        private string BASE_URL = TestContext.Parameters["AppUrl"];
        private ProductDataFactory productDataFactory;
        private LoginHelper loginHelper;
        private RestClient client;

        public ProductHelper()
        {
            client = new RestClient(BASE_URL);
            productDataFactory = new ProductDataFactory();
            loginHelper = new LoginHelper();
        }

        public string GenerateProduct()
        {
            RestRequest request = new RestRequest("/produtos", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", loginHelper.GetToken());
            request.AddJsonBody(productDataFactory.ValidBody());

            RestResponse<Produto> response = client.Execute<Produto>(request);

            return response.Data._id;
        }

        public void ClearCreatedProductOnTest(string ProductIdForDelete)
        {
            RestRequest request = new RestRequest($"/produtos/{{productId}}", Method.Delete);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", loginHelper.GetToken());
            request.AddUrlSegment("productId", ProductIdForDelete);

            client.Execute(request);
        }
    }
}
