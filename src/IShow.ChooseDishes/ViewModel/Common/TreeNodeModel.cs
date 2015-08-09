using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace IShow.ChooseDishes.ViewModel.Common
{
    public  class TreeNodeModel:ViewModelBase
    {

        private string _Id;
        private bool _Selected;
        private bool _Expanded;
        ObservableCollection<TreeNodeModel> _Children;
        private TreeNodeModel _Parent;
        private string _Text;




        public TreeNodeModel(string text)
           : this(null,text, null)
        {
        }

        public TreeNodeModel(string id,string text)
            : this(id, text, null)
        {
        }

        public TreeNodeModel(string text,TreeNodeModel parent)
            : this(null, text, parent)
        {
        }

        public TreeNodeModel(string id,string text, TreeNodeModel parent)
        {
            _Id = id;
            _Text = text;
            _Parent = parent;

            _Children = new ObservableCollection<TreeNodeModel>(new TreeNodeModel[] { });
        }

        public string Id {
            get { return _Id; }
            set {
                Set("Id", ref _Id, value);
            
            }
        
        }
        public bool Selected
        {
            get { return _Selected; }
            set
            {
                if (value != _Selected) {
                    Set("Selected", ref _Selected, value);
                }
            }
        }

        public TreeNodeModel createChild(string id, string name) {
            var node = new TreeNodeModel(id, name, this);
            Children.Add(node);
            return node;
        }

        public bool TextContainsText(string name) {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(Text)) {
                return false;
            }

            return (Convert.ToString(Text)).IndexOf(name, StringComparison.InvariantCultureIgnoreCase) > -1;
        }
        public bool Expanded
        {
            get { return _Expanded; }
            set
            {
                if (value != _Expanded)
                {
                    _Expanded = value;
                    Set("Expanded",ref _Expanded,value);
                }

                // Expand all the way up to the root.
                if (_Expanded && _Parent != null)
                    _Parent.Expanded = true;
            }
        }
        public ObservableCollection<TreeNodeModel> Children
        {
            get { return _Children; }
            set
            {
                
                Set("Children", ref _Children, value);
            }
        }
        public TreeNodeModel Parent
        {
            get { return _Parent; }
            set {
                _Parent = value;
            }
        }
        public string Text
        {
            get { return _Text; }
            set
            {
                Set("Text", ref _Text, value);
            }
        }
  

        

    }
}
