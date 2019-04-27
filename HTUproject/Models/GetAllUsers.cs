using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTUproject.Models
{
    public class GetAllUsers
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }


        
        public string LastName { get; set; }


       
        public string Age { get; set; }


       
        public string Major { get; set; }


        
        public string Country { get; set; }


        
        public string City { get; set; }


       
        public string Company { get; set; }


        
        public string Details { get; set; }

        public string Email { get; set; }


        public string UserName { get; set; }


        public string Roles { get; set; }


    }
}