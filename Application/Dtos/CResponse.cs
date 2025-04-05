using System.Runtime.Serialization;


namespace Application.Dtos
{
    [DataContract]
    public class CResponse
    {
        [DataMember]
        public int statusCode;

        [DataMember]
        public string message = "";
    }
}