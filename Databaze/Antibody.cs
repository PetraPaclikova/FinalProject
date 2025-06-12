using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Databaze
{
    public class Antibody : Item
    {
        public string CatNumber { get; set; }
        public string Reactivity { get; set; } = "Rabbit";



        public Antibody(string name, int roomNumber, string storageCondition, string catNumber, string reactivity = "Rabbit")
            : base(name, roomNumber, storageCondition)
        {
            CatNumber = catNumber;
            Reactivity = reactivity;

        }

        public override string ToString()
        {
            return $"Antibody: {Name}, Cat#: {CatNumber}, Reactivity: {Reactivity}, Room: {RoomNumber}, Storage: {StorageCondition}, Ordered: {MarkedForOrder}";
        }

    }
}

