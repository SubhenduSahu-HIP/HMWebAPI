using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HM_Admin.Filters
{
    public class ApiResponseStatusCodeFilter : IAlwaysRunResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult && objectResult.Value != null)
            {
                var statusCodeProp = objectResult.Value.GetType().GetProperty("StatusCode");
                if (statusCodeProp?.GetValue(objectResult.Value) is int statusCode)
                {
                    objectResult.StatusCode = statusCode;
                    context.HttpContext.Response.StatusCode = statusCode;
                }
            }
        }

        public void OnResultExecuted(ResultExecutedContext context) { }
    }
}
