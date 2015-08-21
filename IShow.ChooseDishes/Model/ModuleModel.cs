using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;

namespace IShow.ChooseDishes.Model
{
    public class ModuleModel:ViewModelBase
    {
        public string Id { get; set; }

        public List<FunctionModel> _Functions;
        public List<FunctionModel> Functions { 
            get{ 
                return _Functions?? (_Functions= new List<FunctionModel>());
            }set{
                Set("Functions", ref _Functions, value);
            } }

        public string Name { get; set; }

        public ModuleModel(string id, string name, List<FunctionModel> functions) {
            this.Id = id;
            this.Name = name;
            this.Functions = functions;
        }

       
        public ModuleModel(Module m) {
            this.Id = m.Id;
            this.Name = m.Name;
            
        }
    }
}
