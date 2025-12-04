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


    public class PersonData : IPersonRepository
    {

        private readonly Clinicdbcontext _context;
        public PersonData(Clinicdbcontext context)
        {
            _context = context;
        }



    
        public async Task<DataLayerOperationResult<PersonEntity>> FindPersonByFullName(
      string firstName,
      string secondName,
      string thirdName,
      string lastName)
        {
            try
            {
                var exist = await _context.Person
                    .FirstOrDefaultAsync(x =>
                        x.FirstName == firstName &&
                        x.SecondName == secondName &&
                        x.ThirdName == thirdName &&
                        x.LastName == lastName);

                if (exist == null)
                {
                    return DataLayerOperationResult<PersonEntity>
                           .Fail("This person does not exist.");
                }

                return DataLayerOperationResult<PersonEntity>
                       .SuccessOperation(exist);
            }
            catch (Exception)
            {
                return DataLayerOperationResult<PersonEntity>
                       .Fail("Database error occurred while searching for full name.");
            }
        }

        public async Task<DataLayerOperationResult<PersonEntity>> FindPersonByFullName(
     string firstName,
     string secondName)
   
        {
            try
            {
                var exist = await _context.Person
                    .FirstOrDefaultAsync(x =>
                        x.FirstName == firstName &&
                        x.SecondName == secondName
                       );

                if (exist == null)
                {
                    return DataLayerOperationResult<PersonEntity>
                           .Fail("This person does not exist.");
                }

                return DataLayerOperationResult<PersonEntity>
                       .SuccessOperation(exist);
            }
            catch (Exception)
            {
                return DataLayerOperationResult<PersonEntity>
                       .Fail("Database error occurred while searching for full name.");
            }
        }




       public async Task<DataLayerOperationResult<int>> AddPerson(PersonEntity entity)
        {

            try
            {





                _context.Person.Add(entity);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<int>.SuccessOperation(entity.PersonID);


                return DataLayerOperationResult<int>.Fail("adding not successfuly");




            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<int>.InternalError();

            }
        }

        public async Task<DataLayerOperationResult<bool>> UpdatePerson(PersonEntity entity)
        {
           try

            {

                var exsit = await _context.Person.FindAsync(entity.PersonID);
                if (exsit == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this person is not exist");

                }



                _context.Person.Update(exsit);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("woring!!");




            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

        public async Task<DataLayerOperationResult<bool>> DeletePersonByID(int id)
        {
            try

            {

                var person = await _context.Person.Where(x => x.PersonID == id).SingleOrDefaultAsync();
                if (person == null)
                {
                    return DataLayerOperationResult<bool>.Fail("this personid is not exist");

                }



                _context.Person.Remove(person);
                if (await _context.SaveChangesAsync() > 0)

                    return DataLayerOperationResult<bool>.SuccessOperation(true);


                return DataLayerOperationResult<bool>.Fail("deleting is not successfuly");




            }

            catch (Exception ex)
            {

                return DataLayerOperationResult<bool>.InternalError();

            }
        }

    

        public async Task<DataLayerOperationResult<PersonEntity>> FindPersonByID(int personid)
        {

            try
            {
                var exist = await _context.Person
                    .FindAsync(personid);


                if (exist == null)
                {
                    return DataLayerOperationResult<PersonEntity>
                           .Fail("This personid does not exist.");
                }

                return DataLayerOperationResult<PersonEntity>
                       .SuccessOperation(exist);
            }
            catch (Exception)
            {
                return DataLayerOperationResult<PersonEntity>
                       .Fail("Database error occurred while searching by personid.");
            }
        }

      

        

     
    }
}
