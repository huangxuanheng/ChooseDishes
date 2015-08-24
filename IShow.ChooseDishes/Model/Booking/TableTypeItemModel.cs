using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Model.Booking
{
    public class TableTypeItemModel : ViewModelBase
    {
        /// <summary>
        /// 桌类id
        /// </summary>
        public int _Id;
        /// <summary>
        /// 桌类编号
        /// </summary>
        private string _Code;
        /// <summary>
        /// 桌类名称
        /// </summary>
        private string _Name;
        /// <summary>
        /// 是否选中
        /// </summary>
        private bool _Checked;

        public TableTypeItemModel(int _Id,string _Code,string _Name)
        {
            this._Id = _Id;
            this._Code = _Code;
            this._Name = _Name;
        }
        public TableTypeItemModel(string _Name):this(-1, null, _Name)
        {
            
        }
        public TableTypeItemModel(int _Id, string _Name)
            : this(_Id, null, _Name)
        {

        }
        public int Id
        {
            get { return _Id; }
            set { Set("Id", ref _Id, value); }
        }

        public string Name
        {
            get { return _Name; }
            set { Set("Name", ref _Name, value); }
        }
        public string Code
        {
            get { return _Code; }
            set { Set("Name", ref _Code, value); }
        }
        public bool Checked
        {
            get { return _Checked; }
            set {
                Set("Checked", ref _Checked, value);
            }
        }
    }
}
