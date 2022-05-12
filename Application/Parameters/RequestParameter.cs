using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Parameters
{
    public abstract class RequestParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }       

    }
}
