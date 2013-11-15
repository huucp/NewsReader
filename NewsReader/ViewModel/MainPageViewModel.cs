using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using NewsReader.View.Controls;

namespace NewsReader.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<NewsPaperSourceControl> _listSource = new ObservableCollection<NewsPaperSourceControl>();
        public ObservableCollection<NewsPaperSourceControl> ListSource
        {
            get { return _listSource; }
            set
            {
                _listSource = value;
                NotifyPropertyChanged("ListSource");
            }
        }

        public void AddToList()
        {
            for (int i = 0; i < 20; i++)
            {
                var item = new NewsPaperSourceControl();
                item.SetInfo("kenh14");
                ListSource.Add(item);
            }
        }
    }
}
