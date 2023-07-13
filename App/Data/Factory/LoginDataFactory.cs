using Bogus;
using restsharp_tests_serverest.App.Model.Login;

namespace restsharp_tests_serverest.App.Data.Factory
{
    public class LoginDataFactory
    {

        private Faker faker = new Faker();

        public LoginRequestBody ValidEmailAndPassword()
        {
            LoginRequestBody loginRequestBodyWhitInvalidEmail = new LoginRequestBody
            {
                Email = TestContext.Parameters["UserEmail"],
                Password = TestContext.Parameters["UserPassword"],
            };

            return loginRequestBodyWhitInvalidEmail;
        }

        public LoginRequestBody InvalidEmail()
        {
            LoginRequestBody loginRequestBodyWhitInvalidEmail = new LoginRequestBody
            {
                Email = faker.Internet.Email(),
                Password = TestContext.Parameters["UserPassword"],
            };

            return loginRequestBodyWhitInvalidEmail;
        }


        public LoginRequestBody InvalidPassword()
        {
            LoginRequestBody loginRequestBodyWhitInvalidEmail = new LoginRequestBody
            {
                Email = TestContext.Parameters["UserEmail"],
                Password = faker.Random.Words(),
            };

            return loginRequestBodyWhitInvalidEmail;
        }
    }
}
