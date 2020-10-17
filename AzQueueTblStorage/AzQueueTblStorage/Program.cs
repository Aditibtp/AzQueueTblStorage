using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Extensions.Configuration;

namespace AzQueueTblStorage
{
    class Program
    {
        static async Task Main(string[] args)
        {

            CloudTable table = await TableUtil.CreateTableAsync("YouTubeWebPageRecords");

            var cd = new YouTubeWebPageRecords.ChannelDetails()
            {
                ChannelTitle = "A super new channel",
                ChannelId = "56diffid5690"
            };


            var cn = new YouTubeWebPageRecords.ChannelDetails.ChannelNumbers()
            {
                ChannelSubscribers = "100000",
                ChannelVideos = new List<string>()
                {
                    "vid1", "vid2"
                }
            };

            cd.YtChannelNumbers = cn;
            YouTubeWebPageRecords yt = new YouTubeWebPageRecords()
            {
                PartitionKey = "YtApp9",
                RowKey = "uiuiyi98348sdkfjh",
                VideoTitle = "Operate",
                PublishedDateTime = DateTime.UtcNow,
                VideoId = "uiuiyi98348sdkfjh",
                RecordId = "uiuiyi98348sdkfjh",
                VideoChannelDetails = cd
            };

            TableUtil.CreateMessage(table, yt);

            Console.ReadKey();
        }
    }
 
}
