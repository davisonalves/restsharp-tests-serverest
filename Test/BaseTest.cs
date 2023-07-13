using RestSharp;

namespace restsharp_tests_serverest.Test
{

    public abstract class BaseTest
    {
        public string BASE_URL = TestContext.Parameters["AppUrl"];
        public RestClient client;

        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            client = new RestClient(BASE_URL);
        }
    }
}
