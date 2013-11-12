using System.Windows.Controls;
using NewsReader.ViewModel.Controls;

namespace NewsReader.View.Controls
{
    public partial class NewsSourceControl : UserControl
    {        
        public NewsSourceControl()
        {
            InitializeComponent();

        }

        public void SetInfo(string title)
        {
            ((NewsSourceControlViewModel)DataContext).SetInfo(title);
        }
    }
}
