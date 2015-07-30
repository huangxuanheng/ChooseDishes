using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace IShow.ChooseDishes
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            bool isOwener = false;
            mutex = new Mutex(true, "IShowChooseDishes", out isOwener);
            if (isOwener)
            {
                App app = new App();
                app.Run();
            }
        }

        static Mutex mutex;
    }
}
