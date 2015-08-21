using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Utils.Internal
{
     public class Function
    {
         public string Id { get; set; }
         public string Name { get; set; }
         public Module Module { get; set; }

         public Function(string _Id, string _Name, Module _Module) {
             this.Id = _Id;
             this.Name = _Name;
             this.Module = _Module;
         }
    }
}
