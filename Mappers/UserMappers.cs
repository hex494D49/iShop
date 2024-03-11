using iShop.DTOs;
using iShop.Models;

namespace iShop.Mappers
{
    public class UserMappers
    {
        public User ToUserDto(UserDto userDto) {

            var user = new User
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password,
                Status = userDto.Status
            };

            return user;
        }

        public UserDto ToUser(User user)
        {

            var userDto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Status = user.Status
            };

            return userDto;
        }

    }
}
