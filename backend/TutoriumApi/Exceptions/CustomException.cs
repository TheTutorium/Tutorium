using tutorium.Utils;

namespace tutorium.Exceptions
{
    public class CustomException : Exception
    {
        public MessageObject MessageObject { get; set; }
        public CustomException(string message) : base(message)
        {
            MessageObject = new MessageObject { Message = message };
        }
    }
}
