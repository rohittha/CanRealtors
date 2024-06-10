using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Realtor.API.Middleware
{
    //public class ErrorHandlingMiddleware
    //{
    //    private readonly RequestDelegate _next;

    //    public ErrorHandlingMiddleware(RequestDelegate next)
    //    {            
    //        _next = next;
    //    }
    //    public async Task Invoke(HttpContext context)
    //    {
    //        try
    //        {
    //            await _next(context);
    //        }
    //        catch (Exception ex) 
    //        {
    //            await HandleExceptionAsync(context, ex);
    //        }
    //    }

    //    public static Task HandleExceptionAsync(HttpContext context, Exception exception)
    //    {
    //        var code = HttpStatusCode.InternalServerError;
    //        var result = JsonSerializer.Serialize(new { error = "An error occured while processig your request!" });
    //        context.Response.ContentType = "application/json";
    //        context.Response.StatusCode = (int)code;
    //        return context.Response.WriteAsync(result);
    //    }



    //}
}
