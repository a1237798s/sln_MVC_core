using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace prj_MVC_core.Models
{
    public class CCustomerWrap
    {
        private TCustomer _customer = null;
        public TCustomer customer 
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public CCustomerWrap() 
        {
            _customer = new TCustomer();
        }

        [DisplayName("編號")]
        public int Fid {
            get { return _customer.Fid; }
            set { _customer.Fid = value; }
        }

        [Required(ErrorMessage = "姓名是必填欄位")]
        [DisplayName("姓名")]
        public string? FName {
            get { return _customer.FName; }
            set { _customer.FName = value; }
        }

        [DisplayName("電話")]
        public string? FPhone
        {
            get { return _customer.FPhone; }
            set { _customer.FPhone = value; }
        }

        [EmailAddress(ErrorMessage = "須為Email格式")]
        [DisplayName("Email")]
        public string? FEmail {
            get { return _customer.FEmail; }
            set { _customer.FEmail = value; }
        }

        [DisplayName("地址")]
        public string? FAddress {
            get { return _customer.FAddress; }
            set { _customer.FAddress = value; }
        }

        [DisplayName("密碼")]
        public string? FPassword {
            get { return _customer.FPassword; }
            set { _customer.FPassword = value; }
        }
    }
}
