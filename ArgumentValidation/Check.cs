using System;

namespace ArgumentValidation
{
    /// <summary>
    /// Provides a selection of validation checks.
    /// </summary>
    /// <typeparam name="T">The type of the argument being validated</typeparam>
    public sealed class Check<T>
    {
        private readonly Argument<T> argument;

        /// <summary>
        /// Constructs a Check.
        /// </summary>
        /// <param name="argument">The argument being validated.</param>
        internal Check(Argument<T> argument)
        {
            this.argument = argument;
        }

        /// <summary>
        /// Checks that the argument is not null.
        /// </summary>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentNullException">If the argument is null.</exception>
        public IAndArgument<T> NotNull(string message = null)
        {
            if (argument.Value == null)
                throw new ArgumentNullException(argument.Name, message ?? $"{argument.Name} cannot be null");

            return argument;
        }

        /// <summary>
        /// Checks that if the argument is a string, that it is not null or whitespace.
        /// </summary>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the argument is a string and it's value is null or whitespace.</exception>
        public IAndArgument<T> NotNullOrWhitespace(string message = null)
        {
            if (typeof(T) == typeof(string) && string.IsNullOrWhiteSpace(argument.Value as string))
                throw new ArgumentException(message ?? $"{argument.Name} cannot be null or whitespace", argument.Name);

            return argument;
        }

        /// <summary>
        /// Checks that if the argument is a string, that it is not null or empty.
        /// </summary>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the argument is a string and it's value is null or empty.</exception>
        public IAndArgument<T> NotNullOrEmpty(string message = null)
        {
            if (typeof(T) == typeof(string) && string.IsNullOrEmpty(argument.Value as string))
                throw new ArgumentException(message ?? $"{argument.Name} cannot be null or empty", argument.Name);

            return argument;
        }

        /// <summary>
        /// Checks that if the argument implements <see cref="IComparable"/>, that it is greater than the provided <paramref name="compareValue"/>.
        /// </summary>
        /// <param name="compareValue">The value to compare the argument against.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the argument implements <see cref="IComparable"/> and is not greater than the <paramref name="compareValue"/>.</exception>
        public IAndArgument<T> GreaterThan(T compareValue, string message = null)
        {
            if (argument.Value is IComparable comparable && comparable.CompareTo(compareValue) != 1)
                throw new ArgumentException(message ?? $"{argument.Name} must be greater than {compareValue}, actual value is {argument.Value}", argument.Name);

            return argument;
        }

        /// <summary>
        /// Checks that if the argument implements <see cref="IComparable"/>, that it is greater than the provided <paramref name="compareValue"/>.
        /// </summary>
        /// <param name="compareValue">The value to compare the argument against.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the argument implements <see cref="IComparable"/> and is not less than the <paramref name="compareValue"/>.</exception>
        public IAndArgument<T> LessThan(T compareValue, string message = null)
        {
            if (argument.Value is IComparable comparable && comparable.CompareTo(compareValue) != -1)
                throw new ArgumentException(message ?? $"{argument.Name} must be less than {compareValue}, actual value is {argument.Value}", argument.Name);

            return argument;
        }

        /// <summary>
        /// Checks that the argument is equal to the provided <paramref name="compareValue"/>.
        /// </summary>
        /// <param name="compareValue">The value to compare the argument against.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the argument is not equal to the provided <paramref name="compareValue"/>.</exception>
        public IAndArgument<T> EqualTo(T compareValue, string message = null)
        {
            if (argument.Value.Equals(compareValue) == false)
                throw new ArgumentException(message ?? $"{argument.Name} must equal {compareValue}, actual value is {argument.Value}", argument.Name);

            return argument;
        }
    }
}
