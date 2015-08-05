using IShow.ChooseDishes.Data;
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
        /**添加做法,传入的对象需要封装如下信息
                DischesWayId=1,    
               DischesWayNameId=2,    //做法类型id
               CreateDatetime=DateTime.Now,    //创建时间
               CreateBy=1,      //创建人编号
               Code=1,         //做法编码
               AddPrice=2,     //是否加价，默认为0
               Deleted=0,      //是否删除
               Name="三分熟加辣",    //做法名称
               Status=0,    //状态
               AddPriceByNum=0,     //是否按照分数加价
               PingYing="sfsjl",     //做法拼音
               WayDetail="要三分熟就可以了"    //做法说明（非必填）
         */
        public bool AddDishesWay(DischesWay odw)
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
        public bool UpdateDishesWay(DischesWay odw)
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
        public bool UpdateDishesWayDeletedTypeByCode(int Code)
        {
            if (Code <0)
            {
                return false;
            }
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.DischesWay.SingleOrDefault(bt => bt.Code == Code);
                    if (type != null)
                    {
                        type.UpdateBy = 1;   //需要从数据库中读取操作人id
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
                return false;
            }
        }
        /**根据指定编码删除对应做法*/
        public bool DeleteDishesWay(int id)
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
        public List<DischesWay> FindAllDishesWayByTypeCode(string Code)
        {
            int wayId = -1;
            using (ChooseDishesEntities entity = new ChooseDishesEntities())
            {
                try
                {
                    var type = entity.DischesWayName.SingleOrDefault(bt => bt.Code == Code);
                    wayId = type.DischesWayNameId;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return null;
                }
            }

            if (wayId < 0)
            {
                return null;
            }
            try
            {
                List<DischesWay> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.DischesWay.Where(dw => dw.DischesWayNameId == wayId).ToList();
                }
                if (odws != null && odws.Count > 0)
                {
                    return odws;
                }
            }
            catch (Exception e)
            {
                e.ToString();
                return null;
            }
            return null;
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
        public DischesWay FindDishesWayByCode(int code)
        {
            if (code < 0)
            {
                return null;
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
        public bool UpdateDishesWayNameDeletedTypeByCode(string Code)
        {
            if (Code==null)
            {
                return false;
            }
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.DischesWayName.SingleOrDefault(bt => bt.Code == Code);
                    if (type != null)
                    {
                        type.UpdateBy = 1;     //操作人员id
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
        public bool DeleteDishesWayNameByCode(string Code)
        {
            if (Code ==null)
            {
                return false;
            }
            //先判断是否存在有做法，如果有做法，则不能返回false
            DishesWayDataService odws = new DishesWayDataService();
            List<DischesWay> orgDischesWay = odws.FindAllDishesWayByTypeCode(Code);
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
                        Code = Code,
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
                    var type = entities.DischesWayName.SingleOrDefault(bt => bt.Code == code);
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
