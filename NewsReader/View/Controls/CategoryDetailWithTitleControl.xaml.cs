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
        public CategoryDetailWithTitleControl()
        {
            InitializeComponent();

            ((CategoryDetailWithTitleControlViewModel)DataContext).AddNews();
        }
    }
}
