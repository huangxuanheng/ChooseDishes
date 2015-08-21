using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Documents;
using System.Collections;
using System.Data.Entity.Infrastructure;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Security;

namespace IShow.ChooseDishes
{
    public class TableService : IShow.ChooseDishes.ITableService
    {
        /***餐桌类型****/
        #region
        /// <summary>
        /// 获取所有的餐桌类型及其下的所有餐桌和餐桌对应的餐桌状态
        /// </summary>
        /// <returns>如果有数据，则返回所有的餐桌类型，否则返回null</returns>
        public List<TableType> GetAllTypes()
        {
            List<TableType> types;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                types = entities.TableType.Include(typeof(IShow.ChooseDishes.Data.Table).Name).Where(info => info.Deleted == 0).ToList();
                foreach (var location in types)
                {
                    ICollection<IShow.ChooseDishes.Data.Table> tables = location.Table;
                    if (tables != null && tables.Count > 0)
                    {
                        for (int x = 0; x < tables.Count; x++)
                        {
                            var table = tables.ElementAt(x);
                            var tb = entities.Table.Include(typeof(TableItem).Name).SingleOrDefault(t => t.Deleted == 0 && t.TableId == table.TableId);
                            table = tb;
                        }

                    }
                }
                return types;
            };
        }
        //查询所有桌类
        public List<TableType> LoadAllTableType()
        {
            List<TableType> types;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                types = entities.TableType.Where(
                    info => info.Deleted == 0
                ).ToList();
                if (types == null || types.Count == 0)
                {
                    types = new List<TableType>();
                }
                return types;
            };
        }

        public TableType LoadTableTypeById(int typeId)
        {
            TableType type;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                type = entities.TableType.Where(
                    info => info.Deleted == 0
                        && (info.TableTypeId == typeId)
                ).ToList()[0];
                if (type == null)
                {
                    type = new TableType();
                }
                return type;
            };
        }

        //新增桌类
        public int SaveTableType(TableType type)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    Hashtable hash = new Hashtable();//返回结果

                    List<TableType> types;
                    //检查类型编号或者类型名称是否重复
                    types = entities.TableType.Where(info => info.Name == type.Name || info.Code == type.Code).ToList();
                    if (types != null && types.Count > 0)
                    {
                        hash.Add("code", 1);
                        if (types[0].Name == type.Name)
                        {
                            throw new ServiceException("类型名称已经存在，请重新命名！");
                        }
                        else if (types[0].Code == type.Code)
                        {
                            throw new ServiceException("类型编号已经存在！");
                        }
                    }
                    entities.TableType.Add(type);
                    entities.SaveChanges();
                    return type.TableTypeId;
                }
                catch (Exception e)
                {
                    throw new ServiceException(e.Message);
                }
            };
        }

        /// <summary>
        /// 新增桌类，包括服务费设置、低消设置
        /// </summary>
        /// <param name="type"></param>
        /// <param name="serverFeeDetail"></param>
        /// <param name="lowConsumerDetail"></param>
        /// <returns></returns>
        public int SaveTableTypeAll(TableType type, TableTypeDetail serverFeeDetail, TableTypeDetail lowConsumerDetail)
        {
            try
            {
                int typeId = SaveTableType(type);
                serverFeeDetail.TableTypeId = typeId;
                lowConsumerDetail.TableTypeId = typeId;
                SaveTableTypeDetail(serverFeeDetail);
                SaveTableTypeDetail(lowConsumerDetail);
                return typeId;
            }
            catch (Exception e)
            {
                throw new ServiceException(e.Message);
            }
        }

        /// <summary>
        /// 修改餐桌类型，包括服务费设置、低消设置
        /// </summary>
        /// <param name="type"></param>
        /// <param name="serverFeeDetail"></param>
        /// <param name="lowConsumerDetail"></param>
        public void UpdateTableTypeAll(TableType type, TableTypeDetail serverFeeDetail, TableTypeDetail lowConsumerDetail)
        {
            try
            {
                UpdateTableType(type);
                UpdateTableTypeDetail(serverFeeDetail);
                UpdateTableTypeDetail(lowConsumerDetail);
            }
            catch (Exception e)
            {
                throw new ServiceException("修改失败！");
            }
        }

        public void UpdateTableType(TableType type)
        {

            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                DbEntityEntry<TableType> entry = entities.Entry<TableType>(type);

                entry.State = System.Data.Entity.EntityState.Unchanged;//Modified
                entry.Property("Name").IsModified = true;
                entry.Property("PeopleMin").IsModified = true;
                entry.Property("PeopleMax").IsModified = true;
                entry.Property("PriceType").IsModified = true;
                entry.Property("ServerfreeModel").IsModified = true;
                entry.Property("ColorType").IsModified = true;
                entry.Property("UpdateBy").IsModified = true;
                entry.Property("UpdateDatetime").IsModified = true;
                entry.Property("LowConsCalcType").IsModified = true;
                entry.Property("ServerFeeCalcType").IsModified = true;
                entry.Property("CanDiscount").IsModified = true;
                entry.Property("InLowConsume").IsModified = true;
                try
                {
                    entities.Configuration.ValidateOnSaveEnabled = false;
                    int result = entities.SaveChanges();
                    entities.Configuration.ValidateOnSaveEnabled = true;
                }
                catch (Exception e)
                {
                    throw new ServiceException(e.Message);
                }
            }
        }

        /**删除桌类,逻辑删除**/
        public void DeleteTableType(int typeId)
        {
            try
            {
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    //检查是否被餐桌关联 

                    List<IShow.ChooseDishes.Data.Table> tableList = LoadTableByTypeId(typeId);
                    if (tableList != null && tableList.Count > 0)
                    {
                        throw new ServiceException("该餐桌类别关联了餐桌，不能删除！");
                    }
                    TableType type = new TableType();
                    type.TableTypeId = typeId;
                    type.Deleted = 1;
                    DbEntityEntry<TableType> entry = entities.Entry<TableType>(type);
                    entry.State = System.Data.Entity.EntityState.Unchanged;//Modified
                    entry.Property("Deleted").IsModified = true;

                    entities.Configuration.ValidateOnSaveEnabled = false;
                    int result = entities.SaveChanges();
                    entities.Configuration.ValidateOnSaveEnabled = true;
                    if (result == 1)
                    {
                        throw new ServiceException("修改失败！");
                    }
                }
            }
            catch (Exception e)
            {
                throw new ServiceException(e.Message);
            }
        }
        #endregion

        #region 餐桌特殊时段
        /// <summary>
        /// 查询时段收费设置
        /// type为1: 查询服务费特殊时段
        /// type为2：查询低消特殊时段
        /// type为3：查询时间单位服务费设置
        /// </summary>
        /// <returns></returns>
        public List<TableTypeDetail> LoadAllTableTypeDetails(int tableTypeId)
        {
            List<TableTypeDetail> types;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                types = entities.TableTypeDetail.Where(
                    info => info.Deleted == 0 && info.TableTypeId == tableTypeId
                ).ToList();
                if (types == null || types.Count == 0)
                {
                    types = new List<TableTypeDetail>();
                }
                return types;
            };
        }

        /// <summary>
        /// 查询时段收费设置
        /// type为1: 查询服务费特殊时段
        /// type为2：查询低消特殊时段
        /// type为3：查询时间单位服务费设置
        /// </summary>
        /// <returns></returns>
        public List<TableTypeDetail> LoadTableTypeDetails(int tableTypeId, int type)
        {
            List<TableTypeDetail> types;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                types = entities.TableTypeDetail.Where(
                    info => info.Deleted == 0 && info.DataType == type && info.TableTypeId == tableTypeId
                ).ToList();
                if (types == null || types.Count == 0)
                {
                    types = new List<TableTypeDetail>();
                }
                return types;
            };
        }

        /// <summary>
        /// 根据ID查询餐桌类别详细设置
        /// </summary>
        /// <param name="tableTypeDetailId"></param>
        /// <returns></returns>
        public TableTypeDetail LoadTableTypeDetailById(int tableTypeDetailId)
        {
            TableTypeDetail type;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                type = (TableTypeDetail)entities.TableTypeDetail.Where(
                    info => info.Deleted == 0 && info.TableTypeDetailId == tableTypeDetailId
                );
                if (type == null)
                {
                    type = new TableTypeDetail();
                }
                return type;
            };
        }
        /// <summary>
        /// 新增服务费时间单位设置
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public bool SaveTableTypeDetail(TableTypeDetail detail)
        {
            try
            {
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    detail.Deleted = 0;
                    detail.Status = 0;
                    detail.CreateDatetime = DateTime.Now;
                    detail.UpdateDatetime = DateTime.Now;
                    entities.TableTypeDetail.Add(detail);
                    int result = entities.SaveChanges();
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 修改服务费低消设置
        /// </summary>
        /// <param name="detail">服务费设置详细</param>
        /// <param name="serverFeeMode">服务费模式</param>
        /// <returns>成功则返回true，失败返回false</returns>
        public bool UpdateTableTypeDetail(TableTypeDetail detail)
        {
            try
            {
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    detail.UpdateBy = SubjectUtils.GetAuthenticationId();
                    detail.UpdateDatetime = DateTime.Now;
                    DbEntityEntry<IShow.ChooseDishes.Data.TableTypeDetail> entry = entities.Entry<IShow.ChooseDishes.Data.TableTypeDetail>(detail);
                    entry.State = System.Data.Entity.EntityState.Unchanged;
                    entry.Property("StartMoney").IsModified = true;
                    entry.Property("StartGetMoneyTime").IsModified = true;
                    entry.Property("StartUnit").IsModified = true;
                    entry.Property("StartDateTime").IsModified = true;
                    entry.Property("EndDateTime").IsModified = true;
                    entry.Property("OutMoney").IsModified = true;
                    entry.Property("OutTime").IsModified = true;
                    entry.Property("OutTimeFree").IsModified = true;
                    entry.Property("ServerfreeNax").IsModified = true;
                    entry.Property("ServerfreeAccountType").IsModified = true;
                    entry.Property("ServerfreeNum").IsModified = true;
                    entry.Property("Rate").IsModified = true;
                    entry.Property("ConsumerMode").IsModified = true;
                    entry.Property("ConsumerMoney").IsModified = true;
                    entry.Property("UpdateDatetime").IsModified = true;
                    entry.Property("UpdateBy").IsModified = true;

                    //entry.Property("TableTypeDetailId").IsModified = false;

                    entities.Configuration.ValidateOnSaveEnabled = false;
                    int result = entities.SaveChanges();
                    entities.Configuration.ValidateOnSaveEnabled = false;
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="detailId"></param>
        /// <returns></returns>
        public bool DeleteTableTypeDetail(int detailId)
        {
            try
            {
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    TableTypeDetail detail = new TableTypeDetail();
                    detail.TableTypeDetailId = detailId;
                    detail.Deleted = 1;
                    DbEntityEntry<IShow.ChooseDishes.Data.TableTypeDetail> entry = entities.Entry<IShow.ChooseDishes.Data.TableTypeDetail>(detail);
                    entry.State = System.Data.Entity.EntityState.Unchanged;
                    entry.Property("Deleted").IsModified = true;

                    entities.Configuration.ValidateOnSaveEnabled = false;
                    int result = entities.SaveChanges();
                    entities.Configuration.ValidateOnSaveEnabled = false;
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region
        public List<IShow.ChooseDishes.Data.Table> LoadAllTable()
        {
            List<IShow.ChooseDishes.Data.Table> types;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                types = entities.Table.Where(
                    info => info.Deleted == 0
                ).ToList();
                if (types == null || types.Count == 0)
                {
                    types = new List<IShow.ChooseDishes.Data.Table>();
                }
                return types;
            };
        }

        public IShow.ChooseDishes.Data.Table LoadTableById(int tableId)
        {
            IShow.ChooseDishes.Data.Table table;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                table = (IShow.ChooseDishes.Data.Table)entities.Table.Where(
                    info => info.Deleted == 0
                        && (info.TableId == tableId)
                );
                if (table == null)
                {
                    table = new IShow.ChooseDishes.Data.Table();
                }
                return table;
            };
        }

        public List<IShow.ChooseDishes.Data.Table> LoadTableByTypeId(int typeId)
        {
            List<IShow.ChooseDishes.Data.Table> tables;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                tables = (List<IShow.ChooseDishes.Data.Table>)entities.Table.Where(
                    info => info.Deleted == 0
                        && (info.TableTypeId == typeId)
                ).ToList();
                if (tables == null)
                {
                    tables = new List<IShow.ChooseDishes.Data.Table>();
                }
                return tables;
            };
        }
        /// <summary>
        /// 根据餐桌类型id查询所有餐桌及其下餐桌状态
        /// </summary>
        /// <param name="typeId">typeId 餐桌类型id</param>
        /// <returns></returns>
        public List<IShow.ChooseDishes.Data.Table> LoadTableAndRefByTypeId(int typeId)
        {
            List<IShow.ChooseDishes.Data.Table> tables;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                tables = entities.Table.Include(typeof(TableItem).Name).Where(info => info.Deleted == 0 && info.TableTypeId == typeId
                ).ToList();
                return tables;
            };
        }

        //新增餐桌
        public Hashtable SaveTable(IShow.ChooseDishes.Data.Table table)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    Hashtable hash = new Hashtable();//返回结果

                    List<IShow.ChooseDishes.Data.Table> tables;
                    //检查类型编号或者类型名称是否重复
                    tables = entities.Table.Where(info => info.Name == table.Name || info.Code == table.Code).ToList();
                    if (tables != null && tables.Count > 0)
                    {
                        hash.Add("code", 1);
                        if (tables[0].Name == table.Name)
                        {
                            hash.Add("message", "餐桌名称已经存在，请重新命名！");
                        }
                        else if (tables[0].Code == table.Code)
                        {
                            hash.Add("message", "餐桌编号已经存在！");
                        }
                        return hash;
                    }
                    entities.Table.Add(table);

                    int result = entities.SaveChanges();
                    if (result == 1)
                    {
                        hash.Add("code", 0);
                        hash.Add("message", "新增成功！");

                    }
                    else
                    {
                        hash.Add("code", 2);
                        hash.Add("message", "新增失败，请稍后再试！");

                    }
                    return hash;
                }
                catch (Exception e)
                {
                    throw e;
                }

            };

        }

        public bool UpdateTable(IShow.ChooseDishes.Data.Table table)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                DbEntityEntry<IShow.ChooseDishes.Data.Table> entry = entities.Entry<IShow.ChooseDishes.Data.Table>(table);

                entry.State = System.Data.Entity.EntityState.Unchanged;//Modified
                entry.Property("Name").IsModified = true;
                entry.Property("Seat").IsModified = true;
                entry.Property("TableTypeId").IsModified = true;
                entry.Property("LocationId").IsModified = true;
                entry.Property("Status").IsModified = true;

                //TODO 是否已经启用，已启用则不能删除
                entry.Property("TableId").IsModified = false;

                try
                {
                    entities.Configuration.ValidateOnSaveEnabled = false;
                    int result = entities.SaveChanges();
                    entities.Configuration.ValidateOnSaveEnabled = true;

                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }
        }

        /**删除餐桌,逻辑删除**/
        public bool DeleteTable(int tableId)
        {
            try
            {
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    IShow.ChooseDishes.Data.Table table = new IShow.ChooseDishes.Data.Table();
                    table.TableId = tableId;
                    DbEntityEntry<IShow.ChooseDishes.Data.Table> entry = entities.Entry<IShow.ChooseDishes.Data.Table>(table);
                    entry.State = System.Data.Entity.EntityState.Unchanged;//Modified
                    entry.Property("Deleted").IsModified = true;

                    entities.Configuration.ValidateOnSaveEnabled = false;
                    int result = entities.SaveChanges();
                    entities.Configuration.ValidateOnSaveEnabled = true;
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 查询区域
        /// <summary>
        /// 获取所有的区域及其下的所有餐桌及餐桌状态
        /// </summary>
        /// <returns>如果查找到，则返回区域集合，否则返回null</returns>
        public List<Location> GetAllLocation()
        {
            List<Location> locations;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                locations = entities.Location.Include(typeof(IShow.ChooseDishes.Data.Table).Name).Where(info => info.Deleted == 0).ToList();
                if (locations != null && locations.Count > 0)
                    foreach (var location in locations)
                    {
                        ICollection<IShow.ChooseDishes.Data.Table> tables = location.Table;
                        if (tables != null && tables.Count > 0)
                        {
                            for (int x = 0; x < tables.Count; x++)
                            {
                                var table = tables.ElementAt(x);
                                var tb = entities.Table.Include(typeof(TableItem).Name).SingleOrDefault(t => t.Deleted == 0 && t.TableId == table.TableId);
                                table = tb;
                            }

                        }
                    }
                return locations;
            };
        }
        /// <summary>
        /// 根据区域id获取其下的所有餐桌及餐桌状态
        /// </summary>
        /// <returns>如果查找到，则返回区域集合，否则返回null</returns>
        public Location GetLocationById(int Id)
        {

            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                Location location = entities.Location.Include(typeof(IShow.ChooseDishes.Data.Table).Name).SingleOrDefault(info => info.Deleted == 0 && info.LocationId == Id);
                if (location != null)
                {
                    ICollection<IShow.ChooseDishes.Data.Table> tables = location.Table;
                    if (tables != null && tables.Count > 0)
                    {
                        for (int x = 0; x < tables.Count; x++)
                        {
                            var table = tables.ElementAt(x);
                            var tb = entities.Table.Include(typeof(TableItem).Name).SingleOrDefault(t => t.Deleted == 0 && t.TableId == table.TableId);
                            table = tb;
                        }

                    }
                }
                return location;
            };
        }
        #endregion
        void Channel_Closed(object sender, EventArgs e)
        {

        }
    }

}
