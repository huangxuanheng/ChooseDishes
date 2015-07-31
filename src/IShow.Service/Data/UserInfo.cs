//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace IShow.Service.Data
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    
    [DataContract(Namespace = "www.IShow.com", IsReference = true)]
    public partial class UserInfo
    {
        public UserInfo()
        {
            this.Role = new HashSet<Role>();
        }
    
        [DataMember]
        public int OperatorId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string OperatorName { get; set; }
        [DataMember]
        public string OperatorPwd { get; set; }
        [DataMember]
        public System.DateTime CreateTime { get; set; }
        [DataMember]
        public string CreatePerson { get; set; }
        [DataMember]
        public Nullable<System.DateTime> EditTime { get; set; }
        [DataMember]
        public string EditPerson { get; set; }
        [DataMember]
        public Nullable<int> Deleted { get; set; }
    
        [DataMember]
        public virtual Employee Employee { get; set; }
        [DataMember]
        public virtual ICollection<Role> Role { get; set; }
    }
}
