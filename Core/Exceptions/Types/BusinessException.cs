using System.Runtime.Serialization;

namespace Core.Exceptions.Types
{
    public class BusinessException:Exception
    {
        public BusinessException() { }

        protected BusinessException(SerializationInfo info,StreamingContext streamingContext) : base(info, streamingContext) { }

        public BusinessException(string? message):base(message)
        {
            
        }

        public BusinessException(string? message,Exception? exception):base(message,exception)
        {
            
        }
    }
}
