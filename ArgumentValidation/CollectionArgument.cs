namespace Zonkflut.ArgumentValidation
{
    /// <summary>
    /// A collection argument, it's name, value, and Validation operations.
    /// </summary>
    /// <typeparam name="T">The type of the argument being validated.</typeparam>
    public class CollectionArgument<T> : Argument<T>, ICollectionIsArgument<T>, ICollectionAndArgument<T>
    {
        /// <summary>
        /// Constructs a <see cref="CollectionArgument{T}"/> class.
        /// </summary>
        /// <param name="name">The name of the argument.</param>
        /// <param name="value">The value of the argument.</param>
        internal CollectionArgument(string name, T value) : base(name, value)
        {
        }

        /// <summary>
        /// The initial validation check.
        /// </summary>
        /// <returns>
        /// The <see cref="CollectionArgument{T}"/> object which provides a selection of validation checks.
        /// </returns>
        CollectionArgument<T> ICollectionIsArgument<T>.Is => this;

        /// <summary>
        /// Any further checks.
        /// </summary>
        /// <returns>
        /// The <see cref="CollectionArgument{T}"/> object which provides a selection of validation checks.
        /// </returns>
        CollectionArgument<T> ICollectionAndArgument<T>.And => this;
    }
}
