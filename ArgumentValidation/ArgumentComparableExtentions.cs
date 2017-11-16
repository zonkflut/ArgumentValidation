using System;

namespace Zonkflut.ArgumentValidation
{
    /// <summary>
    /// A set of <see cref="IComparable"/> checks for the <see cref="Argument{T}"/> class.
    /// </summary>
    public static class ArgumentComparableExtentions
    {
        /// <summary>
        /// Checks that if the argument implements <see cref="IComparable"/>, that it is greater than the provided <paramref name="compareValue"/>.
        /// </summary>
        /// <param name="argument">The argument under test.</param>
        /// <param name="compareValue">The value to compare the argument against.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the argument implements <see cref="IComparable"/> and is not greater than the <paramref name="compareValue"/>.</exception>
        public static IAndArgument<T> GreaterThan<T>(this Argument<T> argument, T compareValue, string message = null)
            where T : IComparable
        {
            if (argument.Value is IComparable comparable && comparable.CompareTo(compareValue) != 1)
                throw new ArgumentException(message ?? $"{argument.Name} must be greater than {compareValue}, actual value is {argument.Value}", argument.Name);

            return argument;
        }

        /// <summary>
        /// Checks that if the argument implements <see cref="IComparable"/>, that it is greater than ore equal to the provided <paramref name="compareValue"/>.
        /// </summary>
        /// <param name="argument">The argument under test.</param>
        /// <param name="compareValue">The value to compare the argument against.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the argument implements <see cref="IComparable"/> and is not greater than or equal to the <paramref name="compareValue"/>.</exception>
        public static IAndArgument<T> GreaterThanOrEqualTo<T>(this Argument<T> argument, T compareValue, string message = null)
            where T : IComparable
        {
            if (argument.Value is IComparable comparable && comparable.CompareTo(compareValue) == -1)
                throw new ArgumentException(message ?? $"{argument.Name} must be greater than or equal to {compareValue}, actual value is {argument.Value}", argument.Name);

            return argument;
        }

        /// <summary>
        /// Checks that if the argument implements <see cref="IComparable"/>, that it is greater than the provided <paramref name="compareValue"/>.
        /// </summary>
        /// <param name="argument">The argument under test.</param>
        /// <param name="compareValue">The value to compare the argument against.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the argument implements <see cref="IComparable"/> and is not less than the <paramref name="compareValue"/>.</exception>
        public static IAndArgument<T> LessThan<T>(this Argument<T> argument, T compareValue, string message = null)
            where T : IComparable
        {
            if (argument.Value is IComparable comparable && comparable.CompareTo(compareValue) != -1)
                throw new ArgumentException(message ?? $"{argument.Name} must be less than {compareValue}, actual value is {argument.Value}", argument.Name);

            return argument;
        }

        /// <summary>
        /// Checks that if the argument implements <see cref="IComparable"/>, that it is greater than or equal to the provided <paramref name="compareValue"/>.
        /// </summary>
        /// <param name="argument">The argument under test.</param>
        /// <param name="compareValue">The value to compare the argument against.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="IAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the argument implements <see cref="IComparable"/> and is not less than or equal to the <paramref name="compareValue"/>.</exception>
        public static IAndArgument<T> LessThanOrEqualTo<T>(this Argument<T> argument, T compareValue, string message = null)
            where T : IComparable
        {
            if (argument.Value is IComparable comparable && comparable.CompareTo(compareValue) == 1)
                throw new ArgumentException(message ?? $"{argument.Name} must be less than or equal to {compareValue}, actual value is {argument.Value}", argument.Name);

            return argument;
        }
    }
}
