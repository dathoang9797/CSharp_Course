using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebKoi.Model;

namespace WebKoi;

public class InvoiceController : BaseController
{
    public InvoiceController(IHttpContextAccessor accessor) : base(accessor)
    {
    }

    public IActionResult Index()
    {
        ViewBag.Statuses = new SelectList(Provider.Status.GetStatus(), "StatusId", "StatusName");
        return View(Provider.Invoice.GetInvoices());
    }

    public void LoadData()
    {
        ViewBag.Services = Provider.Service.GetService();
        ViewBag.Roles = Provider.Role.GetRoles();
        ViewBag.NumberOfOrder = new SelectList(Provider.NumberofOrder.GetNumberOfOrder(), "Id", "Name");
        ViewBag.Businesses = new SelectList(Provider.Business.GetBusiness(), "Id", "Name");
    }

    public IActionResult Details(int id)
    {
        ViewBag.Statuses = new SelectList(Provider.Status.GetStatus(), "StatusId", "StatusName");
        return View(Provider.Invoice.GetInvoice(id));
    }

    [HttpPost]
    public IActionResult Details(int id, Invoice obj)
    {
        obj.InvoiceId = id;
        var ret = Provider.Invoice.UpdateStatus(obj);
        if (ret > 0)
            return Redirect("/invoice");

        return Details(id);
    }

    public IActionResult Contact()
    {
        LoadData();
        return View();
    }

    [HttpPost]
    public IActionResult Contact(Customer obj)
    {
        if (ModelState.IsValid)
        {
            var ret = Provider.Customer.Add(obj);
            if (ret > 0)
            {
                TempData["Msg"] = "You Contact Success";
                return Redirect("/home/success");
            }

            ModelState.AddModelError("Error", "Inser Failed");
        }

        LoadData();
        return View(obj);
    }

    public IActionResult Select(short id = 1)
    {
        var list = Provider.Status.GetStatus();
        ViewBag.List = list;
        ViewBag.Statuses = new SelectList(Provider.Status.GetStatus(), "StatusId", "StatusName", id);
        return View(Provider.Invoice.GetInvoiceByStatus(id));
    }

    [HttpPost]
    public IActionResult Select(int[] ids, short statusId = 1)
    {
        Provider.Invoice.UpdateStatus(ids, statusId);
        return Redirect($"/invoice/select/{statusId}");
    }
}