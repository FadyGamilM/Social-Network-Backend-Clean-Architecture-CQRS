using Social.Application.Constants;

namespace Social.Application.Helpers
{
   public class GenericHandlersResponse<T> where T : class
   {
      // the payload we need to return to the client if the request is handled 
      public T Payload {get; set;}

      public bool IsSuccess {get; set;}

      public List<Error> Errors {get; set;} = new List<Error>();
   }
}