using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatEkoSystem.Core.Utility
{
    public class SuccessDataResults<T> : DataResult<T>
    {
        public SuccessDataResults(T data, string message) : base(data, true, message)
        {

        }
        public SuccessDataResults(T data) : base(data, true)
        {

        }
        public SuccessDataResults(string message) : base(default, true, message)
        {

        }
        public SuccessDataResults() : base(default, true)
        {

        }
    }
}
