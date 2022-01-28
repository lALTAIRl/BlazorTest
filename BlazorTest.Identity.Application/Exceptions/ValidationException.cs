using FluentValidation.Results;

namespace BlazorTest.Identity.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors
        {
            get;
        }

        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            this.Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            this.Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public ValidationException(string propertyName, string errorMessage)
          : this()
        {
            this.Errors.Add(propertyName, new string[] { errorMessage });
        }
    }
}
