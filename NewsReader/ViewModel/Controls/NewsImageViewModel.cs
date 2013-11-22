using System.Windows.Media.Imaging;

namespace NewsReader.ViewModel.Controls
{
    public class NewsImageViewModel : ViewModelBase
    {
        private BitmapImage _imageSource = null;
        public BitmapImage ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                NotifyPropertyChanged("ImageSource");
            }
        }

        private string _description = string.Empty;
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
    }
}
