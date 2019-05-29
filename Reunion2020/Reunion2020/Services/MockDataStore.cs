﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reunion2020.Models;

namespace Reunion2020.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();

            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Title = "Event One", Date ="25/5 - 2019", Location="Somewhere", TargetGroupMin = 10, TargetGroupMax = 20 },
                new Item { Id = Guid.NewGuid().ToString(), Title = "Event Two", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Title = "Event Three", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Title = "Event Four", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Title = "Event Five", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Title = "Event Six", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}