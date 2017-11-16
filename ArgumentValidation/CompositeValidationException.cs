using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Zonkflut.ArgumentValidation
{
    /// <summary>
    /// Contains a collection of collected Validation Exceptions.
    /// </summary>
    // see blog post https://blogs.msdn.microsoft.com/agileer/2013/05/17/the-correct-way-to-code-a-custom-exception-class/
    [Serializable]
    public class CompositeValidationException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CompositeValidationException() { }

        /// <summary>
        /// Constructor with message only
        /// </summary>
        /// <param name="message">The exception message</param>
        public CompositeValidationException(string message) : base(message) { }

        /// <summary>
        /// Complete constructor
        /// </summary>
        /// <param name="exceptions">The list of validation exceptions.</param>
        /// <param name="message">The exception message</param>
        public CompositeValidationException(List<ArgumentException> exceptions, string message) : base(message)
        {
            Exceptions = exceptions;
        }

        /// <summary>
        /// Constructor for deserialization.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected CompositeValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Exceptions = info.GetValue("Exceptions", typeof(List<ArgumentException>)) as List<ArgumentException> ?? new List<ArgumentException>();
        }

        /// <summary>
        /// The list of exceptions.
        /// </summary>
        public List<ArgumentException> Exceptions { get; set; }

        /// <summary>
        /// For serialising the exception
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue("Exceptions", Exceptions);
            base.GetObjectData(info, context);
        }
    }
}