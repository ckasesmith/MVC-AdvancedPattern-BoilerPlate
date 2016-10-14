using System.ComponentModel.DataAnnotations;
using WebApp.Resources;

namespace WebApp.Models
{
    public class Address
    {

        [Key]
        public int AddressId { get; set; }
        [Required]
        [Display(ResourceType = typeof(LanguagePack), Name = "Address_AddressName")]
        public string AddressName { get; set; }
        [StringLength(100)]
        [Display(Name = "Address Ln1")]
        public string AddressLn1 { get; set; }
        [StringLength(100)]
        [Display(Name = "Address Ln2")]
        public string AddressLn2 { get; set; }
        [Display(Name = "Country")]
        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }
        /// <summary>
        /// Limit invitation to a particular parish
        /// </summary>
        /// 
        [Display(Name = "State Parish Province")]
        public int? StateParishId { get; set; }
        public virtual StateParish StateParish { get; set; }


        public string UserId { get; set; }
        // [ForeignKey("UserId")]
        // public Manage User { get; set; }

    }
}
