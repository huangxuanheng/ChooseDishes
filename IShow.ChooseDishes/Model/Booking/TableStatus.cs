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
}
