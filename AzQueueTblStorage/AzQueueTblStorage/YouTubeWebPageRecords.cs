using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob.Protocol;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace AzQueueTblStorage
{
    [DataContract]
    class YouTubeWebPageRecords : TableEntity
    {
        private const string schemaVersionConst = "10162020";

        [DataMember]
        public string SchemaVersion { get; set; }

        [DataMember]
        public string RecordId { get; set; }

        [DataMember]
        public string VideoTitle { get; set; }

        [DataMember]
        public DateTime PublishedDateTime { get; set; }

        [DataMember]
        public string VideoId { get; set; }



        [DataMember(Name = nameof(VideoChannelDetails))]
        [JsonProperty(nameof(VideoChannelDetails))]
        public string VideoChannelDetailsSerialized
        {
            get => JsonConvert.SerializeObject(VideoChannelDetails);
            set
            {
                ChannelDetails videoChannelDetails;
                if (string.IsNullOrWhiteSpace(value))
                {
                    videoChannelDetails = null;
                }
                else
                {
                    videoChannelDetails = JsonConvert.DeserializeObject<ChannelDetails>(value);
                }
                VideoChannelDetails = videoChannelDetails;
            }
        }

        [IgnoreDataMember]
        [JsonIgnore]
        public ChannelDetails VideoChannelDetails { get; set; }

        public class ChannelDetails
        {
            public string ChannelTitle { get; set; }
            public string ChannelId { get; set; }

            public ChannelNumbers YtChannelNumbers { get; set; }

            public class ChannelNumbers
            {
                public string ChannelSubscribers { get; set; }
                public List<string> ChannelVideos { get; set; }
            }
        }

        public YouTubeWebPageRecords()
        {
            this.SchemaVersion = schemaVersionConst;
        }
    }

}
