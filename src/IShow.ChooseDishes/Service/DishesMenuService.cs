using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;

namespace IShow.ChooseDishes.Service
{
    public class DishesMenuService:IDishesMenuService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
      public   List<DishesMenu> QueryAll() {

          using (ChooseDishesEntities entities = new ChooseDishesEntities()) {
              return entities.DishesMenu.ToList();
          }

      }

      public int Add(string code, string name)
      {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              DishesMenu menu = DishesMenuModel.build(code, name, 1000);
             entities.DishesMenu.Add(menu);
             entities.SaveChanges();
             return menu.MenusId;
          }
        
        }

      public void Delete(int dishesMenuId)
      {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              var delObj=entities.DishesMenu.Find(dishesMenuId);
              if (null == delObj) {
                  throw new ServiceException();
              }
              entities.DishesMenu.Remove(delObj);
              entities.SaveChanges();
          }
      }

      /// <summary>
      /// 批量关联菜谱的菜品
      /// </summary>
      /// <param name="menuId"></param>
      /// <param name="dishesIds"></param>
      public void BatchAddDishes(int menuId, int[] dishesIds) {

          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              List<DishesMenuRef> list = new List<DishesMenuRef>();
              for (int i = 0; i < dishesIds.Length; i++)
              {
                  list.Add(new DishesMenuRef()
                  {
                      MenusId=menuId,
                      DishId=dishesIds[i],
                      CreateTime=DateTime.Now
                  });

                  entities.DishesMenuRef.AddRange(list);
                  entities.SaveChanges();
              }
          }
      }

      public void BatchRemoveDishes(int menuId, int[] dishesIds) { 
      
      }

      public List<DishesMenuItemModel> FindItemsById(int menuId) {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
             var list= entities.DishesMenuRef.Where(t =>t.DishId == menuId).ToList();
             return DishesMenuItemModel.To(list);
          } 
      }
    }
}
