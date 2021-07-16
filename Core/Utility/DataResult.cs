using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatEkoSystem.Core.Utility
{
    public class DataResult<T> : Results, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
