using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace IShow.ChooseDishes.Service
{
    public class DiscountDataService : IDiscountDataService
    {
      
        #region Observable 折扣方案管理  阙进午
        //查询所有折扣方案
        public List<DiscountProgram> queryAll()
        {
            List<DiscountProgram> program;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                program = entities.DiscountProgram.Where(Program => Program.Deleted == 0 && Program.Status==0).ToList();
            }
            return program;
        }

        //查询所有折扣方案
        public DiscountProgram queryById(int id)
        {
            DiscountProgram program;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                program = entities.DiscountProgram.Where(Program => Program.Deleted == 0 && Program.Status == 0&& Program.DiscountId == id).Single();
            }
            return program;
        }


        //查询折扣方案明细
        public List<DiscountDetail> queryByDetailId(int id)
        {
            List<DiscountDetail> program;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                program = entities.DiscountDetail.Where(Detail => Detail.Deleted == 0 && Detail.Status == 0 && Detail.DiscountId == id).ToList();
            }
            return program;
        }


        //根据ID查询小类
        public DishType LoadTypeById(int id)
        {
            try
            {
                DishType type;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    type = (DishType)entities.DishType.Where(info => info.DishTypeId == id &&info.Deleted==0&&info.Status==0).Single();
                    if (type == null)
                    {
                        type = new DishType();
                    }
                    return type;
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //根据ID查询大类
        public DishType LoadParentId(int? id)
        {
            try
            {
                
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    DishType type = new DishType(); ;
                    if (id != null)
                    {
                        type = (DishType)entities.DishType.Where(info => info.DishTypeId == id && info.Deleted == 0 && info.Status == 0).Single();
                        if (type == null)
                        {
                            type = new DishType();
                        }
                    }
                     
                    return type;
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        //查询所有小类
        public List<DishType> LoadSmallTypeAll()
        {
            try
            {
                List<DishType> type;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    type = entities.DishType.Where(info => info.ParentId != null && info.Deleted == 0 && info.Status == 0).ToList();
                    return type;
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //查询所有大类
        public List<DishType> LoadBigTypeAll()
        {
            try
            {

                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    List<DishType> type;
                   
                        type = entities.DishType.Where(info => info.ParentId == null && info.Deleted == 0 && info.Status == 0).ToList();
                        
                    

                    return type;
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //删除折扣方案
        public bool DeleteProgram(int typeId)
        {
            bool flag = true;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                Expression<Func<DiscountProgram, bool>> checkCourse = Program => Program.DiscountId == typeId && Program.Deleted == 0;
                //先查询 后修改
                List<DiscountProgram> type = entities.DiscountProgram.Where(checkCourse).ToList();
                if (type != null && type.Count > 0)
                {
                    foreach (var t in type)
                    {
                        t.UpdateBy = SubjectUtils.GetAuthenticationId();
                        t.UpdateDatetime = DateTime.Now;
                        t.Deleted = 1;
                        //直接修改的方式
                        DbEntityEntry<DiscountProgram> entry = entities.Entry<DiscountProgram>(t);
                        entry.State = System.Data.Entity.EntityState.Modified;
                        //设置修改状态为ture 否则数据库不会更新
                        entry.Property("UpdateBy").IsModified = true;
                        entry.Property("Deleted").IsModified = true;
                        entry.Property("UpdateDatetime").IsModified = true;
                        try
                        {
                            //关闭实体验证，不关闭验证需要整个对象全部传值
                            entities.Configuration.ValidateOnSaveEnabled = false;
                            var result = entities.SaveChanges();
                            entities.Configuration.ValidateOnSaveEnabled = true;
                            if (result <= 0)
                            {
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                        }
                    }
                }
                return flag;
            }
        }
        //删除折扣方案明细
         public bool DeleteDetail(int typeId)
        {
            bool flag = true;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                Expression<Func<DiscountDetail, bool>> checkCourse = Detail => Detail.DiscountId == typeId && Detail.Deleted == 0;
                //先查询 后修改
                List<DiscountDetail> type = entities.DiscountDetail.Where(checkCourse).ToList();
                if (type != null && type.Count > 0)
                {
                    foreach (var t in type)
                    {
                        t.UpdateBy = SubjectUtils.GetAuthenticationId();
                        t.UpdateDatetime = DateTime.Now;
                        t.Deleted = 1;
                        //直接修改的方式
                        DbEntityEntry<DiscountDetail> entry = entities.Entry<DiscountDetail>(t);
                        entry.State = System.Data.Entity.EntityState.Modified;
                        //设置修改状态为ture 否则数据库不会更新
                        entry.Property("UpdateBy").IsModified = true;
                        entry.Property("Deleted").IsModified = true;
                        entry.Property("UpdateDatetime").IsModified = true;
                        try
                        {
                            //关闭实体验证，不关闭验证需要整个对象全部传值
                            entities.Configuration.ValidateOnSaveEnabled = false;
                            var result = entities.SaveChanges();
                            entities.Configuration.ValidateOnSaveEnabled = true;
                            if (result <= 0)
                            {
                                return false;
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                        }
                    }
                }
                return flag;
            }
        }


         //添加折扣方案 0 添加失败
         public int AddProgram(DiscountProgram Program)
         {
             int flag = 0;
             using (ChooseDishesEntities entities = new ChooseDishesEntities())
             {
                  //实体绑定MODEL
                 entities.DiscountProgram.Add(Program);
                     try
                     {
                         //操作数据库
                         entities.SaveChanges();
                         flag = Program.DiscountId;
                     }
                     catch (Exception ex)
                     {
                         ex.ToString();
                     }
                
             }
             return flag;
         }

         //添加折扣方案明细 0 添加失败
         public int AddDetail(DiscountDetail Detail)
         {
             int flag = 0;
             using (ChooseDishesEntities entities = new ChooseDishesEntities())
             {
                 entities.DiscountDetail.Add(Detail);
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

         //0修改失败，-1修改重复
         public int UpdateProgram(DiscountProgram Program)
         {
             int flag = 0;
             using (ChooseDishesEntities entities = new ChooseDishesEntities())
             {
                 //查询折扣方案是否存在
                 var type = entities.DiscountProgram.SingleOrDefault(bt => bt.DiscountId == Program.DiscountId && bt.Deleted == 0);
                 if (type != null)
                 {
                    //设置属性是否参与修改 ，设置为false则无法更新数据
                     type.Code = Program.Code;
                     type.Name = Program.Name;
                     type.ByDish = Program.ByDish;
                     type.Rate = Program.Rate;
                     type.UpdateDatetime = Program.UpdateDatetime;
                     type.UpdateBy = Program.UpdateBy;
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
                 
             }
             return flag;
         }

         //0修改失败，-1修改重复
         public int UpdateDetail(DiscountDetail Detail)
         {
             int flag = 0;
             using (ChooseDishesEntities entities = new ChooseDishesEntities())
             {
                 //查询折扣方案是否存在
                 var type = entities.DiscountDetail.SingleOrDefault(bt => bt.Id == Detail.Id && bt.Deleted == 0);
                 if (type != null)
                 {
                     //设置属性是否参与修改 ，设置为false则无法更新数据
                     type.DiscountValue = Detail.DiscountValue;
                     type.UpdateDatetime = Detail.UpdateDatetime;
                     type.UpdateBy = Detail.UpdateBy;
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

             }
             return flag;
         }

        #endregion Observable 折扣方案




    }
}
