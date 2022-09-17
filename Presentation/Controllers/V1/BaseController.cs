using Microsoft.AspNetCore.Mvc;
using Social.Application.Constants;
using Social.Application.Helpers;
using Social.Presentation.Common;

namespace Social.Presentation.Controllers.V1
{
   [ApiController]
   public class BaseController : ControllerBase
   {
      protected IActionResult ErrorHandlingPipeline(List<Error> errors)
      {
         var ApiError = new ErrorResponse();            
         // handling the not found error
         if (errors.Any(E => E.Code == ErrorCode.NotFound))
         {
            var NotFoundError = errors.Where(e => e.Code == ErrorCode.NotFound).FirstOrDefault();
            // define the api-layer error because we should return json object to follow the rest principls

            ApiError.StatusCode = ((int)NotFoundError.Code);
            ApiError.StatusPhrase = "Not Found";
            ApiError.Timespan = DateTime.Now;
            ApiError.Errors.Add(NotFoundError.Message);
            
            return NotFound(ApiError);
         }

         // for other server errors =>
         var ServerError = errors.Where(e => e.Code == ErrorCode.ServerError).FirstOrDefault();
         ApiError.StatusCode = ((int)ServerError.Code);
         ApiError.StatusPhrase = "Server Error";
         ApiError.Timespan = DateTime.Now;
         ApiError.Errors.Add(ServerError.Message);

         return StatusCode(ApiError.StatusCode ,ApiError);
      }
   }
}