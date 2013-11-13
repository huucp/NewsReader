using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

        public void AddNews()
        {
            for (int i =0; i < 10; i++)
            {
                var news = new NewsTitleControl();
                ListNews.Add(news);
            }
        }
    }
}
