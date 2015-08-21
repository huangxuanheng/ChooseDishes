using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IShow.ChooseDishes.Model.EnumSet;

namespace IShow.ChooseDishes.ViewModel.Common
{
    public class NameMapping
    {

        public static  Dictionary<AllowanceType, string> Allowances
        {
            get
            {
                return (new Dictionary<AllowanceType, string>() { 
                    {AllowanceType.SINGLE,"单笔"}
                });
            }
        }

        public static Dictionary<PresentType, string> Presents
        {
            get
            {
                return (new Dictionary<PresentType, string>() { 
                    
                });
            }
        }
    }
}
