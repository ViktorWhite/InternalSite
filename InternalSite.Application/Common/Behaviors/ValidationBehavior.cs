using FluentValidation;
using MediatR;

namespace InternalSite.Application.Common.Behaviors
{
    /// <summary>
    /// Класс интегрирующий валидаторы в пайплайн медиатора, чтобы они работали в запросах
    /// </summary>
    public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) 
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        /// <summary>
        /// Метод проверяет логику валидатора перед началом действия контроллера
        /// </summary>
        /// <param name="request"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }
            return await next();
        }
    }
}
