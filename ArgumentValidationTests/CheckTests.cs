using NUnit.Framework;
using ArgumentValidation;
using static ArgumentValidation.ArgumentValidator;

namespace ArgumentValidationTests
{
    [TestFixture]
    public class CheckTests
    {
        [Test]
        public void GeneralCheckArgument_IsNotNull_ReturnsValue()
        {
            var myArgument = "hello world";
            var returnedValue = CheckArgument(() => myArgument).Is.NotNull().Value;
            Assert.AreEqual(myArgument, returnedValue);
        }

        [Test]
        public void GeneralCheckArgument_IsNotNull_ThrowsArgumentNullException_WithDefaultMessage()
        {
            string myArgument = null;
            Assert.That(
                () => CheckArgument(() => myArgument).Is.NotNull(),
                Throws.ArgumentNullException.With.Message.EqualTo($"{nameof(myArgument)} cannot be null\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void GeneralCheckArgument_IsNotNull_ThrowsArgumentNullException_WithCustomMessage()
        {
            string myArgument = null;
            const string CustomMessage = "Custom Message";
            Assert.That(
                () => CheckArgument(() => myArgument).Is.NotNull(CustomMessage),
                Throws.ArgumentNullException.With.Message.EqualTo($"{CustomMessage}\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void GeneralCheckArgument_OverrideArgumentName_IsNotNull_ThrowsArgumentNullException_WithOverridenArgumentName()
        {
            string myArgument = null;
            const string ArgumentName = "alternateArgumentName";
            Assert.That(
                () => CheckArgument(() => myArgument, ArgumentName).Is.NotNull(),
                Throws.ArgumentNullException.With.Message.EqualTo($"{ArgumentName} cannot be null\r\nParameter name: {ArgumentName}"));
        }

        [Test]
        public void GeneralCheckArgument_EqualTo_ReturnsValue()
        {
            var myArgument = "hello world";
            var returnedValue = CheckArgument(() => myArgument).Is.EqualTo(myArgument).Value;
            Assert.AreEqual(myArgument, returnedValue);
        }

        [Test]
        public void GeneralCheckArgument_EqualTo_ThrowsArgumentException_WithDefaultMessage()
        {
            var myArgument = "hello world";
            var compareValue = "not matched";
            Assert.That(
                () => CheckArgument(() => myArgument).Is.EqualTo(compareValue),
                Throws.ArgumentException.With.Message.EqualTo($"{nameof(myArgument)} must equal {compareValue}, actual value is {myArgument}\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void GeneralCheckArgument_EqualTo_ThrowsArgumentException_WithCustomMessage()
        {
            var myArgument = "hello world";
            var compareValue = "not matched";
            var message = "custom message";
            Assert.That(
                () => CheckArgument(() => myArgument).Is.EqualTo(compareValue, message),
                Throws.ArgumentException.With.Message.EqualTo($"{message}\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void ComparableCheckArgument_IsGreaterThan_ReturnsValue()
        {
            var myArgument = 10;
            var returnedValue = CheckArgument(() => myArgument).Is.GreaterThan(5).Value;
            Assert.AreEqual(myArgument, returnedValue);
        }

        [Test]
        public void ComparableCheckArgument_IsGreaterThan_ThrowsArgumentException_WithDefaultMessage()
        {
            var myArgument = 5;
            const int CheckValue = 10;
            Assert.That(
                () => CheckArgument(() => myArgument).Is.GreaterThan(CheckValue),
                Throws.ArgumentException.With.Message.EqualTo($"{nameof(myArgument)} must be greater than {CheckValue}, actual value is {myArgument}\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void ComparableCheckArgument_IsGreaterThan_ThrowsArgumentException_WithCustomMessage()
        {
            var myArgument = 5;
            const int CheckValue = 10;
            var message = "custom message";
            Assert.That(
                () => CheckArgument(() => myArgument).Is.GreaterThan(CheckValue, message),
                Throws.ArgumentException.With.Message.EqualTo($"{message}\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void ComparableCheckArgument_IsLessThan_ReturnsValue()
        {
            var myArgument = 5;
            var returnedValue = CheckArgument(() => myArgument).Is.LessThan(10).Value;
            Assert.AreEqual(myArgument, returnedValue);
        }

        [Test]
        public void ComparableCheckArgument_IsLessThan_ThrowsArgumentException_WithDefaultMessage()
        {
            var myArgument = 10;
            const int CheckValue = 5;
            Assert.That(
                () => CheckArgument(() => myArgument).Is.LessThan(CheckValue),
                Throws.ArgumentException.With.Message.EqualTo($"{nameof(myArgument)} must be less than {CheckValue}, actual value is {myArgument}\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void ComparableCheckArgument_IsLessThan_ThrowsArgumentException_WithCustomMessage()
        {
            var myArgument = 10;
            const int CheckValue = 5;
            var message = "custom message";
            Assert.That(
                () => CheckArgument(() => myArgument).Is.LessThan(CheckValue, message),
                Throws.ArgumentException.With.Message.EqualTo($"{message}\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void StringCheckArgument_NotNullOrWhitespace_ReturnsValue()
        {
            var myArgument = "hello world";
            var returnValue = CheckArgument(() => myArgument).Is.NotNullOrWhitespace().Value;
            Assert.AreEqual(myArgument, returnValue);
        }

        [TestCase((string)null)]
        [TestCase("")]
        [TestCase("\r")]
        [TestCase("\n")]
        [TestCase("\t")]
        [TestCase(" ")]
        public void StringCheckArgument_NotNullOrWhitespace_ThrowsArgumentException_WithDefaultMessage(string argumentValue)
        {
            var myArgument = argumentValue;
            Assert.That(
                () => CheckArgument(() => myArgument).Is.NotNullOrWhitespace(),
                Throws.ArgumentException.With.Message.EqualTo($"{nameof(myArgument)} cannot be null or whitespace\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void StringCheckArgument_NotNullOrWhitespace_ThrowsArgumentException_WithCustomMessage()
        {
            var myArgument = "\r\n\t ";
            var message = "custom message";
            Assert.That(
                () => CheckArgument(() => myArgument).Is.NotNullOrWhitespace(message),
                Throws.ArgumentException.With.Message.EqualTo($"{message}\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void StringCheckArgument_NotNullOrEmpty_ReturnsValue()
        {
            var myArgument = "hello world";
            var returnedValue = CheckArgument(() => myArgument).Is.NotNullOrEmpty().Value;
            Assert.AreEqual(myArgument, returnedValue);
        }

        [TestCase(null)]
        [TestCase("")]
        public void StringCheckArgument_NotNullOrEmpty_ThrowsArgumentException_WithDefaultMessage(string argumentValue)
        {
            var myArgument = argumentValue;
            Assert.That(
                () => CheckArgument(() => myArgument).Is.NotNullOrEmpty(),
                Throws.ArgumentException.With.Message.EqualTo($"{nameof(myArgument)} cannot be null or empty\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void StringCheckArgument_NotNullOrEmpty_ThrowsArgumentException_WithCustomMessage()
        {
            var myArgument = string.Empty;
            var message = "custom message";
            Assert.That(
                () => CheckArgument(() => myArgument).Is.NotNullOrEmpty(message),
                Throws.ArgumentException.With.Message.EqualTo($"{message}\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void CollectionCheckArgument_NotEmpty_ReturnsValue()
        {
            var myArgument = new[] { "value" };
            var returnedValue = CheckArgument(() => myArgument).Collection().Is.NotEmpty().Value;
            Assert.AreEqual(myArgument, returnedValue);
        }

        [Test]
        public void CollectionCheckArgument_NotEmpty_ThrowsArgumentException_WithDefaultMessage()
        {
            var myArgument = new string[0];
            Assert.That(
                () => CheckArgument(() => myArgument).Collection().Is.NotEmpty(),
                Throws.ArgumentException.With.Message.EqualTo($"{nameof(myArgument)} cannot be empty.\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void CollectionCheckArgument_NotEmpty_ThrowsArgumentException_WithCustomMessage()
        {
            var myArgument = new string[0];
            var message = "custom message";
            Assert.That(
                () => CheckArgument(() => myArgument).Collection().Is.NotEmpty(message),
                Throws.ArgumentException.With.Message.EqualTo($"{message}\r\nParameter name: {nameof(myArgument)}"));
        }

        [Test]
        public void CollectionChecksArgument_Count_ReturnsValue()
        {
            var myArgument = new[] { "1" };
            var returnedValue = CheckArgument(() => myArgument).Collection().Is.Count(myArgument.Length).Value;
            Assert.AreEqual(myArgument, returnedValue);
        }

        [Test]
        public void CollectionChecksArgument_Count_ThrowsArgumentException_WithDefaultMessage()
        {
            var myArgument = new[] { "1" };
            var expectedCount = myArgument.Length + 1;
            Assert.That(
                () => CheckArgument(() => myArgument).Collection().Is.Count(expectedCount),
                Throws.ArgumentException.With.Message.EqualTo($"{nameof(myArgument)} expected count: {expectedCount} actual: {myArgument.Length}\r\nParameter name: {nameof(myArgument)}"));
        }
    }
}
