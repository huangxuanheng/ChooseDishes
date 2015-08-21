using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Security;
using IShow.ChooseDishes.Utils.Logger;

namespace IShow.ChooseDishes.Service
{
    public  class UserService:IUserService
    {
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> QueryUsers() {
            
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询所有非删除的
                return entities.UserInfo.Where(t => t.Deleted == 0).ToList();
            }
        }

        public List<UserInfo> QueryUserRelations() {
            using (ChooseDishesEntities entities = new ChooseDishesEntities()) {
                return entities.UserInfo.Include(typeof(UserSaleRule).Name).Include(typeof(Employee).Name).Include(typeof(UserSaleRule).Name).Where(t => t.Deleted == 0).ToList();
            }

        }


        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="newPasswd"></param>
       public void ResetPasswd(int userId, string newPasswd) {
           using (ChooseDishesEntities entities = new ChooseDishesEntities()) {
               UserInfo _UserInfo = entities.UserInfo.Find(userId);
               if (_UserInfo.Expired==1) {
                   throw new ServiceException("无法修改已经过期的用户！");
               }
               if (_UserInfo.Disabled == 1)
               {
                   throw new ServiceException("无法修改已经禁用的用户！");
               }
               int authId = SubjectUtils.GetAuthenticationId();
               _UserInfo.Salt = CryptoUtils.GetSalt();
               _UserInfo.Password = CryptoUtils.MD5Encrypt(newPasswd);
               _UserInfo.UpdateBy = authId;
               _UserInfo.UpdateDateTime = DateTime.Now;
               entities.SaveChanges();
               //记录日志
               Log.M(Loggers.USER_RESET_PASSWORD, authId, userId, new object[] { authId, userId });
           }
       }

       

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="employeeId"></param>
       public int Add(int employeeId,string username,string passwd) {
           using (ChooseDishesEntities entities = new ChooseDishesEntities()) {
               Employee employee = entities.Employee.Find(employeeId);
               if (null == employee) {
                   throw new ServiceException("无法找到对应的员工，编号为：【"+employeeId+"】");
               }
               int authorId=SubjectUtils.GetAuthenticationId();
               UserInfo _UserInfo = new UserInfo();
              
               _UserInfo.EmployeeId = employeeId;
               if (null != username || null!=passwd) {
                   _UserInfo.Username = username;
                   _UserInfo.Salt = CryptoUtils.GetSalt();
                   _UserInfo.Password = CryptoUtils.MD5Encrypt(passwd);
                   _UserInfo.CreateBy = SubjectUtils.GetAuthenticationId();
               }
               _UserInfo.CreateDatetime = DateTime.Now;
               entities.UserInfo.Add(_UserInfo);
               try
               {
                   entities.SaveChanges();
                   Log.A(Loggers.USER_NEW, authorId, _UserInfo.UserId);
               }catch(DbEntityValidationException e){
                   throw new ServiceException(e.Message);
               }
               return _UserInfo.UserId;
           }

       }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userId"></param>
       public void Delete(int userId) {
           using (ChooseDishesEntities entities = new ChooseDishesEntities()) {
               UserInfo userInfo = entities.UserInfo.Where(t => t.Deleted == 0 && t.UserId==userId).Single();
               if (null == userInfo) {
                   throw new ServiceException("无法找对删除的用户【"+userId+"】");
               }
               int authId = SubjectUtils.GetAuthenticationId();
               userInfo.Deleted = 1;
               userInfo.UpdateBy = authId;
               userInfo.UpdateDateTime = DateTime.Now;
               entities.SaveChanges();

               Log.M(Loggers.USER_DELETE, authId,userId);
           }

       }

        /// <summary>
        /// 查询所有权限
        /// </summary>
        /// <returns></returns>
       public List<Role> QueryRoles() {
           using (ChooseDishesEntities entities = new ChooseDishesEntities()) {
               return entities.Role.Where(t=>t.Deleted==0).ToList();
           }
       }

       /// <summary>
       /// 查询用户角色
       /// </summary>
       /// <returns></returns>
       public List<UserRoleRef> QueryRolesByUserId(int id)
       {
           using (ChooseDishesEntities entities = new ChooseDishesEntities())
           {
               return entities.UserRoleRef.Where(t => t.Deleted == 0 && t.UserId == id).ToList();
           }
       }


