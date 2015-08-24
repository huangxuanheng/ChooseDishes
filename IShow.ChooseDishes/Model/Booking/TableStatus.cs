using IShow.ChooseDishes.Helper.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model.Booking
{
    public enum TableStatus
    {
        //空闲
        Idle = 0,
        //使用
        Using,
        //等待
        Waiting,
        //预定
        Scheduled,
        //加台
        Excess

    }
    /// <summary>
    /// 餐桌定位
    /// </summary>
    public enum TableLocation
    {
        NAME
    }
    public class TableStatusColorMapping{
        public static Dictionary<TableStatus, string> TableStatusBg
        {
            get
            {
                TableStatusConverter tsc = new TableStatusConverter();
                return (new Dictionary<TableStatus, string>() { 
                    {TableStatus.Idle,tsc.Convert(TableStatus.Idle,null,null,null).ToString()},{TableStatus.Using,tsc.Convert(TableStatus.Using,null,null,null).ToString()},
                    {TableStatus.Waiting,tsc.Convert(TableStatus.Waiting,null,null,null).ToString()},{TableStatus.Scheduled,tsc.Convert(TableStatus.Scheduled,null,null,null).ToString()},
                    {TableStatus.Excess,tsc.Convert(TableStatus.Excess,null,null,null).ToString()}
                });
            }
        }
    }
    public class TableLocationMapping
    {
        public static Dictionary<TableLocation, string> TableLocationName
        {
            get
            {
                return (new Dictionary<TableLocation, string>() { 
                    {TableLocation.NAME,"TableLocation"}
                });
            }
        }
    }
}
