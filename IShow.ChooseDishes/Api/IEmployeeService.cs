using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Api
{
    public interface IEmployeeService
    {
        #region Observable 公司管理 阙进午
        //查询公司
         Company QueryByCompany(Company company);
        //添加公司
        int AddCompany(Company company);
        //修改公司
        int EditByCompany(Company company);
        #endregion Observable 公司管理 阙进午

        #region Observable 部门管理 阙进午
        //查询部门
        List<DepartmentInfo> QueryByDepartment(DepartmentInfo departmentInfo);
        //添加部门
        int AddDepartment(DepartmentInfo departmentInfo);
        //修改部门
        int EditByDepartment(DepartmentInfo departmentInfo);
        //删除部门
        int DelByDepartment(DepartmentInfo departmentInfo);
        #endregion Observable 部门管理 阙进午

        #region Observable 员工管理 阙进午
        //查询员工
        /// <summary>
        /// 根据ID查询员工
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Employee</returns>
        Employee FindByEmployeeId(int employeeId);
        //查询所有员工
        List<Employee> QueryByEmployee();
        //查询员工
        List<Employee> QueryByEmployee(Employee employee);
        //添加员工
        int AddEmployee(Employee employee);
        //修改员工
        int EditByEmployee(Employee employee);
        //删除员工
        int DelByEmployee(Employee employee);
        //修改员工状态
        int EditEmployeeFlag(Employee employee);
        #endregion Observable 员工管理 阙进午

    }
}