        /// <summary>
        /// 通过用户ID 查询用户
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
      public  UserInfo Find(int userId) {

          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              return entities.UserInfo.Where(t => t.UserId == userId && t.Deleted == 0).SingleOrDefault();
          }
       }

        /// <summary>
        /// 查询用户并返回关联的用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
      public UserInfo FindWithRelation(int userId) {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              return entities.UserInfo.Include(typeof(Employee).Name).Include(typeof(UserSaleRule).Name).Include(typeof(UserRoleRef).Name).Where(t => t.UserId == userId && t.Deleted == 0).SingleOrDefault();
          }

      }



        /// <summary>
        /// 为制定的用户设置角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
      public void Grant(int userId, int[] roles) {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              UserInfo userInfo = entities.UserInfo.Find(userId);
              if (null == userInfo) {
                  throw new ServiceException("未找到对应的用户【"+userId+"】");
              }

              List<UserRoleRef> _RefList = new List<UserRoleRef>();
              int authId=SubjectUtils.GetAuthenticationId();
              DateTime now = DateTime.Now;
              foreach(var r in roles){
                UserRoleRef _ref= new UserRoleRef();
                _ref.RoleId = r;
                _ref.UserId=userId;
                _ref.CreateBy=authId;
                _ref.CreateDateTime=now;
                _RefList.Add(_ref);
              }
              entities.UserRoleRef.AddRange(_RefList);
              entities.SaveChanges();
              
              Log.M(Loggers.USER_GRANT_ROLE, authId, userId, new object[]{roles});
          }
      }

      /// <summary>
      /// 收回权限
      /// </summary>
      /// <param name="userId"></param>
      /// <param name="roles"></param>
      public void Revoke(int userId, int[] roles) {
          using (ChooseDishesEntities entities = new ChooseDishesEntities()) {

              List<UserRoleRef> roleRes = entities.UserRoleRef.Where(t => t.UserId == userId && roles.Any(a=>t.RoleId==a) && t.Deleted == 0).ToList();
              if (null == roleRes || roleRes.Count==0)
              {
                  throw new ServiceException("无法收回不存在的用户【" + userId + "】的角色【" + Convert.ToString(roleRes) + "】！");
              }
              int authId = SubjectUtils.GetAuthenticationId();
              DateTime now = DateTime.Now;
              foreach (var role in roleRes)
              {
                  role.Deleted = 1;
                  role.UpdateBy = authId;
                  role.UpdateDateTime = now;
              }
              entities.SaveChanges();
              Log.M(Loggers.USER_REVOKE_ROLE, authId, userId, new object[] { roles });
          }
      
      }


      /// <summary>
      /// 查询所有可用的权限
      /// </summary>
      /// <returns></returns>
      public List<Function> QueryFunction() {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              return entities.Function.Where(t => t.Deleted == 0).ToList();
          }
      
      }

      /// <summary>
      /// 查询指定模块的功能权限
      /// </summary>
      /// <param name="module">模块名称</param>
      /// <returns></returns>
      public List<Function> QueryFunction(string module)
      {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              return entities.Function.Where(t => t.Deleted == 0 && t.ModuleId == module).ToList();
          }
      }

      /// <summary>
      /// 查询角色权限
      /// </summary>
      /// <param name="roleId">角色编号</param>
      public List<RoleRefFunction> QueryFunctionForRole(int roleId)
      {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              return entities.RoleRefFunction.Where(t => t.Deleted == 0 && t.RoleId == roleId).ToList();
          }
      }
     
      /// <summary>
      /// 给制定的角色赋予权限
      /// </summary>
      /// <param name="roleId">角色编号</param>
      /// <param name="Function">权限ID列表</param>
      public void GrantFunctionForRole(int roleId, String functionId)
      {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              RoleRefFunction rp = new RoleRefFunction();
              int authId = SubjectUtils.GetAuthenticationId();
              rp.Deleted = 0;
              rp.RoleId = roleId;
              rp.FunctionId = functionId;
              rp.CreateBy = authId;
              rp.CreateDateTime = DateTime.Now;
              entities.RoleRefFunction.Add(rp);
              entities.SaveChanges();
          }
      }

      /// <summary>
      /// 收回制定角色的权限
      /// </summary>
      /// <param name="roleId">角色编号</param>
      /// <param name="Function">权限ID列表</param>
      public void RevokeFunctionForRole(int roleId, String functionId)
      {
          using (ChooseDishesEntities entities = new ChooseDishesEntities()) {
              RoleRefFunction p = entities.RoleRefFunction.Where(t => t.RoleId == roleId && t.FunctionId == functionId && t.Deleted == 0).Single();
              if (null == p) {
                  throw new ServiceException("无法找到对应角色【" + roleId + "】的授权编号【" + functionId + "】");
              }
              int authId = SubjectUtils.GetAuthenticationId();
              p.Deleted = 1;
              p.UpdateBy = authId;
              p.UpdateDateTime = DateTime.Now;
              entities.SaveChanges();
          }
      
      }

      /// <summary>
      /// 批量禁用权限
      /// </summary>
      /// <param name="Function"></param>
      public void BatchDisableFunction(String[] Function)
      {
          foreach (var i in Function)
          {
              EnablePremission(i);
          }
      }

      /// <summary>
      /// 批量启用权限
      /// </summary>
      /// <param name="Function"></param>
     public void BatchEnableFunction(String[] Function)
     { 
        foreach(var i in Function){
            EnablePremission(i);
        }
      }

      /// <summary>
      /// 警用权限
      /// </summary>
      /// <param name="premissionId"></param>
     public void DisablePremission(String functionId)
     {
          UpdateFunctiontatus(functionId, 1);
      }
      /// <summary>
      /// 启用权限
      /// </summary>
      /// <param name="premissionId"></param>
      public void EnablePremission(String functionId) {
          UpdateFunctiontatus(functionId, 0);
      
      }


        /// <summary>
        /// 更新权限状态
        /// </summary>
        /// <param name="premissionId">权限编号</param>
        /// <param name="status">权限状态（0，启用，1禁用）</param>
      private void UpdateFunctiontatus(String FunctionId, int status)
      {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {

              Function pre = entities.Function.Where(t => t.Id == FunctionId).Single();
              if (null == pre)
              {
                  throw new ServiceException("无法找到指定的权限【" + FunctionId + "】");
              }
              int authId = SubjectUtils.GetAuthenticationId();
              DateTime now = DateTime.Now;
              pre.Disabled = status;
              entities.SaveChanges();
          }
      
      }

      /// <summary>
      /// 批量禁用角色
      /// </summary>
      /// <param name="roles"></param>
      public void BatchDisableRoles(int[] roles) {
          foreach (var r in roles)
          {
              EnableRole(r);
          }
      }

      /// <summary>
      /// 批量启用角色
      /// </summary>
      /// <param name="roles"></param>
      public void BatchEnableRoles(int[] roles) {
          foreach (var r in roles) {
              DisableRole(r);
          }
      }


      /// <summary>
      /// 禁用角色
      /// </summary>
      /// <param name="roleId"></param>
      public void DisableRole(int roleId) {
          UpdateRoleStatus(roleId, 0);
          int authId = SubjectUtils.GetAuthenticationId();
          Log.M(Loggers.USER_ENABLE_ROLE, authId, roleId);
      
      }
      /// <summary>
      /// 启用角色
      /// </summary>
      /// <param name="roleId"></param>
      public void EnableRole(int roleId) {
          UpdateRoleStatus(roleId, 0);
          int authId = SubjectUtils.GetAuthenticationId();
          Log.M(Loggers.USER_ENABLE_ROLE, authId, roleId);
      
      }

      private void UpdateRoleStatus(int roleId, int status)
      {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {

              Role role = entities.Role.Where(t => t.RoleId == roleId).Single();
              if (null == role)
              {
                  throw new ServiceException("无法找到指定的角色【" + roleId + "】");
              }
              int authId = SubjectUtils.GetAuthenticationId();
              DateTime now = DateTime.Now;
              role.Deleted = status;
              role.UpdateBy = authId;
              entities.SaveChanges();
          }
      }
      /// <summary>
      /// 删除角色
      /// </summary>
      /// <param name="roleId"></param>
      public void DeleteRole(int roleId)
      {
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {

              Role role = entities.Role.Where(t => t.RoleId == roleId).Single();
              if (null == role)
              {
                  throw new ServiceException("无法找到指定的角色【" + roleId + "】");
              }
              int authId = SubjectUtils.GetAuthenticationId();
              DateTime now = DateTime.Now;
              role.Deleted = 1;
              role.UpdateBy = authId;
              entities.SaveChanges();
             // Log.M(Loggers.USER_DELETE_ROLE, authId, roleId);

          }
          
         
      }


      public void SaveOnUpdateForUserSaleRule(int userId, UserSaleRule saleRule) {
          if (null == saleRule) {
              throw new ServiceException("参数【saleRule】不能为空！");
          }
          using (ChooseDishesEntities entities = new ChooseDishesEntities())
          {
              try
              {
                  UserSaleRule savedSaleRule = entities.UserSaleRule.Where(t => t.Deleted == 0 && t.UserId == userId).SingleOrDefault();
                  //不存在销售规则，则抛出异常
                  if (savedSaleRule == null)
                  {
                      savedSaleRule = new UserSaleRule();
                      try
                      {
                          savedSaleRule.CreateBy = SubjectUtils.GetAuthenticationId();
                          savedSaleRule.CreateDatetime = DateTime.Now;
                          saleRule.UserId = userId;
                          saleRule.CreateBy = SubjectUtils.GetAuthenticationId();
                          saleRule.CreateDatetime = DateTime.Now;
                          entities.UserSaleRule.Add(saleRule);
                          entities.SaveChanges();
                      }
                      catch (DbUpdateException e) {
                          e.ToString();
                      }
                      
                  }
                  else
                  {
                    //  savedSaleRule.DiscountAllowanceLimit = saleRule.DiscountAllowanceLimit;
                      savedSaleRule.DiscountLimit = saleRule.DiscountLimit;
                      savedSaleRule.AlowanceType = saleRule.AlowanceType;
                      savedSaleRule.AllowanceLimit = saleRule.AllowanceLimit;
                      savedSaleRule.PresentType = saleRule.PresentType;
                      savedSaleRule.PresentLimit = saleRule.PresentLimit;
                      savedSaleRule.UpdateDatetime = DateTime.Now;
                      savedSaleRule.UpdateBy = SubjectUtils.GetAuthenticationId();
                      entities.SaveChanges();
                  }
              }
              catch (DbEntityValidationException e) {
                  e.ToString();
              }
          }
      
      }

      

      /// <summary>
      /// 删除用户销售规则
      /// </summary>
      /// <param name="userId"></param>
     public void RemoveSaleRuleByUserId(int userId) {
         using (ChooseDishesEntities entities = new ChooseDishesEntities())
         {
             UserSaleRule saleRule = entities.UserSaleRule.Where(t => t.UserId == userId && t.Deleted == 0).Single();
             if (null == saleRule) {
                 return;
             }
             int authId = SubjectUtils.GetAuthenticationId();
             DateTime now = DateTime.Now;
             saleRule.Deleted = 1;
             saleRule.UpdateBy = authId;
             entities.SaveChanges();
         }
      }

     public void AddRole(string name, string Description) {

             using (ChooseDishesEntities entities = new ChooseDishesEntities())
             {
                 Role _Role = new Role();
                 _Role.Name = name;
                 _Role.Description = Description;
                 _Role.CreateBy = SubjectUtils.GetAuthenticationId();
                 _Role.CreateDateTime = DateTime.Now;
                 entities.Role.Add(_Role);
                 entities.SaveChanges();
             }
        
     }

     public int AddRoleOutId(string name, string Description)
     {

         using (ChooseDishesEntities entities = new ChooseDishesEntities())
         {
             Role _Role = new Role();
             _Role.Name = name;
             _Role.Description = Description;
             _Role.CreateBy = SubjectUtils.GetAuthenticationId();
             _Role.CreateDateTime = DateTime.Now;
             entities.Role.Add(_Role);
             entities.SaveChanges();
             return _Role.RoleId;
         }

     }
     /// <summary>
     /// 获取模块并查询模块对应的功能
     /// </summary>
     /// <returns></returns>
     public List<Module> QueryModuleWithFunctions() {
         using (ChooseDishesEntities entities = new ChooseDishesEntities())
         {
            return entities.Module.Include(typeof(Function).Name).Where(t => t.Deleted == 0).ToList();
         }
        
     }

     /// <summary>
     /// 获取所有模块
     /// </summary>
     /// <returns></returns>
    public  List<Module> QueryModules() {
         using (ChooseDishesEntities entities = new ChooseDishesEntities())
         {
             return entities.Module.Where(t => t.Deleted == 0).ToList();
         }
     }

    /// <summary>
    /// 获取所有父模块
    /// <para>get all of root Module from table Module where ParentId=null</para>
    /// </summary>
    /// <returns>return the list of root Module object which is not null ,else if return null</returns>
    public List<Module> QueryModulesParent()
    {
        using (ChooseDishesEntities entities = new ChooseDishesEntities())
        {
            return entities.Module.Where(t => t.Deleted == 0 && (t.ParentId == null)).ToList();
        }
    }

    /// <summary>
    /// 根据模块父模块获取所有子模块
    /// <para>get all of sub Module from table Module where ParentId=parentId</para>
    /// </summary>
    /// <returns>return the list of sub Module object which is not null ,else if return null</returns>
    public List<Module> QueryModulesByParentId(string parentId)
    {
        using (ChooseDishesEntities entities = new ChooseDishesEntities())
        {
            return entities.Module.Where(t => t.Deleted == 0 && (t.ParentId.Equals(parentId))).ToList();
        }
    }

   }
}
