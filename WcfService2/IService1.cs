using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService2.Model;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {


        // TODO: Add your service operations here

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "seller-rgister", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SellerRegisterRes RegisterSeller(SellerRegisterReq sellerRegisterReq);


        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "seller-login", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        SellerLoginRes LoginSeller(SellerLoginReq sellerLoginReq);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "add-product", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        AddProductRes AddProduct(Product product);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "get-all-product", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Product> GetAllProducts();
    }

    [DataContract]
    public class SellerRgister
    {


        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }

        // Add other properties as needed
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

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
