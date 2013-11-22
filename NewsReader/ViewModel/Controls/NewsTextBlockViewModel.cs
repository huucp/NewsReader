using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsReader.ViewModel.Controls
{
    public class NewsTextBlockViewModel : ViewModelBase
    {
        private string _content = string.Empty;
        public string Content
        {
            get { return _content; }
            set
            {
                if (_content == value) return;
                _content = value;
                NotifyPropertyChanged("Content");
            }
        }
    }
}
