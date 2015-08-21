using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Utils.Logger
{
    public  class LoggerUtils
    {
       
        public  static string Format(Format format, object[] args) {
            return String.Format(format.Template, args);
        }

    }
}
