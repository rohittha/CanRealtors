﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Realtor.API.Filters
{
    //public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    //{
    //    public override void OnException(ExceptionContext context)
    //    {
    //        var exception  =context.Exception;
    //        var problemDetails = new ProblemDetails
    //        {
    //            Type = "https://tools.ietf.org/doc/html/rfc7321#section-6.6.1",
    //            Title = "An error occured while processing your request",
    //            Status = (int)HttpStatusCode.InternalServerError,
    //        };
    //        context.Result = new ObjectResult(new { error = "error occured!" })
    //        {
    //            StatusCode = 500
    //        };
    //        context.ExceptionHandled = true;
    //    }


    //}
}
