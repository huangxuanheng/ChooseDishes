using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Data;

namespace IShow.ChooseDishes.Model
{
    public class FunctionModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Selected { get; set; }
        public FunctionModel(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public FunctionModel(Function function, int Selected)
        {
            this.Id = function.Id;
            this.Name = function.Name;
            this.Selected = Selected;
        }
    }
}
