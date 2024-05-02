namespace FoodService.Data.Model
{
    /// <summary>
    /// Represents a common response with generic data.
    /// </summary>
    /// <typeparam name="T">Type of the data.</typeparam>
    public class ResponseCommon<T>
    {
        /// <summary>
        /// Gets the status code of the response.
        /// </summary>
        public int StatusCode { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the response is successful.
        /// </summary>
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// Gets the message associated with the response.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Gets the error message associated with the response, if any.
        /// </summary>
        public string? Error { get; private set; }

        /// <summary>
        /// Gets the data associated with the response.
        /// </summary>
        public T Data { get; private set; }

        private ResponseCommon(int statusCode, string message, T data, string? error = null, bool success = false)
        {
            StatusCode = statusCode;
            Message = message;
            Error = error;
            Data = data;
            IsSuccess = success;
        }

        /// <summary>
        /// Creates a successful response with the provided data.
        /// </summary>
        /// <param name="data">The data to include in the response.</param>
        /// <param name="message">Optional message for the response.</param>
        /// <returns>A successful response object.</returns>
        public static ResponseCommon<T> Success(T data, string message = "Success")
        {
            return new ResponseCommon<T>(200, message, data, success: true);
        }

        /// <summary>
        /// Creates a failed response with the provided error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="statusCode">Optional status code for the response. Default is 500 (Internal Server Error).</param>
        /// <param name="error">Optional detailed error information.</param>
        /// <returns>A failed response object.</returns>
        public static ResponseCommon<T> Failure(string message, int statusCode = 500, string? error = null)
        {
            return new ResponseCommon<T>(statusCode, message, default!, error);
        }
    }
}
