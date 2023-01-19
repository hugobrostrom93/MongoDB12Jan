namespace ASPNetMongoDB.Controllers;

using ASPNetMongoDB.Database;
using ASPNetMongoDB.Models;
using Microsoft.AspNetCore.Mvc;

public class VarorController : Controller
{
    #region Private Fields
    private readonly MongoDBContextVaror _mongoDBContext;

    #endregion Private Fields
    #region Public Constructors

    public VarorController() => _mongoDBContext = new MongoDBContextVaror();

    #endregion Public Constructors
    #region Public Methods
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Vara vara)
    {
        _mongoDBContext.CreateVaror(vara);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(string id)
    {
        _mongoDBContext.DeleteVara(id);
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
        var vara = _mongoDBContext.Get(id);
        return View(vara);
    }

    [HttpPost]
    public IActionResult Edit(Vara vara)
    {
        _mongoDBContext.UpdateVara(vara.Produkt, vara);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var vara = _mongoDBContext.GetAllVaror();
        return View(vara);
    }

    #endregion Public Methods
}