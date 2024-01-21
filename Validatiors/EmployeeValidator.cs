using FluentValidation;
using StaffApplication.DTOs;
using Microsoft.AspNetCore.Identity;

namespace StaffRegistrationPortal.Validatiors
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployee>
    {
        public CreateEmployeeValidator() 
        {
            RuleFor(x => x.UserId)
               .GreaterThan(0).WithMessage("UserId must be greater than zero.");
          
            RuleFor(x => x.DobUploadPath)
                .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                .WithMessage("DobUploadPath is required.");
            RuleFor(x => x.CertificateUploadPath)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("CertificateUploadPath is required.");
            RuleFor(x => x.PassportUploadPath)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("PassportUploadPath is required.");
            RuleFor(x => x.MaritalStatus)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("MaritalStatus is required.");
            RuleFor(x => x.EmploymentStatus)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("EmploymentStatus is required.");
            RuleFor(x => x.WorkingExperience)
               .GreaterThan(-1).WithMessage("Working Experience years is needed");
            RuleFor(x => x.Disability)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("Disability is required,Enter None if there is no any and Yes for one.");
            RuleFor(x => x.IdUploadPath)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("IdUploadPath name is required.");
            RuleFor(x => x.CreatedBy)
                .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                .WithMessage("Createdby  name is required.");
        }

    }

    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployee>
    {
        public UpdateEmployeeValidator()
        {

            RuleFor(x => x.Id)
               .GreaterThan(0).WithMessage("Id must be greater than zero.");
           
            RuleFor(x => x.UserId)
               .GreaterThan(0).WithMessage("UserId must be greater than zero.");
            
            RuleFor(x => x.DobUploadPath)
                .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                .WithMessage("DobUploadPath is required.");
            RuleFor(x => x.CertificateUploadPath)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("CertificateUploadPath is required.");
            RuleFor(x => x.PassportUploadPath)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("PassportUploadPath is required.");
            RuleFor(x => x.MaritalStatus)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("MaritalStatus is required.");
            RuleFor(x => x.EmploymentStatus)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("EmploymentStatus is required.");
            RuleFor(x => x.WorkingExperience)
               .GreaterThan(-1).WithMessage("Working Experience years is needed");
            RuleFor(x => x.Disability)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("Disability is required,Enter None if there is no any and Yes for one.");
            RuleFor(x => x.IdUploadPath)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("IdUploadPath name is required.");
            RuleFor(x => x.UpdatedBy)
                .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                .WithMessage("Createdby  name is required.");
        }

    }

    public class DeleteEmployeeValidator : AbstractValidator<DeleteEmployee>
    {
        public DeleteEmployeeValidator()
        {

            RuleFor(x => x.Id)
               .GreaterThan(0).WithMessage("Id must be greater than zero.");

            RuleFor(x => x.DeletedBy)
                .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                .WithMessage("Createdby  name is required.");

        }

    }




}
