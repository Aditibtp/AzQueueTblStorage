using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzQueueTblStorage
{
    class YouTubeWebPageRecords : TableEntity
    {
        public string RecordId { get; set; }
        public string VideoTitle { get; set; }

        public DateTime PublishedDateTime { get; set; }

        public List<Tuple<string, int, int>> Thumbnails { get; set; }

        public string VideoId { get; set; }

        public string ChannelTitle { get; set; }

        public string ChannelId { get; set; }

        public YouTubeWebPageRecords()
        {

        }
    }
}
