using IShow.Service.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows;


namespace IShow.Service
{
    public class ChooseDishesDataService : IChooseDishesDataService
    {
        public bool Login(string name, string password)
        {

            MessageBox.Show("登录成功");
            OperationContext.Current.Channel.Closed += Channel_Closed;
            return true;
        }

        void Channel_Closed(object sender, EventArgs e)
        {
            
        }

        #region Observable 区域  阙进午
        public List<Location> queryByLocation()
        {
            List<Location> local;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                local = entities.Location.Where(Location => Location.Deleted==0).ToList();
            }
            return local;
        }

        public int addLocation(string name, string no)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                Location local = new Location()
                {
                    Code = no,
                    Name = name,
                    CreateDatetime=DateTime.Now,
                    CreateBy=1,
                    Deleted=0,
                    Status=0

                };
                entities.Location.Add(local);
                try
                {
                    flag = entities.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            return flag;
        }

        public int editByLocation(string id, string name, string no)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                Location local = new Location()
                {
                    LocationId = int.Parse(id),
                    Code = no,
                    Name = name,
                    UpdateBy=1,
                    UpdateDatetime=DateTime.Now

                };
                DbEntityEntry<Location> entry = entities.Entry<Location>(local);
                entry.State = System.Data.EntityState.Unchanged;
                entry.Property("Code").IsModified = true;
                entry.Property("Name").IsModified = true;
                entry.Property("UpdateBy").IsModified = true;
                entry.Property("UpdateDatetime").IsModified = true;
                try
                {
                    flag=entities.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            return flag;
        }

        public int delByLocation(string id)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                Location local = new Location()
                {
                    LocationId = int.Parse(id),
                    Deleted=1,
                    UpdateBy = 1,
                    UpdateDatetime = DateTime.Now

                };
                DbEntityEntry<Location> entry = entities.Entry<Location>(local);
                entry.State = System.Data.EntityState.Unchanged;
                entry.Property("Deleted").IsModified = true;
                entry.Property("UpdateBy").IsModified = true;
                entry.Property("UpdateDatetime").IsModified = true;
                try
                {
                    entities.Configuration.ValidateOnSaveEnabled = false; 
                    flag = entities.SaveChanges();
                    entities.Configuration.ValidateOnSaveEnabled = true; 
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            return flag;
        }

        #endregion Observable 区域

        #region Observable 方位 阙进午
        public List<Bearing> queryByBearing()
        {
            List<Bearing> bear;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                bear = entities.Bearing.Where(Bearing => Bearing.Deleted == 0).ToList();
            }
            return bear;
        }

        public int addBearing(string name, string no)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                Bearing bear = new Bearing()
                {
                    Code = int.Parse(no),
                    Name = name,
                    CreateDatetime = DateTime.Now,
                    CreateBy = 1,
                    Deleted = 1,
                    Status = 1

                };
                entities.Bearing.Add(bear);
                try
                {
                    flag = entities.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            return flag;
        }

        public int editByBearing(string id, string name, string no)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                Bearing bear = new Bearing()
                {
                    BearingId = int.Parse(id),
                    Code = int.Parse(no),
                    Name = name,
                    UpdateBy=1,
                    UpdateDatetime=DateTime.Now

                };
                DbEntityEntry<Bearing> entry = entities.Entry<Bearing>(bear);
                entry.State = System.Data.EntityState.Unchanged;
                entry.Property("Code").IsModified = true;
                entry.Property("Name").IsModified = true;
                entry.Property("UpdateBy").IsModified = true;
                entry.Property("UpdateDatetime").IsModified = true;
                try
                {
                    flag = entities.SaveChanges();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            return flag;
        }

        public int delByBearing(string id)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                Bearing bear = new Bearing()
                {
                    BearingId = int.Parse(id),
                    UpdateBy=1,
                    Deleted = 1,
                    UpdateDatetime=DateTime.Now

                };
                DbEntityEntry<Bearing> entry = entities.Entry<Bearing>(bear);
                entry.State = System.Data.EntityState.Unchanged;
                entry.Property("UpdateBy").IsModified = true;
                entry.Property("Deleted").IsModified = true;
                entry.Property("UpdateDatetime").IsModified = true;
                try
                {
                    entities.Configuration.ValidateOnSaveEnabled = false; 
                    flag = entities.SaveChanges();
                    entities.Configuration.ValidateOnSaveEnabled = true; 
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            return flag;
        }

        #endregion Observable 区域

        public IEnumerable<string> GetAllName()
        {
            yield return "test1";
            yield return "test2";
            yield return "test3";
        }

        /////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////  滕海东 ////////////////////////////////
        //加载所有的收银方式  传入收银类型编号
        public List<CashType> findCashType(int CashBaseTypeId)
        {
            List<CashType> list;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                if (CashBaseTypeId == 0)
                {
                    list = entities.CashType.ToList();
                }
                else
                {
                    list = entities.CashType.Where(CashType => CashType.CashBaseTypeId == CashBaseTypeId).ToList();
                }

            }
            return list;
        }
        //添加收银方式 返回添加成功后的收银方式
        public CashType addCashType(CashType cashType)
        {
            try
            {
                if (cashType == null)
                {
                    return null;
                }
                CashType newCashType = null;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    var type = entities.CashType.SingleOrDefault(bt => bt.Code == cashType.Code);
                    if (type != null)
                    {
                        return null;
                    }
                    entities.CashType.Add(cashType);
                    entities.SaveChanges();
                    var typenew = entities.CashType.SingleOrDefault(bt => bt.Code == cashType.Code);
                    if (typenew != null)
                    {
                        newCashType = type;
                    }
                }
                return newCashType;
            }
            catch (Exception e)
            {
                e.ToString();
                return null;
            }
        }
        //修改收银方式  返回修改成功后的方式
        public CashType updateCashType(CashType cashType)
        {
            try
            {
                if (cashType == null || cashType.Id == null)
                {
                    return null;
                }
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    var type = entities.CashType.SingleOrDefault(bt => bt.Id == cashType.Id);
                    if (type != null)
                    {
                        type.IsBillIncome = cashType.IsBillIncome;
                        type.IsPaid = cashType.IsPaid;
                        type.IsPrivilege = cashType.IsPrivilege;
                        type.IsScore = cashType.IsScore;
                        type.KeepRecharge = cashType.KeepRecharge;
                        type.Keys = cashType.Keys;
                        type.LossesUsing = cashType.LossesUsing;
                        type.Name = cashType.Name;
                        type.Rate = cashType.Rate;
                        type.ReceptionUseing = cashType.ReceptionUseing;
                        type.RechargeUsing = cashType.RechargeUsing;
                        type.Status = cashType.Status;
                        type.SupplierUsing = cashType.SupplierUsing;
                        type.UpdateBy = type.UpdateBy;
                        type.UpdateDatetime = DateTime.Now;
                        type.UseingKeys = cashType.UseingKeys;
                        entities.SaveChanges();
                    }
                }
                return cashType;
            }
            catch (Exception e)
            {
                e.ToString();
                return null;
            }

        }
        //删除收银方式 返回true 为修改成功
        public bool deleteCashType(int Id)
        {
            try
            {
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    var type = entities.CashType.SingleOrDefault(bt => bt.Id == Id);
                    if (type != null)
                    {
                        type.Deleted = 1;
                        entities.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                e.ToString();
                return false;
            }

        }
        ////////////////////////////////////////  滕海东 ////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////
    }
}
