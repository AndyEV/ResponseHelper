

namespace ResponseWrapperUtil.Core
{
    public interface IResponse
    {
        string message_id { get; set; }

        string message { get; set; }

        bool succeeded { get; set; }

        int statuscode { get; set; }
    }

    public interface IResponse<out T> : IResponse
    {
        T data { get; }
    }
}
