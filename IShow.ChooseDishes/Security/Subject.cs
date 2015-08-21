using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShow.ChooseDishes.Security
{
    public class Subject
    {
        private HashSet<string> Premissions{
            get;
            set;
        }
        private HashSet<string> Roles{
            get;
            set;
        }

        public bool IsAuthenticationed
        {
            get;
            set;
        }

        private string Principal{
            get;
            set;
        }

        public bool IsLocal
        {
            get;
            set;
        }

        public void AddRoles(string[] roles) { 
            foreach(var r in roles){
                AddRole(r);
            }
        }


        public void AddRole(string role) {
            this.Roles.Add(role);
        }

        public void AddPremission(string premission)
        {
            this.Premissions.Add(premission);
        }

        /// <summary>
        /// 是否验证，即登录成功后，验证为true
        /// </summary>
        /// <returns></returns>
        private bool IsAuthorized
        {
            get;
            set;
        }


        protected Subject(string principal,List<string> roles,List<string> premissions){
            this.Principal=principal;
            this.IsAuthorized = true;
            this.IsLocal = true;
            this.Roles = new HashSet<string>();
            this.Premissions= new HashSet<string>();
            CopyToHashset(this.Roles, roles);
            CopyToHashset(this.Premissions, premissions);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="identity"></param>
        public static Subject Login(string principal,List<string> roles, List<string> premissions)
        {
            return new Subject(principal, roles, premissions);
        }

        protected static void CopyToHashset(HashSet<string> target, IEnumerable<string> source)
        {
            if (null == source) {
                return;
            }
            IEnumerator<string> iter = source.GetEnumerator();
            while (iter.MoveNext()) {
                target.Add(iter.Current);
            }
        }

        public void Logout() {
            this.Roles.Clear();
            this.Premissions.Clear();
        }

        public string GetPrincipal() {
            return Principal;
        }
       

        public bool HasRole(string roleName) {
            return Roles.Contains(roleName);
        }

        public bool HasPremission(string action) {
            return Premissions.Contains(action);
        }

        public string ToString() {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("{Principal:"+Principal);
            return builder.ToString();
        }
    }
}
