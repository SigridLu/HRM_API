using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRM_API_ApplicationCore.Models;
using RHRM_API_ApplicationCore.Entities;
using RHRM_API_ApplicationCore.Models;

namespace HRM_API_Infrastructure.Helpers
{
    public static class ModelMapper
    {
        public static CandidateResponseModel ToCandidateResponseModel(this Candidate candidate)
        {
            return new CandidateResponseModel
            {
                Id = candidate.Id,
                Email = candidate.Email,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                MiddleName = candidate.MiddleName,
                ResumeURL = candidate.ResumeURL
            };
        }
        public static EmployeeTypeResponseModel ToEmployeeTypeResponseModel(this EmployeeType empType)
        {
            return new EmployeeTypeResponseModel
            {
                Id = empType.Id,
                TypeName = empType.TypeName
            };
        }
        public static JobRequirementResponseModel ToJobRequirementResponseModel(this JobRequirement jR)
        {
            return new JobRequirementResponseModel
            {
                Id = jR.Id,
                NumberOfPosition = jR.NumberOfPosition,
                Title = jR.Title,
                Description = jR.Description,
                HiringManagerId = jR.HiringManagerId,
                HiringManagerName = jR.HiringManagerName,
                StartDate = jR.StartDate,
                IsActive = jR.IsActive,
                ClosedOn = jR.ClosedOn,
                ClosedReason = jR.ClosedReason,
                CreatedOn = jR.CreatedOn,
                JobCategoryId = jR.JobCategoryId

                /*public JobCategory? JobCategory { get; set; } //Manager, employee, Lead, Senior, 
        public List<EmployeeRequirementType>? EmployeeRequirementTypes { get; set;} //Parttime, intern, Fulltime
        public List<Submission>? Submissions { get; set; }*/
            };
        }
        public static StatusResponseModel ToStatusResponseModel(this Status status)
        {
            return new StatusResponseModel
            {
                Id = status.Id,
                SubmissionId = status.SubmissionId,
                State = status.State,
                ChangedOn = status.ChangedOn,
                StatusMessage = status.StatusMessage
            };
        }
        public static SubmissionResponseModel ToSubmissionResponseModel(this Submission sub)
        {
            return new SubmissionResponseModel
            {
                Id = sub.Id,
                JobRequirementId = sub.JobRequirementId,
                CandidateId = sub.CandidateId,
                SubmittedOn = sub.SubmittedOn,
                ConfirmedOn = sub.ConfirmedOn,
                RejectedOn = sub.RejectedOn,
                CurrentStatus = sub.CurrentStatus
            };
        }

        public static WeatherResponseModel ToWeatherResponseModel(this WeatherForecast weather)
        {
            return new WeatherResponseModel
            {
                Id = weather.Id,
                Date = weather.Date,
                TemperatureC = weather.TemperatureC,
                //TemperatureF =  32 + (int)(weather.TemperatureC / 0.5556),
                Summary = weather.Summary
            };
        }
    }

}
