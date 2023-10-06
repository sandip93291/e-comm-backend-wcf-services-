using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService2.Model
{
    public class SellerLoginReq
    {
      

        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }
    }
    public class SellerLoginRes
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}