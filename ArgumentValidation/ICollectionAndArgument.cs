namespace Zonkflut.ArgumentValidation
{
    /// <summary>
    /// Any further collection validation checks after a <see cref="ICollectionIsArgument{T}"/> check has occurred.
    /// </summary>
    /// <typeparam name="T">The type of the argument being validated.</typeparam>
    public interface ICollectionAndArgument<T> : IValue<T>
    {
        /// <summary>
        /// Any further checks.
        /// </summary>
        /// <returns>
        /// The <see cref="CollectionArgument{T}"/> object which provides a selection of validation checks.
        /// </returns>
        CollectionArgument<T> And { get; }
    }
}
