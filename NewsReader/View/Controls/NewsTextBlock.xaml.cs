using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using NewsReader.ViewModel.Controls;

namespace NewsReader.View.Controls
{
    public partial class NewsTextBlock : UserControl
    {
        private NewsTextBlockViewModel _viewModel;
        public NewsTextBlock()
        {
            InitializeComponent();

            _viewModel = (NewsTextBlockViewModel)DataContext;
        }

        public void SetContent(string content)
        {
            _viewModel.Content = content;
        }

    }
}
