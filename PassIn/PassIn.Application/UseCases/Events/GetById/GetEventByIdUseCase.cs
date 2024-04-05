using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.GetById;

public class GetEventByIdUseCase
{
    public ResponseEventJson Execute(Guid id)
    {
        var dbContext = new PassInDbContext(); // instancia db

        var entity = dbContext.Events.Find(id);  // vai na base de dados procurar por um evento com o id

        if(entity is null) //se o resultado da procura for nulo, é lançado uma exceção
            throw new PassInException("An event with this id dont exist."); 

        return new ResponseEventJson
        {
            Id = entity.Id,
            Title = entity.Title,
            Details = entity.Details,
            MaximumAttendees = entity.Maximum_Attendees,
            AttendeesAmount = -1,
        };
    }
}
