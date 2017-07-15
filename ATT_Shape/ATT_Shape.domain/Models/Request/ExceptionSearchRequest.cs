using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT_Shape.domain.Models.Request
{
    public class ExceptionSearchRequest
    {
        private int _itemsPerPage = 20;

        public string Type { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Url { get; set; }
        public string Person { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage
        {
            get { return _itemsPerPage; }
        }
    }
}
