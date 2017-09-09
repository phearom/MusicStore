using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class User
    {
        public int UserID { get; set; }
        [Required(), Display(Name = "Username")]
        [MaxLength(30), Column(TypeName = "varchar")]
        public string UserName { get; set; }
        [Required(), Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required(), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required()]
        public string Password { get; set; }
        [Required()]
        public string Role { get; set; }
        [Required()]
        public bool IsEnable { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateBy { get; set; }
    }
}