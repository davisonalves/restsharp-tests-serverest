using NJsonSchema;
using RestSharp;
using restsharp_tests_serverest.App.Model.Product;
using static restsharp_tests_serverest.App.Data.Common.TestTags;

namespace restsharp_tests_serverest.Test.Product
{
    [TestFixture]
    public class ProductContractTest : ProductBaseTest
    {
        [Test]
        [Category(CONTRACT)]
        [Description("Should return the product list schema")]
        public void SuccessOnGetProductList()
        {
            RestRequest request = new RestRequest(ROUTE, Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse<ProductResponseBody> response = client.Execute<ProductResponseBody>(request);

            JsonSchema schema = fileHelper.GetJsonSchema("ProductListJsonSchema");
            var errors = schema.Validate(response.Content);

            Assert.That(errors, Is.Empty);
        }

        [Test]
        [Category(CONTRACT)]
        [Description("Should return the product schema")]
        public void SuccessOnGetProduct()
        {
            RestRequest request = new RestRequest($"{ROUTE}/{{productID}}", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddUrlSegment("productID", "BeeJh5lz3k6kSIzA");

            RestResponse<Produto> response = client.Execute<Produto>(request);

            JsonSchema schema = fileHelper.GetJsonSchema("ProductJsonSchema");
            var errors = schema.Validate(response.Content);

            Assert.That(errors, Is.Empty);
        }
    }
}
