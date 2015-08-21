using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Data;

namespace IShow.ChooseDishes.Model
{
    class DishesMenuModel
    {
        public int Id { get; set; }
        public int Name { get; set; }


        public static DishesMenu build(string code,string name,int createBy) {
            return new DishesMenu()
            {
                Code=code,
                Name = name,
                CreateBy=createBy,
                CreateDatetime=DateTime.Now
            };
        }

        public static DishesMenu build(int id) {
            return new DishesMenu()
            {
                MenusId = id
            };
        }

    }
}
