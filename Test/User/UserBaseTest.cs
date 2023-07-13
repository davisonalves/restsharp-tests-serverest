using restsharp_tests_serverest.App.Data.Factory;
using restsharp_tests_serverest.App.Helper;

namespace restsharp_tests_serverest.Test.User
{
    public abstract class UserBaseTest : BaseTest
    {
        public const string ROUTE = "/usuarios";
        public UserHelper userHelper = new UserHelper();
        public FileHelper fileHelper = new FileHelper();
        public UserDataFactory userDataFactory = new UserDataFactory();
    }
}
