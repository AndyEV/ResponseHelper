using System;
using System.Collections.Generic;
using System.Text;

namespace Response.Core
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
