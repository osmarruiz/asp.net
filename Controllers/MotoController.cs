using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practica2.Models;
using Newtonsoft.Json;

namespace Practica2.Controllers;

public class MotoController : Controller
{
    
    public List<Moto> lstmotos = null;
    public MotoController()
    {
        var myJsonString = System.IO.File.ReadAllText("Models/Moto.json");
        lstmotos = JsonConvert.DeserializeObject<List<Moto>>(myJsonString);
    }
    public IActionResult Index()
    {
        return View(lstmotos);
    }

    public IActionResult Find(String Moto)
    {
        List<Moto> lstresultmotos = new List<Moto>();
        foreach(var item in lstmotos){
            if(item.Marca.ToLower().Contains(Moto.ToLower()) || item.Modelo.ToLower().Contains(Moto.ToLower())){
                lstresultmotos.Add(item);
            }
        }
        return View("Index", lstresultmotos);
    }
    public IActionResult Details(int Id)
    {
        List<Moto> lstresultmotos = new List<Moto>();
        foreach(var item in lstmotos){
            if(item.Id == Id){
                return View(item);
            }
        }
        return View(new Moto());
    }
}
