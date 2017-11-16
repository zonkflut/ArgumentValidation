namespace Zonkflut.ArgumentValidation
{
    /// <summary>
    /// Returns the value of the Argument under validation after failed validation.
    /// </summary>
    /// <typeparam name="T">The type of the argument under test.</typeparam>
    internal class FailedResultValue<T> : IValue<T>
    {
        public FailedResultValue(T value)
        {
            Value = value;
        }

        /// <summary>
        /// The value of the validated argument.
        /// </summary>
        /// <returns>
        /// The value of the argument being validated.
        /// </returns>
        public T Value { get; }
    }
}