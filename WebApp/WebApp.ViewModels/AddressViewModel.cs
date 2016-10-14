using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Resources;

namespace WebApp.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public int AddressId { get; set; }
        [Required]
        [Display(ResourceType = typeof(LanguagePack), Name = "Address_AddressName")]
        public string AddressName { get; set; }
        [StringLength(100)]
        [Display(ResourceType = typeof(LanguagePack), Name = "Address_AddressLn1")]
        public string AddressLn1 { get; set; }
        [StringLength(100)]
        [Display(ResourceType = typeof(LanguagePack), Name = "Address_AddressLn2")]
        public string AddressLn2 { get; set; }
        [Display(ResourceType = typeof(LanguagePack), Name = "Address_Country")]
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        [Display(ResourceType = typeof(LanguagePack), Name = "Address_Parish")]
        public int? StateParishId { get; set; }
        public virtual StateParish StateParish { get; set; }
        [Display(ResourceType = typeof(LanguagePack), Name = "User_Identity")]
        public string UserId { get; set; }

        public SelectList CountryList { get; set; }
        public SelectList StateParishList { get; set; }
    }
}
