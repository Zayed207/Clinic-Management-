using DataLayer.Entities;

namespace DataLayer.Contract
{
    using DataLayer.Data;
    using System;
    using System.Collections.Generic;

   
        public interface IPersonRepository
        {
          
            public Task<DataLayerOperationResult<PersonEntity>> FindPersonByID(int id);

         
            public Task<DataLayerOperationResult<PersonEntity>> FindPersonByFullName(
                string firstName,
                string secondName,
                string thirdName,
                string lastName);

      
            public Task<DataLayerOperationResult<PersonEntity>> FindPersonByFullName(
                string firstName,
                string secondName);

          
            public Task<DataLayerOperationResult<int>> AddPerson(PersonEntity entity);

           
            public Task<DataLayerOperationResult<bool>> UpdatePerson(PersonEntity entity);
            public Task<DataLayerOperationResult<bool>> DeletePersonByID(int id);

       
    }





    
}
