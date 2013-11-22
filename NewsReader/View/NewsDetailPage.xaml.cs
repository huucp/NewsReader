using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using NewsReader.Ultility;
using NewsReader.View.Controls;
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

        private void ParseJson()
        {
            string myText = ReadFile(@"Information.json");
            if (myText == string.Empty) return;
            var newsObject = JsonConvert.DeserializeObject<NewsJsonObject>(myText);
            AddTitle(newsObject.Title, newsObject.PubDate);
            AddSource(newsObject.AbstractContent);
            foreach (var content in newsObject.NewsContent)
            {
                AddContent(content.Content);
                if (content.Images.Count > 0)
                {
                    AddImage(content.Images);
                }
            }
        }

        private void AddImage(List<ImageJsonObject> images)
        {
            foreach (var imageJsonObject in images)
            {
                var image = new NewsImage();
                var imageDownload = new ImageDownload(imageJsonObject.Link, image);
                imageDownload.DownloadCompleted += imageDownload_DownloadCompleted;
                image.SetDescription(imageJsonObject.Descript);
                ContentPanel.Children.Add(image);
                GlobalVariables.ImageWorker.AddDownload(imageDownload);
            }
        }

        private void imageDownload_DownloadCompleted(BitmapImage sender, NewsImage image)
        {
            image.SetImageSource(sender);            
        }

        private void AddTitle(string title, string date)
        {            
            var tb = new TitleTextBlock();
            tb.SetTitle(title);
            tb.SetPublicDate(date);
            ContentPanel.Children.Add(tb);
        }

        private void AddSource(string source)
        {

        }
        private void AddContent(string content)
        {
            var tb = new NewsTextBlock();
            tb.SetContent(content);
            ContentPanel.Children.Add(tb);
        }

    }
}