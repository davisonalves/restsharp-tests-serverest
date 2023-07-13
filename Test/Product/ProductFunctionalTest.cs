using RestSharp;
using System.Net;
using restsharp_tests_serverest.App.Model.Product;
using static restsharp_tests_serverest.App.Data.Common.TestTags;

namespace restsharp_tests_serverest.Test.Product
{
    [TestFixture]
    public class ProductFunctionalTest : ProductBaseTest
    {
        [Test]
        [Category(SMOKE)]
        [Description("Should return http status code equal to 200 OK and a list of products")]
        public void SuccessOnGetProductList()
        {
            RestRequest request = new RestRequest(ROUTE, Method.Get);
            request.AddHeader("Accept", "application/json");

            RestResponse<ProductResponseBody> response = client.Execute<ProductResponseBody>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Produtos, Is.Not.Empty);
        }

        [Test]
        [Category(SMOKE)]
        [Description("Should return http status code equal to 200 OK and a one product")]
        public void SuccessOnGetProduct()
        {
            RestRequest request = new RestRequest($"{ROUTE}/{{productID}}", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddUrlSegment("productID", "BeeJh5lz3k6kSIzA");

            RestResponse<Produto> response = client.Execute<Produto>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Nome, Is.EqualTo("Logitech MX Vertical"));
        }

        [Test]
        [Category(FUNCTIONAL)]
        [Description("Should return http status code equal to 400 Bad Request and a product not found message")]
        public void FailOnGetProduct()
        {
            RestRequest request = new RestRequest($"{ROUTE}/{{productID}}", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddUrlSegment("productID", "123");

            RestResponse<Produto> response = client.Execute<Produto>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Data.Message, Is.EqualTo("Produto não encontrado"));
        }

        [Test]
        [Category(FUNCTIONAL)]
        [Description("Should return http status code equal to 201 Created and a success message")]
        public void SuccessOnCreateProduct()
        {
            RestRequest request = new RestRequest(ROUTE, Method.Post);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", loginHelper.GetToken());
            request.AddJsonBody(productDataFactory.ValidBody());

            RestResponse<Produto> response = client.Execute<Produto>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(response.Data.Message, Is.EqualTo("Cadastro realizado com sucesso"));

            productHelper.ClearCreatedProductOnTest(response.Data._id);
        }
    }
}
