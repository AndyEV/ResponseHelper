

namespace ResponseWrapperUtil.Core
{
    public interface IResponse
    {
        string message { get; set; }

        bool succeeded { get; set; }
    }

    public interface IResponse<out T> : IResponse
    {
        T data { get; }
    }
}
