using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetAllProductsQuery
{
    public class GetAllProductParameters
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int SubCategoryId { get; set; }

        public GetAllProductParameters()
        {
            this.PageNumber = this.PageNumber < 1 ? 1 : this.PageNumber;
        }

        //public GetAllProductParameters(int pageNumber, int pageSize, sub)
        //{
        //    this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
        //    this.PageSize = pageSize;
        //}

    }
}
