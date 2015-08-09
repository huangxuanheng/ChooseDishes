using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Service
{
    public class RawUnitDataService : IRawUnitDataService
    {
        public RawUnit AddRawUnit(RawUnit rw)
        {
            if (rw == null)
            {
                return null;
            }
            //添加
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {

                try
                {
                    RawUnit ru=entities.RawUnit.Add(rw);
                    entities.SaveChanges();
                    return ru;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return null;
                }
            }
        }

        public bool UpdateRawUnit(RawUnit rw)
        {
            if (rw == null)
            {
                return false;
            }
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.RawUnit.SingleOrDefault(bt => bt.UnitId == rw.UnitId);
                    if (type != null)
                    {
                        type.Deleted = rw.Deleted;
                        type.Name = rw.Name;
                        type.Status = rw.Status;
                        type.UpdateBy = rw.UpdateBy;
                        type.UpdateDatetime = rw.UpdateDatetime;
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

        public bool UpdateRawUnitDeletedStatusById(int Id, int DeletedStatus)
        {
            if (Id < 0)
            {
                return false;
            }
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.RawUnit.SingleOrDefault(bt => bt.UnitId == Id);
                    if (type != null)
                    {
                        type.Deleted = DeletedStatus;
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

        public bool DeleteRawUnit(int id)
        {
            if (id < 0)
            {
                return false;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    RawUnit booktype = new RawUnit()
                    {
                       UnitId= id,
                    };
                    DbEntityEntry<RawUnit> entry = entities.Entry<RawUnit>(booktype);
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

        public List<RawUnit> FindAllRawUnit()
        {
            try
            {
                List<RawUnit> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.RawUnit.Where(dw => dw.UnitId> 0).ToList();
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

        public RawUnit FindRawUnitById(int Id)
        {
            if (Id < 0)
            {
                return null;
            }

            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.RawUnit.SingleOrDefault(bt => bt.UnitId == Id);
                    return type;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return null;
                }

            }
        }
        public bool  FindRawUnitByName(List<string>names)
        {
            if (names == null)
            {
                return false;
            }

            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    foreach (var name in names)
                    {
                        //遍历所有的名称，如果在数据表中找到记录，则type不为空，返回true,如果为空，则表示没有
                        var type = entities.RawUnit.SingleOrDefault(bt => bt.Name.Equals(name));
                        if (type != null)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return false ;
                }
            }
        }
        /// <summary>
        /// 查找所有未被进行物理删除的单位
        /// </summary>
        public List<RawUnit> FindRawUnitByDeletedStatus()
        {
            try
            {
                List<RawUnit> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.RawUnit.Where(dw => dw.Deleted== 0).ToList();
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
        public List<RawUnit> FindRawUnitByName(string name)
        {
            try
            {
                List<RawUnit> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.RawUnit.Where(dw => dw.Name .Equals(name)&&dw.Deleted==0).ToList();
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
    }
}
