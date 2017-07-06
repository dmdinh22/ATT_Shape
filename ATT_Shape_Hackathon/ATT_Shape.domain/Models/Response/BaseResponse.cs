using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATT_Shape.domain.Models.Response
{
    /// <summary>
    /// The Base class for all our Response models. 
    /// If it is going out the door from our Api it must inherit form here.
    /// </summary>
    public abstract class BaseResponse
    {
        public bool IsSuccessful { get; set; }

        public string TransactionId { get; set; }

        public BaseResponse()
        {
            this.TransactionId = Guid.NewGuid().ToString();
        }
    }
}