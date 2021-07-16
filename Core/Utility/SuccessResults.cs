using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatEkoSystem.Core.Utility
{
    public class SuccessResults : Results
    {
        public SuccessResults(string message) : base(true, message)
        {

        }
        public SuccessResults() : base(true)
        {

        }
    }
}
