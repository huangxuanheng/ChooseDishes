﻿using IShow.Service.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace IShow.Service
{
    public class DischesWayNameDataService : IDischesWayNameDataService
    {
        //添加做法类型，传入的做法类型参数需要包含：DischesWayNameId, Code,Name, CreateBy,CreateDatetime,Status,Deleted字段
        public bool AddDischesWayName(DischesWayName dw)
        {
            //添加
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                entities.DischesWayName.Add(dw);
                entities.SaveChanges();
                var type = entities.DischesWayName.SingleOrDefault(bt => bt.DischesWayNameId == dw.DischesWayNameId);
                if (type != null)
                {
                    return true;
                }
            }

            return false;
        }
        //修改菜品做法类型，传入的参数需要包含：DischesWayNameId/Code,Name,Status,Deleted，UpdateBy，UpdateDatetime字段
        public bool UpdateDischesWayName(DischesWayName dwn)
        {
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {

                var type = entities.DischesWayName.SingleOrDefault(bt => bt.DischesWayNameId == dwn.DischesWayNameId);
                if (type != null)
                {
                    type.Name = dwn.Name;
                    type.Status = dwn.Status;
                    type.UpdateBy = dwn.UpdateBy;
                    type.UpdateDatetime = dwn.UpdateDatetime;
                    type.Deleted = dwn.Deleted;
                }
                entities.SaveChanges();

                var newtype = entities.DischesWayName.SingleOrDefault(bt => bt.DischesWayNameId == dwn.DischesWayNameId);
                if (newtype != null)
                {
                    return true;
                }
            }
            return false;
        }
        //根据做法类型编码删除菜品做法类型,如果删除失败返回false，如果删除成功，则返回true
        public bool DeleteDischesWayName(int id)
        {
            //先判断是否存在有做法，如果有做法，则不能返回false
            DischesWayDataService odws = new DischesWayDataService();
            List<DischesWay> orgDischesWay = odws.FindAllDischesWay(id);
            if (orgDischesWay != null)
            {
                return false;
            }
            //删除
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                DischesWayName booktype = new DischesWayName()
                {
                    DischesWayNameId = id,
                };
                DbEntityEntry<DischesWayName> entry = entities.Entry<DischesWayName>(booktype);
                entry.State = System.Data.EntityState.Deleted;

                entities.SaveChanges();

                var newtype = entities.DischesWayName.SingleOrDefault(bt => bt.DischesWayNameId == id);
                if (newtype != null)
                {
                    //Console.WriteLine(newtype.name);
                    return false;
                }
                else
                {
                    //Console.WriteLine("No Found");
                    return true;
                }
            }
           
        }
        //查询菜品做法类型
        public List<DischesWayName> FindAllDischesWayName()
        {
            List<DischesWayName> dws;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                dws = entities.DischesWayName.Where(dw => dw.DischesWayNameId > 0).ToList();
            }
            if (dws != null)
            {
                return dws;
            }
            return null;
        }
    }
}
