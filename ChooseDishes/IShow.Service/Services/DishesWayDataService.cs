using IShow.Service.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace IShow.Service
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
        /**根据做法类型编号查询做法*/
        public List<DischesWay> FindAllDishesWay(int wayId)
        {
            if (wayId < 0)
            {
                return null;
            }
            try
            {
                List<DischesWay> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.DischesWay.Where(dw => dw.DischesWayId == wayId).ToList();
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
    }
}
