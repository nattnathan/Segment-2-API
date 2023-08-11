using API.DTOs.Account;
using API.DTOs.Employee;
using API.Models;
using API.Utilities;

namespace Client.Contracts
{
    public interface IAccountRepository : IRepository<LoginDto, Guid>
    {
        public Task<ResponseHandler<string>> Login(LoginDto entity);
    }
}
