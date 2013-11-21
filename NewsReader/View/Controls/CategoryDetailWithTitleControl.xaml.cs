using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using NewsReader.ViewModel.Controls;

namespace NewsReader.View.Controls
{
    public partial class CategoryDetailWithTitleControl : UserControl
    {
        private CategoryDetailWithTitleControlViewModel _viewModel;
        public CategoryDetailWithTitleControl()
        {
            InitializeComponent();

            _viewModel = (CategoryDetailWithTitleControlViewModel)DataContext;

            ContainListNews = true;
        }

        public bool ContainListNews
        {
            set
            {
                _viewModel.SourceTitleListBoxVisibility = value ? Visibility.Visible : Visibility.Collapsed;
                if (_viewModel.SourceTitleListBoxVisibility == Visibility.Visible)
                {
                    _viewModel.AddNews();
                }
                else
                {
                    _viewModel.AddCategory();
                }
            }
        }

        private void SourceCategoryListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var uri = new Uri("/View/CategoryDetailPage.xaml", UriKind.Relative);
            ((PhoneApplicationFrame) Application.Current.RootVisual).Navigate(uri);  
        }

        private void SourceTitleListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var uri = new Uri("/View/NewsDetailPage.xaml", UriKind.Relative);
            ((PhoneApplicationFrame)Application.Current.RootVisual).Navigate(uri);  
        }
    }
}
