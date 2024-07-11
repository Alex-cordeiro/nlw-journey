using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;

namespace Journey.Application.UseCases.Trips.Register
{
    public class RegisterTripValidator : AbstractValidator<RequestRegisterTripJson>
    {
        public RegisterTripValidator()
        {

            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.NAME_EMPTY);

            RuleFor(request => request.StartDate)
                .GreaterThanOrEqualTo(DateTime.UtcNow.Date).WithMessage(ResourceErrorMessages.DATE_LATER_THAN_TODAY);

            RuleFor(request => request)
                .Must(request => request.EndDate >= request.StartDate)
                .WithMessage(ResourceErrorMessages.DATE_LATER_THAN_TODAY);
        }

    }
}
