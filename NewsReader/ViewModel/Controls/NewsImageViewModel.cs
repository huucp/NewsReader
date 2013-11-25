using System.Diagnostics;
using System.Windows.Media.Imaging;
using NewsReader.Ultility;

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

        public void GetImage(string url)
        {
            var imageDownload = new ImageDownload(url);
            imageDownload.DownloadCompleted+=imageDownload_DownloadCompleted;
            imageDownload.DownloadFailed += imageDownload_DownloadFailed;
            GlobalVariables.ImageWorker.AddDownload(imageDownload);
        }

        private void imageDownload_DownloadFailed(object sender, string msg)
        {
            Debug.Assert(false,msg);
        }

        private void imageDownload_DownloadCompleted(BitmapImage sender)
        {
            ImageSource = sender;
        }
    }
}
