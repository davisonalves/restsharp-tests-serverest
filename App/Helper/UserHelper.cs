using RestSharp;
using restsharp_tests_serverest.App.Data.Factory;
using restsharp_tests_serverest.App.Model.User;

namespace restsharp_tests_serverest.App.Helper
{
    public class UserHelper
    {

        private string BASE_URL = TestContext.Parameters["AppUrl"];
        private UserDataFactory userDataFactory;
        private RestClient client;

        public UserHelper()
        {
            client = new RestClient(BASE_URL);
            userDataFactory = new UserDataFactory();
        }

        public string GenerateUser()
        {
            RestRequest request = new RestRequest("/usuarios", Method.Post);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(userDataFactory.ValidBody());

            RestResponse<Usuario> response = client.Execute<Usuario>(request);

            return response.Data._id;
        }

        public void ClearCreatedUserOnTest(string UserIdForDelete)
        {
            RestRequest request = new RestRequest($"/usuarios/{{userId}}", Method.Delete);
            request.AddHeader("accept", "application/json");
            request.AddUrlSegment("userId", UserIdForDelete);

            client.Execute(request);
        }
    }
}
