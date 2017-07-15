using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATT_Shape.domain.Models.Request
{
    public class SmsRequest
    {
        public MessageRequest MessageRequest { get; set;}
    }
    public class MessageRequest
    {
        public string[] Addresses { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }
    }
}
