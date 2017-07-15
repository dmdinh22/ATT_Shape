using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATT_Shape3.web.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char? MiddleInitial { get; set; }
    }
}