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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLayer
{

    public class Person
    {

        public int PersonID { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        public string ThirdName { get; set; } = null!;
        public string SecondName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public string Phone { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Country { get; set; } = null!;

        public short? Age { get; set; }

        public string FullName { get; set; } = null!;

        public char Gender { get; set; }




        // خاصية محسوبة في طبقة الأعمال
        public string Full_Name { get { return $"{FirstName} {LastName}"; } }

     

        public Person(PersonEntity perosn)
        {

            this.PersonID = perosn.PersonID;
            this.FirstName = perosn.FirstName;
            this.SecondName= perosn.SecondName;
           this. ThirdName = perosn.ThirdName;   
            this.LastName = perosn.LastName;
            this.DateOfBirth = perosn.DateOfBirth;
            this.Address = perosn.Address;
            this.Phone = perosn.Phone;
            this.Age = perosn.Age;
            this.Country = perosn.Country;
            this.FullName = perosn.FullName;
            this.Gender = perosn.Gender;

            
        }
        public Person(PersonRequestDTO perosn)
        {


            this.FirstName = perosn.FirstName;

            this.LastName = perosn.LastName;
            this.DateOfBirth = perosn.DateOfBirth;
            this.Address = perosn.Address;
            this.Phone = perosn.Phone;
            
            this.Country = perosn.Country;
            

           
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

           

            var id = await _repo.AddPerson(_mapper.Map<PersonEntity>(new Person(person)));
            switch (id.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<int>.Success(id.Data,"Person created successfully.");

                case DataLayerResult.Conflict:
                    return OperationResult<int>.NotFound("Failed to create person..");

                default:
                    return OperationResult<int>.InternalError($"Unexpected error: {id.Message}");


            }

            
            
          
        }

        public async Task<OperationResult<bool>> UpdatePerson(PersonRequestDTO person)
        {
           

            var updated = await _repo.UpdatePerson(_mapper.Map<PersonEntity>(person));
            switch (updated.ResultType)
            {
                case DataLayerResult.Success:
                    return OperationResult<bool>.Success(updated.Data, "Person updated successfully");

                case DataLayerResult.Conflict:
                    return OperationResult<bool>.NotFound("Person not found or nothing to update..");

                default:
                    return OperationResult<bool>.InternalError($"Unexpected error: {updated.Message}");


            }

        }

        public async Task<OperationResult<bool>> DeletePersonByID(int personId)
        {
              
            
            
            if (personId <= 0) return OperationResult<bool>.ValidationError("this personId is not valid");

              var deleted = await _repo.DeletePersonByID(personId);
                      switch (deleted.ResultType)
              {
                  case DataLayerResult.Success:
                      return OperationResult<bool>.Success(deleted.Data, "Person deleted successfully");

                  case DataLayerResult.Conflict:
                      return OperationResult<bool>.NotFound("Person not found or nothing to delete..");

                  default:
                      return OperationResult<bool>.InternalError($"Unexpected error: {deleted.Message}");


              }


        }

        public async Task<OperationResult<Person>> GetPersonByID(int personId)
        {
    if (personId <= 0) return OperationResult<Person>.ValidationError("this id is not valid");

            var entity = await _repo.FindPersonByID(personId);
            switch (entity.ResultType)
    {
        case DataLayerResult.Success:
            return OperationResult<Person>.Success(new Person(entity.Data), "Person  founded.");

        case DataLayerResult.Conflict:
            return OperationResult<Person>.NotFound("Person with ID  not found..");

        default:
            return OperationResult<Person>.InternalError($"Unexpected error: {entity.Message}");


    }

  

           
        }

       

        
     
    }


}
