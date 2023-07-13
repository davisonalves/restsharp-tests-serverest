using RestSharp;
using System.Net;

using restsharp_tests_serverest.App.Model.Login;
using static restsharp_tests_serverest.App.Data.Common.TestTags;

namespace restsharp_tests_serverest.Test.Login
{
    [TestFixture]
    public class LoginFunctionalTest: LoginBaseTest
    {
        [Test]
        [Category(SMOKE)]
        [Description("Should return http status code equal to 200 OK and a success message")]
        public void LoginWithValidEmailAndPassword()
        {
            LoginRequestBody body = loginDataFactory.ValidEmailAndPassword();

            RestRequest request = new RestRequest(ROUTE, Method.Post);
            request.AddJsonBody(body);

            RestResponse<LoginResponseBody> response = client.Execute<LoginResponseBody>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Message, Is.EqualTo("Login realizado com sucesso"));
        }

        [Test]
        [Category(FUNCTIONAL)]
        [Description("Should return http status code equal to 401 Unauthorized and a fail message")]
        public void LoginWithInvalidEmail()
        {
            LoginRequestBody body = loginDataFactory.InvalidEmail();

            RestRequest request = new RestRequest(ROUTE, Method.Post);
            request.AddJsonBody(body);

            RestResponse<LoginResponseBody> response = client.Execute<LoginResponseBody>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Data.Message, Is.EqualTo("Email e/ou senha inválidos"));
        }

        [Test]
        [Category(FUNCTIONAL)]
        [Description("Should return http status code equal to 401 Unauthorized and a fail message")]
        public void LoginWithInvalidPassword()
        {
            LoginRequestBody body = loginDataFactory.InvalidPassword();

            RestRequest request = new RestRequest(ROUTE, Method.Post);
            request.AddJsonBody(body);

            RestResponse<LoginResponseBody> response = client.Execute<LoginResponseBody>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            Assert.That(response.Data.Message, Is.EqualTo("Email e/ou senha inválidos"));
        }
    }
}