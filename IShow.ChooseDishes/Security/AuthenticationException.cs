using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Security
{
    public class AuthenticationException:Exception
    {
         public AuthenticationException()
            : base() { }

        public AuthenticationException(string message)
            : base(message) { }

        public AuthenticationException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public AuthenticationException(string message, Exception innerException)
            : base(message, innerException) { }

        public AuthenticationException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }
    }
}
