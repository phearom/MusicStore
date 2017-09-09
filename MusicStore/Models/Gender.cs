using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Gender
    {
        [Key]
        public string GenderID { get; set; }
        public string Value { get; set; }
    }
}