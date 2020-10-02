using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzQueueTblStorage
{
    class YouTubeWebPageRecords : TableEntity
    {
        public string VideoTitle { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public YouTubeWebPageRecords(string videoTitle, DateTime createdDateTime)
        {
            PartitionKey = "YtApp";
            RowKey = videoTitle;
            VideoTitle = videoTitle;
            CreatedDateTime = createdDateTime;
        }

        public YouTubeWebPageRecords()
        {

        }
    }
}
