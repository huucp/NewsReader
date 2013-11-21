using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Phone.Controls;
using NewsReader.Ultility;
using Newtonsoft.Json;

namespace NewsReader.View
{
    public partial class NewsDetailPage : PhoneApplicationPage
    {
        public NewsDetailPage()
        {
            InitializeComponent();
            ParseJson();
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
            //} 
            if (myText == string.Empty) return;
            var newsObject = JsonConvert.DeserializeObject<NewsJsonObject>(myText);
            AddTitle(newsObject.Title);
            AddSource(newsObject.AbstractContent);
            foreach (var content in newsObject.NewsContent)
            {
                Debug.WriteLine(content.Content);
                if (content.Images.Count > 0) Debug.WriteLine(content.Images[0].Link);
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

        private void AddTitle(string title)
        {
            var foregroundColor = GlobalFunctions.ConvertStringToColor("#164a6e");
            var tb = new TextBlock()
            {
                Foreground = new SolidColorBrush(foregroundColor),
                FontFamily = new FontFamily("Segoe WP"),
                FontSize = 32,
                Text = title,
                //TextAlignment = TextAlignment.Justify
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(20,0,20,0)
            };
            ContentPanel.Children.Add(tb);
        }

        private void AddSource(string source)
        {
            
        }
    }
}