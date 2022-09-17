namespace Social.Application.Helpers
{
   public class GenericHandlersResponse<T> where T : class
   {
      // the payload we need to return to the client if the request is handled 
      public T Payload {get; set;}

      public bool IsSuccess {get; set;}

      public IEnumerable<string> Errors {get; set;}
   }
}