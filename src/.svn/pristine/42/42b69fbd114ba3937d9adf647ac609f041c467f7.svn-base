using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Windows;


namespace IShow.ChooseDishes.Service
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

        //0添加失败，-1添加重复
        public int addLocation(Location location)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
              
                //查询编码是否存在
                var type = entities.Location.SingleOrDefault(bt => bt.Code == location.Code && bt.Deleted == 0);
                if (type == null)
                {
                    //实体绑定数据
                    entities.Location.Add(location);
                    try
                    {
                        //操作数据库
                        flag = entities.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
                else {
                    flag = -1;
                }
            }
            return flag;
        }

        //0修改失败，-1修改重复
        public int editByLocation(Location local)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                
                 //查询编码是否存在
                var type = entities.Location.SingleOrDefault(bt => bt.Code == local.Code && bt.Deleted == 0 && bt.LocationId != local.LocationId);
                if (type == null)
                {
                    DbEntityEntry<Location> entry = entities.Entry<Location>(local);
                    //设置操作类型
                    entry.State = System.Data.Entity.EntityState.Unchanged;
                    //设置属性是否参与修改 ，设置为false则无法更新数据
                    entry.Property("Code").IsModified = true;
                    entry.Property("Name").IsModified = true;
                    entry.Property("UpdateBy").IsModified = true;
                    entry.Property("UpdateDatetime").IsModified = true;
                    try
                    {
                        //关闭实体验证，不关闭验证需要整个对象全部传值
                        entities.Configuration.ValidateOnSaveEnabled = false;
                        //操作数据库
                        flag = entities.SaveChanges();
                        entities.Configuration.ValidateOnSaveEnabled = true;
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
                else {
                    flag = -1;
                }
            }
            return flag;
        }

        public int delByLocation(Location location)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {

                DbEntityEntry<Location> entry = entities.Entry<Location>(location);
                //设置操作类型
                entry.State = System.Data.Entity.EntityState.Unchanged;
                //设置属性是否参与修改 ，设置为false则无法更新数据
                entry.Property("Deleted").IsModified = true;
                entry.Property("UpdateBy").IsModified = true;
                entry.Property("UpdateDatetime").IsModified = true;
                try
                {
                    //关闭实体验证，不关闭验证需要整个对象全部传值
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

        //0添加失败，-1添加重复
        public int addBearing(Bearing bearing)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
               
                //查询编码是否存在
                var type = entities.Bearing.SingleOrDefault(bt => bt.Code == bearing.Code && bt.Deleted == 0);
                if (type == null)
                {
                    //实体绑定MODEL
                    entities.Bearing.Add(bearing);
                    try
                    {
                        //操作数据库
                        flag = entities.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
                else {
                    flag = -1;
                }
            }
            return flag;
        }

        //0修改失败，-1修改重复
        public int editByBearing(Bearing bearing)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.Bearing.SingleOrDefault(bt => bt.Code == bearing.Code && bt.Deleted == 0 && bt.BearingId != bearing.BearingId);
                if (type == null)
                {
                    //实体绑定model
                    DbEntityEntry<Bearing> entry = entities.Entry<Bearing>(bearing);
                    //设置操作类型
                    entry.State = System.Data.Entity.EntityState.Unchanged;
                    //设置修改状态为ture 否则数据库不会更新
                    entry.Property("Code").IsModified = true;
                    entry.Property("Name").IsModified = true;
                    entry.Property("Status").IsModified = true;
                    entry.Property("UpdateBy").IsModified = true;
                    entry.Property("UpdateDatetime").IsModified = true;
                    try
                    {
                        //关闭实体验证，不关闭验证需要整个对象全部传值
                        entities.Configuration.ValidateOnSaveEnabled = false;
                        flag = entities.SaveChanges();
                        entities.Configuration.ValidateOnSaveEnabled = true;
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
                else {
                    flag = -1;
                }
            }
            return flag;
        }

        public int delByBearing(Bearing bearing)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //直接修改的方式
                DbEntityEntry<Bearing> entry = entities.Entry<Bearing>(bearing);
                entry.State = System.Data.Entity.EntityState.Unchanged;
                //设置修改状态为ture 否则数据库不会更新
                entry.Property("UpdateBy").IsModified = true;
                entry.Property("Deleted").IsModified = true;
                entry.Property("UpdateDatetime").IsModified = true;
                try
                {
                    //关闭实体验证，不关闭验证需要整个对象全部传值
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

        #region Observable 公司 阙进午
        public List<Company> queryByCompany(Company company)
        {
            List<Company> bear;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询条件
                Expression<Func<Company, bool>> checkCourse = Company => Company.Deleted == 0;
                if (company.CompanyName != null && !company.CompanyName.Equals(""))
                {
                    checkCourse = Company => Company.Deleted == 0 && Company.CompanyName==company.CompanyName;
                }

                bear = entities.Company.Where(checkCourse).ToList();
            }
            return bear;
        }
        //0 添加失败，-1添加重复
        public int addCompany(Company company)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                 //查询编码是否存在
                var type = entities.Company.SingleOrDefault(bt => bt.CompanyId == company.CompanyId && bt.Deleted == 0);
                if (type == null)
                {
                    //实体绑定MODEL
                    entities.Company.Add(company);
                    try
                    {
                        //操作数据库
                        entities.Configuration.ValidateOnSaveEnabled = false;
                       
                        flag = entities.SaveChanges();
                        entities.Configuration.ValidateOnSaveEnabled = true;
                       
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
                else {
                    flag = -1;
                }
            }
            return flag;
        }

        //0修改失败，-1修改重复
        public int editByCompany(Company company)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询公司是否存在
                var type = entities.Company.SingleOrDefault(bt => bt.CompanyId == company.CompanyId && bt.Deleted == 0 );
                if (type != null)
                {
                    //设置属性是否参与修改 ，设置为false则无法更新数据
                    type.CompanyName = company.CompanyName;
                    type.Contacts = company.Contacts;
                    type.Phone = company.Phone;
                    type.Mobile = company.Mobile;
                    type.Email = company.Email;
                    type.Addr = company.Addr;
                    type.Logo1 = company.Logo1;
                    type.Logo2 = company.Logo2;
                    type.DPName = company.DPName;
                    type.DPAddr = company.DPAddr;
                    type.DPParam = company.DPParam;
                    type.EditPerson = company.EditPerson;
                    type.EditTime = company.EditTime;
                    try
                    {
                        //关闭实体验证，不关闭验证需要整个对象全部传值
                        entities.Configuration.ValidateOnSaveEnabled = false;
                        //操作数据库
                        flag = entities.SaveChanges();
                        entities.Configuration.ValidateOnSaveEnabled = true;
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
                else
                {
                    flag = -1;
                }
            }
            return flag;
        }

        #endregion Observable 公司


        #region Observable 部门 阙进午
        public List<DepartmentInfo> queryByDepartment(DepartmentInfo departmentInfo)
        {
            List<DepartmentInfo> bear;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询条件
                Expression<Func<DepartmentInfo, bool>> checkCourse = DepartmentInfo => departmentInfo.Deleted == 0;
                // if (company.CompanyName != null && !company.CompanyName.Equals(""))
                // {
                //     checkCourse = Company => Company.Deleted == 0 && Company.CompanyName==company.CompanyName;
                // }

                bear = entities.DepartmentInfo.Where(checkCourse).ToList();
            }
            return bear;
        }
        //0 添加失败，-1添加重复
        public int addDepartment(DepartmentInfo departmentInfo)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询编码是否存在
                var type = entities.DepartmentInfo.SingleOrDefault(bt => bt.DepartmentName == departmentInfo.DepartmentName && bt.Deleted == 0);
                if (type == null)
                {
                    //实体绑定MODEL
                    entities.DepartmentInfo.Add(departmentInfo);
                    try
                    {
                        //操作数据库
                        entities.Configuration.ValidateOnSaveEnabled = false;

                        flag = entities.SaveChanges();
                        entities.Configuration.ValidateOnSaveEnabled = true;

                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
                else
                {
                    flag = -1;
                }
            }
            return flag;
        }

        //0修改失败，-1修改重复
        public int editByDepartment(DepartmentInfo departmentInfo)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询部门是否存在
                var type = entities.DepartmentInfo.SingleOrDefault(bt => bt.DepartmentId == departmentInfo.DepartmentId && bt.Deleted == 0);
                if (type != null)
                {
                    //设置属性是否参与修改 ，设置为false则无法更新数据
                    type.DepartmentName = departmentInfo.DepartmentName;
                    type.UpdateDatetime = departmentInfo.UpdateDatetime;
                    type.UpdateBy = departmentInfo.UpdateBy;
                    try
                    {
                        //关闭实体验证，不关闭验证需要整个对象全部传值
                        entities.Configuration.ValidateOnSaveEnabled = false;
                        //操作数据库
                        flag = entities.SaveChanges();
                        entities.Configuration.ValidateOnSaveEnabled = true;
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
                else
                {
                    flag = -1;
                }
            }
            return flag;
        }


        public int delByDepartment(DepartmentInfo departmentInfo)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //直接修改的方式
                DbEntityEntry<DepartmentInfo> entry = entities.Entry<DepartmentInfo>(departmentInfo);
                entry.State = System.Data.Entity.EntityState.Unchanged;
                //设置修改状态为ture 否则数据库不会更新
                entry.Property("EditPerson").IsModified = true;
                entry.Property("Deleted").IsModified = true;
                entry.Property("EditTime").IsModified = true;
                try
                {
                    //关闭实体验证，不关闭验证需要整个对象全部传值
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

        #endregion Observable 部门



        #region Observable 员工 阙进午
        public List<Employee> queryByEmployee(Employee employee)
        {
            List<Employee> bear;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询条件
                Expression<Func<Employee, bool>> checkCourse = Employee => employee.Deleted == 0;
                // if (company.CompanyName != null && !company.CompanyName.Equals(""))
                // {
                //     checkCourse = Company => Company.Deleted == 0 && Company.CompanyName==company.CompanyName;
                // }

                bear = entities.Employee.Where(checkCourse).ToList();
            }
            return bear;
        }
        //0 添加失败，-1添加重复
        public int addEmployee(Employee employee)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询员工工号是否存在
                var type = entities.Employee.SingleOrDefault(bt => bt.JobNo == employee.JobNo && bt.Deleted == 0);
                if (type == null)
                {
                    //实体绑定MODEL
                    entities.Employee.Add(employee);
                    try
                    {
                        //操作数据库
                        entities.Configuration.ValidateOnSaveEnabled = false;

                        flag = entities.SaveChanges();
                        entities.Configuration.ValidateOnSaveEnabled = true;

                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
                else
                {
                    flag = -1;
                }
            }
            return flag;
        }

        //0修改失败，-1修改重复
        public int editByEmployee(Employee employee)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询员工工号是否存在
                var type = entities.Employee.SingleOrDefault(bt => bt.JobNo == employee.JobNo && bt.Deleted == 0);
                if (type != null)
                {
                    //设置属性是否参与修改 ，设置为false则无法更新数据
                    type.JobNo = employee.JobNo;
                    type.Name = employee.Name;
                    type.Sex = employee.Sex;
                    type.Birthday = employee.Birthday;
                    type.Flag = employee.Flag;
                    type.Mobile = employee.Mobile;
                    type.Email = employee.Email;
                    type.UpdateDatetime = employee.UpdateDatetime;
                    type.UpdateBy = employee.UpdateBy;
                    try
                    {
                        //关闭实体验证，不关闭验证需要整个对象全部传值
                        entities.Configuration.ValidateOnSaveEnabled = false;
                        //操作数据库
                        flag = entities.SaveChanges();
                        entities.Configuration.ValidateOnSaveEnabled = true;
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
                else
                {
                    flag = -1;
                }
            }
            return flag;
        }

        public int delByEmployee(Employee employee)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //直接修改的方式
                DbEntityEntry<Employee> entry = entities.Entry<Employee>(employee);
                entry.State = System.Data.Entity.EntityState.Unchanged;
                //设置修改状态为ture 否则数据库不会更新
                entry.Property("EditTime").IsModified = true;
                entry.Property("Deleted").IsModified = true;
                entry.Property("EditPerson").IsModified = true;
                try
                {
                    //关闭实体验证，不关闭验证需要整个对象全部传值
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

        #endregion Observable 员工
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
                if (cashType == null || cashType.Id == 0)
                {
                    return null;
                }
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    //先查询 后修改
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
