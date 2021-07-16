using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatEkoSystem.Core.Utility
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }

    }
}
