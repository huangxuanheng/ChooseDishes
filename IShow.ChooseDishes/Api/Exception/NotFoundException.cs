using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Api
{
    class NotFoundException : Exception
    {
         public NotFoundException()
            : base() { }

        public NotFoundException(string message)
            : base(message) { }

        public NotFoundException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException) { }

        public NotFoundException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }
    }
}
