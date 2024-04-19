using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
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

    public class CellController : Controller
    {
        private readonly IService _servicio;
        private readonly IMapper _mapper;


        private bool GetList()
        {
            var listMarca = _servicio.GetImagesNameType("Marca");
            var listCompany = _servicio.GetImagesNameType("Compañía").ToList();

            //Cargar las marcas ya predefinidas cuando se vayan a crear o editar el equipo
            //var listMarcas = new List<ListItem>()
            //{
            //     new ListItem() { Text = @"Apple", Value = "Apple"},
            //      new ListItem() { Text = @"BlackBerry", Value = "BlackBerry"},
            //       new ListItem() { Text = @"HTC", Value = "HTC"},
            //       new ListItem() { Text = @"LG", Value = "LG"},
            //       new ListItem() { Text = @"Motorola", Value = "Motorola"},
            //       new ListItem() { Text = @"Nokia", Value = "Nokia"},
            //       new ListItem() { Text = @"Samsung", Value = "Samsung"}
            //};

            //var marcas = listMarca.Select(marca => new ListItem() { Text = marca.NameType, Value = marca.NameType }).ToList();
            //marcas.AddRange(listMarcas);
            //ViewBag.ListaMarcas = marcas;


            var listGeneration = new List<ListItem>()
            {
                 new ListItem() { Text = @"1RA GEN", Value = "1RA GEN"},
                  new ListItem() { Text = @"2DA GEN", Value = "2DA GEN"},
                   new ListItem() { Text = @"3RA GEN", Value = "3RA GEN"},
                   new ListItem() { Text = @"4TA GEN", Value = "4TA GEN"},
                   new ListItem() { Text = @"5TA GEN", Value = "5TA GEN"},
                   new ListItem() { Text = @"6TA GEN", Value = "6TA GEN"},
                   new ListItem() { Text = @"7MA GEN", Value = "7MA GEN"}
            };

            if (listMarca == null || listCompany == null) return false;



            var companias = listCompany.Select(company => new ListItem() { Text = company.NameType, Value = company.NameType }).ToList();

            var listCondition = new List<ListItem>()
            {
                 new ListItem() { Text = @"Bueno", Value = "Bueno"},
                  new ListItem() { Text = @"Regular", Value = "Regular"},
                   new ListItem() { Text = @"Malo", Value = "Malo"}
            };
            ViewBag.ListCompany = companias;
            ViewBag.Condition = listCondition;
            ViewBag.Generation = listGeneration;
            return true;
        }

        private void ListTypeDivice()
        {
            var listType = new List<ListItem>()
            {
                 new ListItem() { Text = @"Iphone", Value = "Iphone"},
                  new ListItem() { Text = @"Phone", Value = "Phone"},
                   new ListItem() { Text = @"Ipad", Value = "Ipad"},
                   new ListItem() { Text = @"Tablets", Value = "Tablets"},
                   new ListItem() { Text = @"Ipod", Value = "Ipod"},
                   new ListItem() { Text = @"Computers", Value = "Computers"},
                   new ListItem() { Text = @"Other", Value = "Other"}
            };
            ViewBag.ListType = listType;
        }

        private void ListDataComputers()
        {

            //Size
            var listSize = new List<ListItem>()
            {
                new ListItem() { Text = @"Screen Size", Value = ""},
                 new ListItem() { Text = @"11.6", Value = "11.6"},
                  new ListItem() { Text = @"13.3", Value = "13.,3"},
                   new ListItem() { Text = @"17", Value = "17"},
                   new ListItem() { Text = @"19", Value = "19"},
                   new ListItem() { Text = @"21", Value = "21"}
            };
            //Processor
            var listProcessor = new List<ListItem>()
            {
                new ListItem() { Text = @"Processor", Value = ""},
                  new ListItem() { Text = @"1.40 GHz", Value = "1.40 GHz"},
                  new ListItem() { Text = @"1.8 GHz", Value = "1.8 GHz"},
                  new ListItem() { Text = @"2.00 GHz", Value = "2.00 GHz"},
                  new ListItem() { Text = @"2.26 GHz", Value = "2.26 GHz"},
                  new ListItem() { Text = @"2.40 GHz", Value = "2.40 GHz"},
                  new ListItem() { Text = @"2.50 GHz", Value = "2.50 GHz"},
                  new ListItem() { Text = @"2.66 GHz", Value = "2.66 GHz"},
                  new ListItem() { Text = @"2.70 GHz", Value = "2.70 GHz"},
                  new ListItem() { Text = @"2.80 GHz", Value = "2.80 GHz"},
                  new ListItem() { Text = @"2.90 GHz", Value = "2.90 GHz"},
                  new ListItem() { Text = @"2.93 GHzz", Value = "2.93 GHz"},
                  new ListItem() { Text = @"3.06 GHz", Value = "3.06 GHz"},
                  new ListItem() { Text = @"3.10 GHz", Value = "3.10 GHz"},
                  new ListItem() { Text = @"3.20 GHz", Value = "3.20 GHz"},
                  new ListItem() { Text = @"3.33 GHz", Value = "3.33 GHz"},
                  new ListItem() { Text = @"3.4 GHz", Value = "3.4 GHz"},
                  new ListItem() { Text = @"3.40 GHz", Value = "3.40 GHz"},
                  new ListItem() { Text = @"3.50 GHz", Value = "3.50 GHz"},
                  new ListItem() { Text = @"3.60 GHz", Value = "3.60 GHz"},
                  new ListItem() { Text = @"4.00 GHz", Value = "4.00 GHz"}

            };
            //Year
            var listYear = new List<ListItem>()

            {new ListItem() { Text = @"Year", Value = ""},
                new ListItem() { Text = @"2007", Value = "2006"},
                 new ListItem() { Text = @"2007", Value = "2007"},
                  new ListItem() { Text = @"2008", Value = "2008"},
                   new ListItem() { Text = @"2009", Value = "2009"},
                   new ListItem() { Text = @"2010", Value = "2010"},
                   new ListItem() { Text = @"2011", Value = "2011"},
                   new ListItem() { Text = @"2011", Value = "2012"},
                   new ListItem() { Text = @"2011", Value = "2013"},
                   new ListItem() { Text = @"2011", Value = "2014"}
            };
            ViewBag.ListSize = listSize;
            ViewBag.ListProcessor = listProcessor;
            ViewBag.ListYear = listYear;
        }

        //public void ListModelo()
        //{
        //    //Modelos de Iphone ya predefinidos
        //    var listModelo = new List<ListItem>()
        //    {
        //         new ListItem() { Text = @"Iphone 6S Plus", Value = "Iphone 6S Plus"},
        //          new ListItem() { Text = @"Iphone 6S", Value = "Iphone 6S"},
        //           new ListItem() { Text = @"Iphone 6 Plus", Value = "Iphone 6 Plus"},
        //           new ListItem() { Text = @"Iphone 6", Value = "Iphone 6"},
        //           new ListItem() { Text = @"Iphone 5S", Value = "Iphone 5S"},
        //           new ListItem() { Text = @"Iphone 5C", Value = "Iphone 5C"},
        //           new ListItem() { Text = @"Iphone 5", Value = "Iphone 5"},
        //           new ListItem() { Text = @"Iphone 4S", Value = "Iphone 4S"}
        //    };

        //    ViewBag.ListaModelo = listModelo;
        //}

        public JsonResult ListMarca(string type)
        {
            return Json(_servicio.ListMarca(type), JsonRequestBehavior.AllowGet);

        }

        public JsonResult ListModel(string type, string category)
        {
            return Json(_servicio.ListModel(type, category), JsonRequestBehavior.AllowGet);

        }

        private IEnumerable<IImagen> LoadImagesCell(Guid idEquipo)
        {
            return _servicio.GetImagesNameType("Equipo").Where(c => c.IdEquipo == idEquipo).ToList();


        }

        public CellController(IService servicio, IMapper mapper)
        {
            _servicio = servicio;
            _mapper = mapper;
        }


        //Crear lista del estado del celular
        // GET: Cell

        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");

            var list = _servicio.GetAll().ToList();

            for (int i = 0; i < list.Count(); i++)
            {
                list[i].Imagens = LoadImagesCell(list[i].Id);
            }

            return View(_mapper.Map<IEnumerable<CellModel>>(list));
        }
        // GET: Cell/Details/5
        public ActionResult Details(Guid id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            var cell = _servicio.GetCell(id);
            cell.Imagens = LoadImagesCell(cell.Id);
            return View(_mapper.Map<CellModel>(cell));
        }

        // GET: Cell/Create
        public ActionResult Create()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            //ListModelo();
            GetList();
            ListDataComputers();
            //ListTypeDivice();
            return View();
        }

        // POST: Cell/Create
        [HttpPost]
        public ActionResult Create(CellModel cell, HttpPostedFileBase[] files, string marca, string modelo, string tipo)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            //ListModelo();
            ListTypeDivice();
            ListDataComputers();
            if (!GetList()) return View(cell);
            if (!string.IsNullOrEmpty(modelo))
                cell.Model = modelo;
            if (string.IsNullOrEmpty(marca))
                return View(cell);
            cell.Category = marca;
            if (string.IsNullOrEmpty(tipo))
                return View(cell);
            cell.Type = tipo;
            if (tipo != "Computers")
            {
                cell.Processor = " ";
                cell.FrecuencyProcessor = " ";
            }

         

            var filepathtosave = "/Resources/notImage.jpg";

            var images = new Imagen()
            {
                PathImagen = filepathtosave,
                NameType = cell.Name,
                Category = "Equipo",
                Id = Guid.NewGuid(),
                Name = cell.Name
            };
            var imagenes = new List<Imagen>();
            if (files != null && files.Any())
            {


                foreach (var file in files)
                {
                    images = new Imagen();
                    if (file != null)
                    {
                        var filename = Path.GetFileName(file.FileName);
                        /*Saving the file in server folder*/
                        file.SaveAs(Server.MapPath("~/Upload/" + filename));
                        filepathtosave = "/Upload/" + filename;

                        images.PathImagen = filepathtosave;
                        images.Category = "Equipo";
                        images.NameType = cell.Name;
                        images.Name = cell.Name;
                        images.Id = Guid.NewGuid();
                        images.IdEquipo = cell.Id;
                        imagenes.Add(images);


                        /*HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE*/
                    } /*Geting the file name*/

                }

            }
            else
            {
                imagenes.Add(images);
            }

            cell.Imagens = imagenes;

            _servicio.AddCell(_mapper.Map<CellModel, Cell>(cell));
            return RedirectToAction("Index");
        }

        // GET: Cell/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            GetList();
            ListDataComputers();
            //ListModelo();
            ListTypeDivice();
            var c = _servicio.GetCell(id);
            c.Imagens = LoadImagesCell(c.Id);

            var cell = _mapper.Map<CellModel>(c);
            //ViewBag.NombreCategoria = new SelectList(_servicio.GetAgenciaAll(), "Nombre", "Nombre", agencia.Name);


            return View(cell);
        }


        // POST: Cell/Edit/5
        [HttpPost]
        public ActionResult Edit(CellModel cell, HttpPostedFileBase[] files, string tipo, string marca)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            ListDataComputers();
            //ListModelo();
            ListTypeDivice();
            if (string.IsNullOrEmpty(tipo))
                return View(cell);
            cell.Type = tipo;
            if (string.IsNullOrEmpty(marca))
                return View(cell);
            cell.Category = marca;

            GetList();
          

                var imagenes = new List<Imagen>();
                if (files != null && files.Any())
                {
                    var filepathtosave = "/Resources/notImage.jpg";
                    var images = new Imagen()
                    {
                        PathImagen = filepathtosave,
                        NameType = cell.Name,
                        Category = "Equipo",
                        Id = Guid.NewGuid(),
                        Name = cell.Name
                    };

                    foreach (var file in files)
                    {
                        images = new Imagen();
                        if (file != null)
                        {
                            var filename = Path.GetFileName(file.FileName);
                            /*Saving the file in server folder*/
                            file.SaveAs(Server.MapPath("~/Upload/" + filename));
                            filepathtosave = "/Upload/" + filename;

                            images.PathImagen = filepathtosave;
                            images.Category = "Equipo";
                            images.NameType = cell.Name;
                            images.Name = cell.Name;
                            images.Id = Guid.NewGuid();
                            imagenes.Add(images);

                            /*HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE*/
                        } /*Geting the file name*/

                    }

                }
                else
                {
                    cell.Imagens = LoadImagesCell(cell.Id);
                }
                var pathServer = Server.MapPath("~/");
                cell.Imagens = imagenes;
                _servicio.UpdateCell(_mapper.Map<Cell>(cell), pathServer);
                return RedirectToAction("Index");
           
            //  ViewBag.NombreCategoria = new SelectList(_servicio.GetAll(), "Nombre", "Nombre");

        }

        // GET: Cell/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            var cell = _servicio.GetCell(id);
            cell.Imagens = LoadImagesCell(cell.Id);
            return View(_mapper.Map<CellModel>(cell));
        }

        // POST: Cell/Delete/5  [HttpPost]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(Guid id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            var cell = _servicio.GetCell(id);
            cell.Imagens = LoadImagesCell(cell.Id);
            var pathServer = Server.MapPath("~/Upload/");
            _servicio.RemoveCell(_mapper.Map<Cell>(cell), pathServer);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAllCell()
        {
            try
            {
                var pathServer = Server.MapPath("~/Upload/");
                _servicio.RemoveAllCell(pathServer);
                return RedirectToAction("Index");
            }
            catch (Exception m)
            {

                return RedirectToAction("Index");
            }
           

        }


    }
}
