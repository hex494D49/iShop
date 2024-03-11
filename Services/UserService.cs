using iShop.Models;
using iShop.Repositories;

namespace iShop.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public void CreateUser(User user)
        {
            _userRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            var userToDelete = _userRepository.GetById(id);
            if (userToDelete != null)
            {
                _userRepository.Delete(userToDelete);
            }
        }

        public int GetUserCount()
        {
            return _userRepository.GetCount();
        }
    }


}
