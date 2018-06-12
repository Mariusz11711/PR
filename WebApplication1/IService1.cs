using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebApplication1.Models
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        string AddText(string Title, string Lead, string Content, int CategoryId, List<int> Tags = null);
        [OperationContract]
        string EditText(string Title = null, string Lead = null, string Content = null, int CategoryId = -1, List<int> Tags = null);
        [OperationContract]
        string DeleteText(string Title, int CategoryId);
        [OperationContract]
        string PublishText(string Title, int CategoryId);

    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        String stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}