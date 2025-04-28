using FluentValidation;

namespace CoPilot.Workshop.Framework
{
    public abstract class BaseHandler<T, V, R> : BaseHandler<T, V>
        where T : class
        where V : AbstractValidator<T>, new()
    {
        public override abstract Task<R> ExecuteAsync(T request, CancellationToken cancellationToken = default);
    }

    public abstract class BaseHandler<T>
        where T : class
    {
        public virtual Task HandleAsync(T request, CancellationToken cancellationToken = default)
        {
            return ExecuteAsync(request, cancellationToken);
        }

        public abstract Task ExecuteAsync(T request, CancellationToken cancellationToken = default);
    }

    public abstract class BaseHandler<T, V>
        where T : class
        where V : AbstractValidator<T>, new()
    {
        public virtual Task HandleAsync(T request, CancellationToken cancellationToken = default)
        {
            var validator = new V();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors
                    .GroupBy(e => e.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(e => e.ErrorMessage).ToArray()
                    );

                throw new ValidationException(errors);
            }

            return ExecuteAsync(request, cancellationToken);
        }

        public abstract Task ExecuteAsync(T request, CancellationToken cancellationToken = default);
    }
}
