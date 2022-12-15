using FinalProjectCSharpTrybe.Enums;

namespace FinalProjectCSharpTrybe.Controllers.Response
{
    public class BaseResponse
    {
        public ResponseStatus Status { get; set; }
        public object Result { get; set; }
        
        public BaseResponse(ResponseStatus status, object result) 
        { 
            Status = status;
            Result = result;
        }
    }
}
