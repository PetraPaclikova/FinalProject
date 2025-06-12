using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Databaze
{
    public class Material : Item
    {
        public string CatNumber { get; set; }

        public Material(string name, int roomNumber, string storageCondition, string catNumber)
            : base(name, roomNumber, storageCondition)
        {
            CatNumber = catNumber;

        }
        public override string ToString()
        {
            return $"Material: {Name}, Cat#: {CatNumber}, Room: {RoomNumber}, Storage: {StorageCondition}, Ordered: {MarkedForOrder}";
        }
    }
}