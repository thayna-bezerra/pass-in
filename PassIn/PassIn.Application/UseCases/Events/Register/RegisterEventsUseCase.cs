using PassIn.Communication.Requests;

namespace PassIn.Application.UseCases.Events.Register;

public class RegisterEventsUseCase
{
    public void Execute(RequestEventJson request) 
    {
        Validate(request);
    }

    private void Validate(RequestEventJson request)
    {
        if (request.MaximumAttendees <= 0) 
        {
            throw new ArgumentException("The maximum attendes is invalid.");
        }

        if(string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("The title is invalid");
        }

        if (string.IsNullOrWhiteSpace(request.Details))
        {
            throw new ArgumentException("The details is invalid");
        }
    }
}