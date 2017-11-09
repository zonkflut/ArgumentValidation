using System;

namespace Zonkflut.ArgumentValidation
{
    /// <summary>
    /// A set of general checks for the <see cref="Argument{T}"/> class.
    /// </summary>
    public static class ArgumentExtensions
    {
        /// <summary>
        /// Checks that the argument is not null.
        /// </summary>
        /// <param name="argument">The argument under test.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentNullException">If the argument is null.</exception>
        public static IAndArgument<T> NotNull<T>(this Argument<T> argument, string message = null)
        {
            if (Equals(argument.Value, null))
                throw new ArgumentNullException(argument.Name, message ?? $"{argument.Name} cannot be null");

            return argument;
        }

        /// <summary>
        /// Checks that the argument is equal to the provided <paramref name="compareValue"/>.
        /// </summary>
        /// <param name="argument">The argument under test.</param>
        /// <param name="compareValue">The value to compare the argument against.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the argument is not equal to the provided <paramref name="compareValue"/>.</exception>
        public static IAndArgument<T> EqualTo<T>(this Argument<T> argument, T compareValue, string message = null)
        {
            if (Equals(argument.Value.Equals(compareValue), false))
                throw new ArgumentException(message ?? $"{argument.Name} must equal {compareValue}, actual value is {argument.Value}", argument.Name);

            return argument;
        }

        /// <summary>
        /// Checks that the argument matches on a provided lambda expression.
        /// </summary>
        /// <param name="argument">The argument under test.</param>
        /// <param name="criteria">The lambda expression to match on.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentNullException">If the <paramref name="criteria"/> results in a null reference exception.</exception>
        /// <exception cref="ArgumentException">If the argument does not match the provided <paramref name="criteria"/>.</exception>
        public static IAndArgument<T> MatchingOn<T>(this Argument<T> argument, Func<T, bool> criteria, string message = null)
        {
            try
            {
                if (criteria(argument.Value) == false)
                    throw new ArgumentException(message ?? $"{argument.Name} did not match criteria, actual value is {argument.Value}", argument.Name);

                return argument;
            }
            catch (NullReferenceException)
            {
                throw new ArgumentNullException(argument.Name, message ?? $"{argument.Name} did not match criteria, actual value is {argument.Value?.ToString() ?? "null"}");
            }
        }
    }
}
