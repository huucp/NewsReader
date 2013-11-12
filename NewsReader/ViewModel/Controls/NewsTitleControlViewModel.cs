using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace NewsReader.ViewModel.Controls
{
    public class NewsTitleControlViewModel : ViewModelBase
    {
        private BitmapImage _icon = null;
        public BitmapImage Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                NotifyPropertyChanged("Icon");
            }
        }

        private string _title = "Title";
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value) return;
                _title = value;
                NotifyPropertyChanged("Title");
            }
        }

        private string _source = "Source";
        public string Source
        {
            get { return _source; }
            set
            {
                if (_source == value) return;
                _source = value;
                NotifyPropertyChanged("Source");
            }
        }

        private string _time = "time";
        public string Time
        {
            get { return _time; }
            set
            {
                if (_time == value) return;
                _time = value;
                NotifyPropertyChanged("Time");
            }
        }
    }
}
