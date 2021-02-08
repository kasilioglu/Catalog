using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item(){ Id =Guid.NewGuid(), Name = "Potion", Price = 9, CreateDate = DateTimeOffset.UtcNow },
            new Item(){ Id =Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreateDate = DateTimeOffset.UtcNow },
            new Item(){ Id =Guid.NewGuid(), Name = "Bronz Shield", Price = 18, CreateDate = DateTimeOffset.UtcNow }
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            //create a task that is already completed
            return await Task.FromResult(items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id==id);
            if(index >= 0)
                items.RemoveAt(index);
            
            await Task.CompletedTask;
        }
        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id==item.Id);
            if(index >= 0)
                items[index] = item;

            await Task.CompletedTask;
        }
    }
    
}