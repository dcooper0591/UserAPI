using FSPUserApi.Models;

namespace FSPUserApi.Validations
{
    public class ValidateUser
    {

        public static void ValidateUserId(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (!Guid.TryParse(id, out var userId))
                {
                    throw new ValidationException("User Id was not in the correct format. Please use a guid format.");
                }
                else return;
            }
            else
            {
                throw new ValidationException("User Id was not specified. Please provide an id");
            }
        }

        public static void ValidateUserInfo(string firstName, string lastName, string email)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ValidationException("First Name was not specified. Please provide a first name.");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ValidationException("Last Name was not specified. Please provide a last name.");
            }
            if (string.IsNullOrEmpty(email))
            {
                throw new ValidationException("Email was not specified. Please provide an email.");
            }

        }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string? message) : base(message) { }
        public ValidationException(string? message, Exception? innerException) : base(message, innerException) { }
      
    }
}
