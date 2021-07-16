using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatEkoSystem.Core.Utility
{
    public class ErrorResults : Results
    {
        public ErrorResults(string message) : base(false, message)
        {

        }
        public ErrorResults() : base(false)
        {

        }
    }
}
