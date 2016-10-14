using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
  public class StateParish
    {
       public int StateParishId { get; set; }
       public int CountryId { get; set; }
       [ForeignKey("CountryId")]
       public Country Country { get; set; }
       public string StateParishName { get; set; }
    }
}
