using restsharp_tests_serverest.App.Data.Factory;
using restsharp_tests_serverest.App.Helper;

namespace restsharp_tests_serverest.Test.Login
{
    public  abstract class LoginBaseTest: BaseTest
    {
        public const string ROUTE = "/login";
        public FileHelper fileHelper = new FileHelper();
        public LoginDataFactory loginDataFactory = new LoginDataFactory();
    }
}
