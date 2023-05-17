using Laba_12;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab_16.Models;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Lab_16.Controllers;

public class HomeController : Controller
{
    static public MyNewDoublyLinkedList list = new MyNewDoublyLinkedList();
    public HomeController()
    {

    }

    public IActionResult Index()
    {
        return View();
    }


    public IActionResult Print()
    {
        return View(list);
    }


    public IActionResult Insert()
    {
        var message = TempData["Message"];

        if (message != null)
        {
            ViewBag.Message = message;
            TempData.Remove("Message");
        }
        return View();
    }

    public IActionResult Upload()
    {
        return View();
    }




    [HttpPost]
    public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            using var reader = new StreamReader(file.OpenReadStream());
            using var jsonReader = new JsonTextReader(reader);

            var serializer = new Newtonsoft.Json.JsonSerializer();
            var data = new List<object>();

            while (await jsonReader.ReadAsync())
            {
                if (jsonReader.TokenType == JsonToken.StartObject)
                {
                    var jObject = JObject.Load(jsonReader);
                    var typeName = jObject.GetValue("type").ToString();
                    var type = GetTypeFromString(typeName);

                    var model = serializer.Deserialize(jObject.CreateReader(), type);
                    list.Add((Place)model!);
                }
            }


            return RedirectToAction("Print");
        }

        return BadRequest();
    }

    private Type GetTypeFromString(string typeName)
    {
        switch (typeName)
        {
            case "Place":
                return typeof(Place);
            case "City":
                return typeof(City);
            case "Megapolis":
                return typeof(Megapolis);
            case "Area":
                return typeof(Area);
            case "Address":
                return typeof(Address);
            default:
                throw new Exception($"Unknown type '{typeName}'.");
        }
    }









    public IActionResult DownloadJson()
    {

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        var jsonBytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(list, options);
        var fileName = "mydata.json";

        return File(jsonBytes, "application/json", fileName);
    }

    public IActionResult DownloadTxt()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        var jsonBytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(list, options);
        var txtContent = Encoding.UTF8.GetString(jsonBytes);
        var fileName = "mydata.txt";

        return File(Encoding.UTF8.GetBytes(txtContent), "text/plain", fileName);
    }



    [HttpPost]
    public IActionResult AddPlace(string name, string id)
    {
        int placeId;
        if (int.TryParse(id, out placeId))
        {
            TempData["Message"] = "Выполнено";
            Place place = new Place(name, placeId);
            list.Add(place);
        }
        else
        {
            TempData["Message"] = "Ошибка";
        }
        var message = TempData["Message"];
        if (message as string == "Ошибка")
        {
            return RedirectToAction("Insert");
        }
        else
        {
            return RedirectToAction("Print");
        }
    }

    [HttpPost]
    public IActionResult AddCity(string name, string id)
    {
        int cityId;
        if (int.TryParse(id, out cityId))
        {
            TempData["Message"] = "Выполнено";
            City city = new City();
            city.Id = cityId;
            city.Name = name;
            list.Add(city);
        }
        else
        {
            TempData["Message"] = "Ошибка";
        }
        var message = TempData["Message"];
        if (message as string == "Ошибка")
        {
            return RedirectToAction("Insert");
        }
        else
        {
            return RedirectToAction("Print");
        }
    }

    [HttpPost]
    public IActionResult AddArea(string name, string id, string longetuide, string width)
    {
        int areaId;
        int areaLong;
        int areaWidth;
        if (int.TryParse(id, out areaId) && int.TryParse(longetuide, out areaLong) && int.TryParse(width, out areaWidth))
        {
            TempData["Message"] = "Выполнено";
            Area area = new Area();
            area.Id = areaId;
            area.Name = name;
            area.Longuitude = areaLong;
            area.Width = areaWidth;
            list.Add(area);
        }
        else
        {
            TempData["Message"] = "Ошибка";
        }
        var message = TempData["Message"];
        if (message as string == "Ошибка")
        {
            return RedirectToAction("Insert");
        }
        else
        {
            return RedirectToAction("Print");
        }
    }

    [HttpPost]
    public IActionResult AddAddress(string name, string id, string street, string numbHome)
    {
        int addresId;
        int addresNumber;
        if (int.TryParse(id, out addresId) && int.TryParse(numbHome, out addresNumber))
        {
            TempData["Message"] = "Выполнено";
            Address address = new Address();
            address.Id = addresId;
            address.Name = name;
            address.NumbHome = addresNumber;
            address.Street = street;
            list.Add(address);
        }
        else
        {
            TempData["Message"] = "Ошибка";
        }
        var message = TempData["Message"];
        if (message as string == "Ошибка")
        {
            return RedirectToAction("Insert");
        }
        else
        {
            return RedirectToAction("Print");
        }
    }


    [HttpPost]
    public IActionResult AddMegapolis(string name, string id, string budjet)
    {
        int megaId;
        int megaBudjet;
        if (int.TryParse(id, out megaId) && int.TryParse(budjet, out megaBudjet))
        {
            TempData["Message"] = "Выполнено";
            Megapolis megapolis = new Megapolis();
            megapolis.Id = megaId;
            megapolis.Name = name;
            megapolis.Budjet = megaBudjet;
            list.Add(megapolis);
        }
        else
        {
            TempData["Message"] = "Ошибка";
        }
        var message = TempData["Message"];
        if (message as string == "Ошибка")
        {
            return RedirectToAction("Insert");
        }
        else
        {
            return RedirectToAction("Print");
        }
    }
}

