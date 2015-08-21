using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Utils.Internal
{

    public class Modules {
       public  static Module M_SYSTEM = new Module("00", "系统");
    }
    /// <summary>
    /// 该接口例举系统所有功能
    /// </summary>
    public class Functions
    {
        public static Function USER = new Function("100001", "登录", Modules.M_SYSTEM);
    }
}
