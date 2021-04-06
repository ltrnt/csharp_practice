using System;
using csharp_practice.ltrnt.practice24.shkabura.entity.enums;

namespace csharp_practice.ltrnt.practice24.shkabura.entity
{
    public class Room
    {
        static int id = 0; // Static variable

        private int localId;
        private int number;
        private Specialty specialty;

        public Room(int number, Specialty specialty)
        {
            this.Number = number;
            this.Specialty = specialty;
            this.localId = Room.id++; // Without setter

        }

        public int Number { get => number; set => number = value; }
        public Specialty Specialty { get => specialty; set => specialty = value; }
        public int LocalId { get => localId;}

        public override string ToString()
        {
            return "Room with ID = " + localId + ". Number = " + number + ". Specialty = " + specialty;
        }

        public override bool Equals(object obj)
        {
            return obj is Room room &&
                   number == room.number &&
                   specialty == room.specialty;
        }

        public override int GetHashCode()
        {
            int hashCode = 1520414671;
            hashCode = hashCode * -1521134295 + number.GetHashCode();
            hashCode = hashCode * -1521134295 + specialty.GetHashCode();
            return hashCode;
        }
    }
}
