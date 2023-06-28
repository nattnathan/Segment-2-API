using API.Contracts;
using API.DTOs.Account;
using API.Models;
using API.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace API.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUniversityRepository _universityRepository;
    private readonly IEducationRepository _educationRepository;

    public AccountService(IAccountRepository accountRepository, 
                         IEmployeeRepository employeeRepository,
                         IUniversityRepository universityRepository,
                         IEducationRepository educationRepository)
    {
        _accountRepository = accountRepository;
        _employeeRepository = employeeRepository;
        _universityRepository = universityRepository;
        _educationRepository = educationRepository;
    }

    public RegisterDto? Register(RegisterDto registerDto)
    {
        EmployeeService employeService = new EmployeeService(_employeeRepository);
        Employee employee = new Employee
        {
            Guid = new Guid(),
            Nik = employeService.GenerateNIK(),
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            BirthDate = registerDto.BirthDate,
            Gender = registerDto.Gender,
            HiringDate = registerDto.HiringDate,
            Email = registerDto.Email,
            PhoneNumber = registerDto.Phone,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdEmployee = _employeeRepository.Create(employee);
        if (createdEmployee is null)
        {
            return null;
        }


        University university = new University
        {
            Guid = new Guid(),
            Code = registerDto.UniversityCode,
            Name = registerDto.UniversityName
        };

        var createdUniversity = _universityRepository.Create(university);
        if (createdUniversity is null)
        {
            return null;
        }

        Education education = new Education
        {
            Guid = employee.Guid,
            Major = registerDto.Major,
            Degree = registerDto.Degree,
            Gpa = registerDto.Gpa,
            UniversityGuid = university.Guid
            
        };

        var createdEducation = _educationRepository.Create(education);
        if (createdEducation is null)
        {
            return null;
        }

        Account account = new Account
        {
            Guid = employee.Guid,
            Password = Hashing.HashPassword(registerDto.Password),
            ConfirmPassword = registerDto.ConfirmPassword
        };

        var createdAccount = _accountRepository.Create(account);
        if (createdAccount is null)
        {
            return null;
        }
        

        var toDto = new RegisterDto
        {
            FirstName = createdEmployee.FirstName,
            LastName = createdEmployee.LastName,
            BirthDate = createdEmployee.BirthDate,
            Gender = createdEmployee.Gender,
            HiringDate = createdEmployee.HiringDate,
            Email = createdEmployee.Email,
            Phone = createdEmployee.PhoneNumber,
            Password = createdAccount.Password,
            Major = createdEducation.Major,
            Degree = createdEducation.Degree,
            Gpa = createdEducation.Gpa,
            UniversityCode = createdUniversity.Code,
            UniversityName = createdUniversity.Name
        };

        return toDto;
    }

    public IEnumerable<GetAccountDto>? GetAccount()
    {
        var accounts = _accountRepository.GetAll();
        if (!accounts.Any())
        {
            return null;
        }

        var toDto = accounts.Select(account => new GetAccountDto
        {
            Guid = account.Guid,
            Password = account.Password,
            Otp = account.Otp,
            IsDeleted = account.IsDeleted,
            IsUsed = account.IsUsed,
            ExpiredTime = account.ExpiredTime
        });

        return toDto;
    }

    public GetAccountDto? GetAccount(Guid guid)
    {
        var account = _accountRepository.GetByGuid(guid);
        if (account is null)
        {
            return null;
        }

        var toDto = new GetAccountDto
        {
            Guid = account.Guid,
            IsDeleted = account.IsDeleted,
            IsUsed = account.IsUsed
        };

        return toDto;
    }

    public GetAccountDto? CreateAccount(NewAccountDto newAccountDto)
    {
        var account = new Account
        {
            Guid = newAccountDto.Guid,
            Password = Hashing.HashPassword(newAccountDto.Password),            
            Otp = newAccountDto.Otp,
            IsDeleted = newAccountDto.IsDeleted,
            IsUsed = newAccountDto.IsUsed,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdAccount = _accountRepository.Create(account);
        if (createdAccount is null)
        {
            return null;
        }

        var toDto = new GetAccountDto
        {
            Guid = createdAccount.Guid,
            Password = createdAccount.Password,
            IsDeleted = createdAccount.IsDeleted,
            IsUsed = createdAccount.IsUsed,
            Otp = createdAccount.Otp
        };

        return toDto;

    }

    public int UpdateAccount(GetAccountDto updateAccountDto)
    {
        var isExist = _accountRepository.IsExist(updateAccountDto.Guid);
        if (!isExist)
        {
            return -1; // Not Found
        }

        var getAccount = _accountRepository.GetByGuid(updateAccountDto.Guid);
        var account = new Account
        {
            Guid = updateAccountDto.Guid,
            Password = Hashing.HashPassword(updateAccountDto.Password),
            Otp = updateAccountDto.Otp,
            ModifiedDate = DateTime.Now,
            CreatedDate = getAccount!.CreatedDate
        };

        var isUpdate = _accountRepository.Update(account);
        if (!isUpdate)
        {
            return 0;
        }

        return 1;
    }

    public int DeleteAccount(Guid guid)
    {
        var isExist = _accountRepository.IsExist(guid);
        if (!isExist)
        {
            return -1;
        }

        var account = _accountRepository.GetByGuid(guid);
        var isDelete = _accountRepository.Delete(account!);
        if (!isDelete)
        {
            return 0; // 
        }

        return 1;
    }

    public ForgotPasswordDto GenerateOtp(string email)
    {
        var employee = _employeeRepository.GetAll().SingleOrDefault(account => account.Email == email);
        if (employee is null)
        {
            return null;
        }

        var toDto = new ForgotPasswordDto
        {
            Email = employee.Email,
            Otp = GenerateRandomOTP(),
            ExpireTime = DateTime.Now.AddMinutes(5)
        };

        var relatedAccount = _accountRepository.GetByGuid(employee.Guid);

        var updateAccountDto = new Account
        {
            Guid = relatedAccount.Guid,
            Password = relatedAccount.Password,
            IsDeleted = (bool)relatedAccount.IsDeleted,
            Otp = toDto.Otp,
            IsUsed = false,
            ExpiredTime = DateTime.Now.AddMinutes(5)
        };

        var updateResult = _accountRepository.Update(updateAccountDto);

        return toDto;
    }

    private int GenerateRandomOTP()
    {
        var random = new Random();
        var otp = random.Next(100000, 999999);
        return otp;
    }

}





