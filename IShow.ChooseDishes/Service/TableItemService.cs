using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using IShow.ChooseDishes.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Service
{
    public class TableItemService : ITableItemService
    {
        public List<TableItem> GetAll()
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                return entities.TableItem.Include(typeof(Table).Name).Where(t => t.Deleted == 0).ToList();
            }
        }
        public TableItem Add(int TableId)
        {
            //添加
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {

                try
                {
                    TableItem mt = new TableItem();
                    mt.TableId = TableId;
                    mt.CreateBy = SubjectUtils.GetAuthenticationId();
                    mt.CreateDatetime = DateTime.Now;
                    var market = entities.TableItem.Add(mt);
                    entities.SaveChanges();
                    return market;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return null;
                }
            }
        }
        public bool Remove(int TableId)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.TableItem.SingleOrDefault(bt => bt.Deleted == 0 && bt.TableId == TableId);
                if (type != null)
                {
                    type.UpdateBy = SubjectUtils.GetAuthenticationId();
                    type.UpdateDatetime = DateTime.Now;
                    type.Deleted = 1;
                    entities.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public bool ModifyStatus(int TableId, int Status)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.TableItem.SingleOrDefault(bt => bt.Deleted == 0 && bt.TableId == TableId);
                if (type != null)
                {
                    type.UpdateBy = SubjectUtils.GetAuthenticationId();
                    type.UpdateDatetime = DateTime.Now;
                    type.Status = Status;
                    entities.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        //TODO 建立与开台关联的关系和获取订单对象
        public List<TableItem> GetDetailByTableId(int TableId)
        {
            List<TableItem> tis;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                tis=entities.TableItem.Include(typeof(Table).Name).Include(typeof(DeskDishes).Name).Where(t => t.Deleted == 0&&t.TableId==TableId).ToList();
                
            }
            return tis;
        }
        //TODO 建立与开台关联的关系和获取开台关联信息
        public List<TableItem> GetDetailByStatus(int Status)
        {
            List<TableItem> tis;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                tis = entities.TableItem.Include(typeof(Table).Name).Where(t => t.Deleted == 0&&t.Status==Status).ToList();

            }
            return tis;
        }
        public int GetNumByStatus(int Status)
        {
            List<TableItem> tis;
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                tis = entities.TableItem.Where(t => t.Deleted == 0 && t.Status == Status).ToList();

            }
            return tis.Count;
        }


        public bool ModifyIdle(int TableId)
        {
            return ModifyStatus(TableId, 0);
        }

        public bool ModifyUsing(int TableId)
        {
            return ModifyStatus(TableId, 1);
        }

        public bool ModifyWaitting(int TableId)
        {
            return ModifyStatus(TableId, 2);
        }

        public bool ModifyScheduled(int TableId)
        {
            return ModifyStatus(TableId, 3);
        }

        public bool ModifyExcess(int TableId)
        {
            return ModifyStatus(TableId, 4);
        }
    }
}
