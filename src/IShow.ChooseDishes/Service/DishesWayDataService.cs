using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace IShow.ChooseDishes
{
    public class DishesWayDataService : IDishesWayDataService
    {
        /// <summary>
        /// 新增做法
        /// </summary>
        /// <param name="odw">做法对象</param>
        /// <returns></returns>
        public bool Add(DischesWay odw)
        {
            if (odw == null)
            {
                return false;
            }
            //添加
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    entities.DischesWay.Add(odw);
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
        /**根据做法对象id作为参数修改做法
                     type.Name = odw.Name;   
                    type.Status = odw.Status;
                    type.UpdateBy = odw.UpdateBy;    //修改人编号
                    type.UpdateDatetime = odw.UpdateDatetime;   //修改时间
                    type.WayDetail = odw.WayDetail;
                    type.DischesWayId = odw.DischesWayId;
                    type.AddPrice = odw.AddPrice;
                    type.AddPriceByNum = odw.AddPriceByNum;
                    type.Deleted = odw.Deleted;
                    type.PingYing = odw.PingYing;
         */
        public bool Modify(DischesWay odw)
        {
            if (odw == null)
            {
                return false;
            }
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.DischesWay.SingleOrDefault(bt => bt.DischesWayId == odw.DischesWayId);
                    if (type != null)
                    {
                        type.Name = odw.Name;
                        type.Status = odw.Status;
                        type.UpdateBy = odw.UpdateBy;
                        type.UpdateDatetime = odw.UpdateDatetime;
                        type.WayDetail = odw.WayDetail;
                        type.AddPrice = odw.AddPrice;
                        type.AddPriceByNum = odw.AddPriceByNum;
                        type.Deleted = odw.Deleted;
                        type.PingYing = odw.PingYing;
                        entities.SaveChanges();
                        return true;
                    }

                }
                catch (Exception e)
                {
                    e.ToString();
                    return false;
                }
                return false;
            }
        }
        /**根据做法id更新做法删除的状态*/
        public bool UpdateDeletedById(int id,int deletedStatus)
        {
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.DischesWay.SingleOrDefault(bt => bt.DischesWayId==id);
                    if (type != null)
                    {
                        type.Deleted = deletedStatus;
                        entities.SaveChanges();
                        return true;
                    }

                }
                catch (Exception e)
                {
                    e.ToString();
                    return false;
                }
                return false;
            }
        }
        /**根据指定编码删除对应做法*/
        public bool Deleted(int id)
        {
            if (id < 0)
            {
                return false;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    DischesWay booktype = new DischesWay()
                    {
                        DischesWayId = id,
                    };
                    DbEntityEntry<DischesWay> entry = entities.Entry<DischesWay>(booktype);
                    entry.State = EntityState.Deleted;
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
        /**根据做法类型编号查询做法*/
        public List<DischesWay> FindAllDishesWayByTypeId(int wayId)
        {
            if (wayId < 0)
            {
                new ServiceException("做法类型id小于零");
            }
            using (ChooseDishesEntities entity = new ChooseDishesEntities())
            {
                var type = entity.DischesWay.Where(d => d.DischesWayNameId == wayId&&d.Deleted==0).ToList();
                return type;
            }
        }
        /**根据做法id查找做法*/
        public DischesWay FindDishesWayById(int id)
        {
            if (id < 0)
            {
                return null;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.DischesWay.SingleOrDefault(bt => bt.DischesWayId == id);
                    return type;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return null;
                }

            }
        }
        public DischesWay FindDishesWayByCode(string code)
        {
            if (code ==null)
            {
                new ServiceException("编码不能为空");
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.DischesWay.SingleOrDefault(bt => bt.Code == code);
                    return type;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return null;
                }

            }
        }
        /// <summary>
        /// 查询所有的做法，包括状态为删除的
        /// query all of DishesWay 
        /// </summary>
        /// <returns>reutrn list of DishesWay</returns>
        public List<DischesWay> FindAll()
        {
            using (ChooseDishesEntities entity = new ChooseDishesEntities())
            {
                var type = entity.DischesWay.OrderBy(d=>d.DischesWayId).ToList();
                return type;
            }
        }




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
        //根据做法类型id修改删除状态
        public bool UpdateDishesWayNameDeletedTypeById(int Id)
        {
            if (Id==null)
            {
                return false;
            }
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.DischesWayName.SingleOrDefault(bt => bt.DischesWayNameId == Id);
                    if (type != null)
                    {
                        type.UpdateBy = SubjectUtils.GetAuthenticationId();     //操作人员id
                        type.UpdateDatetime =DateTime.Now;
                        type.Deleted = 1;
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
        public bool DeleteDishesWayNameByCode(int id)
        {
            if (id == null)
            {
            return false;
            }
            //先判断是否存在有做法，如果有做法，则不能返回false
            DishesWayDataService odws = new DishesWayDataService();
            List<DischesWay> orgDischesWay = odws.FindAllDishesWayByTypeId(id);
            if (orgDischesWay != null && orgDischesWay.Count > 0)
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
                    entry.State = System.Data.Entity.EntityState.Deleted;

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
                    dws = entities.DischesWayName.Include(typeof(DischesWay).Name).Where(dw => dw.Deleted == 0).ToList();
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
                    var type = entities.DischesWayName.SingleOrDefault(bt => bt.DischesWayNameId == id&&bt.Deleted==0);
                    return type;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return null;
                }
            }
        }
        /**根据做法类型编码查找做法类型*/
        public DischesWayName FindDishesWayNameByCode(string code)
        {
            if (code==null)
            {
                return null;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.DischesWayName.SingleOrDefault(bt => bt.Code == code&&bt.Deleted==0);
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
