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
    }
}