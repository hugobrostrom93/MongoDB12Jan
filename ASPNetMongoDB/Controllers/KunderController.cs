namespace ASPNetMongoDB.Controllers;

using ASPNetMongoDB.Database;
using ASPNetMongoDB.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

public class KunderController : Controller
{
    #region Private Fields

    private readonly MongoDBContextKunder _mongoDBContext;
    private readonly MongoDBContextOrder _mongoDBContextOrder;

    #endregion Private Fields

    #region Public Constructors

    public KunderController()
    {
        _mongoDBContext = new MongoDBContextKunder();
        _mongoDBContextOrder = new MongoDBContextOrder();
    }

    #endregion Public Constructors

    #region Public Methods

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Kund kund)
    {
        _mongoDBContext.CreateKund(kund);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(string id)
    {
        _mongoDBContext.DeleteKund(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(string id)
    {
        var kund = _mongoDBContext.Get(id);
        var orders = _mongoDBContextOrder.GetAllOrders().Where(o => o.KundId == id).ToList();
        var viewModel = new ViewModel(kund, orders);
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Edit(string id)
    {
        var kund = _mongoDBContext.Get(id);
        return View(kund);
    }
    
    [HttpPost]
    public IActionResult Edit(Kund kund)
    {
        _mongoDBContext.UpdateKund(kund.Id, kund);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Index()
    {
        var order = _mongoDBContext.GetAllKunder();
        return View(order);
    }

    #endregion Public Methods
}