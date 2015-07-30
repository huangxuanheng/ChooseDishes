using IShow.Service.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace IShow.Service.Services
{
    public class TakeoutOrderDataService : ITakeoutOrderDataService
    {
        public bool AddTakeoutClientInfo(TakeoutClientInfo info)
        {
            if (info == null)
            {
                return false;
            }
            //添加
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {

                try
                {
                    entities.TakeoutClientInfo.Add(info);
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
        //根据外卖客户id修改外卖客户信息
        public bool UpdateTakeoutClientInfo(TakeoutClientInfo info)
        {
            if (info == null)
            {
                return false;
            }
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.TakeoutClientInfo.SingleOrDefault(bt => bt.OrderPeopleId == info.OrderPeopleId);
                    if (type != null)
                    {
                        type.Order_people = info.Order_people;
                        type.Mobile = info.Mobile;
                        type.Status = info.Status;
                        type.Telephone = info.Telephone;
                        type.Update_by = info.Update_by;
                        type.Update_datetime = info.Update_datetime;
                        type.Address = info.Address;
                        type.Deleted = info.Deleted;
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
        //根据外卖客户id删除外卖客户信息,删除成功则返回true，删除失败则返回false
        public bool DeletedTakeoutClientInfo(int id)
        {
            if (id < 0)
            {
                return false;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    TakeoutClientInfo booktype = new TakeoutClientInfo()
                    {
                        OrderPeopleId = id,
                    };
                    DbEntityEntry<TakeoutClientInfo> entry = entities.Entry<TakeoutClientInfo>(booktype);
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
        //根据外卖客户id查找外卖客户信息
        public TakeoutClientInfo FindTakeoutClientInfoById(int id)
        {
            if (id < 0)
            {
                return null;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.TakeoutClientInfo.SingleOrDefault(bt => bt.OrderPeopleId == id);
                    return type;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return null;
                }

            }
        }
        //查找全部的外卖客户信息,如果找不到客户则返回null。否则返回一个集合对象
        public List<TakeoutClientInfo> FindAllTakeoutClientInfo()
        {
            try
            {
                List<TakeoutClientInfo> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.TakeoutClientInfo.Where(dw => dw.OrderPeopleId > 0).ToList();
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



        //添加外卖单
        public bool AddTakeoutOrder(TakeoutOrder To)
        {
            if (To == null)
            {
                return false;
            }
            //添加
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {

                try
                {
                    entities.TakeoutOrder.Add(To);
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
        //修改外卖单
        public bool UpdateTakeoutOrder(TakeoutOrder To)
        {
            if (To == null)
            {
                return false;
            }
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.TakeoutOrder.SingleOrDefault(bt => bt.OrderId == To.OrderId);
                    if (type != null)
                    {
                        type.OrderPeopleId = To.OrderPeopleId;
                        type.DeliveryManNum = To.DeliveryManNum;
                        type.Num = To.Num;
                        type.AdvanceAmount = To.AdvanceAmount;
                        type.DeliverTime = To.DeliverTime;
                        type.SendTime = To.SendTime;
                        type.Status = To.Status;
                        type.Deleted = To.Deleted;
                        type.UpdateBy = To.UpdateBy;
                        type.UpdateDatetime = To.UpdateDatetime;
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
        //删除外卖单

        public bool DeletedTakeoutOrder(int id)
        {
            if (id < 0)
            {
                return false;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    TakeoutOrder booktype = new TakeoutOrder()
                    {
                        TakeoutId = id,
                    };
                    DbEntityEntry<TakeoutOrder> entry = entities.Entry<TakeoutOrder>(booktype);
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
        //查询所有外卖单
        public List<TakeoutOrder> FindAllTakeoutOrder()
        {
            try
            {
                List<TakeoutOrder> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.TakeoutOrder.Where(dw => dw.OrderId > 0).ToList();
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
        //根据指定外卖单号查询外卖单
        public TakeoutOrder FindTakeoutOrderByOrderId(int id)
        {
            if (id < 0)
            {
                return null;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.TakeoutOrder.SingleOrDefault(bt => bt.OrderId == id);
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
