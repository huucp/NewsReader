using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using NewsReader.View.Controls;

namespace NewsReader.ViewModel.Controls
{
    public class CategoryDetailWithTitleControlViewModel : ViewModelBase
    {
        private string _category = "category";
        public string Category
        {
            get { return _category; }
            set
            {
                if (_category == value) return;
                _category = value;
                NotifyPropertyChanged("Category");
            }
        }

        private ObservableCollection<NewsTitleControl> _listNews = new ObservableCollection<NewsTitleControl>();
        public ObservableCollection<NewsTitleControl> ListNews
        {
            get { return _listNews; }
            set
            {
                _listNews = value;
                NotifyPropertyChanged("ListNews");
            }
        }

        private Visibility _sourceTitleListBoxVisibility = Visibility.Visible;

        public Visibility SourceTitleListBoxVisibility
        {
            get { return _sourceTitleListBoxVisibility; }
            set
            {
                if (_sourceTitleListBoxVisibility == value) return;
                _sourceTitleListBoxVisibility = value;
                NotifyPropertyChanged("SourceTitleListBoxVisibility");
                NotifyPropertyChanged("SourceCategoryListBoxVisibility");
            }
        }

        public Visibility SourceCategoryListBoxVisibility
        {
            get
            {
                if (_sourceTitleListBoxVisibility == Visibility.Visible) return Visibility.Collapsed;
                return Visibility.Visible;
            }            
        }

        private ObservableCollection<CategoryTitleControl> _listCategory = new ObservableCollection<CategoryTitleControl>();

        public ObservableCollection<CategoryTitleControl> ListCategory
        {
            get { return _listCategory; }
            set
            {
                _listCategory = value;
                NotifyPropertyChanged("ListCategory");
            }
        }

        public void AddNews()
        {
            for (int i = 0; i < 10; i++)
            {
                var news = new NewsTitleControl();
                ListNews.Add(news);
            }
        }

        public void AddCategory()
        {
            for (int i = 0; i < 10; i++)
            {
                var category = new CategoryTitleControl();
                ListCategory.Add(category);
            }
        }
    }
}
