using System.Windows.Media.Imaging;
using NewsReader.Ultility;

namespace NewsReader.ViewModel.Controls
{
    public class NewsSourceControlViewModel : ViewModelBase
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

        public void SetInfo(string sourceTag)
        {
            Title = NewsSources.GetTitle(sourceTag);
            Description = NewsSources.GetDescription(sourceTag);
        }
    }
}
