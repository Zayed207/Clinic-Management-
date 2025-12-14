using AutoMapper;
using BusinessLayer;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsPresentation;
using BusinessLayer.DTOsPresentation;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BusinessLayer
{
    public class Employee
    {

        public int EmployeeID { get; set; }

        public short EmpployeeTypeID{ get; set; }

        public int ClinicID { get; set; }
        public string Title { get; set; } = null!;

        public int PersonID{ get; set; }

        public string NationalID { get; set; } = null!;

        public int UserID{ get; set; }


        private readonly IMapper _mapper;

        public Employee(EmployeeEntity Entity)
        {
            EmployeeID = Entity.EmployeeID;
            EmpployeeTypeID = Entity.EmpployeeTypeID_FK;
            ClinicID = Entity.ClinicID_FK;
            Title = Entity.Title;   
            PersonID= Entity.PersonID_FK;
            NationalID = Entity.NationalID;
       
            UserID = Entity.UserID_FK;
           
        }
        public Employee(EmployeeRequestDTO  Entity)
        {
            EmployeeID = Entity.EmployeeID;
            EmpployeeTypeID = Entity.EmpployeeTypeID;
            ClinicID = Entity.ClinicID;
            Title = Entity.Title;
            PersonID = Entity.PersonID;
            NationalID = Entity.NationalID;

            UserID = Entity.UserID;

        }
        internal static List<Employee> EmployeeEntityListToEmployee(List<EmployeeEntity> clinicEntities)
        {
            var clinics = new List<Employee>();

            foreach (var entity in clinicEntities)
            {
                clinics.Add(new Employee(entity));

            }
            return clinics;
        }
    }
    public class EmployeeServices
    {
        readonly IEmployeeRepository _repo;
        readonly IMapper _mapper;

        public EmployeeServices(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> AddNewEmployee(EmployeeRequestDTO employeeDto)
        {
            
            var result = await _repo.AddEmployee(_mapper.Map<EmployeeEntity>(new Employee(employeeDto)));
            switch (result.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<int>.Success(result.Data, " created successfully");

                case DataLayerResult.Conflict:
                    return OperationResult<int>.NotFound("Failed to create employee.");

                default:
                    return OperationResult<int>.InternalError($"Unexpected error: {result.Message}");

            }
        }

        public async Task<OperationResult<bool>> UpdateEmployee(EmployeeRequestDTO employeeDto,int employee)
        {
            var prepareing = new Employee(employeeDto);
            prepareing.EmployeeID = employee;
            var updated = await _repo.UpdateEmployee(_mapper.Map<EmployeeEntity>(prepareing));
            switch (updated.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(updated.Data, "Employee updated successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("Employee not found or nothing to update..");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {updated.Message}");
            }
          
        }

        public async Task<OperationResult<bool>> DeleteEmployee(int employeeId)
        {
            if (employeeId <= 0) return OperationResult<bool>.ValidationError("this id is not valid");
            var deleted = await _repo.DeleteEmployee(employeeId);
            switch (deleted.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(deleted.Data, "Employee deleted successfully");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("Employee not found or nothing to update..");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {deleted.Message}");
            }
          
              
        }

        public async Task<OperationResult<Employee>> GetEmployeeByUserId(int userId)
        {
            if (userId <= 0) return OperationResult<Employee>.ValidationError("this id is not valid");

            var entity = await _repo.GetEmployeeByUserId(userId);



            switch (entity.ResultType)
    {
        case DataLayerResult.Success:
            return OperationResult<Employee>.Success(new Employee(entity.Data), "Employee updated successfully.");

        case DataLayerResult.Conflict:
            return OperationResult<Employee>.NotFound("Employee not found or nothing to update..");

        default:
            return OperationResult<Employee>.InternalError($"Unexpected error: {entity.Message}");
    }
   
        }

        public async Task<OperationResult<List<Employee>>> GetAllEmployeesInClinicByClinicID(int clinicId)
        {
            if (clinicId <= 0) return OperationResult<List<Employee>>.ValidationError("this id is not valid");

            var entities = await _repo.GetAllEmployyesInClinicByClinicID(clinicId);


            switch (entities.ResultType)
    {
        case DataLayerResult.Success:
            return OperationResult<List<Employee>>.Success(Employee.EmployeeEntityListToEmployee(entities.Data),
                "employees loaded successfully.");

        case DataLayerResult.Conflict:
            return OperationResult<List<Employee>>.NotFound("No employees found in this clinic.");

        default:
            return OperationResult<List<Employee>>.InternalError($"Unexpected error: {entities.Message}");
    }
    
             
        }

        public async Task<OperationResult<List<Employee>>> GetAllEmployeesInClinicByClinicName(string clinicName)
        {
            var entities = await _repo.GetAllEmployyesInClinicByClinicName(clinicName);
            switch (entities.ResultType)
    {
        case DataLayerResult.Success:
            return OperationResult<List<Employee>>.Success(Employee.EmployeeEntityListToEmployee(entities.Data), "Employee updated successfully.");

        case DataLayerResult.Conflict:
            return OperationResult<List<Employee>>.NotFound("Employee not found or nothing to update..");

        default:
            return OperationResult<List<Employee>>.InternalError($"Unexpected error: {entities.Message}");
    }
    
        }
    }
}
