using System.Windows.Controls;
using NewsReader.ViewModel.Controls;

namespace NewsReader.View.Controls
{
    public partial class NewsPaperSourceControl : UserControl
    {        
        public NewsPaperSourceControl()
        {
            InitializeComponent();

        }

        public void SetInfo(string title)
        {
            ((NewsSourceControlViewModel)DataContext).SetInfo(title);
        }
    }
}
