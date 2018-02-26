using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sabs.AccountService.Exceptions;

namespace Sabs.AccountService.Controllers.Filters
{
    public class GenericExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(!context.ExceptionHandled)
            {
                if(context.Exception is DataRetentionException)
                {
                    OnDataRetentionException(context);
                }
                else
                {
                    OnUnknownException(context);
                }
            }
        }

        public void OnUnknownException(ExceptionContext context)
        {
            Exception exception = context.Exception;
            ExceptionResult result = new ExceptionResult(exception, false);
            context.Result = result;
        }

        public void OnDataRetentionException(ExceptionContext context)
        {
            if(context.Exception is DataRetentionException)
            {
                DataRetentionException exception = context.Exception as DataRetentionException;
                BadRequestObjectResult result = new BadRequestObjectResult(new {exception = exception.Message});
                context.Result = result;
            }
        }
    }
}
