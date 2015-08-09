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
    public class MaterialDataService : IMaterialDataService
    {
        public bool AddRawMaterial(RawMaterial rw)
        {
            if (rw == null)
            {
                return false;
            }
            //添加
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {

                try
                {
                    entities.RawMaterial.Add(rw);
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

        public bool UpdateRawMaterial(RawMaterial rw)
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
                    var type = entities.RawMaterial.SingleOrDefault(bt => bt.Id == rw.Id);
                    if (type != null)
                    {
                        type.CheckDay = rw.CheckDay;
                        type.Deleted = rw.Deleted;
                        type.Detail = rw.Detail;
                        type.Format = rw.Format;
                        type.FormulaUnit = rw.FormulaUnit;
                        type.InGoodsPrice = rw.InGoodsPrice;
                        type.InGoodsStock = rw.InGoodsStock;
                        type.InGoodsUnit = rw.InGoodsUnit;
                        type.IsWeight = rw.IsWeight;
                        type.MaterialName = rw.MaterialName;
                        type.OrderRawAdd = rw.OrderRawAdd;
                        type.Pinying = rw.Pinying;
                        type.Raw = rw.Raw;
                        type.RawAddPrice = rw.RawAddPrice;
                        type.SaleUnit = rw.SaleUnit;
                        type.Status = rw.Status;
                        type.StockFormula = rw.StockFormula;
                        type.StockMax = rw.StockMax;
                        type.StockMin = rw.StockMin;
                        type.StockUnit = rw.StockUnit;
                        type.UpdateBy = rw.UpdateBy;
                        type.UpdateDatetime = rw.UpdateDatetime;
                        type.WriteDowns = rw.WriteDowns;
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
        /**根据原料id和指定的删除状态修改原料的删除状态*/
        public bool UpdateRawMaterialDeletedStatusById(int Id,int DeletedStatus)
        {
            if (Id <0)
            {
                return false;
            }
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.RawMaterial.SingleOrDefault(bt => bt.Id == Id);
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

        public bool DeleteRawMaterial(int id)
        {
            if (id < 0)
            {
                return false;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    RawMaterial booktype = new RawMaterial()
                    {
                        Id = id,
                    };
                    DbEntityEntry<RawMaterial> entry = entities.Entry<RawMaterial>(booktype);
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
        /// <summary>
        /// 根据小类查找所有的 原料资料
        /// </summary>
        /// <param name="RawId"> 原料小类id</param>
        /// <returns></returns>
        public List<RawMaterial> FindAllRawMaterialByRawId(int RawId)
        {
            try
            {
                List<RawMaterial> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.RawMaterial.Where(dw => dw.RawId == RawId).ToList();
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
        /// <summary>
        /// 根据小类id 查找所有的未被物理删除的 原料资料
        /// </summary>
        /// <param name="RawId"> 原料小类id</param>
        /// <returns></returns>
        public List<RawMaterial> FindAllRawMaterialByRawIdAndDeletedStatus(int RawId)
        {
            try
            {
                List<RawMaterial> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.RawMaterial.Where(dw => dw.RawId == RawId&&dw.Deleted==0).ToList();
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
        /// <summary>
        /// 根据单位id查找所有的原料
        /// </summary>
        /// <param name="RawUnitId"></param>
        /// <returns></returns>
        public List<RawMaterial> FindAllRawMaterialByRawUnitId(int RawUnitId)
        {
            try
            {
                List<RawMaterial> odws = null;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.RawMaterial.Where(dw => dw.StockUnit == RawUnitId&&dw.Deleted==0).ToList();
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

        public RawMaterial FindRawMaterialById(int Id)
        {
            if (Id<0)
            {
                return null;
            }

            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.RawMaterial.SingleOrDefault(bt => bt.Id==Id);
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
        /// 查找所有的原料资料
        /// </summary>
        /// <returns></returns>
        public List<RawMaterial> FindAllRawMaterial()
        {
            try
            {
                List<RawMaterial> odws = null;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.RawMaterial.Where(dw => dw.Id >0).ToList();
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
        /// <summary>
        /// 根据名字查找原料
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List<RawMaterial> 集合</returns>
        public List<RawMaterial> FindRawMaterialByName(string name)
        {
            if (name ==null)
            {
                return null;
            }
            List<RawMaterial> odws = null;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                odws = entities.RawMaterial.Where(dw => dw.MaterialName == name&&dw.Deleted==0).ToList();
            }
            if (odws != null && odws.Count > 0)
            {
                return odws;
            }
            return null;
        }
        /// <summary>
        /// 查找所有未被进行物理删除的原料
        /// </summary>
        /// <returns> List<RawMaterial> </returns>
        public List<RawMaterial> FindAllRawMaterialByDeleted()
        {
            List<RawMaterial> odws = null;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                odws = entities.RawMaterial.Where(dw => dw.Deleted == 0).ToList();
            }
            if (odws != null && odws.Count > 0)
            {
                return odws;
            }
            return null;
        }


        public bool AddRaw(Raw rw)
        {
            if (rw == null)
            {
                return false;
            }
            //添加
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {

                try
                {
                    entities.Raw.Add(rw);
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

        public bool UpdateRaw(Raw rw)
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
                    var type = entities.Raw.SingleOrDefault(bt => bt.RawId == rw.RawId);
                    if (type != null)
                    {
                        type.ParentRawId = rw.ParentRawId;
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
        /**根据原料类型id做物理删除*/
        public bool UpdateRawDeletedStatusById(int id,int DeletedStatus)
        {

            if (id < 0)
            {
                return false;
            }
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.Raw.SingleOrDefault(bt => bt.RawId == id);
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

        public bool DeleteRaw(int id)
        {
            if (id < 0)
            {
                return false;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    Raw booktype = new Raw()
                    {
                        RawId = id,
                    };
                    DbEntityEntry<Raw> entry = entities.Entry<Raw>(booktype);
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

        public List<Raw> FindAllRawByBigRawId(int BigRawId)
        {
            try
            {
                List<Raw> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.Raw.Where(dw => dw.ParentRawId == BigRawId).ToList();
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
        /// <summary>
        /// 根据大类id查找所有的没有被进行物理删除的小类
        /// </summary>
        /// <param name="BigRawId"> 大类id</param>
        /// <returns> List<Raw></returns>
        public List<Raw> FindAllRawByBigRawIdAndDeletedStatus(int BigRawId)
        {
            try
            {
                List<Raw> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.Raw.Where(dw => dw.ParentRawId == BigRawId && dw.Deleted==0).ToList();
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
        public Raw FindRawById(int Id)
        {

            if (Id < 0)
            {
                return null;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.Raw.SingleOrDefault(bt => bt.RawId == Id);
                    return type;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return null;
                }

            }
        }
        public List<Raw> FindAllBigRaw()
        {
            try
            {
                List<Raw> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.Raw.Where(dw => dw.ParentRawId==0||dw.ParentRawId==null).ToList();
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
        /// <summary>
        /// 查找所有的菜品大类并且没有被进行物理删除的
        /// </summary>
        /// <returns></returns>
        public List<Raw> FindAllBigRawByDeletedStatus()
        {
            try
            {
                List<Raw> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.Raw.Where(dw => (dw.ParentRawId == 0 || dw.ParentRawId == null )&&dw.Deleted == 0).ToList();
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
