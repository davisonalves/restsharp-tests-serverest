using RestSharp;
using NJsonSchema;
using restsharp_tests_serverest.App.Model.Login;
using static restsharp_tests_serverest.App.Data.Common.TestTags;

namespace restsharp_tests_serverest.Test.Login
{
    [TestFixture]
    public class LoginContractTest: LoginBaseTest
    {
        [Test]
        [Category(CONTRACT)]
        [Description("Should return the login schema for success case")]
        public void ContractOnLoginWithSuccess()
        {
            LoginRequestBody body = loginDataFactory.ValidEmailAndPassword();

            RestRequest request = new RestRequest(ROUTE, Method.Post);
            request.AddJsonBody(body);

            RestResponse<LoginResponseBody> response = client.Execute<LoginResponseBody>(request);

            JsonSchema schema = fileHelper.GetJsonSchema("LoginJsonSchemaOnSuccess");
            var errors = schema.Validate(response.Content);

            Assert.That(errors, Is.Empty);
        }

        [Test]
        [Category(CONTRACT)]
        [Description("Should return the login schema for fail case")]
        public void ContractOnLoginWithFail()
        {
            LoginRequestBody body = loginDataFactory.InvalidEmail();

            RestRequest request = new RestRequest(ROUTE, Method.Post);
            request.AddJsonBody(body);

            RestResponse<LoginResponseBody> response = client.Execute<LoginResponseBody>(request);

            JsonSchema schema = fileHelper.GetJsonSchema("LoginJsonSchemaOnFail");
            var errors = schema.Validate(response.Content);

            Assert.That(errors, Is.Empty);
        }
    }
}
