using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IShow.ChooseDishes.Model.Util
{
    public static class CommonUtil
    {
        public static bool RegextNumber(String value)
        {
            try
            {
                string[] array = value.Split(new char[] { '-'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var element in array)
                {
                    if (element.ToCharArray()[0] >= 'A' && element.ToCharArray()[0] <= 'Z')
                    {
                        return true;
                    }
                }
            }
            catch (Exception e) 
            {
                e.ToString();
            }

            return false;
        }
    }
}
