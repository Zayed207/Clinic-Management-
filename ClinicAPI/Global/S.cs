using AutoMapper;
using BusinessLayer;
using BusinessLayer.b;
using DataLayer.Contract;
using DataLayer;
using DataLayer.Data;
using DataLayer.Entities;
using static BusinessLayer.Patient;
namespace ClinicAPI.Global
{


    public static class DI
    {
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
        {
            // Data Layer
            services.AddScoped<IAppointmentRepository, AppointmentData>();
            services.AddScoped<IAppointmentStatusRepository, AppointmentStatusData>();
            services.AddScoped<IAppointmentTypeRepository, AppointmentTypeData>();
            services.AddScoped<IAccountRepository, AccountData>();
            services.AddScoped<IClinicRepository, ClinicData>();
            services.AddScoped<IConsultationModeRepository, ConsultationModeData>();
            services.AddScoped<IDoctorRepository, DoctorData>();
            services.AddScoped<IEmployeeRepository, EmployeeData>();
            services.AddScoped<IMedicalRecordRepository, MedicalRecordData>();
            services.AddScoped<INurseRepository, NurseData>();
            services.AddScoped<IPatientRepository, PatientData>();
            //services.AddScoped<IPayPalRepository, PayPalData>();
            services.AddScoped<IPersonRepository, PersonData>();
            services.AddScoped<IUserRepository, UserData>();
            services.AddScoped<IDoctorTypeRepository, DoctorTypeData>();
            //services.AddScoped<IEmployeeTypeRepository, EmployeeData>();
            services.AddScoped<IPaymentRepository, PaymentData>();
            services.AddScoped<IPaymentProviderRepository, PaymentProviderData>();
            services.AddScoped<IScheduleRepository, ScheduleData>();

            
            services.AddScoped<AppointmentServices>();
            services.AddScoped<AppointmentStatusServices>();
            services.AddScoped<AppointmentTypeServices>();
            services.AddScoped<AccountServices>();
            services.AddScoped<ClinicServices>();
            services.AddScoped<ConsultationModeServices>();
            services.AddScoped<DoctorServices>();
            services.AddScoped<EmployeeServices>();
            services.AddScoped<MedicalRecordServices>();
            services.AddScoped<NurseServices>();
            services.AddScoped<PatientServices>();
            //services.AddScoped<PayPalServices>();
            services.AddScoped<PersonServices>();
            services.AddScoped<UserServices>();
            services.AddScoped<DoctorTypeServices>();
            //services.AddScoped<EmployeeTypeServices>();
            //services.AddScoped<PaymentServices>();
            //services.AddScoped<PaymentProviderServices>();
            //services.AddScoped<ScheduleServices>();

            return services;
        }
}

}




