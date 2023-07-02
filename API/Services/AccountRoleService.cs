using API.Contracts;
using API.DTOs.AccountRole;
using API.Models;

namespace API.Services;

public class AccountRoleService
{
    private readonly IAccountRoleRepository _accountRoleRepository;

    public AccountRoleService(IAccountRoleRepository accountRoleRepository)
    {
        _accountRoleRepository = accountRoleRepository;
    }

    public IEnumerable<GetAccountRoleDto>? GetAccountRole()
    {
        var accountRoles = _accountRoleRepository.GetAll();
        if (!accountRoles.Any())
        {
            return null;
        }

        var toDto = accountRoles.Select(accountRole => new GetAccountRoleDto
        {
            Guid = accountRole.Guid,
            AccountGuid = accountRole.AccountGuid,
            RoleGuid = accountRole.RoleGuid
        });

        return toDto;
    }

    public GetAccountRoleDto? GetAccountRole(Guid guid)
    {
        var accountRole = _accountRoleRepository.GetByGuid(guid);
        if (accountRole is null)
        {
            return null;
        }

        var toDto = new GetAccountRoleDto
        {
            Guid = accountRole.Guid,
            AccountGuid = accountRole.AccountGuid,
            RoleGuid = accountRole.RoleGuid
        };

        return toDto;
    }

    public GetAccountRoleDto? CreateAccountRole(NewAccountRoleDto newAccountRoleDto)
    {
        var accountRole = new AccountRole
        {
            Guid = new Guid(),
            AccountGuid = newAccountRoleDto.AccountGuid,
            RoleGuid = newAccountRoleDto.RoleGuid,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdaccountRole = _accountRoleRepository.Create(accountRole);
        if (createdaccountRole is null)
        {
            return null;
        }

        var toDto = new GetAccountRoleDto
        {
            Guid = createdaccountRole.Guid,
            AccountGuid = createdaccountRole.AccountGuid,
            RoleGuid = createdaccountRole.RoleGuid,
        };

        return toDto;

    }

    public int UpdateAccountRole(GetAccountRoleDto updateAccountRoleDto)
    {
        var isExist = _accountRoleRepository.IsExist(updateAccountRoleDto.Guid);
        if (!isExist)
        {
            return -1; // Not Found
        }

        var getaccountRole = _accountRoleRepository.GetByGuid(updateAccountRoleDto.Guid);
        var accountRole = new AccountRole
        {
            Guid = updateAccountRoleDto.Guid,
            AccountGuid = updateAccountRoleDto.AccountGuid,
            RoleGuid = updateAccountRoleDto.RoleGuid,
            ModifiedDate = DateTime.Now,
            CreatedDate = getaccountRole!.CreatedDate
        };

        var isUpdate = _accountRoleRepository.Update(accountRole);
        if (!isUpdate)
        {
            return 0; // Bad Request
        }

        return 1; // succes update
    }

    public int DeleteAccountRole(Guid guid)
    {
        var isExist = _accountRoleRepository.IsExist(guid);
        if (!isExist)
        {
            return -1;
        }

        var accountRole = _accountRoleRepository.GetByGuid(guid);
        var isDelete = _accountRoleRepository.Delete(accountRole!);
        if (!isDelete)
        {
            return 0; // 
        }

        return 1;
    }
}
