using System.ComponentModel.DataAnnotations;
using WebApp.Resources;

namespace WebApp.Models
{

    public class Country
    {
        public int CountryId { get; set; }
        public string Tld { get; set; }  // top level domain (JM, same thing geoip use it too)
        [Display(ResourceType = typeof(LanguagePack), Name = "Country_CountryName")]
        public string CountryName { get; set; } // not not free, i got it from Shawn it dare
                                                // you sort that out.
        public string Capital { get; set; }
    }
}
