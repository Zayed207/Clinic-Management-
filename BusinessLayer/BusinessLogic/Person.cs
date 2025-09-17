using AutoMapper;
using BusinessLayer.BusinessLogic;
using BusinessLayer.DTOsForPresentationLayer;
using DataLayer.Contract;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{

    public class Person
    {
        
        public enum enMode { enAddNewMode = 1, enUpdateMode = 2 } 
        public enMode Mode  = enMode.enAddNewMode; 

        public int PersonID { get; set; }
        public string FirstName { get; set; }
     
       

        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Phone { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }

        public int? Age { get; set; }
        

        public int? UserID_FK { get; set; }

        // خاصية محسوبة في طبقة الأعمال
        public string Full_Name { get { return $"{FirstName} {LastName}"; } }

        public Person(int personID, string firstName, string lastName,
            DateTime dateOfBirth, string phone, string? address, string? country, int? age, int? userID_FK)
        {
            PersonID = personID;
            FirstName = firstName;
          
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Address = address;
            Country = country;
            Age = age;
            UserID_FK = userID_FK;
        }

        public Person(PersonEntity perosn)
        {

            this.PersonID = perosn.PersonID;
            this.FirstName = perosn.FirstName;
            
            this.LastName = perosn.LastName;
            this.DateOfBirth = perosn.DateOfBirth;
            this.Address = perosn.Address;
            this.Phone = perosn.Phone;
            this.Age = perosn.Age;
            this.Country = perosn.Country;
            this.UserID_FK = perosn.UserID_FK ;
        }
        public Person(PersonRequestDTO perosn)
        {

            this.PersonID = perosn.PersonID;
            this.FirstName = perosn.FirstName;

            this.LastName = perosn.LastName;
            this.DateOfBirth = perosn.DateOfBirth;
            this.Address = perosn.Address;
            this.Phone = perosn.Phone;
            
            this.Country = perosn.Country;
            this.UserID_FK = perosn.UserID_FK;

            Mode=enMode.enAddNewMode;
        }

       
        }

    //private PerosnEntity MapToDalDto()
    //{
    //    return new PerosnEntity
    //    {
    //        Person_Id = this.Person_Id,
    //        FirstName = this.FirstName,
    //        SecondName = this.SecondName,
    //        ThirdName = this.ThirdName,
    //        LastName = this.LastName,
    //        DateOfBirth = this.DateOfBirth,
    //        Email = this.Email,
    //        Phone = this.Phone,
    //        Address = this.Address
    //    };
    //}

    public class PersonServices
    {
        private readonly IPersonRepository _repo;
        private readonly IMapper _mapper;

        public PersonServices(IPersonRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> AddNewPerson(PersonRequestDTO person)
        {
            try
            {
                int id =await _repo.AddPerson(_mapper.Map<PersonEntity>(person));

                if (id > 0)
                    return OperationResult<int>.Success(id, "Person created successfully");

                return OperationResult<int>.Conflict("Failed to create person.");
            }
            catch (Exception ex)
            {
                return OperationResult<int>.InternalError($"Unexpected error: {ex}");
            }
        }

        public async Task<OperationResult<bool>> UpdatePerson(PersonRequestDTO person)
        {
            try
            {
                bool updated =await _repo.UpdatePerson(_mapper.Map<PersonEntity>(person));

                if (updated)
                    return OperationResult<bool>.Updated("Person updated successfully");

                return OperationResult<bool>.NotFound("Person not found or nothing to update.");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.InternalError($"Unexpected error: {ex}");
            }
        }

        public async Task<OperationResult<bool>> DeletePerson(int personId)
        {
            try
            {
                bool deleted =await _repo.DeletePerson(personId);

                if (deleted)
                    return OperationResult<bool>.Success(true, "Person deleted successfully");

                return OperationResult<bool>.NotFound("Person not found or nothing to delete.");
            }
            catch (Exception ex)
            {
                return OperationResult<bool>.InternalError($"Unexpected error: {ex}");
            }
        }

        public async Task<OperationResult<Person>> GetPersonById(int personId)
        {
            try
            {
                var entity =await _repo.FindPersonById(personId);

                if (entity == null)
                    return OperationResult<Person>.NotFound($"Person with ID {personId} not found.");

                return OperationResult<Person>.Success(new Person(entity), "Person found");
            }
            catch (Exception ex)
            {
                return OperationResult<Person>.InternalError($"Unexpected error: {ex}");
            }
        }

        public async Task<OperationResult<Person>> GetPersonByUserId(int userId)
        {
            try
            {
                var entity =await _repo.FindPersonByUserId(userId);

                if (entity == null)
                    return OperationResult<Person>.NotFound($"Person with UserID {userId} not found.");

                return OperationResult<Person>.Success(new Person(entity), "Person found");
            }
            catch (Exception ex)
            {
                return OperationResult<Person>.InternalError($"Unexpected error: {ex}");
            }
        }

        public async Task<OperationResult<Person>> GetPersonByEmail(string email)
        {
            try
            {
                var entity =await _repo.FindPersonByEmail(email);

                if (entity == null)
                    return OperationResult<Person>.NotFound($"Person with Email {email} not found.");

                return OperationResult<Person>.Success(new Person(entity), "Person found");
            }
            catch (Exception ex)
            {
                return OperationResult<Person>.InternalError($"Unexpected error: {ex}");
            }
        }

        
     
    }


}
