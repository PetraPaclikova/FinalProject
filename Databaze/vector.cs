using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Databaze
{
    public class Vector : Item
    {
        public string Resistance { get; set; }
        public int Size { get; set; }

        public Vector(string name, int roomNumber, string storageCondition, string resistance, int size)
            : base(name, roomNumber, storageCondition)
        {
            Resistance = resistance;
            Size = size;
            
        }
        public override string ToString()
    {
        return $"Vector: {Name}, Resistance: {Resistance}, Size: {Size}, Room: {RoomNumber}, Storage: {StorageCondition}, Ordered: {MarkedForOrder}";
    }
    }
}