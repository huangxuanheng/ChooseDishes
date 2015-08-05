using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace IShow.ChooseDishes.Api
{
   
    public interface IChooseDishesDataService
    {
        [OperationContract]
        bool Login(string name, string password);
        [OperationContract]
        IEnumerable<string> GetAllName();
        //查询所有区域
        [OperationContract]
        List<Location> queryByLocation();
        //添加区域
        [OperationContract]
        int addLocation(Location location);
        //修改区域
        [OperationContract]
        int editByLocation(Location location);
        //删除区域
        [OperationContract]
        int delByLocation(Location location);
        //查询方位
        [OperationContract]
        List<Bearing> queryByBearing();
        //添加方位
        [OperationContract]
        int addBearing(Bearing bearing);
        //修改方位
        [OperationContract]
        int editByBearing(Bearing bearing);
        //删除方位
        [OperationContract]
        int delByBearing(Bearing bearing);

        //查询公司
        [OperationContract]
        Company queryByCompany(Company company);
        //添加公司
        [OperationContract]
        int addCompany(Company company);
        //修改公司
        [OperationContract]
        int editByCompany(Company company);

        //查询部门
        [OperationContract]
        List<DepartmentInfo> queryByDepartment(DepartmentInfo departmentInfo);
        //添加部门
        [OperationContract]
        int addDepartment(DepartmentInfo departmentInfo);
        //修改部门
        [OperationContract]
        int editByDepartment(DepartmentInfo departmentInfo);
        //删除部门
        [OperationContract]
        int delByDepartment(DepartmentInfo departmentInfo);

        //查询员工
        [OperationContract]
        List<Employee> queryByEmployee(Employee employee);
        //添加员工
        [OperationContract]
        int addEmployee(Employee employee);
        //修改员工
        [OperationContract]
        int editByEmployee(Employee employee);
        //删除员工
        [OperationContract]
        int delByEmployee(Employee employee);
        //修改员工状态
        [OperationContract]
        int editEmployeeFlag(Employee employee);
        
        #region Observable 收银方式 滕海东
        //加载所有的收银方式  传入收银类型编号
        [OperationContract]
        List<CashType> findCashType(int CashBaseTypeId);
        //添加收银方式 返回添加成功后的收银方式
        [OperationContract]
        CashType addCashType(CashType cashType);
        //修改收银方式  返回修改成功后的方式
        [OperationContract]
        CashType updateCashType(CashType cashType);
        //删除收银方式 返回true 为修改成功
        [OperationContract]
        bool deleteCashType(int Id);
        #endregion Observable 收银方式 滕海东
        #region Observable 菜品管理 滕海东
        //查询菜品
        //[OperationContract]
        List<Dish> FindDishs(int  dishId);
        //新增菜品
        [OperationContract]
        Dish AddDish(Dish dish);
        //修改收银方式  返回修改成功后的方式
        [OperationContract]
        bool updateDish(Dish dish);
        //删除收银方式 返回true 为修改成功
        [OperationContract]
        bool deleteDish(int Id, int UpdateBy);
        #endregion Observable 菜品管理 滕海东

        //根据菜品查询菜品
        List<Dish> findAllDishByDishMenusId(int p);

        //加载菜品大类小类
        List<DishType> FindDishTypeByType(int dishTypeId);
    }
}
