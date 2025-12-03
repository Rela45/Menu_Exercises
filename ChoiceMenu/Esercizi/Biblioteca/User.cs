namespace Biblioteca
{
    public class User
    {
        private string? _name;
        private string? _surname;
        private string? _email;
        private string? _password;

        public User(string? name, string? surname, string? email, string? password)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _password = password;
        }
    }
}
