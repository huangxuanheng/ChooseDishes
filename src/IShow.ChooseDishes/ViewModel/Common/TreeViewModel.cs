using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace IShow.ChooseDishes.ViewModel.Common
{
    public class TreeViewModel
    {

        #region Data
        ObservableCollection<TreeNodeModel> _FirstGeneration;
        readonly TreeNodeModel _RootTreeNode;
        RelayCommand _SearchCommand;
        RelayCommand _AddCommand;
        RelayCommand _DeleteCommand;
        IEnumerator<TreeNodeModel> _MatchingEnumerator;

        private string _SearchText;

        public TreeNodeModel RootTreeNode {
            get { 
                return _RootTreeNode;
            }
        
        }

        public RelayCommand DeleteCommand {

            get
            {
                return _DeleteCommand ?? (_DeleteCommand = new RelayCommand(() =>
                {
                    TreeNodeModel node = FindSelected(RootTreeNode);
                    if (null != node && node.Parent != null)
                    {

                        node.Parent.Children.Remove(node);

                    }
                    else
                    {
                        MessageBox.Show(
                       "No selected node were found.",
                       "Try Again",
                       MessageBoxButton.OK,
                       MessageBoxImage.Information
                       );

                    }

                }));
            }
        
        }

        public RelayCommand SearchCommand {
            get
            {
                return _SearchCommand ?? (_SearchCommand = new RelayCommand(() =>
                {
                    if (_SearchText.Equals(""))
                    {
                        return;
                    }
                    PerformSearch();


                }));
            }
        }

        public void SelectedItemChanged(TreeNodeModel node) {
            MessageBox.Show("hello "+node.Text);
        }
        public RelayCommand AddCommand {
            get { 
                return _AddCommand ??(_AddCommand=new RelayCommand(()=>{
                    if (null == SearchText || SearchText.Equals(""))
                    {
                        MessageBox.Show(
                  "Please input the text.",
                  "Try Again",
                  MessageBoxButton.OK,
                  MessageBoxImage.Information
                  );
                        return;
                    }

                    TreeNodeModel node =FindSelected(RootTreeNode);
                    if (null != node)
                    {
                        TreeNodeModel newNode = new TreeNodeModel(SearchText, node);
                        node.Children.Add(newNode);

                    }
                    else {
                        MessageBox.Show(
                   "No selected node were found.",
                   "Try Again",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information
                   );
                    
                    }
                    
            
            }));
            }
        
        }

        public TreeViewModel()
        {
            _RootTreeNode = new TreeNodeModel("根节点");


            TreeNodeModel hunan = new TreeNodeModel("湖南", _RootTreeNode);


            TreeNodeModel hubei = new TreeNodeModel("湖北", _RootTreeNode);
            

            TreeNodeModel shaoyan = new TreeNodeModel("邵阳",hunan);
            TreeNodeModel hengyan = new TreeNodeModel("衡阳",hunan);
            TreeNodeModel wuhan = new TreeNodeModel("武汉",hubei);

            _RootTreeNode.Children.Add(hubei);
            _RootTreeNode.Children.Add(hunan);
            hunan.Children.Add(shaoyan);
            hunan.Children.Add(hengyan);
            hubei.Children.Add(wuhan);

            _FirstGeneration = new ObservableCollection<TreeNodeModel>(new TreeNodeModel[]{ 
                _RootTreeNode
            });
        }


        public ObservableCollection<TreeNodeModel> FirstGeneration
        {
            get { return _FirstGeneration; }
        
        
        }

        public string SearchText {
            get { return _SearchText; }
            set {
                if (value == _SearchText) {
                    return;
                }
                    _SearchText=value;
                    _MatchingEnumerator = null;
            }
        }

        #endregion


        #region Search Logic

        void PerformSearch()
        {
            if (_MatchingEnumerator == null || !_MatchingEnumerator.MoveNext())
                this.VerifyMatchingEnumerator();

            var person = _MatchingEnumerator.Current;

            if (person == null)
                return;

            // Ensure that this person is in view.
            if (person.Parent != null)
                person.Parent.Expanded = true;
            person.Selected = true;
        }

        void VerifyMatchingEnumerator()
        {
            var matches = this.FindMatches(_SearchText, _RootTreeNode);
            _MatchingEnumerator = matches.GetEnumerator();

            if (!_MatchingEnumerator.MoveNext())
            {
                MessageBox.Show(
                    "No matching names were found.",
                    "Try Again",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                    );
            }
        }

        TreeNodeModel FindSelected(TreeNodeModel treeNode) {
            if (treeNode.Selected) {
                return treeNode;
            }
            foreach (TreeNodeModel child in treeNode.Children) {
                if (child.Selected)
                {
                    return child;
                }
            }
            return null;
        }

        IEnumerable<TreeNodeModel> FindMatches(string searchText, TreeNodeModel treeNode)
        {
            if (treeNode.TextContainsText(searchText))
                yield return treeNode;

            foreach (TreeNodeModel child in treeNode.Children)
                foreach (TreeNodeModel match in this.FindMatches(searchText, child))
                    yield return match;
        }

        #endregion // Search Logic
    }
}
