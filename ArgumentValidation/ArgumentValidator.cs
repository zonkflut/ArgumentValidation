using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Zonkflut.ArgumentValidation
{
    /// <summary>
    /// Provides a set of validations for arguements.
    /// </summary>
    public class ArgumentValidator
    {
        /// <summary>
        /// Validates a provided parameter.
        /// </summary>
        /// <typeparam name="T">The type of the provided parmeter.</typeparam>
        /// <param name="argument">A lambda expression that selects a parameter for validation.</param>
        /// <param name="argumentName">Overrides the reflected name of the parameter.</param>
        /// <returns>An instance of <see cref="IIsArgument{T}"/>.</returns>
        /// <example>
        /// var myParameter = "hello world";
        /// var validatedMyParameter = ArgumentValidator.CheckArgument(() => myParameter).Is.NotNull().Value;
        /// </example>
        public static IIsArgument<T> CheckArgument<T>(Expression<Func<T>> argument, string argumentName = null)
        {
            var member = (MemberExpression)argument.Body;
            var value = argument.Compile()();
            return member.Type.GetInterfaces().Contains(typeof(ICollection))
                ? new CollectionArgument<T>(argumentName ?? member.Member.Name, value)
                : new Argument<T>(argumentName ?? member.Member.Name, value);
        }

        /// <summary>
        /// Creates an instance of the ArgumentValidator for collecting validation errors.
        /// </summary>
        /// <returns>An instance of the ArgumentValidator</returns>
        public static ArgumentValidator CreateValidationErrorCollector()
        {
            return new ArgumentValidator();
        }

        private readonly List<ArgumentException> exceptions;

        /// <summary>
        /// Private constructor to force the use of the static method.
        /// </summary>
        private ArgumentValidator()
        {
            exceptions = new List<ArgumentException>();
        }

        /// <summary>
        /// Collects the validation error for a IAndArgument
        /// </summary>
        /// <typeparam name="T">The type of the Argument under validation.</typeparam>
        /// <param name="argument">The argument under validation.</param>
        /// <param name="validation"></param>
        /// <returns>The an object with the initial value</returns>
        public IValue<T> Add<T>(Expression<Func<T>> argument, Func<IIsArgument<T>, IAndArgument<T>> validation) => Add(argument, null, validation);

        /// <summary>
        /// Collects the validation error for a IAndArgument
        /// </summary>
        /// <typeparam name="T">The type of the Argument under validation.</typeparam>
        /// <param name="argument">The argument under validation.</param>
        /// <param name="argumentName">Overrides the reflected name of the parameter.</param>
        /// <param name="validation"></param>
        /// <returns>The an object with the initial value</returns>
        public IValue<T> Add<T>(Expression<Func<T>> argument, string argumentName, Func<IIsArgument<T>, IAndArgument<T>> validation)
        {
            var check = CheckArgument(argument, argumentName);
            try
            {
                return validation(check);
            }
            catch (ArgumentException e)
            {
                var value = ((IValue<T>)check).Value;
                exceptions.Add(e);
                return new FailedResultValue<T>(value);
            }
        }

        /// <summary>
        /// Collects the validation error for a ICollectionAndArgument
        /// </summary>
        /// <typeparam name="T">The type of the Argument under validation.</typeparam>
        /// <param name="argument">The argument under validation.</param>
        /// <param name="validation"></param>
        /// <returns>The an object with the initial value</returns>
        public IValue<T> Add<T>(Expression<Func<T>> argument, Func<IIsArgument<T>, ICollectionAndArgument<T>> validation) => Add(argument, null, validation);

        /// <summary>
        /// Collects the validation error for a ICollectionAndArgument
        /// </summary>
        /// <typeparam name="T">The type of the Argument under validation.</typeparam>
        /// <param name="argument">The argument under validation.</param>
        /// <param name="argumentName">Overrides the reflected name of the parameter.</param>
        /// <param name="validation"></param>
        /// <returns>The an object with the initial value</returns>
        public IValue<T> Add<T>(Expression<Func<T>> argument, string argumentName, Func<IIsArgument<T>, ICollectionAndArgument<T>> validation)
        {
            var check = CheckArgument(argument);
            try
            {
                return validation(check);
            }
            catch (ArgumentException e)
            {
                var value = ((IValue<T>)check).Value;
                exceptions.Add(e);
                return new FailedResultValue<T>(value);
            }
        }

        /// <summary>
        /// Throws a <see cref="CompositeValidationException"/> if any validation exceptions are collected.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void ThrowAll(string message)
        {
            if (exceptions.Any())
                throw new CompositeValidationException(exceptions, message);
        }
    }
}
