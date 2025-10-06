using AutoMapper;
using BusinessLayer.BusinessLogic;
using ClinicAPI.temp.DTOs___Validations;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Employee
    {
        
        public int EmployeeID { get; set; }
        public int TypeEmpployeeID_FK { get; set; }
        public int PersonID_FK { get; set; }
        public string Titel { get; set; }
        public string NationalID { get; set; }
        public decimal? Salary { get; set; }

        private readonly IMapper _mapper;

        public Employee(EmployeeEntity Entity)
        {
            EmployeeID = Entity.EmployeeID;
            TypeEmpployeeID_FK = Entity.EmpployeeTypeID_FK;
            PersonID_FK = Entity.PersonID_FK;
            NationalID = Entity.NationalID;
            Salary = Entity.Salary;
           
        }
        public Employee(EmployeeRequestDTO  Entity)
        {
            EmployeeID = Entity.EmployeeID;
            TypeEmpployeeID_FK = Entity.TypeEmpployeeID_FK;
            PersonID_FK = Entity.PersonID_FK;
            NationalID = Entity.NationalID;
            Salary = Entity.Salary;

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
            try
            {
                var entity = _mapper.Map<EmployeeEntity>(new Employee(employeeDto));
                int id =await _repo.AddEmployee(entity);
                if (id > 0)
                    return OperationResult<int>.Success(id, "Employee created successfully.");
                return OperationResult<int>.InternalError("Failed to create employee.");
            }
            catch (Exception ex)
            {
                return OperationResult<int>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<bool>> UpdateEmployee(EmployeeRequestDTO employeeDto)
        {
            try
            {
                var entity = _mapper.Map<EmployeeEntity>(new Employee(employeeDto));
                bool updated =await _repo.UpdateEmployee(entity);
                if (updated)
                    return OperationResult<bool>.Updated("Employee updated successfully.");
                return OperationResult<bool>.NotFound("Employee not found or nothing to update.");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<bool>> DeleteEmployee(int employeeId)
        {
            try
            {
                bool deleted =await _repo.DeleteEmployee(employeeId);
                if (deleted)
                    return OperationResult<bool>.Success(true, "Employee deleted successfully.");
                return OperationResult<bool>.NotFound("Employee not found or nothing to delete.");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<Employee>> GetEmployeeByUserId(int userId)
        {
            try
            {
                var entity =await _repo.GetEmployeeByUserId(userId);
                if (entity == null)
                    return OperationResult<Employee>.NotFound("Employee not found.");

                var model = new Employee(entity);
                return OperationResult<Employee>.Success(model);
            }
            catch (Exception ex)
            {
                return OperationResult<Employee>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<List<Employee>>> GetAllEmployeesInClinicByClinicID(int clinicId)
        {
            try
            {
                var entities =await _repo.GetAllEmployyesInClinicByClinicID(clinicId);
                if (entities == null || entities.Count == 0)
                    return OperationResult<List<Employee>>.NotFound("No employees found in this clinic.");

                var mapped = entities.Select(e => new Employee(e)).ToList();
                return OperationResult<List<Employee>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Employee>>.InternalError($"Unexpected error: {ex.Message}");
            }
        }

        public async Task<OperationResult<List<Employee>>> GetAllEmployeesInClinicByClinicName(string clinicName)
        {
            try
            {
                var entities =await _repo.GetAllEmployyesInClinicByClinicName(clinicName);
                if (entities == null || entities.Count == 0)
                    return OperationResult<List<Employee>>.NotFound("No employees found in this clinic.");

                var mapped = entities.Select(e => new Employee(e)).ToList();
                return OperationResult<List<Employee>>.Success(mapped);
            }
            catch (Exception ex)
            {
                return OperationResult<List<Employee>>.InternalError($"Unexpected error: {ex.Message}");
            }
        }
    }
}
