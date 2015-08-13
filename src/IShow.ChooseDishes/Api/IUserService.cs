using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Data;

namespace IShow.ChooseDishes.Api
{
    public   interface IUserService
    {

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        List<UserInfo> QueryUsers();

        /// <summary>
        /// 查询用户，并查询关联关系
        /// </summary>
        /// <returns></returns>
        List<UserInfo> QueryUserRelations();

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newPasswd"></param>
        void ResetPasswd(int userId, string newPasswd);

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>用户ID</returns>
        int Add(int employeeId,string username,string passwd);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
        void Delete(int userId);

        /// <summary>
        /// 查询所有权限
        /// </summary>
        /// <returns></returns>
        List<Role> QueryRoles();

        /// <summary>
        /// 通过用户ID 查询用户
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserInfo Find(int userId);

        /// <summary>
        /// 查询用户并返回关联的用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserInfo FindWithRelation(int userId);


        /// <summary>
        /// 为制定的用户设置角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        void Grant(int userId, int[] roles);

        /// <summary>
        /// 收回权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        void Revoke(int userId, int[] roles);


        /// <summary>
        /// 查询所有可用的权限
        /// </summary>
        /// <returns></returns>
        List<Function> QueryFunction();

        /// <summary>
        /// 查询指定模块的功能权限
        /// </summary>
        /// <param name="module">模块名称</param>
        /// <returns></returns>
        List<Function> QueryFunction(string module);

        List<RoleRefFunction> QueryFunctionForRole(int roleId);

        /// <summary>
        /// 给制定的角色赋予权限
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="Function">权限ID列表</param>
        void GrantFunctionForRole(int roleId, String Function);

        /// <summary>
        /// 收回制定角色的权限
        /// </summary>
        /// <param name="roleId">角色编号</param>
        /// <param name="Function">权限ID列表</param>
        void RevokeFunctionForRole(int roleId, String Function);

        /// <summary>
        /// 批量禁用权限
        /// </summary>
        /// <param name="Function"></param>
        void BatchDisableFunction(String[] Function);

        /// <summary>
        /// 批量启用权限
        /// </summary>
        /// <param name="Function"></param>
        void BatchEnableFunction(String[] Function);

        /// <summary>
        /// 警用权限
        /// </summary>
        /// <param name="premissionId"></param>
        void DisablePremission(String premissionId);

        /// <summary>
        /// 启用权限
        /// </summary>
        /// <param name="premissionId"></param>
        void EnablePremission(String premissionId);

        /// <summary>
        /// 批量禁用角色
        /// </summary>
        /// <param name="roles"></param>
        void BatchDisableRoles(int[] roles);

        /// <summary>
        /// 批量启用角色
        /// </summary>
        /// <param name="roles"></param>
        void BatchEnableRoles(int[] roles);


        /// <summary>
        /// 禁用角色
        /// </summary>
        /// <param name="roleId"></param>
        void DisableRole(int roleId);


        /// <summary>
        /// 启用角色
        /// </summary>
        /// <param name="roleId"></param>
        void EnableRole(int roleId);
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        void DeleteRole(int roleId);

        #region 用户销售规则



        /// <summary>
        /// 为指定的用户添加销售规则
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="saleRule"></param>
        void SaveOnUpdateForUserSaleRule(int userId, UserSaleRule saleRule);

        /// <summary>
        /// 删除用户销售规则
        /// </summary>
        /// <param name="userId"></param>
        void RemoveSaleRuleByUserId(int userId);

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Description"></param>
        void AddRole(string name, string Description);
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Description"></param>
        /// <returns>roleId</returns>
        int AddRoleOutId(string name, string Description);

        /// <summary>
        /// 获取模块并查询模块对应的功能
        /// </summary>
        /// <returns></returns>
        List<Module> QueryModuleWithFunctions();

        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <returns></returns>
        List<Module> QueryModules();

        #endregion

        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <returns></returns>
        List<Module> QueryModulesParent();
        /// <summary>
        /// 根据模块父模块获取所有子模块
        /// <para>get all of sub Module from table Module where ParentId=parentId</para>
        /// </summary>
        /// <returns>return the list of sub Module object which is not null ,else if return null</returns>
        List<Module> QueryModulesByParentId(string parentId);
       

    }
}
