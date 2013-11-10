using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace NewsReader.ViewModel
{
    public class NewsSourceViewModel : ViewModelBase
    {
        private string _title = "title";
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

        private string _description = "description";
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description == value) return;
                _description = value;
                NotifyPropertyChanged("Description");
            }
        }

        private BitmapImage _icon;
        public BitmapImage Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                NotifyPropertyChanged("Icon");
            }
        }

    }
}
