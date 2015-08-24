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
        public TableItem Add(int TableId, int CreateTableId)
        {
            //添加
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {

                try
                {
                    TableItem mt = new TableItem();
                    mt.TableId = TableId;
                    mt.CreateTableId = CreateTableId;
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
        public bool Remove(int TableId, int CreateTableId)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.TableItem.SingleOrDefault(bt => bt.Deleted == 0 && bt.TableId == TableId && bt.CreateTableId == CreateTableId);
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
        public TableItem ModifyStatusBy(int TableId, int CreateTableId, int Status)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var type = entities.TableItem.SingleOrDefault(bt => bt.Deleted == 0 && bt.TableId == TableId && bt.CreateTableId == CreateTableId);
                if (type != null)
                {
                    type.UpdateBy = SubjectUtils.GetAuthenticationId();
                    type.UpdateDatetime = DateTime.Now;
                    type.Status = Status;
                    entities.SaveChanges();
                    return type;
                }
                return null;
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
    }
}
