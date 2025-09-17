using AutoMapper;
using DataLayer.Data;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            // Clinic
            CreateMap<Clinic, ClinicEntity>();

            // Doctor
            CreateMap<Doctor, DoctorEntity>();

            // Employee
            CreateMap<Employee, EmployeeEntity>();

            // Medical Record
            CreateMap<MedicalRecord, MedicalRecordData>();

            // Patient
            CreateMap<Patient, PatientData>();

            // Person (صححتها)
            CreateMap<Person, PersonEntity>();

            // User
            CreateMap<User, UserEntity>();
            
            //Appointment
            CreateMap<AppointmentEntity , AppointmentResposeDTO>();
            CreateMap< Appointment ,AppointmentEntity>();

            //cclsConsultationMode
            CreateMap<ConsultationMode, ConsultationModeEntity>();
        }
    }
    }
