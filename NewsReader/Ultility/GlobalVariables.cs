using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace NewsReader.Ultility
{
    public static class GlobalVariables
    {
        public static NewsWorker MainWorker = NewsWorker.Instance;
        public static ImageDownloadWorker ImageWorker = ImageDownloadWorker.Instance;
        public static LimitedItemImageDictionary ImageDictionary = new LimitedItemImageDictionary();
    }
}
