using System;
using System.Collections.Generic;
using csharp_practice.ltrnt.practice24.shkabura.entity;
using csharp_practice.ltrnt.practice24.shkabura.entity.enums;

namespace csharp_practice.ltrnt.practice24.shkabura
{

    // TODO Добавить проверку на корректность создания записи.
    // TODO Добавить CRUD для записей.
    // TODO Добавить вывод расписания врача на неделю.
    public class Hospital
    {
        private List<Doctor> doctors;
        private List<Room> rooms;
        private List<Patient> patients;
        private List<Appointment> appointments; // TODO Sort after each action with list for generate good schedule

        public Hospital()
        {
            doctors = new List<Doctor>();
            rooms = new List<Room>();
            patients = new List<Patient>();
            appointments = new List<Appointment>();
        }

        // Doctors
        public bool AddDoctor(String fullname, Specialty specialty, WorkShift[] workShifts)
        {
            Doctor doctor = new Doctor(fullname, specialty, workShifts);

            if (doctors.Contains(doctor))
            {
                return false;
            }

            doctors.Add(doctor);
            return true;
        }

        public bool DeleteDoctor(int id)
        {
            Doctor target = null;

            foreach (var item in doctors)
            {
                if (item.LocalId == id)
                {
                    target = item;
                    break;
                }
            }

            if (target != null)
            {
                doctors.Remove(target);
                return true;
            }

            return false;
        }

        public bool DeleteDoctor(String fullname)
        {
            Doctor target = null;

            foreach (var item in doctors)
            {
                if (item.Fullname.Equals(fullname))
                {
                    target = item;
                    break;
                }
            }

            if (target != null)
            {
                doctors.Remove(target);
                return true;
            }

            return false;
        }

        public Doctor FindDoctor(String fullname)
        {
            Doctor target = null;

            foreach (var item in doctors)
            {
                if (item.Fullname.Equals(fullname))
                {
                    target = item;
                    break;
                }
            }

            return target;
        }

        // Rooms
        public bool AddRoom(int number, Specialty specialty)
        {
            Room room = new Room(number, specialty);

            if (rooms.Contains(room))
            {
                return false;
            }

            rooms.Add(room);
            return true;
        }

        public bool DeleteRoom(int id)
        {
            Room target = null;

            foreach (var item in rooms) 
            {
                if (id == item.LocalId)
                {
                    target = item;
                    break;
                }
            }

            if (target != null)
            {
                rooms.Remove(target);
                return true;
            }

            return false;
        }

        public Room FindRoom(int id)
        {
            Room target = null;

            foreach (var item in rooms)
            {
                if (id == item.LocalId)
                {
                    target = item;
                    break;
                }
            }

            return target;
        }

        // Patients
        public bool AddPatient(String fullname)
        {
            Patient patient = new Patient(fullname);

            if (patients.Contains(patient))
            {
                return false;
            }

            patients.Add(patient);
            return true;
        }

        public bool DeletePatient(int id)
        {
            Patient target = null;

            foreach (var item in patients)
            {
                if (item.LocalId == id)
                {
                    target = item;
                    break;
                }
            }

            if (target != null)
            {
                patients.Remove(target);
                return true;
            }

            return false;
        }

        public bool DeletePatient(String fullname)
        {
            Patient target = null;

            foreach (var item in patients)
            {
                if (item.Fullname.Equals(fullname))
                {
                    target = item;
                    break;
                }
            }

            if (target != null)
            {
                patients.Remove(target);
                return true;
            }

            return false;
        }

        public Patient FindPatient(String fullname)
        {
            Patient target = null;

            foreach (var item in patients)
            {
                if (item.Fullname.Equals(fullname))
                {
                    target = item;
                    break;
                }
            }

            return target;
        }

        // Appointments
        private bool CheckBeforeCreateAppointment(Doctor doctor, Patient patient)
        {
            return false;
        }
    }

}
