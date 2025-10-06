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

       
        async Task<int> IPersonRepository.AddPerson(PersonEntity entity)
        {  _context.Add(entity);
           await _context.SaveChangesAsync();

            return entity.PersonID;
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
