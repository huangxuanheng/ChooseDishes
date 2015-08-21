using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Security
{
    public class AuthenticationToken
    {

        public AuthenticationToken(int _Id, string _Username, string _Credentials,string _Salt, bool _Disabled, bool _Expired) {
            this.Id = _Id;
            this.Username = _Username;
            this.Credentials = _Credentials;
            this.Salt = _Salt;
            this.Dishabled = _Disabled;
            this.Expired = Expired;
        }

        public AuthenticationToken(string _Username, string _Credentails):this(0,_Username,_Credentails,null,false,false) { 
            
        }

        public bool IsDisabled() {
            return this.Dishabled;
        }

        public bool IsExpried() {
            return this.Expired;

        }

        /// <summary>
        /// 认证ID
        /// </summary>
        public int Id
        {
            get;
            set;
        }
        /// <summary>
        /// 认证用户名
        /// </summary>
        public string Username
        {
            get;
            set;
        }
        /// <summary>
        /// 认证证书密码
        /// </summary>
        public string Credentials
        {
            get;
            set;
        }
        /// <summary>
        /// 加密字符串
        /// </summary>
        public string Salt
        {
            get;
            set;
        }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Dishabled
        {
            get;
            set;
        }
        /// <summary>
        /// 是否过期
        /// </summary>
        public bool Expired
        {
            get;
            set;
        }

    }
}
