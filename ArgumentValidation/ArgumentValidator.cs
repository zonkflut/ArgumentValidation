using System;
using System.Collections;
using System.Linq.Expressions;

namespace ArgumentValidation
{
    /// <summary>
    /// Provides a set of validations for arguements.
    /// </summary>
    public static class ArgumentValidator
    {
        /// <summary>
        /// Validates a provided parameter.
        /// </summary>
        /// <typeparam name="T">The type of the provided parmeter.</typeparam>
        /// <param name="argument">A lambda expression that selects a parameter for validation.</param>
        /// <param name="argumentName">Overrides the reflected name of the parameter.</param>
        /// <returns>An instance of <see cref="IIsArgument{T}"/>.</returns>
        /// <example>
        /// var myParameter = "hello world";
        /// var validatedMyParameter = ArgumentValidator.CheckArgument(() => myParameter).Is.NotNull().Value;
        /// </example>
        public static IIsArgument<T> CheckArgument<T>(Expression<Func<T>> argument, string argumentName = null)
        {
            var member = (MemberExpression)argument.Body;
            var value = argument.Compile()();
            return value is ICollection
                ? new CollectionArgument<T>(argumentName ?? member.Member.Name, value)
                : new Argument<T>(argumentName ?? member.Member.Name, value);
        }
    }
}
