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
    }
}
