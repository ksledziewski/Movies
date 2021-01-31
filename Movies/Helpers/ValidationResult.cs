namespace Movies.Helpers
{
    /// <summary>
    /// Validation result class
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Validation was success
        /// </summary>
        public bool IsValid { get; }
        /// <summary>
        /// Message in case of failure
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="isValid">Validation success</param>
        public ValidationResult(bool isValid)
        {
            IsValid = isValid;
            Message = "";
        }
        
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="isValid">Validation success</param>
        /// <param name="message">Failure message</param>
        public ValidationResult(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }
    }
}