using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CC.Core.Mapping;
using CellService;
using Domain.T2C;
using Domain.T2C.Interface;
using T2C.Login;
using T2C.Models;

namespace T2C.Controllers
{
    [AllowAnonymous]
    public class PageController : Controller
    {
        private readonly IService _servicio;
        private readonly IMapper _mapper;

        public PageController(IService servicio, IMapper mapper)
        {
            _servicio = servicio;
            _mapper = mapper;
        }

        //Listar las compañia

        //Si marco una compañia, cargar lmarcas de esa compaña y mostrar los equpos
        //Cuando cargo la marca y la compañia mostrar los equipos de estas dopciones 



        public JsonResult ListCompanAndMarca(string name)
        {
            var list = _servicio.GetImagesNameType(name);
            return Json(list, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ListImageToType(string tipo)
        {
            var list = _servicio.GetImagesType(tipo);
            return Json(list, JsonRequestBehavior.AllowGet);
           
        }

        public JsonResult ListAllDivice()
        {
            var list = _servicio.GetAll();
            return Json(list, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ListComputers(string size, string processor, int year, string model, string category)
        {
            
            var list = _servicio.FilterComputers( Convert.ToDouble(size),  processor,  year,  model,  category);
            foreach (var t in list)
            {
                t.Imagens = LoadImagesCell(t.Id);
                if (!t.Imagens.Any())
                {
                    var pathImage = "/Resources/notImage.jpg";
                    t.Imagens = new List<IImagen>()
                    {
                        new Imagen()
                        {
                            PathImagen = pathImage
                        }
                    };
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);

        }

        public JsonResult FilterDivice(string name, string model, string company, string condition, int price,
            int memory, string category, string type, string generation)
        {
            var list = _servicio.ListCEll(name, model, company, condition, price, memory, category, type, generation);
            foreach (var t in list)
            {
                t.Imagens = LoadImagesCell(t.Id);
                if (!t.Imagens.Any())
                {
                    var pathImage = "/Resources/notImage.jpg";
                    t.Imagens = new List<IImagen>()
                    {
                        new Imagen()
                        {
                            PathImagen = pathImage
                        }
                    };
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public void ListAttributeCell(IEnumerable<CellModel> list)
        {
            var listModel = new List<ListItem>();
            var a = new ListItem() {Text = "Modelo", Value = string.Empty};
            listModel.Add(a);
            var listMemory = new List<ListItem>();
            a = new ListItem() {Text = "Capacidad", Value = "0"};
            listMemory.Add(a);
            var listCompany = new List<ListItem>();
            a = new ListItem() {Text = "Compania", Value = string.Empty};
            listCompany.Add(a);
            foreach (var cell in list)
            {
                var lista = new ListItem() {Text = cell.Model, Value = cell.Model};
                listModel.Add(lista);
                lista = new ListItem() {Text = cell.Memory.ToString(), Value = cell.Memory.ToString()};
                listMemory.Add(lista);
                lista = new ListItem() {Text = cell.Company, Value = cell.Company};
                listCompany.Add(lista);
            }

            ViewBag.Model = listModel;
            ViewBag.Memory = listMemory;
            ViewBag.Company = listCompany;
        }

        public void ListSelect()
        {
            // list.AddRange(from object state in Enum.GetValues(typeof(State)) select new ListItem() { Text = Enum.ToObject(typeof(State), state).ToString(), Value = Enum.ToObject(typeof(State), state).ToString() });
            //ViewBag.Activate = list;

            var listCondition = new List<ListItem>()
            {
                new ListItem() {Text = @"Condicion", Value = string.Empty},
                new ListItem() {Text = @"Bueno", Value = "Bueno"},
                new ListItem() {Text = @"Regular", Value = "Regular"},
                new ListItem() {Text = @"Malo", Value = "Malo"}
            };

            var listPrice = new List<ListItem>()
            {
                new ListItem() {Text = @"Precio", Value = "0"},
                new ListItem() {Text = @"$10 - $20", Value = "1"},
                new ListItem() {Text = @"$20 - 100", Value = "2"},
                new ListItem() {Text = @"$100 - $300", Value = "3"},
                new ListItem() {Text = @"$300 - más", Value = "4"}
            };


            ViewBag.Price = listPrice;
            ViewBag.Condition = listCondition;
        }

        private IEnumerable<IImagen> LoadImagesCell(Guid IdidEquipo)
        {
            return _servicio.GetImagesNameType("Equipo").Where(c => c.IdEquipo == IdidEquipo).ToList();


        }
       
        private void Visit(IEnumerable<CellModel> list)
        {
            list = list.OrderBy(e => e.Price).Take(8).ToList();
            var cellModels = list.ToArray();

            for (int i = 0; i < cellModels.Count(); i++)
            {
                cellModels[i].Imagens = LoadImagesCell(cellModels[i].Id);
            }
            ViewBag.Visits = list;
        }

        public ActionResult t2c()
        {
            return View();
        }

        public ActionResult Iphone()
        {
            return View(); 
        }
        public ActionResult Tablet()
        {
            return View();
        }
        public ActionResult Android()
        {
            return View();
        }
        public ActionResult Ipad()
        {
            return View();
        }
        public ActionResult Ipod()
        {
            return View();
        }
        public ActionResult Computers()
        {
            return View();
        }
        public ActionResult DetailsIpod(Guid id)
        {
            var cell = _servicio.GetCell(id);
            cell.Imagens = LoadImagesCell(cell.Id);
            return View(_mapper.Map<CellModel>(cell));
        }
        public ActionResult DetailsIpad(Guid id)
        {
            var cell = _servicio.GetCell(id);
            cell.Imagens = LoadImagesCell(cell.Id);
            return View(_mapper.Map<CellModel>(cell));
        }
        public ActionResult DetailsComputers(Guid id)
        {
            var cell = _servicio.GetCell(id);
            cell.Imagens = LoadImagesCell(cell.Id);
            return View(_mapper.Map<CellModel>(cell));
        }

        // GET: Cell
        public ActionResult Index()
        {
            ListSelect();
         
            var list = _mapper.Map<IEnumerable<CellModel>>(_servicio.GetAll());
            ListAttributeCell(list);
            Visit(list);
            return View(list);
        }
       
        [HttpPost]
        public ActionResult Index(string name, string model, string company, string condition,  int price, int memory,string category,string type,string generation)
        {
            ListSelect();
       
            var list = _mapper.Map<IEnumerable<CellModel>>(_servicio.GetAll());
            ListAttributeCell(list);
            Visit(list);
            var a = _mapper.Map<IEnumerable<CellModel>>(_servicio.ListCEll(name, model, company, condition, price, memory, category, type, generation));

            return View(a);
        }

        
        public ICell AddVisit(Guid id)
        {

            var cell = _servicio.GetCell(id);
            if (cell != null)
            {
                cell.Visits++;
                _servicio.UpdateCell(cell,"");

            }
            return cell;
        }
        public ActionResult Details(Guid id)
        
        {
            ListSelect(); 
         
            var list = _mapper.Map<IEnumerable<CellModel>>(_servicio.GetAll());
            ListAttributeCell(list);
            Visit(list);
            var cell = AddVisit(id);
            cell.Imagens = LoadImagesCell(cell.Id);
            return View(_mapper.Map<CellModel>(cell));
        }

       
      
       
    }
}