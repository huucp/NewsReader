using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace NewsReader.ViewModel.Controls
{
    public class CategoryTitleControlViewModel : ViewModelBase
    {
        private string _categoryTitle = "category title";

        public string CategoryTitle
        {
            get { return _categoryTitle; }
            set
            {
                if (_categoryTitle == value) return;
                _categoryTitle = value;
                NotifyPropertyChanged("CategoryTitle");
            }
        }       
    }
}
