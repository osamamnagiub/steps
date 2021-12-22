using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASP.NETCoreWebApplication.DTOs;

namespace ASP.NETCoreWebApplication.Model
{
    public class Step
    {
        public Step()
        {
            Items = new List<Item>();
        }

        [Key] public int Id { get; set; }

        public List<Item> Items { get; set; }

        public void AddNewItem(ItemDto itemDto)
        {
            var item = new Item
            {
                Title = itemDto.Title,
                Description = itemDto.Description
            };

            Items.Add(item);
        }
    }
}