using System;

namespace ATT_Shape.domain.Classes
{
    public class Exception
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string StackTrace { get; set; }
        public string ApiUrl { get; set; }
        public string ViewUrl { get; set; }
        public string RequestBody { get; set; }
        public DateTime LogDate { get; set; }
    }
}
