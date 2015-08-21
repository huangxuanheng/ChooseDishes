using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.ViewModel
{
    public class ViewModelDeliver
    {
        public static string LOCAL_VAR = "local_single_var";
        static LocalDataStoreSlot _Slot = Thread.AllocateNamedDataSlot(LOCAL_VAR);
        public static void Set(object obj) {
            Thread.SetData(_Slot,obj);
        }

        public static object Get()
        {
            object data = Thread.GetData(_Slot);
            return data;
        }
    }
}
