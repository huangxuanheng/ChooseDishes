using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;

namespace IShow.Service
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            bool isOwener = false;
            mutex = new Mutex(true, "IShowService", out isOwener);
            if (isOwener)
            {
                Uri uri = new Uri(ConfigurationManager.AppSettings["addr"]);
                using (ServiceHost host = new ServiceHost(typeof(ChooseDishesDataService), uri))
                {
#if DEBUG
                    ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                    if (smb == null)
                        host.Description.Behaviors.Add(new ServiceMetadataBehavior());
                    host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
#endif
                    host.Open();

                    App app = new App();
                    app.Run();

                }

                
            }
        }

        static Mutex mutex;
    }
}
