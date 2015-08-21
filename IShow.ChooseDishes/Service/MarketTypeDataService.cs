using IShow.ChooseDishes.Api;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Service
{
    public class MarketTypeDataService : IMarketTypeDataService
    {
        
	    public List<MarketType> FindAllMarketType() {
            try
            {
                List<MarketType> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.MarketType.OrderBy(dw => dw.Id).ToList();
                }
                if (odws != null && odws.Count > 0)
                {
                    return odws;
                }
            }
            catch (Exception e)
            {
                e.ToString();
                return null;
            }
            return null;
	    }

	
	    public List<MarketType> FindAllMarketTypeByDeletedStatus() {
            try
            {
                List<MarketType> odws;
                using (ChooseDishesEntities entities = new ChooseDishesEntities())
                {
                    odws = entities.MarketType.Where(dw => dw.Deleted==0).OrderBy(dw => dw.Id).ToList();
                }
                if (odws != null && odws.Count > 0)
                {
                    return odws;
                }
            }
            catch (Exception e)
            {
                e.ToString();
                return null;
            }
            return null;
	    }

	
	    public MarketType AddMarketType(MarketType mt) {
            if (mt == null)
            {
                return null;
            }
            //添加
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {

                try
                {
                    MarketType market=entities.MarketType.Add(mt);
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

	
	    public MarketType UpdateMarketType(MarketType mt) {
            if (mt == null)
            {
                return null;
            }
            //修改  直接修改
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.MarketType.SingleOrDefault(bt => bt.Id == mt.Id);
                    if (type != null)
                    {
                        type.Deleted = mt.Deleted;
                        type.Name = mt.Name;
                        type.StartTime = mt.StartTime;
                        type.Status = mt.Status;
                        type.UpdateBy = mt.UpdateBy;
                        type.UpdateDatetime = mt.UpdateDatetime;
                        entities.SaveChanges();
                        return type;
                    }

                }
                catch (Exception e)
                {
                    e.ToString();
                    return null;
                }
                return null;
            }
	    }

	
	    public bool DeleteMarketTypeById(int id) {
            if (id < 0)
            {
                return false;
            }
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    MarketType booktype = new MarketType()
                    {
                        Id = id,
                    };
                    DbEntityEntry<MarketType> entry = entities.Entry<MarketType>(booktype);
                    entry.State = EntityState.Deleted;
                    entities.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return false;
                }

            }
	    }

	
	    public MarketType FindMarketTypeById(int Id) {
            if (Id < 0)
            {
                return null;
            }

            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                try
                {
                    var type = entities.MarketType.SingleOrDefault(bt => bt.Id == Id);
                    return type;
                }
                catch (Exception e)
                {
                    e.ToString();
                    return null;
                }

            }
	    }
        /// <summary>
        /// 根据当前时间获取当前市别
        /// <para>get the current MarketType from all of the table MarketType by the currentTime </para>
        /// </summary>
        /// <param name="dt">currentTime</param>
        /// <returns>
        /// return the current MarketType by the time from the range which Two MarketType Object's createTime had,else if return null
        /// </returns>
        public MarketType FindCurrentMarketTypeByDateTime(DateTime currentTime)
        {
            using (ChooseDishesEntities entities = new ChooseDishesEntities())
            {
                var mts=entities.MarketType.OrderBy(mt => mt.CreateDatetime).ToList();
                if (mts != null)
                {
                    for (int x = 0; x < mts.Count; x++)
                    {
                        if (x+1 < mts.Count)
                        if (mts.ElementAt(x).CreateDatetime <= currentTime && mts.ElementAt(x+1).CreateDatetime> currentTime)
                        {
                            return mts.ElementAt(x);
                        }
                    }
                }
            }
            return null;
        }
    }
}
