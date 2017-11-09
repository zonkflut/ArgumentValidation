using System;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Zonkflut.ArgumentValidation
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
        /// <exception cref="ArgumentNullException">If the argument's value is null.</exception>
        /// <exception cref="ArgumentException">If the argument is a string and it's value is whitespace.</exception>
        public static IAndArgument<T> NotNullOrWhitespace<T>(this Argument<T> argument, string message = null)
            where T : IEquatable<string>
        {
            if (Equals(argument.Value, null))
                throw new ArgumentNullException(argument.Name, message ?? $"{argument.Name} cannot be null or whitespace");

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
        /// <exception cref="ArgumentNullException">If the argument's value is null.</exception>
        /// <exception cref="ArgumentException">If the argument is a string and it's value is empty.</exception>
        public static IAndArgument<T> NotNullOrEmpty<T>(this Argument<T> argument, string message = null)
            where T : IEquatable<string>
        {
            if (Equals(argument.Value, null))
                throw new ArgumentNullException(argument.Name, message ?? $"{argument.Name} cannot be null or empty");

            if (typeof(T) == typeof(string) && string.IsNullOrEmpty(argument.Value as string))
                throw new ArgumentException(message ?? $"{argument.Name} cannot be null or empty", argument.Name);

            return argument;
        }

        /// <summary>
        /// Checks that if the argument is a string, that it matches a provided regular expression.
        /// </summary>
        /// <param name="argument">The argument under test.</param>
        /// <param name="regex">The regular expression to match.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentNullException">If the argument's value is null.</exception>
        /// <exception cref="ArgumentException">If the argument is a string and it's value does not match the provided regular expression.</exception>
        public static IAndArgument<T> Matching<T>(this Argument<T> argument, [RegexPattern] string regex, string message = null)
            where T : IEquatable<string>
        {
            if (Equals(argument.Value, null))
                throw new ArgumentNullException(argument.Name, message ?? $"{argument.Name} does not match pattern");

            if (typeof(T) == typeof(string) && Regex.IsMatch(argument.Value.ToString(), regex, RegexOptions.Singleline) == false)
                throw new ArgumentException(message ?? $"{argument.Name} does not match pattern", argument.Name);

            return argument;
        }
    }
}
