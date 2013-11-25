using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using NewsReader.ViewModel.Controls;

namespace NewsReader.View.Controls
{
    public partial class NewsImage : UserControl
    {
        private NewsImageViewModel _viewModel;
        private NewsImage()
        {
            InitializeComponent();

            _viewModel = (NewsImageViewModel)DataContext;
        }

        public NewsImage(string url, string description):this()
        {
            SetImageUrl(url);
            SetDescription(description);            
        }

        private void SetImageUrl(string url)
        {
            _viewModel.GetImage(url);
        }

        private void SetDescription(string description)
        {
            _viewModel.Description = description;
        }
    }
}
