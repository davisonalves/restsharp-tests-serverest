using Bogus;
using restsharp_tests_serverest.App.Model.User;

namespace restsharp_tests_serverest.App.Data.Factory
{
    public class UserDataFactory
    {

        private Faker faker = new Faker();

        public UserRequestBody ValidBody()
        {
            UserRequestBody userRequestBody = new UserRequestBody
            {
                Nome = faker.Name.FullName(),
                Email = faker.Internet.Email(),
                Password = faker.Internet.Password(),
                Administrador = faker.Random.Bool().ToString().ToLower(),
            };

            return userRequestBody;
        }

        public UserRequestBody InvalidEmail()
        {
            UserRequestBody userRequestBody = new UserRequestBody
            {
                Nome = faker.Name.FullName(),
                Email = faker.Random.Words(),
                Password = faker.Internet.Password(),
                Administrador = faker.Random.Bool().ToString().ToLower(),
            };

            return userRequestBody;
        }
    }
}
