using BusinessLayer;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOsPresentation
{
    public class PersonResponseDTO
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

        

        public char Gender { get; set; }


        public PersonResponseDTO(Person Person)
        {
            PersonID = Person.PersonID;
          //  FullName = Person.Full_Name;
           
           
            DateOfBirth = Person.DateOfBirth;
            Phone = Person.Phone;
            Address = Person.Address;
            Country = Person.Country;
            Age = Person.Age;
           
        }

       
    }



    public class PersonRequestDTO
    {


        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        public string ThirdName { get; set; } = null!;
        public string SecondName { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public string Phone { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Country { get; set; } = null!;

        public short? Age { get; set; }



        public char Gender { get; set; }



        //public static bool ValidatePersonObject(PersonResponseDTO person)
        //{
        //    if (person == null) return false;

        //    if (person.CurrentUserID <= 0 || person.FirstName.IsNullOrEmpty()
        //        || person.LastName.IsNullOrEmpty() || person.Phone.IsNullOrEmpty() || person.Country.IsNullOrEmpty()) return false;
        //    else return true;
        //}
    }
}
