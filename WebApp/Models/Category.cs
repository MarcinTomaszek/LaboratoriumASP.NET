using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public enum Category
{
    [Display(Name = "Family", Order = 1)]
    Family,
    [Display(Name = "Friend")]
    Friend,
    [Display(Name = "Business")]
    Business,
}