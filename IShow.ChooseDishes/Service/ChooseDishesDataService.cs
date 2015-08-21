using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Security;
using IShow.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                local = entities.Location.Where(Location => Location.Deleted == 0).ToList();
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
                else
                {
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
                else
                {
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
            List<Bearing> result;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                result = entities.Bearing.Where(Bearing => Bearing.Deleted == 0).ToList();
            }
            return result;
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
                else
                {
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
                else
                {
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



        #region Observable 套菜管理 阙进午
        public List<Dish> queryByDish(Dish dish)
        {
            List<Dish> result;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询条件
                Expression<Func<Dish, bool>> checkCourse = Dish => Dish.PackagesConfirm == 1 && Dish.Deleted==0;
                result = entities.Dish.Include(t => t.DishPrice).Include(t => t.DishUnit).Where(checkCourse).ToList();
             }
            return result;
        }

        #endregion Observable 套菜管理 阙进午

        #region Observable 道菜管理 阙进午
        public List<DishDao> queryByDishDaoID(DishDao dish)
        {
            List<DishDao> result;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询条件
                Expression<Func<DishDao, bool>> checkCourse = DishDao => DishDao.DishId == dish.DishId && DishDao.Deleted == 0 && DishDao.Status == 0;
                result = entities.DishDao.Include(t =>t.Dish).Where(checkCourse).ToList();
            }
            return result;
        }

        public int EditByDishDao(DishDao dish)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询道菜是否存在
                var type = entities.DishDao.SingleOrDefault(bt => bt.DishDaoId == dish.DishDaoId && bt.Deleted == 0);
                if (type != null)
                {
                    //设置属性是否参与修改 ，设置为false则无法更新数据
                    type.Name = dish.Name;
                    type.OptionalNumber = dish.OptionalNumber;
                    type.UpdateDatetime = dish.UpdateDatetime;
                    type.UpdateBy = dish.UpdateBy;
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
                    entities.DishDao.Add(dish);
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
        //删除道菜
        public int delDishDao(DishDao dishDao)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //直接修改的方式
                DbEntityEntry<DishDao> entry = entities.Entry<DishDao>(dishDao);
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

        #endregion Observable 道菜管理 阙进午

        #region Observable 道菜明细管理 阙进午
        public int EditByDishDetail(DishDetail dish)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询道菜是否存在
                var type = entities.DishDetail.SingleOrDefault(bt => bt.DishDetailId == dish.DishDetailId && bt.Deleted == 0);
                if (type != null)
                {
                    //设置属性是否参与修改 ，设置为false则无法更新数据
                    type.Num = dish.Num;
                    type.IsMain = dish.IsMain;
                    type.UpdateDatetime = dish.UpdateDatetime;
                    type.UpdateBy = dish.UpdateBy;
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
                    entities.DishDetail.Add(dish);
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

        //根据菜品ID查询菜品
        public Dish queryByDishId(int dishID)
        {
            Dish result;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询条件
                Expression<Func<Dish, bool>> checkCourse = Dish => Dish.DishId==dishID && Dish.Deleted == 0;
                result = entities.Dish.Include(t => t.DishPrice).Where(checkCourse).Single();
            }
            return result;
        }

        //根据道菜ID查询道菜明细主菜品
        public DishDetail queryByDishDetail(int dishDetailID)
        {
            List<DishDetail> result;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询条件
                Expression<Func<DishDetail, bool>> checkCourse = Dish => Dish.DishDaoId == dishDetailID && Dish.IsMain == 1 && Dish.Deleted == 0;
                result = entities.DishDetail.Where(checkCourse).ToList(); ;
            }
            if (result != null && result.Count > 0) {
                return result[0];
            }
            return null;
        }


        //删除道菜明细
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"> 0按主键ID删除，1，按道菜编号删除</param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public int delDishDetail(int Id,int Type)
        {
            int flag = 0;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                Expression<Func<DishDetail, bool>> checkCourse = Detail => Detail.DishDetailId == Id&&Detail.Deleted==0;
               //先查询 后修改
                
                if (Type == 1) {
                    checkCourse = Detail => Detail.DishDaoId == Id && Detail.Deleted == 0;
                }

                List<DishDetail> type = entities.DishDetail.Where(checkCourse).ToList();
                if (type != null&&type.Count>0) {
                    foreach (var t in type) {
                        t.UpdateBy = SubjectUtils.GetAuthenticationId();
                        t.UpdateDatetime = DateTime.Now;
                        t.Deleted = 1;
                        //直接修改的方式
                        DbEntityEntry<DishDetail> entry = entities.Entry<DishDetail>(t);
                        entry.State = System.Data.Entity.EntityState.Modified;
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
                }
            }
            return flag;
        }

        public List<DishDetail> queryByDishDetail(DishDetail detail)
        {
            List<DishDetail> result;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //查询条件
                Expression<Func<DishDetail, bool>> checkCourse = DishDetail => DishDetail.DishDaoId == detail.DishDaoId && DishDetail.Deleted == 0;
                result = entities.DishDetail.Include(t => t.Dish).Include(t => t.DishDao).Include(t => t.Dish.DishPrice).Include(t => t.Dish.DishUnit).Where(checkCourse).ToList();
            }
            return result;
        }

        #endregion Observable 道菜明细管理 阙进午

        public IEnumerable<string> GetAllName()
        {
            yield return "test1";
            yield return "test2";
            yield return "test3";
        }

        #region Observable 收银方式 滕海东
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
                    list = entities.CashType.Where(CashType => CashType.Deleted == 0).ToList();
                }
                else
                {
                    list = entities.CashType.Where(CashType => (CashType.Deleted == 0) && (CashType.CashBaseTypeId == CashBaseTypeId)).ToList();
                }

            }
            return list;
        }
        //添加收银方式 返回添加成功后的收银方式
        public CashType addCashType(CashType cashType)
        {
            //try
            //{
                if (cashType == null)
                {
                    return null;
                }
                CashType newCashType = null;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    //快捷键不能相同 编号不能相同
                        var list = entities.CashType.Where(bt =>bt.Deleted==0 && (bt.Code == cashType.Code) || (bt.Keys == cashType.Keys)).ToList() ;
                    if (list != null&&list.Count>0)
                    {
                        return null;
                    }
                    entities.CashType.Add(cashType);
                    entities.SaveChanges();
                    var typenew = entities.CashType.SingleOrDefault(bt => bt.Code == cashType.Code);
                    if (typenew != null)
                    {
                        newCashType = typenew;
                    }
                }
                return newCashType;
            //}
            //catch (Exception e)
            //{
            //    e.ToString();
            //    return null;
            //}
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

                        if (!type.Keys.Equals(cashType.Keys)) {
                            var type1 = entities.CashType.Where(bt => bt.Keys == cashType.Keys).ToList();
                            if (type1.Count > 1) { 
                                return null;
                            }

                        }
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
        #endregion Observable 收银方式 滕海东
        #region Observable 菜品管理 滕海东
        /**
         * 传入参数为 菜品类型id ,如果菜品类型id 为null 那么查询全部
         * 如果传入菜品类型id不为空,则先查找菜品小类 ,如果有菜品小类,者根据菜品小类集合匹配
         * 如果没有菜品小类,则直接将菜品类型id作为菜品小类id 查询 .
         * 
         * 
         * 
         */
        public List<Dish> FindDishs(int DishTypeId)
        {

            List<Dish> list;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {

                if (DishTypeId == 0)

                {
                    list = entities.Dish.Where(Dish => Dish.Deleted == 0).Include(bt => bt.DishPrice).Include(bt => bt.DishUnit).Include(bt => bt.DishType).ToList();
                }
                else
                {
                    //先查找菜品小类
                    List<DishType> listDC = LoadTypeByParentId(DishTypeId);
                    if (listDC != null && listDC.Count > 0 )
                    {
                        List<int> DishTypeIds = new List<int>();
                        foreach (var element in listDC)
                        {
                            DishTypeIds.Add(element.DishTypeId);
                        }
                        list = entities.Dish.Where(Dish => Dish.Deleted == 0 && DishTypeIds.Contains(Dish.DishTypeId)).Include(bt => bt.DishPrice).Include(bt => bt.DishUnit).Include(bt => bt.DishType).ToList();
                    }
                    else
                    {
                        list = entities.Dish.Where(Dish => Dish.Deleted == 0 && Dish.DishTypeId == DishTypeId).Include(bt => bt.DishPrice).Include(bt => bt.DishUnit).Include(bt => bt.DishType).ToList();

                    }
                }

            }
            return list;
        }

        //根据菜品id 查询菜品对象
        public Dish FindDishByDishId(int dishId) {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.Dish.SingleOrDefault(bt => bt.DishId == dishId);
                return type;
            }
        
        }
        //查询可做道菜的菜品
        public List<Dish> FindDishPackages(int DishTypeId)
        {

            List<Dish> list;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {

                if (DishTypeId > 0)
                {
                    list = entities.Dish.Include(bt => bt.DishPrice).Where(Dish => Dish.Deleted == 0 && Dish.DishTypeId == DishTypeId && Dish.DischesType == 1 && Dish.PackagesConfirm == 1).ToList();
                }
                else
                {
                    //先查找菜品小类
                    List<DishType> listDC = LoadTypeByParentId(DishTypeId);
                    if (listDC != null && listDC.Count > 0)
                    {
                        List<int> DishTypeIds = new List<int>();
                        foreach (var element in listDC)
                        {
                            DishTypeIds.Add(element.DishTypeId);
                        }
                        list = entities.Dish.Where(Dish => Dish.Deleted == 0 && Dish.DischesType == 1 && Dish.PackagesConfirm == 1 && DishTypeIds.Contains(Dish.DishTypeId)).Include(bt => bt.DishPrice).ToList();
                    }
                    else
                    {
                        list = entities.Dish.Where(Dish => Dish.Deleted == 0 && Dish.DischesType == 1 && Dish.PackagesConfirm == 1 && Dish.DishTypeId == DishTypeId).Include(bt => bt.DishPrice).ToList();

                    }
                }

            }
            return list;
        }

        //根据菜品父id 查询子类集合
        public List<DishType> LoadTypeByParentId(int ParentId)
        {
            
            List<DishType> types;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                types = entities.DishType.Where(info => info.Deleted == 0 && (ParentId == 0 ? info.ParentId == null : info.ParentId == ParentId)).ToList();
                if (types == null || types.Count == 0)
                {
                    types = new List<DishType>();
                }
                return types;
            };
        }
        //新增菜品
        public Dish AddDish(Dish dish)
        {
            //try
            //{
                if (dish == null || dish.Code == null)
                {
                    return null;
                }
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    var type = entities.Dish.SingleOrDefault(bt =>bt.Deleted == 0 && bt.Code == dish.Code);
                    if (type != null)
                    {
                        return null;
                    }
                    entities.Dish.Add(dish);
                    //关闭实体验证，不关闭验证需要整个对象全部传值
                    entities.Configuration.ValidateOnSaveEnabled = false;
                    entities.SaveChanges();
                }
                return dish;
            //}
            //catch (Exception e)
            //{
            //    e.ToString();
            //    return null;
            //}
        }
        //修改收银方式  返回修改成功后的方式
        public bool updateDish(Dish dish)
        {
            if (dish == null)
            {
                return false;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                dish.UpdateDatetime = DateTime.Now;
                var type = entities.Dish.SingleOrDefault(bt => bt.DishId == dish.DishId);
                if (type != null)
                {
                    type.AidNumber = dish.AidNumber;
                    type.DischesType = dish.DischesType;
                    type.DiscountConfirm = dish.DiscountConfirm;
                    type.DishFormat = dish.DishFormat;
                    type.DishName = dish.DishName;
                    type.DishUnitId = dish.DishUnitId;
                    type.EnglishName = dish.EnglishName;
                    type.FoodFight = dish.FoodFight;
                    type.IsStop = dish.IsStop;
                    type.KitchenType = dish.KitchenType;
                    type.LineConfirm = dish.LineConfirm;
                    type.LowConsumerConfirm = dish.LowConsumerConfirm;
                    type.PackagesConfirm = dish.PackagesConfirm;
                    type.PingYing = dish.PingYing;
                    type.PosConfirm = dish.PosConfirm;
                    type.PriceTimeConfirm = dish.PriceTimeConfirm;
                    type.PublisherType = dish.PublisherType;
                    type.SanpConfirm = dish.SanpConfirm;
                    type.Status = dish.Status;
                    type.ServerfreeConsumer = dish.ServerfreeConsumer;
                    type.UpdateBy = SubjectUtils.GetAuthenticationId();
                    type.UpdateDatetime = dish.UpdateDatetime;
                    type.WeightConfirm = dish.WeightConfirm;

                    int num = entities.SaveChanges();
                    return num == 0 ? false : true;
                }

                return false;
               
            }
        }
        //删除收银方式 返回true 为修改成功
        public bool deleteDish(int Id)
        {
            try
            {
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    var type = entities.Dish.SingleOrDefault(bt => bt.DishId == Id);
                    if (type != null)
                    {
                        type.Deleted = 1;
                        type.UpdateDatetime = DateTime.Now;
                        type.UpdateBy = SubjectUtils.GetAuthenticationId();
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

        public List<Dish> findAllDishByDishMenusId(int p) {
            List<Dish> list = null;
            using (ChooseDishesEntities entities = new ChooseDishesEntities()) { 
                //先查询菜牌关联表
                List<DishesMenuRef> listref = findDishesMenuRefByMenusId(p);
                if (listref != null) {
                    List<int> listint = new List<int>();
                    foreach (var element in listref) {
                        listint.Add(element.DishId);
                    }
                    list = entities.Dish.Include(bt => bt.DishUnit ).Include(bt=>bt.DishPrice).Where(bt => listint.Contains(bt.DishId)).ToList();
                }
            
            }
            return list;
        }
        public List<DishesMenuRef> findDishesMenuRefByMenusId(int DishMenusId)
        {
            List<DishesMenuRef> list;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                list = entities.DishesMenuRef.Where(bt => bt.MenusId == DishMenusId).ToList();
            }
            return list;
            
        }

        public List<DishType> FindDishTypeByType(int dishTypeId) {
            List<DishType> list;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                list = entities.DishType.Where(bt => bt.Deleted == 0 && (dishTypeId == 0 ? bt.ParentId == null : (dishTypeId == -1 ? bt.ParentId != null : bt.ParentId == dishTypeId))).ToList();
            }
            return list;
        
        }
        // FindDishsByDishName 根据菜品名字模糊查找
        public List<Dish> FindDishsByDishName(String value) {
            List<Dish> list;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                list = entities.Dish.Where(bt => bt.Deleted == 0 && (value == null ? true : (bt.DishName.IndexOf(value) >= 0))).Include(bt => bt.DishPrice).Include(bt => bt.DishUnit).Include(bt=>bt.DishType).ToList();
            }
            return list;
        }

        /// <summary>
        /// 查询不是套餐的菜品
        /// </summary>
        /// <param name="ObjectName">可以是 菜品名称 菜品拼音 菜品编码</param>
        /// <returns></returns>
        public List<Dish> FindDishNotTaoCanList(string ObjectName) {
            try 
            {
                List<Dish> list;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    if (ObjectName == null || "".Equals(ObjectName))
                    {
                        list = entities.Dish.Where(bt => bt.Deleted == 0 && bt.PackagesConfirm != 1).Include(bt => bt.DishPrice).Include(bt => bt.DishUnit).Include(bt => bt.DishType).ToList();
                    }
                    else 
                    {
                        list = entities.Dish.Where(bt => bt.Deleted == 0 && bt.PackagesConfirm != 1 && (bt.DishName.IndexOf(ObjectName) >= 0 || bt.Code.Equals(ObjectName) || bt.PingYing.IndexOf(ObjectName) >= 0)).Include(bt => bt.DishPrice).Include(bt => bt.DishUnit).Include(bt => bt.DishType).ToList();
                    }
                }
                return list;

            }
            catch (Exception e) {

                throw new ServiceException("查询非套菜报错!",e);
            
            }
        }

        
        #endregion Observable 菜品管理 滕海东
        #region  菜品价格修改 滕海东
        //根据一个 菜品id 查找菜品所有的价格 
        public List<DishPrice> FindDishPriceByDishId(int DishId)
        {
            List<DishPrice> list;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                list = entities.DishPrice.Where(bt => bt.Deleted == 0 && bt.DishId == DishId ).ToList();
            }
            return list;
        }

        
        //根据 一个 菜品 id 和菜品价格集合 新增 菜品价格 
        public bool SaveDishPrice(int DishId, DishPrice[] dishPrices)
        {
            if (dishPrices != null) {
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    for (int i = 0; i < dishPrices.Length; i++)
                    {

                            entities.DishPrice.Add(dishPrices[i]);
                            entities.SaveChanges();
                        
                    }
                }
               
            }

            return false;
        }
        //根据菜品id 和 菜品价格id 删除菜品价格 
        public bool DeleteDishPrice(DishPrice dishPrice)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.DishPrice.SingleOrDefault(bt => bt.DishId == dishPrice.DishId && bt.IsMainPrice != 1&&bt.Id ==dishPrice.Id);
                if (type != null)
                {
                    type.Deleted = 1;
                    type.Update_by = SubjectUtils.GetAuthenticationId();
                    type.UpdateTime = DateTime.Now;
                    entities.SaveChanges();
                }
            }

            return true;
        }
        //根据菜品id 和 菜品价格id 修改菜品价格 
        public bool UpdateDishPrice(int DishId, DishPrice[] dishPrices)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                foreach (var dishPrice in dishPrices)
                {
                    if (dishPrice.IsMainPrice != 1) { 
                        var type = entities.DishPrice.SingleOrDefault(bt => bt.Id == dishPrice.Id);
                        if (type != null)
                        {
                            type.Price1 = dishPrice.Price1;
                            type.Price2 = dishPrice.Price2;
                            type.Price3 = dishPrice.Price3;
                            type.MemberPrice1 = dishPrice.MemberPrice1;
                            type.MemberPrice2 = dishPrice.MemberPrice2;
                            type.MemberPrice3 = dishPrice.MemberPrice3;
                            type.Update_by = SubjectUtils.GetAuthenticationId();
                            type.UpdateTime = DateTime.Now;
                            entities.SaveChanges();
                        }
                        else {
                            dishPrice.CreateTime = DateTime.Now;
                            entities.DishPrice.Add(dishPrice);
                            entities.SaveChanges();
                        }
                    }
                }

            }
            return true;
        }
        //修改菜品主价格
        public bool UpdateDishPriceMain(DishPrice dishPrice) {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.DishPrice.SingleOrDefault(bt => bt.DishId == dishPrice.DishId && bt.IsMainPrice == 1);
                if (type != null)
                {
                    type.Price1 = dishPrice.Price1;
                    type.Price2 = dishPrice.Price2;
                    type.Price3 = dishPrice.Price3;
                    type.MemberPrice1 = dishPrice.MemberPrice1;
                    type.MemberPrice2 = dishPrice.MemberPrice2;
                    type.MemberPrice3 = dishPrice.MemberPrice3;
                    type.Update_by = SubjectUtils.GetAuthenticationId();
                    type.UpdateTime = DateTime.Now;
                    entities.SaveChanges();
                }
                else 
                {
                    entities.DishPrice.Add(dishPrice);
                    entities.SaveChanges();
                }
            }
            return true;
        
        }
        #endregion

        
        #region  特价菜品价格修改 滕海东

        //查询 特价菜信息  如果传入date 将根据时间查找
        public List<BargainDish> findBargainDishList(DateTime date) {
            List<BargainDish> list = null ;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                if (date != null)
                {
                    list = entities.BargainDish.Where(bt => bt.Deleted == 0 && ((DateTime.Compare(date, bt.StartDate)) >= 0) && ((DateTime.Compare(date, bt.EndDate)) <= 0)).Include(bt => bt.BargainDishPrice).Include(bt=>bt.Dish).Include(bt=>bt.Dish.DishUnit).ToList();
                }
            }
            return list;
        }
        public List<BargainDish> findBargainDishAll() {
            List<BargainDish> list;
            string nowstr = DateTime.Now.ToShortTimeString().ToString();
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                list = entities.BargainDish.Where(bt => bt.Deleted == 0 && ((DateTime.Compare(DateTime.Now, bt.StartDate)) >= 0) && ((DateTime.Compare(DateTime.Now, bt.EndDate)) <= 0) && ((nowstr.CompareTo(bt.StartTime)) >= 0) && ((nowstr.CompareTo(bt.EndTime)) <= 0)).Include(bt => bt.BargainDishPrice).Include(bt => bt.Dish).Include(bt => bt.Dish.DishUnit).ToList();
            }
            return list;
        }
        //修改 特价菜信息
        public bool UpdateBargainDish(BargainDish BDish)
        {
            if (BDish == null) {
                return false;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var  type  = entities.BargainDish.SingleOrDefault(bt=>bt.Id==BDish.Id);
                if (type != null) {
                    type.StartDate = BDish.StartDate;
                    type.EndDate = BDish.EndDate;
                    type.StartTime = BDish.StartTime;
                    type.EndTime = BDish.EndTime;
                    type.Week1 = BDish.Week1;
                    type.Week2 = BDish.Week2;
                    type.Week3 = BDish.Week3;
                    type.Week4 = BDish.Week4;
                    type.Week5 = BDish.Week5;
                    type.Week6 = BDish.Week6;
                    type.Week0 = BDish.Week0;
                    type.MarketTypeId = BDish.MarketTypeId;
                    entities.SaveChanges();
                    BargainDishPrice bdp = BDish.BargainDishPrice.First();
                    int priceId = bdp.Id;
                    if (priceId != 0)
                    {
                        var typeprice = entities.BargainDishPrice.SingleOrDefault(bt => bt.Id == priceId);
                        if (typeprice != null) {
                            typeprice.Price1 = bdp.Price1;
                            typeprice.Price2 = bdp.Price2;
                            typeprice.Price3 = bdp.Price3;
                            typeprice.MemberPrice3 = bdp.MemberPrice3;
                            typeprice.MemberPrice2 = bdp.MemberPrice2;
                            typeprice.MemberPrice1 = bdp.MemberPrice1;
                            entities.SaveChanges();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //删除特价菜品
        public bool DeleteBargainDish(int id, int DishId)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.BargainDish.SingleOrDefault(bt => bt.Id == id && bt.DishId == DishId);
                if (type != null) {
                    type.Deleted = 1;
                    type.Update_by = SubjectUtils.GetAuthenticationId();
                    type.UpdateTime = DateTime.Now;
                    entities.SaveChanges();
                    var typeprice = entities.BargainDishPrice.SingleOrDefault(bt =>bt.BargainDishId == id && bt.Deleted == 0 );
                    if (typeprice != null) {
                        typeprice.Deleted = 1;
                        typeprice.Update_by = SubjectUtils.GetAuthenticationId();
                        typeprice.UpdateTime = DateTime.Now;
                        entities.SaveChanges();
                    }
                    return true;
                }
            }
            return false;
        }
        //批量删除特价菜品 
        public bool BatchDeleteBargainDish(int[] ids)
        {
            return false;
        }
        //
        public bool BatchDeleteBargainDish()
        {
            try { 
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    string str = " update BargainDish set Deleted = 1 , UpdateTime = '" + DateTime.Now + "' , Update_by = "+ SubjectUtils.GetAuthenticationId() + "  where 1 =1 ";
                    entities.Database.ExecuteSqlCommand(str);
                    string strprice = " update BargainDishPrice set Deleted = 1 , UpdateTime = '" + DateTime.Now + "' , Update_by = " + SubjectUtils.GetAuthenticationId() + "  where 1 =1 ";
                    entities.Database.ExecuteSqlCommand(strprice);
                    return true;
                
                }
            }
            catch (Exception e) { 
            }
            return false;
        }
        public List<BargainDish> BatchSaveBargainDish(BargainDish[] DBDishes)
        {
            if (DBDishes != null && DBDishes.Length > 0) {
                List<BargainDish> list = new List<BargainDish>();
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    foreach (var element in DBDishes) {
                        
                        entities.BargainDish.Add(element);
                        entities.SaveChanges();
                        //foreach (var elem in element.BargainDishPrice) { 
                        //    elem.BargainDishId = element.Id;
                        //    entities.BargainDishPrice.Add(elem);
                        //    entities.SaveChanges();
                        //}
                        list.Add(element);
                    }
                    return list;
                }
            }

            return null;
        }
        /// <summary>
        /// 
        /// 加载所有有效的特价菜品
        /// </summary>
        /// <returns></returns>
        public List<BargainDish> findBargainDishAllAll() {
            List<BargainDish> list;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                //&& ((DateTime.Compare(DateTime.Now, bt.StartDate)) >= 0) && ((DateTime.Compare(DateTime.Now, bt.EndDate)) <= 0) && ((DateTime.Compare(DateTime.Now, bt.StartTime)) >= 0) && ((DateTime.Compare(DateTime.Now, bt.EndTime)) <= 0)
                list = entities.BargainDish.Where(bt => bt.Deleted == 0 && ((DateTime.Compare(DateTime.Now, bt.EndDate)) <= 0)).Include(bt => bt.BargainDishPrice).Include(bt => bt.Dish).Include(bt => bt.Dish.DishUnit).ToList();
            }
            return list;
        }
        #endregion Observable 特价菜品管理 滕海东

        #region Observable 菜品促销管理 滕海东

        //菜品促销条目查询
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="startDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="status">状态 -1 表示查询全部  	1 为 未审核 2 为审核 3 为作废</param>
        /// <returns></returns>
        public List<PromotionsDish> FindPromotionsDishByObject(DateTime? startDate, DateTime? endDate, int status) {
            List<PromotionsDish> list;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                if (startDate == null && endDate==null)
                {
                    list = entities.PromotionsDish.Where(bt => bt.Deleted == 0 && status == -1 ? true : bt.Status == status).Include(bt => bt.PromotionsDishDetail).Include(bt => bt.Dish).ToList();
                }
                else if (startDate == null && endDate != null) {
                    DateTime nowDate = endDate ?? DateTime.Now;
                    list = entities.PromotionsDish.Where(bt => bt.Deleted == 0 && status == -1 ? true : bt.Status == status && DateTime.Compare(bt.EndDate, nowDate) < 0).Include(bt => bt.PromotionsDishDetail).Include(bt => bt.Dish).ToList();
                }
                else if (startDate != null && endDate == null) {
                    DateTime nowDate = startDate ?? DateTime.Now;
                    list = entities.PromotionsDish.Where(bt => bt.Deleted == 0 && status == -1 ? true : bt.Status == status && DateTime.Compare(bt.StartDate, nowDate) > 0).Include(bt => bt.PromotionsDishDetail).Include(bt => bt.Dish).ToList();
                }
                else if (startDate != null && endDate != null)
                {
                    DateTime nowStartDate = startDate ?? DateTime.Now;
                    DateTime nowEndDate = endDate ?? DateTime.Now;
                    list = entities.PromotionsDish.Where(bt => bt.Deleted == 0 && status == -1 ? true : bt.Status == status && DateTime.Compare(bt.StartDate, nowStartDate) > 0 && DateTime.Compare(bt.EndDate, nowEndDate) < 0).Include(bt => bt.PromotionsDishDetail).Include(bt => bt.Dish).ToList();
                }
                else {
                    return null;
                }
            }
            return list;

        }
        //删除促销条目
        public bool DeletePromotionsDishByPdID(int PromotionsDishId, int DishId) {
            return false;
        }
        //新增促销条目
        public PromotionsDish SavePromotionsDish(PromotionsDish PD)
        {
            if (PD == null) {
                return null;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                entities.PromotionsDish.Add(PD);
                entities.SaveChanges();
                //foreach (var elem in element.BargainDishPrice) { 
                //    elem.BargainDishId = element.Id;
                //    entities.BargainDishPrice.Add(elem);
                //    entities.SaveChanges();
                //}
                return PD;
            }
        }
        //审核促销条目
        public bool CheckPromotionsDish(int PromotionsDishId, int DishId ,int status) {

            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.PromotionsDish.Include(bt=>bt.PromotionsDishDetail).SingleOrDefault(bt => bt.PromotionsDishId == PromotionsDishId && bt.DishId == DishId && bt.Status ==1);
                if (type != null) {
                    type.Status = status;
                    type.UpdateBy = SubjectUtils.GetAuthenticationId();
                    type.UpdateDatetime = DateTime.Now;
                    entities.SaveChanges();
                    foreach (var element in type.PromotionsDishDetail) {
                        element.Status = status;
                        element.UpdateBy = SubjectUtils.GetAuthenticationId();
                        element.UpdateDatetime = DateTime.Now;
                        entities.SaveChanges();
                    }
                }
                
                return true;
            }
        }
        //停用/启用  促销条目
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <param name="PromotionsDishId"></param>
        /// <param name="DishId"></param>
        /// <param name="?"></param>
        /// <param name="status"> 0 为启用 1 为停用  </param>
        /// <returns></returns>
        public bool StartOrStopPromotionsDish(int PromotionsDishId, int DishId, int status)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.PromotionsDish.Include(bt => bt.PromotionsDishDetail).SingleOrDefault(bt => bt.PromotionsDishId == PromotionsDishId && bt.DishId == DishId );
                if (type != null)
                {
                    type.Usering = status;
                    type.UpdateBy = SubjectUtils.GetAuthenticationId();
                    type.UpdateDatetime = DateTime.Now;
                    entities.SaveChanges();
                }

                return true;
            }
        }
        //复制促销条目
        public PromotionsDish CopyPromotionsDish(int PromotionsDishId, int DishId) {
            PromotionsDish copyPD = null ;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.PromotionsDish.Include(bt => bt.PromotionsDishDetail).SingleOrDefault(bt => bt.PromotionsDishId == PromotionsDishId && bt.DishId == DishId);
                if (type != null)
                {
                    copyPD = CreateCopyPromotionsDish(type);
                    entities.PromotionsDish.Add(copyPD);
                    entities.SaveChanges();
                    List<PromotionsDishDetail> list = type.PromotionsDishDetail.ToList();
                    //促销菜品组装
                    for (int i = 0; i < list.Count;i++ )
                    {
                        if (list[i].Deleted == 0) { 
                            PromotionsDishDetail beanBackDetail = new PromotionsDishDetail();
                            beanBackDetail.PromotionsDishId = copyPD.PromotionsDishId;
                            beanBackDetail.DishId =  list[i].DishId;
                            beanBackDetail.DishNumber =  list[i].DishNumber;
                            beanBackDetail.DishFormat =  list[i].DishFormat;
                            beanBackDetail.CreateDatetime = copyPD.CreateDatetime;
                            beanBackDetail.CreateBy = copyPD.CreateBy;
                            beanBackDetail.Deleted = 0;
                            beanBackDetail.Status = 1;
                            entities.PromotionsDishDetail.Add(beanBackDetail);
                            entities.SaveChanges();
                        }
                    }
                }

                return copyPD;
            }
        }
        public PromotionsDish CreateCopyPromotionsDish(PromotionsDish bean){
            PromotionsDish beanBack = new PromotionsDish();
            beanBack.TradeNo = DateTime.Now.ToString("yyyyMMddhhmmss");
            beanBack.DishId = bean.DishId;
            beanBack.MarketTypeId = bean.MarketTypeId;
            beanBack.DishFormat = bean.DishFormat;
            beanBack.Price = bean.Price;
            beanBack.StartTime = bean.StartTime;
            beanBack.EndTime = bean.EndTime;
            beanBack.StartDate = bean.StartDate;
            beanBack.EndDate = bean.EndDate;
            beanBack.Week_1 = bean.Week_1;
            beanBack.Week_2 = bean.Week_2;
            beanBack.Week_3 = bean.Week_3;
            beanBack.Week_4 = bean.Week_4;
            beanBack.Week_5 = bean.Week_5;
            beanBack.Week_6 = bean.Week_6;
            beanBack.Week_0 = bean.Week_0;
            beanBack.Status = 1;
            beanBack.Usering = 0;
            beanBack.CreateDatetime = DateTime.Now;
            beanBack.CreateBy = SubjectUtils.GetAuthenticationId();
            beanBack.Deleted = 0;
            
            return beanBack;
        }

        public bool UpdatePromotionsDish(PromotionsDish PD) {

            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.PromotionsDish.Include(bt => bt.PromotionsDishDetail).SingleOrDefault(bt => bt.Deleted == 0 && bt.PromotionsDishId == PD.PromotionsDishId );
                if (type != null)
                {
                    type.DishId = PD.DishId;
                    type.DishFormat = PD.DishFormat;
                    type.Price = PD.Price;
                    type.StartTime = PD.StartTime;
                    type.EndTime = PD.EndTime;
                    type.StartDate = PD.StartDate;
                    type.EndDate = PD.EndDate;
                    type.Week_1 = PD.Week_1;
                    type.Week_2 = PD.Week_2;
                    type.Week_3 = PD.Week_3;
                    type.Week_4 = PD.Week_4;
                    type.Week_5 = PD.Week_5;
                    type.Week_6 = PD.Week_6;
                    type.Week_0 = PD.Week_0;
                    type.Usering = PD.Usering;
                    type.UpdateBy = SubjectUtils.GetAuthenticationId();
                    type.UpdateDatetime = DateTime.Now;
                    List<PromotionsDishDetail> list = type.PromotionsDishDetail.ToList();
                    for (int i = 0; i < list.Count; i++)
                    {
                        list[i].Deleted = 1;
                        list[i].UpdateBy = SubjectUtils.GetAuthenticationId();
                        list[i].UpdateDatetime = DateTime.Now;
                    }
                    entities.SaveChanges();
                    
                    List<PromotionsDishDetail> listnew = PD.PromotionsDishDetail.ToList();
                    for (int i = 0; i < listnew.Count; i++) {
                        listnew[i].PromotionsDishId = type.PromotionsDishId;
                        listnew[i].PromotionsDish = null;
                        entities.PromotionsDishDetail.Add(listnew[i]);
                        entities.SaveChanges();
                    }
                    return true;
                }
                return false;
            }
        }

        #endregion Observable 菜品促销管理 滕海东

        #region Observable 菜品估清管理
        /// <summary>
        /// 查询所有估清菜品
        /// </summary>
        public List<ClearEstimate> QueryClearEstimateDishesList()
        {
            List<ClearEstimate> list;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                list = entities.ClearEstimate.Where(bt => bt.Deleted == 0 && bt.Status == 1).ToList();
            }
            return list;
        }
        /// <summary>
        /// 新增估清菜品
        /// </summary>
        public ClearEstimate AddClearEstimateDish(ClearEstimate CE)
        {
            if (CE == null)
            {
                return null;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                entities.ClearEstimate.Add(CE);
                entities.SaveChanges();
                return CE;
            }
        }
        /// <summary>
        /// 修改估清菜品
        /// </summary>
        public bool UpdataClearEstimateDish(ClearEstimate CE)
        {
            bool isSuccess = false;
            if (CE == null)
            {
                isSuccess = false;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.ClearEstimate.SingleOrDefault(bt => bt.Id == CE.Id);
                if (type != null)
                {
                    type.Num = CE.Num;
                    type.LastNum = CE.LastNum;
                    type.SaleNum = CE.SaleNum;
                    type.WarnNum = CE.WarnNum;
                    type.StartTime = CE.StartTime;
                    type.Operator = CE.Operator;
                    type.EndTime = CE.EndTime;
                    type.CancleTime = CE.CancleTime;
                    type.CancleMan = CE.CancleMan;
                    type.MidwayCancle = CE.MidwayCancle;
                    entities.SaveChanges();
                    isSuccess = true;
                }
            }
            return isSuccess;
        }
        #endregion
    }
}
