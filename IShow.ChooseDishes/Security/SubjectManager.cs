
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace IShow.ChooseDishes.Security
{
    public class SubjectManager
    {

        /// <summary>
        /// 测试
        /// </summary>
        private static Subject CurrentSubjectInstance=Subject.Login("1000",null,null);

        /// <summary>
        /// 
        /// 登录
        /// </summary>
        /// <param name="orginal">原有的认证TOken，登录的TOken</param>
        /// <param name="login"></param>
        /// <returns></returns>
        public static Subject Login(AuthenticationToken orginal,AuthenticationToken login){
            if (null == login || orginal==null) {
                throw new AuthenticationException("验证TOKEN不能为空！");
            }
            if (ValidateToken(orginal, login))
            {
                CurrentSubjectInstance = Subject.Login(orginal.Id.ToString(), null, null);
                return CurrentSubjectInstance;
            }   
            else {
                //认证失败
                throw new AuthenticationException("鉴定用户证书密码不匹配！");
            }
        }

        public static object GetPrincipal()
        {
            return GetSubject().GetPrincipal();
        }

        public static Subject GetSubject() {
            if (null == CurrentSubjectInstance) {
                throw new AuthenticationException();
            }
            return CurrentSubjectInstance;
        }

        protected static bool ValidateToken(AuthenticationToken orginal, AuthenticationToken login)
        {
            if (!orginal.Username.Equals(login.Username)) {
                throw new AuthenticationException("验证证书信息与原有的证书信息不符合,原有："+orginal.Username+",验证："+login.Username);
            }

            string salt=orginal.Salt;
            string encryptCredentials= CryptoUtils.MD5Encrypt(login.Credentials);
            return orginal.Credentials.Equals(encryptCredentials);
            
        }
    }
}
