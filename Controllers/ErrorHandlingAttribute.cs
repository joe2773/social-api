using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ErrorHandlingAttribute : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        // Perform your error handling logic here
        // You can access the thrown exception using context.Exception
        // You can modify the result or response based on the exception

        if(context.Exception is ValidationException validationException){
             context.Result = new BadRequestObjectResult(validationException.Message);
        } 
        if(context.Exception is NotFoundException notFoundException){
            context.Result = new NotFoundObjectResult(notFoundException.Message ?? "Resource not found");
        }
        if(context.Exception is DomainException domainException){
            context.Result = new ObjectResult(domainException.Message);
        }
        // For example, you can return a specific status code and error message
       
        
        // Set the ExceptionHandled flag to true to indicate that the exception has been handled
        context.ExceptionHandled = true;
    }
}
