using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;
using System.Data.Common;
using System.Data.SqlClient;

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
                  throw new NotFoundException();
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
              for (int i = 0; i < dishesIds.Length; i++)
              {
                  int Id = dishesIds[i];
                  var date = DateTime.Now;

                  string sql = " insert into DishesMenuRef (MenusId,DishId,CreateTime,Deleted ) values(" + menuId + "," + Id + ",'" + date + "',0)";
                  entities.Database.ExecuteSqlCommand(sql);
                  //DishesMenuRef dmref = new DishesMenuRef()
                  //{
                  //    MenusId = menuId,
                  //    DishId = dishesIds[i],
                  //    CreateTime = DateTime.Now,
                  //    Deleted = 0

                  //};
                  //entities.DishesMenuRef.Add(dmref);
                  //entities.SaveChanges();
              }
          }
      }

      public void BatchRemoveDishes(int menuId, int[] dishesIds) { 
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              for (int i = 0; i < dishesIds.Length; i++)
              {
                  var id = dishesIds[i];
                  var type = entities.DishesMenuRef.SingleOrDefault(bt => bt.Deleted == 0 && bt.DishId == id && bt.MenusId == menuId);
                  if (type != null) {
                      string sql = " update DishesMenuRef set Deleted = 1 where DishId = " + id + "  and  MenusId =  " +menuId;
                      entities.Database.ExecuteSqlCommand(sql);
                  }
              }
          }
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
