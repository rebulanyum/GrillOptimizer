using System;
using System.Collections.Generic;
using System.Text;

namespace rebulanyum.GrillOptimizer.Business.Objects
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        { }

        public BusinessException(string format, params object[] args) : base(string.Format(format, args))
        { }
    }
}
