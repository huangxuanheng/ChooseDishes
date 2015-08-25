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
using IShow.ChooseDishes.Security;

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
              return entities.DishesMenu.Where(bt=>bt.Deleted == 0 ).ToList();
          }

      }

      public int Add(string code, string name)
      {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              var list = entities.DishesMenu.Where(t => t.Deleted == 0 && (t.Code == code || t.Name == name)).ToList();
              if (list != null && list.Count > 0)
              {
                  return 0;
              }
              DishesMenu menu = DishesMenuModel.build(code, name, SubjectUtils.GetAuthenticationId());
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
                 // throw new NotFoundException();
              }
              delObj.Deleted = 1;
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
      public bool update(int menusId, string code, string name) {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              var list = entities.DishesMenu.Where(t => t.Deleted == 0 && (t.Code == code || t.Name == name)).ToList();
              if (list != null && list.Count > 1) {
                  return false;
              }
              var type = entities.DishesMenu.SingleOrDefault(t => t.Deleted == 0 && t.MenusId == menusId);
              type.Code = code;
              type.Name = name;
              type.UpdateBy = SubjectUtils.GetAuthenticationId();
              type.UpdateDatetime = DateTime.Now;
              entities.SaveChanges();
              return true;

          } 
      }
      public DishesMenu FindDishesMenuByMenuId(int menuId) {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              var type = entities.DishesMenu.SingleOrDefault(t => t.Deleted == 0 && t.MenusId == menuId);
              return type;
          } 
      }
    }
}
