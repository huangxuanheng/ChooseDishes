using IShow.Service.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace IShow.Service
{
    public class DischesWayNameDataService : IDishesWayNameDataService
    {
        //添加做法类型，传入的做法类型参数需要包含：DischesWayNameId, Code,Name, CreateBy,CreateDatetime,Status,Deleted字段
        public bool AddDishesWayName(DischesWayName dw)
        {
            if (dw == null)
            {
                return false;
            }
            //添加
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    entities.DischesWayName.Add(dw);
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return false;
                }
            }  
        }
        //修改菜品做法类型，传入的参数需要包含：DischesWayNameId/Code,Name,Status,Deleted，UpdateBy，UpdateDatetime字段
        public bool UpdateDishesWayName(DischesWayName dwn)
        {
            if (dwn == null)
            {
                return false;
            }
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.DischesWayName.SingleOrDefault(bt => bt.DischesWayNameId == dwn.DischesWayNameId);
                    if (type != null)
                    {
                        type.Name = dwn.Name;
                        type.Status = dwn.Status;
                        type.UpdateBy = dwn.UpdateBy;
                        type.UpdateDatetime = dwn.UpdateDatetime;
                        type.Deleted = dwn.Deleted;
                        entities.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                    return false;
                }
            }
            return false;
        }
        //根据做法类型编码删除菜品做法类型,如果删除失败返回false，如果删除成功，则返回true
        public bool DeleteDishesWayName(int id)
        {
            if (id < 0)
            {
                return false;
            }
            //先判断是否存在有做法，如果有做法，则不能返回false
            DishesWayDataService odws = new DishesWayDataService();
            List<DischesWay> orgDischesWay = odws.FindAllDishesWay(id);
            if (orgDischesWay != null&&orgDischesWay.Count>0)
            {
                return false;
            }
            //删除
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    DischesWayName booktype = new DischesWayName()
                    {
                        DischesWayNameId = id,
                    };
                    DbEntityEntry<DischesWayName> entry = entities.Entry<DischesWayName>(booktype);
                    entry.State = System.Data.EntityState.Deleted;

                    entities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return false;
                }
               
            }
           
        }
        //查询菜品做法类型
        public List<DischesWayName> FindAllDishesWayName()
        {
            try
            {
                List<DischesWayName> dws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    dws = entities.DischesWayName.Where(dw => dw.DischesWayNameId > 0).ToList();
                }
                if (dws != null && dws.Count > 0)
                {
                    return dws;
                }
            }
            catch (Exception e)
            {
                e.ToString();
                return null;
            }
            return null; 
        }
        //根据做法类型id查询菜品做法类型
        public DischesWayName FindDishesWayNameById(int id)
        {
            if (id < 0)
            {
                return null;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.DischesWayName.SingleOrDefault(bt => bt.DischesWayNameId == id);
                    return type;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return null;
                }
            }
        }
    }
}
