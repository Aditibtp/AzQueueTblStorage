using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Queues; 
using Azure.Storage.Queues.Models;
using Microsoft.WindowsAzure; 
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace AzQueueTblStorage
{
    class QueueUtil
    {
        public static async Task<CloudQueue> CreateQueueAsync()
        { 
            string storageConnectionString = AppSettings.LoadAppSettings().StorageConnectionString;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            // Create the queue client
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue 
            CloudQueue queue = queueClient.GetQueueReference("YoutubeRecordQueue");

            // Create the queue if it doesn't already exist
            if (await queue.CreateIfNotExistsAsync())
            {
                Console.WriteLine("Created queue named: {0}", "YoutubeRecordQueue");
            }
            else
            {
                Console.WriteLine("Queue {0} already exists", "YoutubeRecordQueue");
            }
            queue.CreateIfNotExists();
            return queue;
        }

        public static async Task<CloudQueueMessage> peekAtQueue(CloudQueue queue)
        {
            CloudQueueMessage peekedMessage = await queue.PeekMessageAsync();

            // Display message.
            Console.WriteLine(peekedMessage.AsString);

            return peekedMessage;
        }

        public static async Task addMessageToQueue(CloudQueue cloudQ, CloudQueueMessage qMessage)
        {
            await cloudQ.AddMessageAsync(qMessage);
        }

        public static async Task<CloudQueueMessage> getAndRemoveMessage(CloudQueue cloudQ)
        {
            CloudQueueMessage qMessage = await cloudQ.GetMessageAsync();
            await cloudQ.DeleteAsync();

            return qMessage;
        }

    }
}
