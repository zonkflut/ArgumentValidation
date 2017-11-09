namespace Zonkflut.ArgumentValidation
{
    /// <summary>
    /// The initial Validation check.
    /// </summary>
    /// <typeparam name="T">The type of the argument.</typeparam>
    public interface IIsArgument<T>
    {
        /// <summary>
        /// The initial validation check.
        /// </summary>
        /// <returns>
        /// The <see cref="Argument{T}"/> object which provides a selection of validation checks.
        /// </returns>
        Argument<T> Is { get; }
    }
}
