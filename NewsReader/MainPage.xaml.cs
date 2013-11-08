using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;
using NewsReader.Ultility;
using Newtonsoft.Json;

namespace NewsReader
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            //LoadWebContent();
            //ParseJson();
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            // Stop timer in title to 
            Title.StopTimer();
        }

        private void ParseJson()
        {
            string myText = ReadFile(@"Information.json");
            var objects = JsonConvert.DeserializeObject<List<NewsObject>>(myText);
            foreach (var newsObject in objects)
            {
                Debug.WriteLine(newsObject.Title);
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

    }    
}