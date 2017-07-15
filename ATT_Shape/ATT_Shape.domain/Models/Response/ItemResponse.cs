using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATT_Shape.domain.Models.Response
{
    public class ItemResponse<T> : SuccessResponse
    {

        public T Item { get; set; }

    }
}