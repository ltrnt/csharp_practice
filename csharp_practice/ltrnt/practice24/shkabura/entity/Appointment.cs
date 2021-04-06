using System;
namespace csharp_practice.ltrnt.practice24.shkabura.entity
{
    public class Appointment : IComparable<Appointment>
    {
        static DateTime startDateTime = new DateTime(2021, 4, 5, 8, 0, 0); // Понедельник
        static int id = 0;

        private int localId;
        private DateTime dateTime;
        private Doctor doctor;
        private Patient patient;
        private Room room;

        public Appointment()
        {
        }

        public Appointment(DateTime dateTime, Doctor doctor, Patient patient, Room room)
        {
            this.DateTime = dateTime;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Room = room;

            this.localId = Appointment.id++;
        }

        public int LocalId { get => localId; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public Doctor Doctor { get => doctor; set => doctor = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public Room Room { get => room; set => room = value; }

        public int CompareTo(Appointment other)
        {
            return this.dateTime.CompareTo(other.dateTime);
        }
    }
}
