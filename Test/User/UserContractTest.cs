using RestSharp;
using NJsonSchema;
using restsharp_tests_serverest.App.Model.User;
using static restsharp_tests_serverest.App.Data.Common.TestTags;

namespace restsharp_tests_serverest.Test.User
{
    [TestFixture]
    public class UserContractTest : UserBaseTest
    {
        [Test]
        [Category(CONTRACT)]
        [Description("Should return the user schema")]
        public void ContractOnGetUser()
        {
            RestRequest request = new RestRequest($"{ROUTE}/{{userId}}", Method.Get);
            request.AddHeader("accept", "application/json");
            request.AddUrlSegment("userId", "0uxuPY0cbmQhpEz1");

            RestResponse<Usuario> response = client.Execute<Usuario>(request);

            JsonSchema schema = fileHelper.GetJsonSchema("UserJsonSchema");
            var errors = schema.Validate(response.Content);

            Assert.That(errors, Is.Empty);
        }

        [Test]
        [Category(CONTRACT)]
        [Description("Should return the user list schema")]
        public void ContractOnGetUserList()
        {
            RestRequest request = new RestRequest(ROUTE, Method.Get);
            request.AddHeader("accept", "application/json");

            RestResponse<UserResponseBody> response = client.Execute<UserResponseBody>(request);

            JsonSchema schema = fileHelper.GetJsonSchema("UserListJsonSchema");
            var errors = schema.Validate(response.Content);

            Assert.That(errors, Is.Empty);
        }
    }
}
