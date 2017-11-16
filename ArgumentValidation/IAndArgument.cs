namespace Zonkflut.ArgumentValidation
{
    /// <summary>
    /// Any further validation checks after a <see cref="IIsArgument{T}"/> check has occurred.
    /// </summary>
    /// <typeparam name="T">The type of the argument being validated.</typeparam>
    public interface IAndArgument<T> : IValue<T>
    {
        /// <summary>
        /// Any further checks.
        /// </summary>
        /// <returns>
        /// The <see cref="Argument{T}"/> object which provides a selection of validation checks.
        /// </returns>
        Argument<T> And { get; }
    }
}
