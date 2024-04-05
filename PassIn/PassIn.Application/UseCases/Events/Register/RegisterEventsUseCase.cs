using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.Register;

public class RegisterEventsUseCase
{
    public ResponseRegisteredEventJson Execute(RequestEventJson request) 
    {
        Validate(request);

        var dbContext = new PassInDbContext();

        var entity = new Infrastructure.Entities.Event //instanciando classe //criando objeto para o evento
        {
            Title = request.Title,
            Details = request.Details,
            Maximum_Attendees = request.MaximumAttendees,
            Slug = request.Title.ToLower().Replace(" ", "-"),
        };

        dbContext.Events.Add(entity); //preparação
        dbContext.SaveChanges(); //execução

        return new ResponseRegisteredEventJson
        {
            Id = entity.Id,
        };
    }

    private void Validate(RequestEventJson request)
    {
        if (request.MaximumAttendees <= 0) 
        {
            throw new ErrorOnValidationException("The maximum attendes is invalid.");
        }

        if(string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ErrorOnValidationException("The title is invalid");
        }

        if (string.IsNullOrWhiteSpace(request.Details))
        {
            throw new ErrorOnValidationException("The details is invalid");
        }
    }
}