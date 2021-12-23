using blog_api.Dtos.Users;
using blog_api.Models;

namespace blog_api.Services.Interfaces
{
    public interface IUserInfosUpdatorService
    {
        Task UpdateInfos(User user, UpdateUserInfosDto userInfosDto);
    }
}
