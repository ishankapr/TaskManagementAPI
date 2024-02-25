using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class AuthService : IAuthService
    {
        List<User> users = new()
        {
           new User(){ UserId = 1, Name = "Test1", Username = "testuser1", Password = "testpassword1"},
           new User(){ UserId = 2, Name = "Test2", Username = "testuser2", Password = "testpassword2"}
        };

        public bool AuthenticateAsync(LoginUser loginUser)
        {
            bool response = false;

            if (users.Exists(x => x.Username == loginUser.Username))
            {
                var user = users.Where(x => x.Username == loginUser.Username).SingleOrDefault();

                if (user.Password == loginUser.Password)
                {
                    response = true;
                }

            }

            return response;
        }

    }
}
