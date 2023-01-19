namespace ASPNetMongoDB.Controllers;

using ASPNetMongoDB.Database;
using ASPNetMongoDB.Models;
using Microsoft.AspNetCore.Mvc;

public class OrdrarController : Controller
{
    #region Private Fields

    private readonly MongoDBContextOrder _mongoDBContext;

    #endregion Private Fields

    #region Public Constructors

    public OrdrarController()
    {
        _mongoDBContext = new MongoDBContextOrder();
    }
    #endregion Public Constructors
    #region Public Methods

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Order order)
    {
        var kundId = order.KundId;
        _mongoDBContext.CreateOrder(order);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(string id)
    {
        _mongoDBContext.DeleteOrder(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(string id)
    {
        var vara = _mongoDBContext.Get(id);
        return View(vara);
    }
    
    [HttpGet]
    public IActionResult Edit(string id)
    {
        var order = _mongoDBContext.Get(id);
        return View(order);
    }

    [HttpPost]
    public IActionResult Edit(Order order)
    {
        _mongoDBContext.UpdateOrder(order.KundId, order);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var order = _mongoDBContext.GetAllOrders();
        return View(order);
    }

    #endregion Public Methods
}