namespace ArgumentValidation
{
    /// <summary>
    /// An argument, it's name, value, and Validation operations.
    /// </summary>
    /// <typeparam name="T">The type of the argument being validated.</typeparam>
    public class Argument<T> : IIsArgument<T>, IAndArgument<T>
    {
        /// <summary>
        /// Constructs a <see cref="Argument{T}"/> class.
        /// </summary>
        /// <param name="name">The name of the argument.</param>
        /// <param name="value">The value of the argument.</param>
        internal Argument(string name, T value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// The name of the argument.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The value of the validated argument.
        /// </summary>
        public T Value { get; }

        /// <summary>
        /// The initial validation check.
        /// </summary>
        /// <returns>
        /// The <see cref="Argument{T}"/> object which provides a selection of validation checks.
        /// </returns>
        Argument<T> IIsArgument<T>.Is => this;

        /// <summary>
        /// Any further checks.
        /// </summary>
        /// <returns>
        /// The <see cref="Argument{T}"/> object which provides a selection of validation checks.
        /// </returns>
        Argument<T> IAndArgument<T>.And => this;
    }
}
