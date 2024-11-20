using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCareSystem.Core.IServices.Appointment.Dtos;
using HealthCareSystem.Core.IServices.Department.Dtos;
using HealthCareSystem.Core.IServices.Doctor.Dtos;
using HealthCareSystem.Core.IServices.Hospital.Dtos;
using HealthCareSystem.Core.IServices.MedicalRecord.Dtos;
using HealthCareSystem.Core.IServices.Patient;
using HealthCareSystem.Core.IServices.Prescription.Dtos;
using HealthCareSystem.Core.IServices.Staff.Dtos;
using HealthCareSystem.Core.Models;
using HealthCareSystem.Core.Models.Identity;

namespace HealthCareSystem.API.Helper
{
    public class Mapping:Profile
    {
        public Mapping(){
            CreateMap<Doctor,DoctorDto>().ReverseMap();
            CreateMap<Doctor,CreateUpdateDoctorDto>().ReverseMap();

            CreateMap<Patient,PatientDto>().ReverseMap();
            CreateMap<Patient,CreateUpdatePatientDto>().ReverseMap();

            CreateMap<Staff,StaffDto>().ReverseMap();
            CreateMap<Staff,CreateUpdateStaffDto>().ReverseMap();

            CreateMap<Appointment,AppointmentDto>().ReverseMap();
            CreateMap<Appointment,CreateUpdateAppointmentDto>().ReverseMap();

            CreateMap<Prescription,PrescriptionDto>().ReverseMap();
            CreateMap<Prescription,CreateUpdatePrescriptionDto>().ReverseMap();

            CreateMap<MedicalRecord,MedicalRecordDto>().ReverseMap();
            CreateMap<MedicalRecord,CreateUpdateMedicalRecordDto>().ReverseMap();

            CreateMap<Hospital,HospitalDto>().ReverseMap();
            CreateMap<Hospital,CreateUpdateHosiptalDto>().ReverseMap();

            CreateMap<Department,DepartmentDto>().ReverseMap();
            CreateMap<CreateUpdateDepartmentDto,Department>().ReverseMap();

            CreateMap<Admin,RegisterDTO>().ReverseMap();
            CreateMap<Admin,LoginDTO>().ReverseMap();
        }

    }
}