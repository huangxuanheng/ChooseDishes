using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model.EnumSet
{
    public enum SaleType {ONE=1,TWO=2 }

    /// <summary>
    /// 餐桌状台
    /// </summary>
    public enum TableStatus { 
        FREE=1,LOCKED=2
    }

    /// <summary>
    /// 服务费/低消特殊时段计算方式
    /// </summary>
    public enum AccountType{
        BILLINGTIME=1,ACCOUNTTIME=2
    }
    public class Names
    {
        public static Dictionary<SaleType, string> SaleTypeNames
        {
            get
            {
                return new Dictionary<SaleType, string>() { 
                    {SaleType.ONE,"整数"},
                     {SaleType.TWO,"小数"},
                };
            }
        }
    }

    /// <summary>
    /// 折让控制类型
    /// </summary>
    public enum AllowanceType {
        SINGLE=1,SINGLEDAY=2, SINGLEMONTH=3
        
    }

    /// <summary>
    /// 赠送渠道
    /// </summary>
    public enum PresentType
    {
        SINGLEMONEY = 1, SINGLETABLE = 2, SINGLEDAY = 3, SINGLEMONTH = 4, SINGLEPRICE = 5
    }
    /// <summary>
    /// 界面按钮复用定义
    /// </summary>
    public enum ButtonEventType
    {
        ADD,UPDATE,DELECTED,DEFAULT
    }
    
   /// <summary>
   /// 菜品售价类
   /// </summary>
    public enum PriceType
    {
        PRICE1=1,PRICE2=2,PRICE3=3
    }

    /// <summary>
    /// 服务费模式
    /// </summary>
    public enum ServerfreeMode
    {
        NOTHANDLE = 1, TIMEUNIT = 2, CONSSERVERFEERATE = 3, TABLEFEE = 4, DISHSERVERFEERATE=5
    }

    /// <summary>
    /// 服务计算方式 折前服务费或折后服务费
    /// </summary>
    public enum ServerfreeAccountType
    {
        BEFOREDISCOUNT=1,AFTERDISCOUNT=2
    }

    /// <summary>
    /// 低消方式 餐桌低消 人均低消
    /// </summary>
    public enum ConsumerMode
    {
        TABLE=1,PEOPLE=2
    }
    /// <summary>
    /// 保存类型
    /// <para>BIGTYPE 表示为大类</para>
    /// <para>LITTLETYPE 表示为小类</para>
    /// <para>ITEM 表示为详细</para>
    /// </summary>
    public enum SaveType
    {
        BIGTYPE,LITTLETYPE,ITEM
    }

  
}
