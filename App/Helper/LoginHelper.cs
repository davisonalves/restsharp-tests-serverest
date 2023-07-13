using RestSharp;
using restsharp_tests_serverest.App.Data.Factory;
using restsharp_tests_serverest.App.Model.Login;

namespace restsharp_tests_serverest.App.Helper
{
    public class LoginHelper
    {

        private string BASE_URL = TestContext.Parameters["AppUrl"];
        private LoginDataFactory loginDataFactory;
        private RestClient client;
        
        public LoginHelper()
        {
            client = new RestClient(BASE_URL);
            loginDataFactory = new LoginDataFactory();
        }

        public string GetToken()
        {
            LoginRequestBody body = loginDataFactory.ValidEmailAndPassword();

            RestRequest request = new RestRequest("/login", Method.Post);
            request.AddJsonBody(body);

            RestResponse<LoginResponseBody> response = client.Execute<LoginResponseBody>(request);

            return response.Data.Authorization;
        }
    }
}
