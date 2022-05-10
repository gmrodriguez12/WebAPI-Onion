using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Application.Exceptions
{
    public class BusinessValidationException : Exception
    {
        public List<string> Errors { get; set; }
        public BusinessValidationException(): base("Validation errors found")
        {
            Errors = new List<string>();
        }

        public BusinessValidationException(IEnumerable<ValidationFailure> failures): this()
        {
            foreach (var item in failures)
            {
                Errors.Add(item.ErrorMessage);
            }
        }
    }
}
