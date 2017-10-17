namespace ArgumentValidation
{
    /// <summary>
    /// Any further validation checks after a <see cref="IIsArgument{T}"/> check has occurred.
    /// </summary>
    /// <typeparam name="T">The type of the argument being validated.</typeparam>
    public interface IAndArgument<T>
    {
        /// <summary>
        /// Any further checks.
        /// </summary>
        /// <returns>
        /// The <see cref="Check{T}"/> object which provides a selection of validation checks.
        /// </returns>
        Check<T> And { get; }

        /// <summary>
        /// The value of the validated argument.
        /// </summary>
        /// <returns>
        /// The value of the argument being validated.
        /// </returns>
        T Value { get; }
    }
}
