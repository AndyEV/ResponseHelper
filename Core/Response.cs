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

        public int statuscode { get; set; }

        public static IResponse Fail()
        {
            return new Response { succeeded = false, statuscode = 400 };
        }

        public static IResponse Fail(string message, int statuscode = 400)
        {
            return new Response { succeeded = false, message = message, statuscode = statuscode };
        }

        public static Task<IResponse> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public static Task<IResponse> FailAsync(string message, int statuscode = 400)
        {
            return Task.FromResult(Fail(message, statuscode));
        }

        public static IResponse Success()
        {
            return new Response { succeeded = true, statuscode = 200 };
        }

        public static IResponse Success(string message, int statuscode = 200)
        {
            return new Response { succeeded = true, message = message, statuscode = statuscode };
        }

        public static Task<IResponse> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<IResponse> SuccessAsync(string message, int statuscode = 200)
        {
            return Task.FromResult(Success(message, statuscode));
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

        public new static Response<T> Fail(string message, int statuscode = 400)
        {
            return new Response<T> { succeeded = false, message = message, statuscode = statuscode };
        }

        public new static Task<Response<T>> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public new static Task<Response<T>> FailAsync(string message, int statuscode = 400)
        {
            return Task.FromResult(Fail(message, statuscode));
        }

        public new static Response<T> Success()
        {
            return new Response<T> { succeeded = true, statuscode = 200 };
        }

        public new static Response<T> Success(string message, int statuscode = 200)
        {
            return new Response<T> { succeeded = true, message = message, statuscode = statuscode };
        }

        public static Response<T> Success(T data, int statuscode = 200)
        {
            return new Response<T> { succeeded = true, data = data, statuscode = statuscode };
        }

        public static Response<T> Success(T data, string message, int statuscode = 200)
        {
            return new Response<T> { succeeded = true, data = data, message = message, statuscode = statuscode };
        }

        public new static Task<Response<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public new static Task<Response<T>> SuccessAsync(string message, int statuscode = 200)
        {
            return Task.FromResult(Success(message, statuscode));
        }

        public static Task<Response<T>> SuccessAsync(T data, int statuscode = 200)
        {
            return Task.FromResult(Success(data, statuscode));
        }

        public static Task<Response<T>> SuccessAsync(T data, string message, int statuscode = 200)
        {
            return Task.FromResult(Success(data, message, statuscode));
        }
    }

}
