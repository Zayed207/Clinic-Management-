using DataLayer.Contract;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Data
{
    
   
    public class PersonData:IPersonRepository
    {

        private readonly Clinicdbcontext _context;
        public PersonData(Clinicdbcontext context)
        {
            _context = context;
        }

        public  async Task< List<PersonEntity>> GetAllPeople()
        {
            using (_context )
            {
                var list = await _context.Person.ToListAsync();
                return list;
            }


           
        }



        public  PersonEntity FindPersonByID( int id)
        {
            var person = new PersonEntity(); 


            return person;
        }


        public  PersonEntity FindPersonByEmail(string email)
        {
            var person = new PersonEntity();


            return person;
        }
        public  PersonEntity FindPersonByUserID(int userid)
        {
            var person = new PersonEntity();


            return person;
        }

        public  bool Delete(int Person_Id)
        {
            int rowaffected = 0;
            return rowaffected>0;
        }
        public  int AddPerson(PersonEntity Person)
        {
            int id = -1;
            
          
            return id;
        }
        public  bool UpdatePerson(PersonEntity Person)
        {
           
           
            return false;
        }

        Task<int> IPersonRepository.AddPerson(PersonEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPersonRepository.UpdatePerson(PersonEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonEntity> FindPersonById(int personId)
        {
            throw new NotImplementedException();
        }

        Task<PersonEntity> IPersonRepository.FindPersonByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<PersonEntity> FindPersonByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
