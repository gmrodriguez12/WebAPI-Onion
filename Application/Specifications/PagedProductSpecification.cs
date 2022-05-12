using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications
{
    public class PagedProductSpecification : Specification<Product>
    {
        public PagedProductSpecification(int pageSize, int pageNumber, int? subcategoryId)
        {
            int skip = (pageNumber - 1) * pageSize;

            Query.Skip(skip).Take(pageSize);

            if(subcategoryId.HasValue && subcategoryId.Value > 0)
            {
                Query.Where(x => x.ProductSubcategoryId.Equals(subcategoryId));
            }

            Query.OrderByDescending(x => x.ProductId);
        }
    }
}
