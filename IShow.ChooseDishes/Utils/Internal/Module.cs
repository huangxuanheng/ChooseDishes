using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Utils.Internal
{
    public class Module
    {
        /// <summary>
        /// 模块ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public Module Parent  { get; set;}

        public Module(string _Id, string _Name, Module _Parent)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.Parent = _Parent;
        }

        public Module(string _Id, string _Name)
            : this(_Id, _Name, null)
        {
        }
    }
}
