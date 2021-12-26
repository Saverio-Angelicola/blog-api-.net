using blog_api.Dtos.Users;
using blog_api.Models;
using blog_api.Repositories.Interfaces;
using blog_api.Services.Interfaces;

namespace blog_api.Services.Implementations.Users
{
    public class UserInfosUpdatorService : IUserInfosUpdatorService
    {
        private readonly IUserRepository userRepository;

        public UserInfosUpdatorService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task UpdateInfos(User user, UpdateUserInfosDto userInfosDto)
        {
            if (userInfosDto == null)
            {
                throw new Exception("UpdateUserInfosDto is null!");
            }

            user.FirstName = userInfosDto.Firstname;
            user.LastName = userInfosDto.Lastname;

            await userRepository.Update(user);
        }
    }
}
