namespace Zonkflut.ArgumentValidation
{
    public interface IValue<T>
    {
        /// <summary>
        /// The value of the validated argument.
        /// </summary>
        /// <returns>
        /// The value of the argument being validated.
        /// </returns>
        T Value { get; }
    }
}