using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService2.Model
{
    [DataContract]
    public class SellerRegisterReq
    {

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }


    }


    [DataContract]
    public class SellerRegisterRes
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}