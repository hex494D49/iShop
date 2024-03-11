using iShop.Models;

namespace iShop.Services
{
    public interface IUserService
    {
        User GetUserById(int id);

        IEnumerable<User> GetAllUsers();

        void CreateUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);

        int GetUserCount();
    }
}
