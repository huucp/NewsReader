using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;
using NewsReader.Ultility;
using NewsReader.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NewsReader.View
{
    public partial class MainPage : PhoneApplicationPage
    {
        private MainPageViewModel _viewModel;
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //LoadWebContent();
            //ParseJson();

            _viewModel = (MainPageViewModel) DataContext;
            _viewModel.AddToList();
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            // Stop timer in title to dispose this page title
            Title.StopTimer();
        }

        private void ParseJson()
        {
            string myText = ReadFile(@"Information.json");
            //var objects = JsonConvert.DeserializeObject<List<NewsJsonObject>>(myText);
            //foreach (var newsObject in objects)
            //{
            //    Debug.WriteLine(newsObject.title);
            //    Debug.WriteLine(newsObject.abstractContent);
            //}
            var newsObject = JsonConvert.DeserializeObject<NewsJsonObject>(myText);
            Debug.WriteLine(newsObject.Title);
            Debug.WriteLine(newsObject.AbstractContent);
            foreach (var content in newsObject.NewsContent)
            {
                Debug.WriteLine(content.Content);
                if (content.Images.Count>0) Debug.WriteLine(content.Images[0].Link);
            }
        }

        private string ReadFile(string filePath)
        {
            //this verse is loaded for the first time so fill it from the text file
            var resrouceStream = Application.GetResourceStream(new Uri(filePath, UriKind.Relative));
            if (resrouceStream != null)
            {
                Stream myFileStream = resrouceStream.Stream;
                if (myFileStream.CanRead)
                {
                    var myStreamReader = new StreamReader(myFileStream);

                    //read the content here
                    return myStreamReader.ReadToEnd();
                }
            }
            return string.Empty;
        }

        private void DownloadStringCallback(object sender, DownloadStringCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                Debug.WriteLine(e.Result);                
            }
        }

        private void LoadWebContent()
        {
            string uriString = "http://ideamining.zapto.org:8090/ServletTutorial/hello?name=kyhoolee";
            var uri = new Uri(uriString);            
            var client = new WebClient();

            client.DownloadStringCompleted += DownloadStringCallback;
            client.DownloadStringAsync(uri);
        }

        private void SourceListBox_OnSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {            
            var uri = new Uri("/View/SourceDetailPage.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }

    }    
}