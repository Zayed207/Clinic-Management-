using BusinessLayer;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOsPresentation
{
    public class PersonResponseDTO
    {
        public int PersonID { get; set; }
        public string FullName { get; set; }
       
       

       
        public DateOnly DateOfBirth { get; set; }

        public string Phone { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }

        public int? Age { get; set; }
     

        public PersonResponseDTO(Person Person)
        {
            PersonID = Person.PersonID;
            FullName = Person.Full_Name;
           
           
            DateOfBirth = Person.DateOfBirth;
            Phone = Person.Phone;
            Address = Person.Address;
            Country = Person.Country;
            Age = Person.Age;
           
        }

       
    }



    public class PersonRequestDTO
    {
        

        [Required]
        public string FirstName { get; set; }


        [Required]
        public string LastName { get; set; }

        public DateOnly DateOfBirth { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Country { get; set; }



        //public static bool ValidatePersonObject(PersonResponseDTO person)
        //{
        //    if (person == null) return false;

        //    if (person.CurrentUserID <= 0 || person.FirstName.IsNullOrEmpty()
        //        || person.LastName.IsNullOrEmpty() || person.Phone.IsNullOrEmpty() || person.Country.IsNullOrEmpty()) return false;
        //    else return true;
        //}
    }
}
