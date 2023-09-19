using System.Threading.Tasks;

namespace ResponseWrapperUtil.Core
{
    public class Response : IResponse
    {
        public Response()
        {
        }

        public string message_id { get; set; } = "RP-00";

        public string message { get; set; }

        public bool succeeded { get; set; }

        public int? statuscode { get; set; }

        public static IResponse Fail()
        {
            return new Response { succeeded = false, statuscode = 400 };
        }

        public static IResponse Fail(string message)
        {
            return new Response { succeeded = false, message = message, statuscode = 400 };
        }

        public static Task<IResponse> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public static Task<IResponse> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }

        public static IResponse Success()
        {
            return new Response { succeeded = true, statuscode = 200 };
        }

        public static IResponse Success(string message)
        {
            return new Response { succeeded = true, message = message, statuscode = 200 };
        }

        public static Task<IResponse> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<IResponse> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
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

        public new static Response<T> Fail(string message)
        {
            return new Response<T> { succeeded = false, message = message, statuscode = 400 };
        }

        public new static Task<Response<T>> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public new static Task<Response<T>> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }

        public new static Response<T> Success()
        {
            return new Response<T> { succeeded = true, statuscode = 200 };
        }

        public new static Response<T> Success(string message)
        {
            return new Response<T> { succeeded = true, message = message, statuscode = 200 };
        }

        public static Response<T> Success(T data)
        {
            return new Response<T> { succeeded = true, data = data, statuscode = 200 };
        }

        public static Response<T> Success(T data, string message)
        {
            return new Response<T> { succeeded = true, data = data, message = message, statuscode = 200 };
        }

        public new static Task<Response<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public new static Task<Response<T>> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        public static Task<Response<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        public static Task<Response<T>> SuccessAsync(T data, string message)
        {
            return Task.FromResult(Success(data, message));
        }
    }

}
