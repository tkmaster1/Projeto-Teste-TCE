namespace Livraria.Infrastructure.CrossCutting.Util
{
    public class JsonResponseFactory
    {
        public static object ErrorResponse(string error)
        {
            return new { Success = false, ErrorMessage = error };
        }

        public static object ErrorResponse()
        {
            return new { Success = false };
        }

        public static object AlertResponse(string alert, object referenceObject)
        {
            return new { Success = false, AlertMessage = alert, Data = referenceObject };
        }

        public static object SuccessResponse()
        {
            return new { Success = true };
        }

        public static object SuccessResponse(object referenceObject)
        {
            return new { Success = true, Data = referenceObject };
        }
    }
}
