using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATT_Shape.domain.Models.Response
{
    /// <summary>
    /// This class simply sets IsSuccesful to true by default.
    /// Many of the response classes will end up inheriting from here
    /// since they should be returning IsSuccessful = true
    /// </summary>
    public class SuccessResponse :  BaseResponse
    {
        public SuccessResponse()
        {
            
            this.IsSuccessful = true;
        }
    }
}