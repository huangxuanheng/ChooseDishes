using GalaSoft.MvvmLight;
using IShow.ChooseDishes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace IShow.ChooseDishes.Model
{
    [DataContract(Namespace = "www.IShow.com", IsReference = true)]
    public partial class CompanyBean : ObservableObject
    {
        int _CompanyId;
        public int CompanyId {
            get
            {
                return _CompanyId;
            }
            set
            {
                Set("CompanyId", ref _CompanyId, value);
            }
        }
        string _CompanyName;
        public string CompanyName
        {
            get
            {
                return _CompanyName;
            }
            set
            {
                Set("CompanyName", ref _CompanyName, value);
            }
        }
        string _Contacts;
        public string Contacts
        {
            get
            {
                return _Contacts;
            }
            set
            {
                Set("Contacts", ref _Contacts, value);
            }
        }
        string _Phone;
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                Set("Phone", ref _Phone, value);
            }
        }
        string _Mobile;
        public string Mobile
        {
            get
            {
                return _Mobile;
            }
            set
            {
                Set("Mobile", ref _Mobile, value);
            }
        }
        string _Email;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                Set("Email", ref _Email, value);
            }
        }
        string _Addr;
        public string Addr
        {
            get
            {
                return _Addr;
            }
            set
            {
                Set("Addr", ref _Addr, value);
            }
        }
        string _Logo1;
        public string Logo1
        {
            get
            {
                return _Logo1;
            }
            set
            {
                Set("Logo1", ref _Logo1, value);
            }
        }
        string _Logo2;
        public string Logo2
        {
            get
            {
                return _Logo2;
            }
            set
            {
                Set("Logo2", ref _Logo2, value);
            }
        }
        string _DPName;
        public string DPName
        {
            get
            {
                return _DPName;
            }
            set
            {
                Set("DPName", ref _DPName, value);
            }
        }
        string _DPAddr;
        public string DPAddr
        {
            get
            {
                return _DPAddr;
            }
            set
            {
                Set("DPAddr", ref _DPAddr, value);
            }
        }
        string _DPParam;
        public string DPParam
        {
            get
            {
                return _DPParam;
            }
            set
            {
                Set("DPParam", ref _DPParam, value);
            }
        }
        DateTime _CreateTime;
        public System.DateTime CreateTime
        {
            get
            {
                return _CreateTime;
            }
            set
            {
                Set("CreateTime", ref _CreateTime, value);
            }
        }
        string _CreatePerson;
        public string CreatePerson
        {
            get
            {
                return _CreatePerson;
            }
            set
            {
                Set("CreatePerson", ref _CreatePerson, value);
            }
        }
        DateTime? _EditTime;
        public System.DateTime? EditTime
        {
            get
            {
                return _EditTime;
            }
            set
            {
                Set("EditTime", ref _EditTime, value);
            }
        }
        string _EditPerson;
        public string EditPerson
        {
            get
            {
                return _EditPerson;
            }
            set
            {
                Set("EditPerson", ref _EditPerson, value);
            }
        }
        int _Deleted;
        public int Deleted
        {
            get
            {
                return _Deleted;
            }
            set
            {
                Set("Deleted", ref _Deleted, value);
            }
        }


        public CompanyBean CreateCompanyBean(Company bean)
        {
            this.CompanyId = bean.CompanyId;
            this.CompanyName = bean.CompanyName;
            this.Contacts = bean.Contacts;
            this.Phone = bean.Phone;
            this.Mobile = bean.Mobile;
            this.Email = bean.Email;
            this.Addr = bean.Addr;
            this.Logo1 = bean.Logo1;
            this.Logo2 = bean.Logo2;
            this.DPName = bean.DPName;
            this.DPAddr = bean.DPAddr;
            this.DPParam = bean.DPParam;
            this.CreateTime = bean.CreateTime;
            this.CreatePerson = bean.CreatePerson;
            this.EditTime = bean.EditTime;
            this.EditPerson = bean.EditPerson;
            this.Deleted = bean.Deleted;
            return this;

        }
        public Company CreateCompany(CompanyBean bean)
        {
            Company beanBack = new Company();
            beanBack.CompanyId = bean.CompanyId;
            beanBack.CompanyName = bean.CompanyName;
            beanBack.Contacts = bean.Contacts;
            beanBack.Phone = bean.Phone;
            beanBack.Mobile = bean.Mobile;
            beanBack.Email = bean.Email;
            beanBack.Addr = bean.Addr;
            beanBack.Logo1 = bean.Logo1;
            beanBack.Logo2 = bean.Logo2;
            beanBack.DPName = bean.DPName;
            beanBack.DPAddr = bean.DPAddr;
            beanBack.DPParam = bean.DPParam;
            beanBack.CreateTime = bean.CreateTime;
            beanBack.CreatePerson = bean.CreatePerson;
            beanBack.EditTime = bean.EditTime;
            beanBack.EditPerson = bean.EditPerson;
            beanBack.Deleted = bean.Deleted;
            return beanBack;

        }

        public Boolean Verification(CompanyBean bean)
        {
            Boolean flag = false;
            var regexTelephone = new Regex(@"^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$");
            var regexMobilePhone = new Regex(@"^[1][358]\d{9}$");
            String strExp = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
               
               
                if (!string.IsNullOrWhiteSpace(bean.Phone)) {
                    if (!regexTelephone.IsMatch(bean.Phone) && !regexMobilePhone.IsMatch(bean.Phone))
                    {
                         MessageBox.Show("请填写正确的电话号码！");
                        return flag;
                    }
                }

                if (!string.IsNullOrWhiteSpace(bean.Mobile)) {
                    if (!regexMobilePhone.IsMatch(bean.Mobile))
                    {
                        MessageBox.Show("请填写正确的手机号码！");
                        return flag;
                    }
                }
                if (!string.IsNullOrWhiteSpace(bean.Email))
                {
                    Regex r = new Regex(strExp);
                    Match m = r.Match(bean.Email);
                    if (!m.Success)
                    {
                        MessageBox.Show("请填写正确的邮箱地址！");
                        return flag;
                    }
                }
             return true;
        }
    }


}
