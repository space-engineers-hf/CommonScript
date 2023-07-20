using System;
using System.Collections.Generic;
using System.Text;

namespace IngameScript
{
    public sealed class StackOverflowException : Exception
    {

        public StackOverflowException(string message) : base(message)
        {

        }

    }
}
