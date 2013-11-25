using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using NewsReader.View.Controls;

namespace NewsReader.Ultility
{
    public class ImageDownload
    {
        public delegate void DownloadSuccessfullyEventHandler(BitmapImage sender);

        public event DownloadSuccessfullyEventHandler DownloadCompleted;

        //public void OnDownloadCompleted(BitmapImage sender)
        //{
        //    OnDownloadCompleted(sender, default(NewsImage));
        //}

        public void OnDownloadCompleted(BitmapImage sender)
        {
            DownloadSuccessfullyEventHandler handler = DownloadCompleted;
            if (handler != null) handler(sender);
        }


        public delegate void DownloadErrorEventHandler(object sender, string msg);

        public event DownloadErrorEventHandler DownloadFailed;

        public void OnDownloadFailed(object sender, string msg)
        {
            DownloadErrorEventHandler handler = DownloadFailed;
            if (handler != null) handler(sender, msg);
        }


        private string ImageUrl { get; set; }       
        public ImageDownload(string url)
        {
            ImageUrl = url;            
        }

        public void Process()
        {
            string filename = GlobalFunctions.GenerateNameFromUrl(ImageUrl);
            if (GlobalVariables.ImageDictionary.Contain(filename))
            {
                OnDownloadCompleted(GlobalVariables.ImageDictionary.GetImage(filename));
                return;
            }
            DownloadRemoteImage(ImageUrl, filename);
        }

        private void DownloadRemoteImage(string imageUrl, string filename)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                OnDownloadFailed(null, "URL invalid");
                return;
            }
            DownloadImageFromUrl(imageUrl, filename);
        }

        private void DownloadImageFromUrl(string url, string filename)
        {
            Uri urlUri;
            try
            {
                urlUri = new Uri(url);
            }
            catch (Exception e)
            {
                OnDownloadFailed(null, e.Message);
                return;
            }
            var client = new WebClient();

            client.OpenReadCompleted +=
                delegate(object o, OpenReadCompletedEventArgs args)
                {
                    if (args.Error != null || args.Cancelled)
                    {
                        if (args.Error != null) OnDownloadFailed(null, args.Error.Message);
                        else OnDownloadFailed(null, "Cancel download");
                        return;
                    }
                    try
                    {
                        Deployment.Current.Dispatcher.BeginInvoke(() =>
                        {
                            var bi = new BitmapImage();
                            bi.SetSource(args.Result);
                            //GlobalVariables.ImageDict.Add(url, bi);
                            OnDownloadCompleted(bi);
                            GlobalVariables.ImageDictionary.Add(filename, bi);
                        });
                    }
                    catch (Exception e)
                    {
                        OnDownloadFailed(e, e.Message);
                        throw;
                    }
                };
            client.OpenReadAsync(urlUri);
        }
    }

    /// <summary>
    /// Worker for download image
    /// </summary>
    public class ImageDownloadWorker
    {
        private Thread backgroundWorker;

        private BlockingQueue<ImageDownload> ListsJobs = new BlockingQueue<ImageDownload>();


        private static readonly ImageDownloadWorker _instance = new ImageDownloadWorker();
        public static ImageDownloadWorker Instance
        {
            get { return _instance; }
        }

        // Explicit static constructor to tell C# compiler not to mark type as BeforeFieldInit
        static ImageDownloadWorker()
        {

        }

        private ImageDownloadWorker()
        {
            backgroundWorker = new Thread(MainProcess)
            {
                IsBackground = true,
                Name = "Image Download Worker",
            };

            backgroundWorker.Start();
        }

        public void AddDownload(ImageDownload request)
        {
            ListsJobs.Add(request);
        }

        public void ClearAll()
        {
            ListsJobs.ClearAll();
        }

        private void MainProcess()
        {
            while (true)
            {
                var currentJob = ListsJobs.Get();
                if (currentJob == null) continue;
                currentJob.Process();
            }
        }
    }

    /// <summary>
    /// Worker for process all server request
    /// </summary>
    public class NewsWorker
    {
        public static BlockingQueue<IRequest> ListsJobs = new BlockingQueue<IRequest>(true);

        private static readonly NewsWorker _instance = new NewsWorker();
        public static NewsWorker Instance
        {
            get { return _instance; }
        }

        // Explicit static constructor to tell C# compiler not to mark type as BeforeFieldInit
        static NewsWorker()
        {

        }

        private readonly Thread _backgroundWorker;

        private bool _isClearWorker;

        private bool IsClearWorker
        {
            get { return _isClearWorker; }
            set
            {
                _isClearWorker = value;
                ListsJobs.ClearQueue = value;
            }
        }

        private NewsWorker()
        {
            _backgroundWorker = new Thread(MainProcess)
            {
                IsBackground = true,
                Name = "News Worker"
            };
            IsClearWorker = true;
            _backgroundWorker.Start();
        }

        public void AddRequest(IRequest request)
        {
            ListsJobs.Add(request);
        }

        public void ForceAddRequest(IRequest request)
        {
            IsClearWorker = false;
            ListsJobs.Add(request);
            IsClearWorker = true;
        }

        private static void MainProcess()
        {
            while (true)
            {
                var currentJob = ListsJobs.Get();
                if (currentJob == null) continue;
                currentJob.Process();
            }
        }
    }

    /// <summary>
    /// IRequest interface
    /// </summary>
    public interface IRequest
    {
        object Process();
    }

    /// <summary>
    /// Blocking queue for worker process
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BlockingQueue<T>
    {
        private const int MaxWaitingCount = 1;
        private Queue<T> q = new Queue<T>();
        public bool ClearQueue { get; set; }

        public BlockingQueue(bool clearQueue = false)
        {
            ClearQueue = clearQueue;
        }

        public void Add(T element)
        {
            lock (q)
            {
                if (q.Count > MaxWaitingCount && ClearQueue)
                {
                    Console.WriteLine("clear queue");
                    q.Clear();
                }
                q.Enqueue(element);
                Monitor.PulseAll(q);
            }
        }

        public T Get()
        {
            lock (q)
            {
                while (IsEmpty())
                {
                    Monitor.Wait(q);
                }
                return q.Dequeue();
            }
        }

        private bool IsEmpty()
        {
            lock (q)
            {
                return q.Count == 0;
            }
        }

        public void ClearAll()
        {
            lock (q)
            {
                q.Clear();
            }
        }
    }
}
