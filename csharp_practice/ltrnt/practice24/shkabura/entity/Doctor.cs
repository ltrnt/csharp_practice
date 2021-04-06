using System;
using System.Collections.Generic;
using csharp_practice.ltrnt.practice24.shkabura.entity.enums;

namespace csharp_practice.ltrnt.practice24.shkabura.entity
{
    public class Doctor
    {
        static DateTime firstShiftStart = new DateTime(2021, 4, 5, 8, 0, 0);
        static DateTime firstShiftEnd = new DateTime(2021, 4, 5, 13, 0, 0);
        static DateTime secondShiftStart = new DateTime(2021, 4, 5, 14, 0, 0);
        static DateTime secondShiftEnd = new DateTime(2021, 4, 5, 18, 0, 0);

        static int id = 0;

        private int localId;
        private String fullname;
        private Specialty specialty;
        private WorkShift[] workShifts;

        public Doctor(string fullname, Specialty speciality, WorkShift[] workShifts)
        {
            this.Fullname = fullname;
            this.Speciality = speciality;
            this.WorkShifts = workShifts;

            this.localId = Doctor.id++;
        }

        public string Fullname { get => fullname; set => fullname = value; }
        public Specialty Speciality { get => specialty; set => specialty = value; }
        public WorkShift[] WorkShifts { get => workShifts; set => workShifts = value; }
        public int LocalId { get => localId; }

        public override string ToString()
        {
            string result = "Врач с ID: " + localId + ". Fullname: " + fullname + ". Specialty: " + specialty;

            result += "Work shifts: { ";

            for (int i = 0; i < workShifts.Length; i++)
            {
                if (workShifts[i] == WorkShift.FirstShift)
                {
                    result += (i + 1) + " = first, ";
                }
                else
                {
                    result += (i + 1) + " = second, ";
                }
            }

            result += "}";

            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is Doctor doctor &&
                   fullname == doctor.fullname;
                   //&&
                   //specialty == doctor.specialty &&
                   //EqualityComparer<WorkShift[]>.Default.Equals(workShifts, doctor.workShifts);
        }

        public override int GetHashCode()
        {
            int hashCode = -1781895549;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(fullname);
            hashCode = hashCode * -1521134295 + specialty.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<WorkShift[]>.Default.GetHashCode(workShifts);
            return hashCode;
        }
    }
}
