namespace Hqv.CSharp.Common
{
    /// <summary>
    /// Message used for warnings
    /// </summary>
    public class Message
    {
        public Message(string title, object additionalInfo)
        {
            Title = title;
            AdditionalInfo = additionalInfo;
        }

        public string Title { get; }
        public object AdditionalInfo { get; }
    }
}