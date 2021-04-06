using System;
using System.Collections.Generic;

namespace csharp_practice.ltrnt.practice24.shkabura.entity
{
    public class Patient
    {
        static int id = 0;

        private int localId;
        private String fullname;

        public Patient(String fullname)
        {
            this.Fullname = fullname;
            this.localId = Patient.id++;
        }

        public string Fullname { get => fullname; set => fullname = value; }
        public int LocalId { get => localId; }

        public override string ToString()
        {
            return "Patient with ID: " + localId + ". Fullname: " + fullname;
        }

        public override bool Equals(object obj)
        {
            return obj is Patient patient &&
                   fullname == patient.fullname;
        }

        public override int GetHashCode()
        {
            return -1176568369 + EqualityComparer<string>.Default.GetHashCode(fullname);
        }
    }
}
