using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model
{
    public class SystemLogBean : ObservableObject
    {
        public string _LineNumber;
        public string LineNumber     //行号
        {
            get
            {
                return _LineNumber;
            }
            set
            {
                Set("LineNumber", ref _LineNumber, value);
            }
        }
        public string  _CurrentScale;
        public string CurrentScale     //显示当前位置和总数
        {
            get
            {
                return _CurrentScale;
            }
            set
            {
                Set("CurrentScale", ref _CurrentScale, value);
            }
        }
        
        public int _Id;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                Set("Id", ref _Id, value);
            }
        }

        public string _Module;
        public string Module
        {
            get
            {
                return _Module;
            }
            set
            {
                Set("Module", ref _Module, value);
            }
        }

        public string _Function;
        public string Function
        {
            get
            {
                return _Function;
            }
            set
            {
                Set("Function", ref _Function, value);
            }
        }

        public string _OpType;
        public string OpType
        {
            get
            {
                return _OpType;
            }
            set
            {
                Set("OpType", ref _OpType, value);
            }
        }

        public string _Actor;
        public string Actor    //操作人
        {
            get
            {
                return _Actor;
            }
            set
            {
                Set("Actor", ref _Actor, value);
            }
        }
        public string _Authorizer;
        public string Authorizer    //授权人
        {
            get
            {
                return _Authorizer;
            }
            set
            {
                Set("Authorizer", ref _Authorizer, value);
            }
        }
        
        public System.DateTime _CreateDatetime;
        public System.DateTime CreateDatetime
        {
            get
            {
                return _CreateDatetime;
            }
            set
            {
                Set("CreateDatetime", ref _CreateDatetime, value);
            }
        }

        public string _Body;
        public string Body
        {
            get
            {
                return _Body;
            }
            set
            {
                Set("Body", ref _Body, value);
            }
        }

        public string _ItemId;
        public string ItemId
        {
            get
            {
                return _ItemId;
            }
            set
            {
                Set("ItemId", ref _ItemId, value);
            }
        }



        public SystemLogBean CreateSystemLogBean(SystemLog bean)
        {
            this.Id = bean.Id;
            this.Module = bean.Module;
            this.Function = bean.Function;
            this.OpType = bean.OpType;
            this.Actor = bean.Actor;
            this.CreateDatetime = bean.CreateDatetime;
            this.Body = bean.Body;
            this.ItemId = bean.ItemId;
            return this;

        }
        public SystemLog CreateSystemLog(SystemLogBean bean)
        {
            SystemLog beanBack = new SystemLog();
            beanBack.Id = bean.Id;
            beanBack.Module = bean.Module;
            beanBack.Function = bean.Function;
            beanBack.OpType = bean.OpType;
            beanBack.Actor = bean.Actor;
            beanBack.CreateDatetime = bean.CreateDatetime;
            beanBack.Body = bean.Body;
            beanBack.ItemId = bean.ItemId;
            return beanBack;

        }

    }
}
