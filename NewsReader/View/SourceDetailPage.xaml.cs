using Microsoft.Phone.Controls;

namespace NewsReader.View
{
    public partial class SourceDetailPage : PhoneApplicationPage
    {
        public SourceDetailPage()
        {
            InitializeComponent();

            ListCategory.ContainListNews = false;
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            // Stop timer in title to dispose page title control
            Title.StopTimer();
        }
    }
}