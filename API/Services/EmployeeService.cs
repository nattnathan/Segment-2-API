using API.Contracts;
using API.DTOs.Account;
using API.DTOs.Employee;
using API.DTOs.Roles;
using API.Models;
using API.Utilities;
using System.Net.WebSockets;

namespace API.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEducationRepository _educationRepository;
    private readonly IUniversityRepository _universityRepository;
    public EmployeeService(IEmployeeRepository employeeRepository,
                           IEducationRepository educationRepository,
                           IUniversityRepository universityRepository)
    {
        _employeeRepository = employeeRepository;
        _educationRepository = educationRepository;
        _universityRepository = universityRepository;
    }

    public IEnumerable<GetEmployeeDto>? GetEmployee()
    {
        var employees = _employeeRepository.GetAll();
        if (!employees.Any())
        {
            return null;
        }

        var toDto = employees.Select(employee => new GetEmployeeDto
        {
            Guid = employee.Guid,
            Nik = employee.Nik,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            Gender = employee.Gender,
            HiringDate = employee.HiringDate,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber
        });

        return toDto;
    }

    public GetEmployeeDto? GetEmployee(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null)
        {
            return null;
        }

        var toDto = new GetEmployeeDto
        {
            Guid = employee.Guid,
            Nik = employee.Nik,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            Gender = employee.Gender,
            HiringDate = employee.HiringDate,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber
        };

        return toDto;
    }

    public IEnumerable<GetEmployeeDto>? GetEmploye(string firstName)
    {
        var employees = _employeeRepository.GetByFirstName(firstName);
        if (!employees.Any())
        {
            return null;
        }

        var toDto = employees.Select(employee => new GetEmployeeDto
        {
            Guid = employee.Guid,
            Nik = employee.Nik,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            Gender = employee.Gender,
            HiringDate = employee.HiringDate,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber
        }).ToList();

        return toDto;
    }

    public GetEmployeeDto? CreateEmployee(NewEmployeDto newEmployeDto)
    {
        var employee = new Employee
        {
            Guid = new Guid(),
            Nik = GenerateNIK(),
            FirstName = newEmployeDto.FirstName,
            LastName = newEmployeDto.LastName,
            BirthDate = newEmployeDto.BirthDate,
            Gender = newEmployeDto.Gender,
            HiringDate = newEmployeDto.HiringDate,
            Email = newEmployeDto.Email,
            PhoneNumber = newEmployeDto.PhoneNumber,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdEmployee = _employeeRepository.Create(employee);
        if (createdEmployee is null)
        {
            return null;
        }

        var toDto = new GetEmployeeDto
        {
            Guid = createdEmployee.Guid,
            Nik = createdEmployee.Nik,
            FirstName = createdEmployee.FirstName,
            LastName = createdEmployee.LastName,
            BirthDate = createdEmployee.BirthDate,
            Gender = createdEmployee.Gender,
            HiringDate = createdEmployee.HiringDate,
            Email = createdEmployee.Email,
            PhoneNumber = createdEmployee.PhoneNumber,
        };

        return toDto;

    }

    public int UpdateEmploye(GetEmployeeDto updateEmployeeDto)
    {
        var isExist = _employeeRepository.IsExist(updateEmployeeDto.Guid);
        if (!isExist)
        {
            return -1; // Not Found
        }

        var getEmployee = _employeeRepository.GetByGuid(updateEmployeeDto.Guid);
        var employee = new Employee
        {
            Guid = updateEmployeeDto.Guid,
            Nik = updateEmployeeDto.Nik,
            FirstName = updateEmployeeDto.FirstName,
            LastName = updateEmployeeDto.LastName,
            BirthDate = updateEmployeeDto.BirthDate,
            Gender = updateEmployeeDto.Gender,
            HiringDate = updateEmployeeDto.HiringDate,
            Email = updateEmployeeDto.Email,
            PhoneNumber = updateEmployeeDto.PhoneNumber,
            ModifiedDate = DateTime.Now,
            CreatedDate = getEmployee!.CreatedDate
        };

        var isUpdate = _employeeRepository.Update(employee);
        if (!isUpdate)
        {
            return 0;
        }

        return 1;
    }

    public int DeleteEmployee(Guid guid)
    {
        var isExist = _employeeRepository.IsExist(guid);
        if (!isExist)
        {
            return -1; 
        }

        var employee = _employeeRepository.GetByGuid(guid);
        var isDelete = _employeeRepository.Delete(employee!);
        if (!isDelete)
        {
            return 0; 
        }

        return 1;
    }

    public string GenerateNIK()
    {
        var lastEmployee = _employeeRepository.GetAll();

        if (!lastEmployee.Any())
        {
            return "111111";
        }

        var lastData = lastEmployee.LastOrDefault();
        var nik = (int.Parse(lastData.Nik) + 1).ToString();

        return nik;
    }

    public IEnumerable<EmployeeEducationDto>? GetMaster()
    {
        var master = (from e in _employeeRepository.GetAll()
                      join education in _educationRepository.GetAll() on e.Guid equals education.Guid
                      join u in _universityRepository.GetAll() on education.UniversityGuid equals u.Guid
                      select new EmployeeEducationDto
                      {
                          Guid = e.Guid,
                          FullName = e.FirstName + " " + e.LastName,
                          Nik = e.Nik,
                          BirthDate = e.BirthDate,
                          Email = e.Email,
                          HiringDate = e.HiringDate,
                          PhoneNumber = e.PhoneNumber,
                          Major = education.Major,
                          Degree = education.Degree,
                          Gpa = education.Gpa,
                          UniversityName = u.Name
                      }).ToList();

        if (!master.Any())
        {
            return null;
        }

        return master;
    }

    public EmployeeEducationDto? GetMasterByGuid(Guid guid)
    {
        var master = GetMaster();

        var masterByGuid = master.FirstOrDefault(master => master.Guid == guid);

        return masterByGuid;
    }
}