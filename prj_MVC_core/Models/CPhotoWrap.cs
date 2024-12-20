using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace prj_MVC_core.Models
{
    public class CPhotoWrap
    {
        private TPhoto _photo = null;
        public TPhoto photo
        {
            get { return _photo; }
            set { _photo = value; }
        }

        public CPhotoWrap()
        {
            _photo = new TPhoto();
        }

        [DisplayName("編號")]
        public int Fid
        {
            get { return _photo.Fid; }
            set { _photo.Fid = value; }
        }

        
        [DisplayName("上傳日期")]
        public string? FDate
        {
            get { return _photo.FDate; }
            set { _photo.FDate = value; }
        }

        [DisplayName("照片描述")]
        public string? FDescription
        {
            get { return _photo.FDescription; }
            set { _photo.FDescription = value; }
        }
       
        [DisplayName("上傳者ID")]
        public int? FOwnerId
        {
            get { return _photo.FOwnerId; }
            set { _photo.FOwnerId = value; }
        }

        [DisplayName("照片名稱")]
        public string? FImage
        {
            get { return _photo.FImage; }
            set { _photo.FImage = value; }
        }

        public IFormFile photoPath { get;set;}

        public TCustomer postUser {  get;set;}
    }
}
