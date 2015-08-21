using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Data;

namespace IShow.ChooseDishes.Model
{

   public   class DishesMenuItemModel
    {

        /// <summary>
        /// 
        /// 将菜牌与菜品的关系转换为菜品实体
        /// </summary>
        /// <param name="refList"></param>
        /// <returns></returns>
        public static List<DishesMenuItemModel> To(List<DishesMenuRef> refList){
            List<DishesMenuItemModel> itemList = new List<DishesMenuItemModel>();
            foreach (var t in refList) {
                itemList.Add(build(t));
            }
            return itemList;
        }

        /// <summary>
        /// 
        /// 将菜牌与菜品的关系转换为菜品实体
        /// </summary>
        /// <param name="refList"></param>
        /// <returns></returns>
        public static DishesMenuItemModel build(DishesMenuRef menuRef) {

            return null;
        }
        
    }




}
