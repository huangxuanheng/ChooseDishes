using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Data;

namespace IShow.ChooseDishes.Model
{
    public class RoleModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Had{get;set;}


        public RoleModel(int _Id, string _Name, string _Description, bool _Had)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.Description = _Description;
            this.Had = _Had;
        }

        public RoleModel(Role r)
        {
            this.Id = r.RoleId;
            this.Name = r.Name;
            this.Description = r.Description;
            this.Had = false;
        }
    }
}
