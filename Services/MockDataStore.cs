using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Wallet.Models;

[assembly: Xamarin.Forms.Dependency(typeof(Wallet.Services.MockDataStore))]
namespace Wallet.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "CreateAccount", Description="Create a new account" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "ExchangeRate", Description="Find your ExchangeRate Here" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "MyWallet", Description="This is your wallet infor" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Transaction", Description="Pay someone?" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Information", Description="More information" },
                
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
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

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