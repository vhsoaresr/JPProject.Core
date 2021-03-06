using System;
using FluentValidation;
using JPProject.Admin.Domain.Commands.PersistedGrant;

namespace JPProject.Admin.Domain.Validations.PersistedGrant
{
    public abstract class PersistedGrantValidation<T> : AbstractValidator<T> where T : PersistedGrantCommand
    {
        protected void ValidateKey()
        {
            RuleFor(c => c.Key).NotEmpty();
        }
    }
}