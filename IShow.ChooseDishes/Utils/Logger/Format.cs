using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Utils.Internal;

namespace IShow.ChooseDishes.Utils.Logger
{
    public class Format
    {
        public Function Function{get;set;}
        public string Template { get; set; }
        public DateTime Now { get { return DateTime.Now; } }

        public Format(Function _Function, string _Template) {
            this.Function = _Function;
            this.Template = _Template;
        }
    }
}
