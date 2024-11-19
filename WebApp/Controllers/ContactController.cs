using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;
using WebApp.Models.Services;

namespace WebApp.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    public IActionResult Index()
    {
        return View(_contactService.GetAll());
    }

    [Authorize(Roles = "admin")]
    [Authorize]
    public IActionResult Add()
    {
        ContactModel model = new ContactModel();
        model.Organizations = _contactService.GetOrganizations()
            .Select(e=> new SelectListItem()
            {
                Text = e.Name,
                Value = e.Id.ToString()
                
            }).ToList();
        
        return View(model);
    }

    [Authorize(Roles = "admin")]
    [HttpPost]
    public IActionResult Add(ContactModel cm)
    {
        
        if (!ModelState.IsValid)
        {
            ContactModel model = new ContactModel();
            model.Organizations = _contactService.GetOrganizations()
                .Select(e=> new SelectListItem()
                {
                    Text = e.Name,
                    Value = e.Id.ToString()
                
                }).ToList();
            return View(model);
        }
        
        _contactService.Add(cm);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        _contactService.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int id)
    {
        return View(_contactService.GetById(id));
    }

    public IActionResult Edit(int id)
    {
        return View(_contactService.GetById(id));
    }

    [HttpPost]
    public IActionResult Edit(ContactModel cm)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _contactService.Update(cm);
        return RedirectToAction(nameof(System.Index));
    }
}