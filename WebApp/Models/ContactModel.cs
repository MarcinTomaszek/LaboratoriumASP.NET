using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;

namespace WebApp.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(length:20, ErrorMessage = "Name must have at most 20 characters")]
    [MinLength(length:2, ErrorMessage = "Name must have at least 2 characters")]
    [Display(Name = "Name")]
    public string FirstName { get; set; }  
    
    [Required]
    [MaxLength(length:50, ErrorMessage = "Surame must have at most 50 characters")]
    [MinLength(length:2, ErrorMessage = "Surame must have at least 2 characters")]
    [Display(Name = "Surname")]
    public string LastName { get; set; }
    
    [EmailAddress]
    [Display(Name = "E-mail")]
    public string Email { get; set; }
    
    [Phone]
    [RegularExpression("\\d{3} \\d{3} \\d{3}",ErrorMessage = "Type number in format xxx xxx xxx")]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
    
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    public DateOnly BirthDate { get; set; }

    
    [Display(Name = "Category")]
    public Category Category { get; set; }

    [Display(Name = "Organization")]
    [HiddenInput] public int OrganizationId { get; set; }

    public OrganizationEntity? Organization { get; set; }
    
    [ValidateNever] public List<SelectListItem> Organizations { get; set; }
}