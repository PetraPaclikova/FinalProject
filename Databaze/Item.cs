using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Databaze
{
    public class Item
    {
        public string Name { get; set; }
        public int RoomNumber { get; set; }
        public string StorageCondition { get; set; }
        public bool MarkedForOrder { get; set; } = false;

        public Item(string name, int roomNumber, string storageCondition)
        {
            Name = name;
            RoomNumber = roomNumber;
            StorageCondition = storageCondition;
        }
    }
}