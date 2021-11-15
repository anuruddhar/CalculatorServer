#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Online Calculator         
   Module      -   Middleware
   Sub_Module  -   
   Copyright   -   Anuruddha.Rajapaksha   

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
09/11/2021        	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
#endregion

namespace Calculator.Middleware {
    public class ExceptionMiddleware {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {
            try {
                await _next.Invoke(context);
            }  catch (Exception ex) {
                await HandleExceptionAsync(context, ex);
            }
        }


        private async Task HandleExceptionAsync(HttpContext context, Exception exception) {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //await response.WriteAsync(JsonConvert.SerializeObject(new ErrorResponse() {
            //    Message = exception.Message,
            //    Description = "Unexpected Error"
            //}));
            await response.WriteAsync(JsonConvert.SerializeObject(exception));
        }

    }
}
