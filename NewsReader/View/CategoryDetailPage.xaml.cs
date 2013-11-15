using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using NewsReader.View.Controls;

namespace NewsReader.View
{
    public partial class CategoryDetailPage : PhoneApplicationPage
    {
        public CategoryDetailPage()
        {
            InitializeComponent();

            var textblock = new TextBlock { Text = "header 1", FontSize = 36 };
            var pivotItem = new PivotItem() { Header = textblock };
            var grid = new Grid();
            var listBox = new ListBox()
                              {
                                  HorizontalAlignment = HorizontalAlignment.Stretch,
                                  VerticalAlignment = VerticalAlignment.Stretch,
                                  Margin = new Thickness(0)
                              };
            for (int i = 0; i < 10; i++)
            {
                var newsTitle = new NewsTitleControl();
                listBox.Items.Add(newsTitle);
            }
            grid.Children.Add(listBox);
            pivotItem.Content = grid;
            PivotContainer.Items.Add(pivotItem);
            var textblock2 = new TextBlock { Text = "header 2", FontSize = 36 };
            var pivotItem2 = new PivotItem() { Header = textblock2 };
            PivotContainer.Items.Add(pivotItem2);
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            // Stop timer in title to dispose page title control
            Title.StopTimer();
        }
    }
}