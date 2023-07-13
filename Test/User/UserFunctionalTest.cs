using RestSharp;
using System.Net;
using restsharp_tests_serverest.App.Model.User;
using static restsharp_tests_serverest.App.Data.Common.TestTags;

namespace restsharp_tests_serverest.Test.User
{
    [TestFixture]
    public class UserFunctionalTest : UserBaseTest
    {

        [Test]
        [Category(SMOKE)]
        [Description("Should return http status code equal to 200 OK and a list of users")]
        public void SuccessOnGetUserList()
        {
            RestRequest request = new RestRequest(ROUTE, Method.Get);
            request.AddHeader("accept", "application/json");

            RestResponse<UserResponseBody> response = client.Execute<UserResponseBody>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Usuarios, Is.Not.Empty);
        }

        [Test]
        [Category(SMOKE)]
        [Description("Should return http status code equal to 200 OK and a one user")]
        public void SuccessOnGetUser()
        {
            RestRequest request = new RestRequest($"{ROUTE}/{{userId}}", Method.Get);
            request.AddHeader("accept", "application/json");
            request.AddUrlSegment("userId", "0uxuPY0cbmQhpEz1");

            RestResponse<Usuario> response = client.Execute<Usuario>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Nome, Is.EqualTo("Fulano da Silva"));
        }

        [Test]
        [Category(FUNCTIONAL)]
        [Description("Should return http status code equal to 400 Bad Request and a user not found message")]
        public void FailOnGetUser()
        {
            RestRequest request = new RestRequest($"{ROUTE}/{{userId}}", Method.Get);
            request.AddHeader("accept", "application/json");
            request.AddUrlSegment("userId", "123");

            RestResponse<Usuario> response = client.Execute<Usuario>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Data.Message, Is.EqualTo("Usuário não encontrado"));
        }

        [Test]
        [Category(FUNCTIONAL)]
        [Description("Should return http status code equal to 201 Created and a success message")]
        public void SuccessOnCreateUser()
        {
            RestRequest request = new RestRequest(ROUTE, Method.Post);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(userDataFactory.ValidBody());

            RestResponse<Usuario> response = client.Execute<Usuario>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(response.Data.Message, Is.EqualTo("Cadastro realizado com sucesso"));

            userHelper.ClearCreatedUserOnTest(response.Data._id);
        }

        [Test]
        [Category(FUNCTIONAL)]
        [Description("Should return http status code equal to 400 Bad Request and a invalid email message")]
        public void FailOnCreateUser()
        {
            RestRequest request = new RestRequest(ROUTE, Method.Post);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(userDataFactory.InvalidEmail());

            RestResponse<Usuario> response = client.Execute<Usuario>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Data.Email, Is.EqualTo("email deve ser um email válido"));
        }

        [Test]
        [Category(FUNCTIONAL)]
        [Description("Should return http status code equal to 200 OK and a alter with success message")]
        public void SuccessOnUpdateUser()
        {
            string userId = userHelper.GenerateUser();

            RestRequest request = new RestRequest($"{ROUTE}/{{userId}}", Method.Put);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddUrlSegment("userId", userId);

            request.AddJsonBody(userDataFactory.ValidBody());

            RestResponse<Usuario> response = client.Execute<Usuario>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Data.Message, Is.EqualTo("Registro alterado com sucesso"));

            userHelper.ClearCreatedUserOnTest(userId);
        }

        [Test]
        [Category(FUNCTIONAL)]
        [Description("Should return http status code equal to 400 Bad Request and a invalid email message")]
        public void FailOnUpdateUser()
        {
            string userId = userHelper.GenerateUser();

            RestRequest request = new RestRequest($"{ROUTE}/{{userId}}", Method.Put);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddUrlSegment("userId", userId);

            request.AddJsonBody(userDataFactory.InvalidEmail());

            RestResponse<Usuario> response = client.Execute<Usuario>(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(response.Data.Email, Is.EqualTo("email deve ser um email válido"));

            userHelper.ClearCreatedUserOnTest(userId);
        }
    }
}