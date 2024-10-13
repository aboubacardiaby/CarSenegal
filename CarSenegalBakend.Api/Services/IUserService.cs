using CarSenegalBakend.Domain.Entities;

namespace CarSenegalBakend.Api.Services
{
    public interface IUserService
    {
        UserEntity Authenticate(string username, string password);
        IEnumerable<UserEntity> GetAll();
    }
}
