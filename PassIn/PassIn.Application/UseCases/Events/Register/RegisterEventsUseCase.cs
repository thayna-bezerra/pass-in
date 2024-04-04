﻿using PassIn.Communication.Requests;
using PassIn.Exceptions;

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
            throw new PassInException("The maximum attendes is invalid.");
        }

        if(string.IsNullOrWhiteSpace(request.Title))
        {
            throw new PassInException("The title is invalid");
        }

        if (string.IsNullOrWhiteSpace(request.Details))
        {
            throw new PassInException("The details is invalid");
        }
    }
}