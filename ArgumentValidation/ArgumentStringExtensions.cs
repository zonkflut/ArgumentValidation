using System;

namespace ArgumentValidation
{
    /// <summary>
    /// A set of string checks for the <see cref="Argument{T}"/> class.
    /// </summary>
    public static class ArgumentStringExtensions
    {
        /// <summary>
        /// Checks that if the argument is a string, that it is not null or whitespace.
        /// </summary>
        /// <param name="argument">The argument under test.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the argument is a string and it's value is null or whitespace.</exception>
        public static IAndArgument<T> NotNullOrWhitespace<T>(this Argument<T> argument, string message = null)
            where T : IEquatable<string>
        {
            if (typeof(T) == typeof(string) && string.IsNullOrWhiteSpace(argument.Value as string))
                throw new ArgumentException(message ?? $"{argument.Name} cannot be null or whitespace", argument.Name);

            return argument;
        }

        /// <summary>
        /// Checks that if the argument is a string, that it is not null or empty.
        /// </summary>
        /// <param name="argument">The argument under test.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the argument is a string and it's value is null or empty.</exception>
        public static IAndArgument<T> NotNullOrEmpty<T>(this Argument<T> argument, string message = null)
            where T : IEquatable<string>
        {
            if (typeof(T) == typeof(string) && string.IsNullOrEmpty(argument.Value as string))
                throw new ArgumentException(message ?? $"{argument.Name} cannot be null or empty", argument.Name);

            return argument;
        }
    }
}
