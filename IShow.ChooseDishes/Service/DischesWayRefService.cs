using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Service
{
    public class DischesWayRefService : IDischesWayRefService
    {
        private DischesWayRef GetDischesWayRef(int dishesId, int DishesWayId)
        {
            DischesWayRef dr = new DischesWayRef()
            {
                DishId = dishesId,
                DischesWayId = DishesWayId,
                CreateBy = SubjectUtils.GetAuthenticationId(),
                CreateDatetime=DateTime.Now
            };
            return dr;
        }
	    public bool Add(int dishesId, int DishesWayId) {
            try
            {
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    entities.DischesWayRef.Add(GetDischesWayRef(dishesId, DishesWayId));
                    entities.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw new ServiceException("新增菜品做法关联失败");
            }
	    }

	
	    public List<DischesWayRef> QueryAll() {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                return entities.DischesWayRef.Include(typeof(Dish).Name).Include(typeof(DischesWay).Name).Where(d=>d.Deleted==0).ToList();
            }
	    }

	
	    public bool ModifyByPrice(int dishesId, int DishesWayId, double price) {
            try
            {
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    var type = entities.DischesWayRef.SingleOrDefault(d =>d.Deleted==0&& d.DishId == dishesId && d.DischesWayId == DishesWayId);
                    type.Price = price;
                    type.UpdateBy = SubjectUtils.GetAuthenticationId();
                    type.UpdateDatetime = DateTime.Now;
                    entities.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw new ServiceException("新增菜品做法关联失败");
            }
	    }

	
	    public bool ModifyDeleted(int dishesId, int DishesWayId) {
            try
            {
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    var type = entities.DischesWayRef.SingleOrDefault(d =>d.Deleted==0&& d.DishId == dishesId && d.DischesWayId == DishesWayId);
                    type.Deleted = 1;
                    type.UpdateBy = SubjectUtils.GetAuthenticationId();
                    type.UpdateDatetime = DateTime.Now;
                    entities.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw new ServiceException("删除菜品做法关联状态失败");
            }
	    }
        public List<DischesWayRef> QueryAllByDishesId(int dishesId)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                return entities.DischesWayRef.Include(typeof(DischesWay).Name).Where(d => d.Deleted == 0 && d.DishId == dishesId).ToList();
            }
        }
    }
}
