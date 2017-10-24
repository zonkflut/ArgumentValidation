using System;
using System.Collections;
using System.Linq;

namespace ArgumentValidation
{
    /// <summary>
    /// A set of Collection checks for the <see cref="Argument{T}"/> class.
    /// </summary>
    public static class ArgumentCollectionExtesnsions
    {
        /// <summary>
        /// Returns the collection interfaces for collection checks.
        /// </summary>
        /// <typeparam name="T">The type of the argument under test.</typeparam>
        /// <param name="argument">The argument under test</param>
        /// <returns>The Collection argument interfaces.</returns>
        public static ICollectionIsArgument<T> Collection<T>(this IIsArgument<T> argument)
            where T : ICollection
        {
            return argument as CollectionArgument<T>;
        }

        /// <summary>
        /// Checks that the collection is not empty.
        /// </summary>
        /// <typeparam name="T">The type of collection.</typeparam>
        /// <param name="argument">The argument under validation.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="ICollectionAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the collection is empty.</exception>
        public static ICollectionAndArgument<T> NotEmpty<T>(this CollectionArgument<T> argument, string message = null)
            where T : ICollection
        {
            if (argument.Value?.Count == 0)
                throw new ArgumentException(message ?? $"{argument.Name} cannot be empty.", argument.Name);

            return argument;
        }

        /// <summary>
        /// Checks that the collection contains a specified number of items.
        /// </summary>
        /// <typeparam name="T">The type of collections.</typeparam>
        /// <param name="argument">The argument under validation.</param>
        /// <param name="expectedCount">The expected count of items in the collection.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="ICollectionAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the collection does not contain the specified number of items.</exception>
        public static ICollectionAndArgument<T> Count<T>(this CollectionArgument<T> argument, int expectedCount, string message = null)
            where T : ICollection
        {
            if (argument.Value?.Count != expectedCount)
                throw new ArgumentException(message ?? $"{argument.Name} expected count: {expectedCount} actual: {argument.Value?.Count.ToString() ?? "null"}", argument.Name);
            
            return argument;
        }

        /// <summary>
        /// Checks that the collection's count is less than the specified number.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="argument">The argument under validation.</param>
        /// <param name="lessThanCount">The comparison value for the Less Than Check.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="ICollectionAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the collection's count is not less than the specified number.</exception>
        public static ICollectionAndArgument<T> CountLessThan<T>(this CollectionArgument<T> argument, int lessThanCount, string message = null)
            where T : ICollection
        {
            if (argument.Value == null || argument.Value.Count >= lessThanCount)
                throw new ArgumentException(message ?? $"{argument.Name} count must be less than {lessThanCount} actual value {argument.Value?.Count.ToString() ?? "null"}", argument.Name);

            return argument;
        }

        /// <summary>
        /// Checks that the collection's count is greater than the specified number.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="argument">The argument under validation.</param>
        /// <param name="greaterThanCount">The comparison value for the Greater Than Check.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="ICollectionAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the collection's count is not greater than the specified number.</exception>
        public static ICollectionAndArgument<T> CountGreaterThan<T>(this CollectionArgument<T> argument, int greaterThanCount, string message = null)
            where T : ICollection
        {
            if (argument.Value == null || argument.Value.Count <= greaterThanCount)
                throw new ArgumentException(message ?? $"{argument.Name} count must be greater than {greaterThanCount} actual value {argument.Value?.Count.ToString() ?? "null"}", argument.Name);

            return argument;
        }

        /// <summary>
        /// Checks that the collection contains a specified item.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="argument">The argument under validation.</param>
        /// <param name="item">The item to appear in the collection.</param>
        /// <param name="message">An optional exception message that overrides the default.</param>
        /// <returns>An <see cref="ICollectionAndArgument{T}"/> providing access to the argument's value and further checks.</returns>
        /// <exception cref="ArgumentException">If the collection does not contain the specified item.</exception>
        public static ICollectionAndArgument<T> ContainingItem<T>(this CollectionArgument<T> argument, object item, string message = null)
            where T : ICollection
        {
            if (argument.Value == null || argument.Value.Cast<object>().All(i => i != item))
                throw new ArgumentException(message ?? $"{argument.Name} does not contain provided item", argument.Name);

            return argument;
        }
    }
}
