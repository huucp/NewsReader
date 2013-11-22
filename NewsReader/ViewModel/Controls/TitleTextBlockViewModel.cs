namespace NewsReader.ViewModel.Controls
{
    public class TitleTextBlockViewModel : ViewModelBase
    {
        private string _title = string.Empty;
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

        private string _publicDate = string.Empty;
        public string PublicDate
        {
            get { return _publicDate; }
            set
            {
                if (_publicDate == value) return;
                _publicDate = value;
                NotifyPropertyChanged("PublicDate");
            }
        }

        //private string _title = string.Empty;
        //public string Title
        //{
        //    get { return _title; }
        //    set
        //    {
        //        if (_title == value) return;
        //        _title = value;
        //        NotifyPropertyChanged("Title");
        //    }
        //}
    }
}
