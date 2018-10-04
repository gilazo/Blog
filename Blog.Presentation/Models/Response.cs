namespace Blog.Presentation.Models
{
    public class Response<T>
    {        
        private Response(T data, string message, params string[] errors)
        {
            Data = data;
            Message = message;
            Errors = errors;
        }

        public T Data { get; }
        public string Message { get; }
        public string[] Errors { get; }

        public static Response<T> Success(T data) => new Response<T>(data, "success");
        public static Response<T> Error(params string[] errors) => new Response<T>(default(T), string.Empty, errors);
    }
}