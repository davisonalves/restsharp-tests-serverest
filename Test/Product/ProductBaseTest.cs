using restsharp_tests_serverest.App.Data.Factory;
using restsharp_tests_serverest.App.Helper;

namespace restsharp_tests_serverest.Test.Product
{
    public abstract class ProductBaseTest : BaseTest
    {
        public const string ROUTE = "/produtos";
        public FileHelper fileHelper = new FileHelper();
        public LoginHelper loginHelper = new LoginHelper();
        public ProductHelper productHelper = new ProductHelper();
        public ProductDataFactory productDataFactory = new ProductDataFactory();
    }
}
