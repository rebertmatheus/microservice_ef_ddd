using System.Collections.Generic;
using System.Linq;

namespace TransactionContext.Api.Responses
{
    public class Response
    {
        public List<string> Errors { get; set; }
        public object Message { get; set; }

        public Response()
        {
            Errors = new List<string>();
        }

        public Response(object message, params string[] errors)
        {
            Message = message;
            Errors = errors.ToList();
        }
    }   
}
