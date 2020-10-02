﻿using System;
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

            CloudTable table = await Common.CreateTableAsync("YouTubeWebPageRecords");
            Console.ReadKey();
        }
    }
 
}