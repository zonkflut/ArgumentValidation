namespace ArgumentValidation
{
    /// <summary>
    /// Any further collection validation checks after a <see cref="ICollectionIsArgument{T}"/> check has occurred.
    /// </summary>
    /// <typeparam name="T">The type of the argument being validated.</typeparam>
    public interface ICollectionAndArgument<T>
    {
        /// <summary>
        /// Any further checks.
        /// </summary>
        /// <returns>
        /// The <see cref="CollectionArgument{T}"/> object which provides a selection of validation checks.
        /// </returns>
        CollectionArgument<T> And { get; }
        
        /// <summary>
        /// The value of the validated argument.
        /// </summary>
        /// <returns>
        /// The value of the argument being validated.
        /// </returns>
        T Value { get; }
    }
}