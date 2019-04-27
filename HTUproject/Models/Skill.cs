using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTUproject.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string SkillName { get; set; }

        
        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}