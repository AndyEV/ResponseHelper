using System.Threading.Tasks;

namespace ResponseWrapperUtil.Core
{
    public class Response : IResponse
    {
        public Response()
        {
        }

        public string message_id { get; set; }

        public string message { get; set; }

        public bool succeeded { get; set; }

        public int statuscode { get; set; }

        public static IResponse Fail()
        {
            return new Response { succeeded = false, statuscode = 400 };
        }

        public static IResponse Fail(string message, int statuscode = 400, string message_id = "")
        {
            return new Response { succeeded = false, message = message, statuscode = statuscode, message_id = message_id };
        }

        public static Task<IResponse> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public static Task<IResponse> FailAsync(string message, int statuscode = 400, string message_id = "")
        {
            return Task.FromResult(Fail(message, statuscode, message_id));
        }

        public static IResponse Success()
        {
            return new Response { succeeded = true, statuscode = 200 };
        }

        public static IResponse Success(string message, int statuscode = 200, string message_id = "")
        {
            return new Response { succeeded = true, message = message, statuscode = statuscode, message_id = message_id };
        }

        public static Task<IResponse> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<IResponse> SuccessAsync(string message, int statuscode = 200, string message_id = "")
        {
            return Task.FromResult(Success(message, statuscode, message_id));
        }
    }

    public class Response<T> : Response, IResponse<T>
    {
        public Response()
        {
        }

        public T data { get; set; }

        public new static Response<T> Fail()
        {
            return new Response<T> { succeeded = false, statuscode = 400 };
        }

        public new static Response<T> Fail(string message, int statuscode = 400, string message_id = "")
        {
            return new Response<T> { succeeded = false, message = message, statuscode = statuscode, message_id = message_id };
        }

        public new static Task<Response<T>> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public new static Task<Response<T>> FailAsync(string message, int statuscode = 400, string message_id = "")
        {
            return Task.FromResult(Fail(message, statuscode, message_id));
        }

        public new static Response<T> Success()
        {
            return new Response<T> { succeeded = true, statuscode = 200 };
        }

        public new static Response<T> Success(string message, int statuscode = 200, string message_id = "")
        {
            return new Response<T> { succeeded = true, message = message, statuscode = statuscode, message_id = message_id };
        }

        public static Response<T> Success(T data, int statuscode = 200, string message_id = "")
        {
            return new Response<T> { succeeded = true, data = data, statuscode = statuscode, message_id = message_id };
        }

        public static Response<T> Success(T data, string message, int statuscode = 200, string message_id = "")
        {
            return new Response<T> { succeeded = true, data = data, message = message, statuscode = statuscode, message_id = message_id };
        }

        public new static Task<Response<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public new static Task<Response<T>> SuccessAsync(string message, int statuscode = 200, string message_id = "")
        {
            return Task.FromResult(Success(message, statuscode, message_id));
        }

        public static Task<Response<T>> SuccessAsync(T data, int statuscode = 200, string message_id = "")
        {
            return Task.FromResult(Success(data, statuscode, message_id));
        }

        public static Task<Response<T>> SuccessAsync(T data, string message, int statuscode = 200, string message_id = "")
        {
            return Task.FromResult(Success(data, message, statuscode, message_id));
        }
    }

}
