using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATT_Shape_Hackathon.web.Models
{
    public class Channel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime DateCreated { get; set; }
    }
}