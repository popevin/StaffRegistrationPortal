using FluentValidation;
using Microsoft.AspNetCore.Identity;
using StaffApplication.DTOs;

namespace StaffRegistrationPortal.Validatiors
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.GenderId)
                .GreaterThan(0).WithMessage("GenderId must be greater than zero.");
            RuleFor(x => x.GenderId)
               .LessThan(3).WithMessage("GenderId cannot be greater than two.");

            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("RoleId must be greater than zero.");
            RuleFor(x => x.RoleId)
               .LessThan(3).WithMessage("RoleId cannot be greater than two.");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("DepartmentId must be greater than zero.");

            RuleFor(x => x.FirstName)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("FirstName is required.");
            RuleFor(x => x.LastName)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("LastName is required.");
            RuleFor(x => x.Email)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("Email is required.");
            RuleFor(x => x.Password)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("Password is required.");
            RuleFor(x => x.Address)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("Address is required.");
            RuleFor(x => x.Phone)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("Phone number is required.");
            RuleFor(x => x.CreatedBy)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("CreatedBy name is required.");
        }
    }


    public class UpdateUserValidator : AbstractValidator<UpdateUser>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Id must be greater than zero.");

            RuleFor(x => x.GenderId)
                .GreaterThan(0).WithMessage("GenderId must be greater than zero.");
            RuleFor(x => x.GenderId)
               .LessThan(3).WithMessage("GenderId cannot be greater than two.");

            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("RoleId must be greater than zero.");
            RuleFor(x => x.RoleId)
               .LessThan(3).WithMessage("RoleId cannot be greater than two.");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("DepartmentId must be greater than zero.");

            RuleFor(x => x.FirstName)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("FirstName is required.");
            RuleFor(x => x.LastName)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("LastName is required.");
            RuleFor(x => x.Email)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("Email is required.");
            RuleFor(x => x.Password)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("Password is required.");
            RuleFor(x => x.Address)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("Address is required.");
            RuleFor(x => x.Phone)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("Phone number is required.");
            RuleFor(x => x.UpdatedBy)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("CreatedBy name is required.");
            RuleFor(x => x.IsActive)
                 .NotNull().Must(value => value == true || value == false)
                 .WithMessage("IsActive must be either true or false.");
            RuleFor(x => x.IsUpdated)
                 .NotNull().Must(value => value == true || value == false)
                 .WithMessage("IsUpdated must be either true or false.");

        }
    }

    
    public class EmailandPasswordValidator: AbstractValidator<EmailandPassword>
    {
        public EmailandPasswordValidator()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("Email is required.");
            RuleFor(x => x.Password)
                 .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                 .WithMessage("Password is required.");
        }
    }

    public class  DeactivatorValidator: AbstractValidator<DeactivateUser>
    {
        public DeactivatorValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x.DeactivateEmail)
                .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                .WithMessage("Email to be Deactivated is required");
            RuleFor(x => x.DeactivatedBy)
                .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                .WithMessage("DeactivatedBy field is required");
        }
    }

    public class ReactivatorValidator : AbstractValidator<ReactivateUser>
    {
        public ReactivatorValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
            RuleFor(x => x.ReactivateEmail)
                .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                .WithMessage("Email to be Reactivated is required");
            RuleFor(x => x.ReactivatedBy)
                .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
                .WithMessage("ReactivatedBy field is required");
        }
    }

    public class EmailValidator : AbstractValidator<EmailInput>
    {
        public EmailValidator()
        {
            RuleFor(x => x.Email)
               .NotEmpty().Must(value => !string.IsNullOrEmpty(value) && !value.Contains("string"))
               .WithMessage("Email Input is required");
        }

      
    }
    public class IdValidator:AbstractValidator<InputId>
    {
        public IdValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
