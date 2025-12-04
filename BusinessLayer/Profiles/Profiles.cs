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
            CreateMap<MedicalRecord, MedicalRecordEntity>();

            // Patient
            CreateMap<Patient, PatientEntity>();

            // Person (صححتها)
            CreateMap<Person, PersonEntity>();

            // User
            CreateMap<User, UserEntity>();

            //Appointment
            CreateMap<AppointmentEntity, AppointmentResposeDTO>();
            CreateMap<Appointment, AppointmentEntity>();

            CreateMap<AppointmentTypeDTO, AppointmentEntity>();

            //cclsConsultationMode
            CreateMap<ConsultationMode, ConsultationModeEntity>();

            CreateMap<AppointmentsDetails, AppointmentsDetailsDTO>();
            //public AppointmentProfile()
            //{
            //    // من Details إلى DTO
            //    CreateMap<AppointmentDetails, AppointmentDto>()
            //        .ForMember(dest => dest.PatientFullName,
            //                   opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            //        .ForMember(dest => dest.AppointmentType,
            //                   opt => opt.MapFrom(src => src.AppointmentTypeName))
            //        .ForMember(dest => dest.AppointmentStatus,
            //                   opt => opt.MapFrom(src => src.AppointmentStatusName))
            //        .ForMember(dest => dest.Hour,
            //                   opt => opt.MapFrom(src => src.AppointmentDateTime.Hour));

            //    // والعكس (لو احتجت ترجّع البيانات تاني مثلاً)
            //    CreateMap<AppointmentDto, AppointmentDetails>()
            //        .ForMember(dest => dest.FirstName,
            //                   opt => opt.MapFrom(src => src.PatientFullName.Split(' ')[0]))
            //        .ForMember(dest => dest.LastName,
            //                   opt => opt.MapFrom(src => src.PatientFullName.Split(' ').Length > 1
            //                       ? src.PatientFullName.Split(' ')[1]
            //                       : ""))
            //        .ForMember(dest => dest.AppointmentTypeName,
            //                   opt => opt.MapFrom(src => src.AppointmentType))
            //        .ForMember(dest => dest.AppointmentStatusName,
            //                   opt => opt.MapFrom(src => src.AppointmentStatus))
            //        .ForMember(dest => dest.AppointmentDateTime,
            //                   opt => opt.Ignore()); // لأنك ما عندكش تاريخ كامل في الـ DTO
            //}
        }
    }
    }
    
