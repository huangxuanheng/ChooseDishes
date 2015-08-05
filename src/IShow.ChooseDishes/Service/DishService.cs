using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Windows.Documents;
using System.Collections;
using System.Data.Entity.Infrastructure;
using System.Windows;
using IShow.ChooseDishes;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Model;

namespace IShow.ChooseDishes
{
    public class DishService : IDishService
    {
        //菜品类型
        #region
        public List<DishType> LoadType(DishType type){
            //MessageBox.Show("进入查询");
            List<DishType> types;
            
            using (ChooseDishesEntities entities = new ChooseDishesEntities()) {
                types=entities.DishType.Where(info=>info.Deleted==0&&(type.ParentId!=null?true:(info.ParentId==type.ParentId))).ToList();
                if (types == null || types.Count == 0) {
                     types =new List<DishType>();
                }
                //MessageBox.Show("Service查询结果："+types.Count + "====" + types[0].Name);
                return types;
            };  
        }

        public List<DishType> LoadSubType(DishType type)
        {
            //MessageBox.Show("进入查询");
            List<DishType> types;

            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                types = entities.DishType.Where(info => info.Deleted == 0 && info.ParentId !=null).ToList();
                if (types == null || types.Count == 0)
                {
                    types = new List<DishType>();
                }
                //MessageBox.Show("Service查询结果："+types.Count + "====" + types[0].Name);
                return types;
            };
        }

        public Hashtable SaveType(DishType type)
        {
            
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    Hashtable hash = new Hashtable();//返回结果


                    List<DishType> types;
                    //检查类型编号或者类型名称是否重复
                    types = entities.DishType.Where(info => info.Name == type.Name || info.Code == type.Code).ToList();
                    if (types != null && types.Count > 0)
                    {
                        hash.Add("code", 1);
                        if (types[0].Name == type.Name)
                        {
                            hash.Add("message", "类型名称已经存在，请重新命名！");
                        }
                        else if (types[0].Code == type.Code)
                        {
                            hash.Add("message", "类型编号已经存在！");
                        }
                        return hash;
                    }
                    entities.DishType.Add(type);
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


        public bool UpdateType(DishType type)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                DbEntityEntry<DishType> entry = entities.Entry<DishType>(type);


                entry.State = System.Data.Entity.EntityState.Unchanged;//Modified
                entry.Property("Name").IsModified = true;
                entry.Property("DishTypeId").IsModified = false;
                //TODO 如果更新状态为“删除”则要检查是否关联了菜品
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


        public bool DeleteType(DishType type)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                DbEntityEntry<DishType> entry = entities.Entry<DishType>(type);
                entry.State = System.Data.Entity.EntityState.Deleted;
                var result=entities.SaveChanges();
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

        public List<DishType> LoadTypeById(int id)
        {
            List<DishType> types;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                types = entities.DishType.Include("Dish").Where(info => info.DishTypeId == id).ToList();
                if (types == null || types.Count == 0)
                {
                    types = new List<DishType>();
                }
                return types;
            };  
        }
        #endregion


        public List<DishUnit> QueryAllDishesUnits() {
            using (ChooseDishesEntities entities = new ChooseDishesEntities()) {
                return entities.DishUnit.ToList();
            }
        }

        public int[] BatchAddDishesUnit(DishUnit[] dishesUnits) {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                foreach (var unit in dishesUnits) {
                    unit.CreateDatetime = DateTime.Now;
                    unit.CreateBy = 10000;
                }
                entities.DishUnit.AddRange(dishesUnits);
                entities.SaveChanges();
                return new int[]{};
            }
          
        }

        public int AddDishesUnit(DishUnit dishesUnit) {
            using (ChooseDishesEntities entities = new ChooseDishesEntities()){
                entities.DishUnit.Add(dishesUnit);
                entities.SaveChanges();
                return dishesUnit.DishUnitId;
            }
        }

        public bool RemoveDishesUnitById(int dishUnitId) {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                DishUnit dishUnit= entities.DishUnit.Find(dishUnitId);
                if (null != dishUnit) {
                    entities.DishUnit.Remove(dishUnit);
                }
                entities.SaveChanges();
                return true;
            }
        }

        void Channel_Closed(object sender, EventArgs e)
        {

        }
    }
}
