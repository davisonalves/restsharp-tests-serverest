namespace restsharp_tests_serverest.App.Model.User
{
    public class UserResponseBody
    {
        public int Quantidade { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }

    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Administrador { get; set; }
        public string _id { get; set; }
        public string? Message { get; set; }
    }
}
