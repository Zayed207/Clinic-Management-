using DataLayer.Entities;

namespace DataLayer.Contract
{
    using System;
    using System.Collections.Generic;

    public interface IPersonRepository
    {
       Task <int> AddPerson(PersonEntity entity);
       Task <bool> UpdatePerson(PersonEntity entity);
       Task <bool >DeletePerson(int id);
       Task < PersonEntity >FindPersonById(int personId);
       Task  <PersonEntity  >FindPersonByEmail(string email);
       Task  <PersonEntity  >FindPersonByUserId(int userId);




    }
}
