using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model.Booking
{
    public  class DishModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }

        public DishModel(string id, string name, double unitPrice) {
            this.Id = id;
            this.Name = name;
            this.UnitPrice = unitPrice;
        }
    }
}
