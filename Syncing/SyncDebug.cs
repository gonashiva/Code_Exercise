using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            Parallel.ForEach(items, i =>
            {
                bag.Add(i);
            });
            var list = bag.ToList();
            return list;
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            //var threads = Enumerable.Range(0, 3)
            //    .Select(i => new Thread(() => {
            //        foreach (var item in itemsToInitialize)
            //        {
            //            concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
            //        }
            //    }))
            //    .ToList();

            //foreach (var thread in threads)
            //{
            //    thread.Start();
            //}
            //foreach (var thread in threads)
            //{
            //    thread.Join();
            //}

            //Parallel.ForEach(Enumerable.Range(0, 3), i =>
            //{
            //    foreach (var item in itemsToInitialize)
            //    {
            //        concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
            //    }
            //});

            Parallel.ForEach(itemsToInitialize, (i) =>
            {
                concurrentDictionary.AddOrUpdate(i, getItem, (_, s) => s);
            });

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}