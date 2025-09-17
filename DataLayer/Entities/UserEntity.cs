using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class UserEntity
    {

   
        public int UserID { get; set; }

        
        public string UserName { get; set; }


        public string Password { get; set; }

        
        public string Email { get; set; }
        public short ?Permissions { get; set; }
      

     
        public bool IsActive { get; set; }

        public PersonEntity Person { get; set; }
    }
    }

