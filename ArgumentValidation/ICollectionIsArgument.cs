namespace ArgumentValidation
{
    /// <summary>
    /// The initial Collection Validation check.
    /// </summary>
    /// <typeparam name="T">The type of the argument.</typeparam>
    public interface ICollectionIsArgument<T>
    {
        /// <summary>
        /// The initial validation check.
        /// </summary>
        /// <returns>
        /// The <see cref="CollectionArgument{T}"/> object which provides a selection of validation checks.
        /// </returns>
        CollectionArgument<T> Is { get; }
    }
}