using FluentValidation;
using MediatR;

namespace Application.Beheaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {                
                var context = new ValidationContext<TRequest>(request);

                //execute defained validations
                var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));

                //Get validation failures list
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Any())
                {
                    //Custom exception to return list of validation failures
                    throw new Exceptions.BusinessValidationException(failures);
                }
            }

            return await next();
        }
    }
}
