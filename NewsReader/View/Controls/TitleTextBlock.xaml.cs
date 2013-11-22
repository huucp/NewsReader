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
    public partial class TitleTextBlock : UserControl
    {
        private TitleTextBlockViewModel _viewModel;
        public TitleTextBlock()
        {
            InitializeComponent();

            _viewModel = (TitleTextBlockViewModel) DataContext;
        }

        public void SetTitle(string title)
        {
            _viewModel.Title = title;
        }

        public void SetPublicDate(string date)
        {
            _viewModel.PublicDate = date;
        }            
    }
}
