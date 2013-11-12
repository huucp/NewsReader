using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NewsReader.Ultility
{

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


        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
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
