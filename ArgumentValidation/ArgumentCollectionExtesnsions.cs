using System;
using System.Collections;

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
            where T: ICollection
        {
            return argument as CollectionArgument<T>;
        }

        /// <summary>
        /// Checks that the collection is not empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument">The argument under test.</param>
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

        public static ICollectionAndArgument<T> Count<T>(this CollectionArgument<T> argument, int expectedCount, string message = null)
            where T : ICollection
        {
            if (argument.Value?.Count != expectedCount)
                throw new ArgumentException(message ?? $"{argument.Name} expected count: {expectedCount} actual: {argument.Value?.Count}", argument.Name);

            return argument;
        }
    }
}
