using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Service
{
    public class EmployeeService : IEmployeeService
    {
        #region Observable 公司 阙进午
        public Company QueryByCompany(Company company)
        {
            Company result;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询条件
                Expression<Func<Company, bool>> checkCourse = Company => Company.Deleted == 0 && Company.CompanyId == company.CompanyId;
                if (company.CompanyName != null && !company.CompanyName.Equals(""))
                {
                    checkCourse = Company => Company.Deleted == 0 && Company.CompanyName == company.CompanyName;
                }
                try
                {
                    result = entities.Company.Where(checkCourse).Single();
                }
                catch (Exception)
                {
                    result = new Company();
                }
            }
            return result;
        }
        //0 添加失败，-1添加重复
        public int AddCompany(Company company)
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
                else
                {
                    flag = -1;
                }
            }
            return flag;
        }

        //0修改失败，-1修改重复
        public int EditByCompany(Company company)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询公司是否存在
                var type = entities.Company.SingleOrDefault(bt => bt.CompanyId == company.CompanyId && bt.Deleted == 0);
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
            }
            return flag;
        }

        #endregion Observable 公司


        #region Observable 部门 阙进午
        public List<DepartmentInfo> QueryByDepartment(DepartmentInfo departmentInfo)
        {
            List<DepartmentInfo> result;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询条件
                Expression<Func<DepartmentInfo, bool>> checkCourse = DepartmentInfo => DepartmentInfo.Deleted == 0;
                if (departmentInfo.DepartmentId > 0)
                {
                    checkCourse = DepartmentInfo => DepartmentInfo.DepartmentId == departmentInfo.DepartmentId;
                }

                result = entities.DepartmentInfo.Where(checkCourse).ToList();
            }
            return result;
        }
        //0 添加失败，-1添加重复
        public int AddDepartment(DepartmentInfo departmentInfo)
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
        public int EditByDepartment(DepartmentInfo departmentInfo)
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
            }
            return flag;
        }


        public int DelByDepartment(DepartmentInfo departmentInfo)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //直接修改的方式
                DbEntityEntry<DepartmentInfo> entry = entities.Entry<DepartmentInfo>(departmentInfo);
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

        #endregion Observable 部门



        #region Observable 员工 阙进午

        public Employee FindByEmployeeId(int id)
        {
            Employee employee;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询条件
                Expression<Func<Employee, bool>> checkCourse = Employee => Employee.Deleted == 0;
                checkCourse = Employee => Employee.Deleted == 0 && Employee.UserId == id;
                employee = entities.Employee.Where(checkCourse).Single();
            }
            return employee;
        }

        public List<Employee> QueryByEmployee(Employee employee)
        {
            List<Employee> result;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询条件
                Expression<Func<Employee, bool>> checkCourse = Employee => Employee.Deleted == 0;
                if (employee != null && employee.DepartmentId > 0)
                {
                    checkCourse = Employee => Employee.Deleted == 0 && Employee.DepartmentId == employee.DepartmentId;
                }
                result = entities.Employee.Where(checkCourse).ToList();
            }
            return result;
        }

        public List<Employee> QueryByEmployee()
        {
            List<Employee> result;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询条件
                Expression<Func<Employee, bool>> checkCourse = Employee => Employee.Deleted == 0;
              
                result = entities.Employee.Where(checkCourse).ToList();
            }
            return result;
        }

        //0 添加失败，-1添加重复
        public int AddEmployee(Employee employee)
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
        public int EditByEmployee(Employee employee)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询员工工号是否存在
                var type = entities.Employee.SingleOrDefault(bt => bt.UserId == employee.UserId && bt.Deleted == 0);
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

                    type.Position = employee.Position;
                    type.Phone = employee.Phone;
                    type.Code = employee.Code;
                    type.ResidentialAddress = employee.ResidentialAddress;
                    type.IDAddress = employee.IDAddress;
                    type.Remark = employee.Remark;
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
        //删除员工
        public int DelByEmployee(Employee employee)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //直接修改的方式
                DbEntityEntry<Employee> entry = entities.Entry<Employee>(employee);
                entry.State = System.Data.Entity.EntityState.Unchanged;
                //设置修改状态为ture 否则数据库不会更新
                entry.Property("UpdateDatetime").IsModified = true;
                entry.Property("Deleted").IsModified = true;
                entry.Property("UpdateBy").IsModified = true;
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
        //员工状态修改
        public int EditEmployeeFlag(Employee employee)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //直接修改的方式
                DbEntityEntry<Employee> entry = entities.Entry<Employee>(employee);
                entry.State = System.Data.Entity.EntityState.Unchanged;
                //设置修改状态为ture 否则数据库不会更新
                entry.Property("UpdateDatetime").IsModified = true;
                entry.Property("Flag").IsModified = true;
                entry.Property("UpdateBy").IsModified = true;
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
    }
}
