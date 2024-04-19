using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CC.Core.Mapping;
using CellService;
using Domain.T2C;
using T2C.Login;
using T2C.Models;

namespace T2C.Controllers
{
[AllowAnonymous]
    public class ImagenController : Controller
    {
        private readonly IService _servicio;
        private readonly IMapper _mapper;

        public ImagenController(IService servicio, IMapper mapper)
        {
            _servicio = servicio;
            _mapper = mapper;
        }

      
        public void ListSelect()
        {
            // list.AddRange(from object state in Enum.GetValues(typeof(State)) select new ListItem() { Text = Enum.ToObject(typeof(State), state).ToString(), Value = Enum.ToObject(typeof(State), state).ToString() });
            //ViewBag.Activate = list;

            var listCategorias = new List<ListItem>()
            {
               
                 new ListItem() { Text = @"Compañía", Value = "Compañía"},
                  new ListItem() { Text = @"Marca", Value = "Marca"}
            };
            var listCondition = new List<ListItem>()
            {
                 new ListItem() { Text = @"Bueno", Value = "Bueno"},
                  new ListItem() { Text = @"Regular", Value = "Regular"},
                   new ListItem() { Text = @"Malo", Value = "Malo"}
            };


            ViewBag.ListCondition = listCondition;



            ViewBag.ListCategriaImagenes = listCategorias;

        }
        // GET: Imagen
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            return View(_mapper.Map<IEnumerable<ImagenModel>>(_servicio.GetAllImagen()));
        }

        // GET: Imagen/Details/5
        public ActionResult Details(Guid id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");

            return View(_mapper.Map<ImagenModel>(_servicio.GetImagen(id)));
        }

        // GET: Imagen/Create
        public ActionResult Create()
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            ListSelect();
            
            return View();
        }

        // POST: Imagen/Create
        [HttpPost]
        public ActionResult Create(ImagenModel imagen, HttpPostedFileBase[] files,string category,string type)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            ListSelect();
            if (string.IsNullOrEmpty(category))
                return View();
            imagen.Category = category;
            imagen.Type = type;
            try
            {
                var filename = string.Empty;
                var filepathtosave = "/Resources/notImage.jpg";
                if (files != null && files.Any())
                {
                    foreach (HttpPostedFileBase file in files)
                    {
                        if (file != null)
                        {
                            filename = Path.GetFileName(file.FileName);
                            /*Saving the file in server folder*/
                            file.SaveAs(Server.MapPath("~/Upload/" + filename));
                            filepathtosave = "/Upload/" + filename;
                            /*HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE*/
                        }
                        /*Geting the file name*/

                    }

                }
                
                imagen.Name = filename;
                imagen.PathImagen = filepathtosave;
                _servicio.AddImagen(_mapper.Map<ImagenModel, Imagen>(imagen));

                ViewBag.Message = "La imagen subio satisfactoriamente";
                return RedirectToAction("Create");
            }
            catch(Exception m)
            {
                ViewBag.MessageData = m.Message;
            }
            return View();
        }




        // GET: Imagen/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            ListSelect();
          
            var imagen = _mapper.Map<ImagenModel>(_servicio.GetImagen(id));
            //ViewBag.NombreCategoria = new SelectList(_servicio.GetAgenciaAll(), "Nombre", "Nombre", agencia.Name);


            return View(imagen); 
        }

        // POST: Imagen/Edit/5
        [HttpPost]
        public ActionResult Edit(ImagenModel imagen, HttpPostedFileBase[] files)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            ListSelect();
           
            if (ModelState.IsValid)
            {

                if (files != null && files[0]!=null)
                {
                    var filename = string.Empty;
                    var filepathtosave = "/Resources/notImage.jpg";
                    foreach (HttpPostedFileBase file in files)
                    {
                        if (file != null)
                        {
                            filename = Path.GetFileName(file.FileName);
                            /*Saving the file in server folder*/
                            file.SaveAs(Server.MapPath("~/Upload/" + filename));
                            filepathtosave = "/Upload/" + filename;
                            /*HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE*/
                        }
                        /*Geting the file name*/

                    }
                    imagen.Name = filename;
                    imagen.PathImagen = filepathtosave;

                }

                var pathServer = Server.MapPath("~/Upload/");
                _servicio.UpdateImagen(_mapper.Map<Imagen>(imagen), pathServer);

                return RedirectToAction("Index");
            }

            return View(imagen);
        }

        // GET: Imagen/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            return View(_mapper.Map<ImagenModel>(_servicio.GetImagen(id)));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(Guid id)
        {
            if (Session["UserID"] == null)
                return RedirectToAction("LoginUser", "User");
            _servicio.RemoveImagen(_mapper.Map<Imagen>(_servicio.GetImagen(id)));
            return RedirectToAction("Index");
        }


        public ActionResult DeleteAllImagen()
        {
            try
            {
                _servicio.RemoveAllImages();
                return RedirectToAction("Index");
            }
            catch (Exception m)
            {

                return RedirectToAction("Index");
            }


        }



        //----------------------------------Prueba de metoos para guardar imagen----------


        public JsonResult UploadFiles(object obj)
        {
            try
            {
                var length = Request.ContentLength;
                var bytes = new byte[length];
                Request.InputStream.Read(bytes, 0, length);

                var fileName = Request.Headers["X-File-Name"];
                var fileSize = Request.Headers["X-File-Size"];
                var fileType = Request.Headers["X-File-Type"];

                var saveToFileLoc = Server.MapPath("~/Upload/" + fileName);

                // save the file.
                var fileStream = new FileStream(saveToFileLoc, FileMode.Create, FileAccess.ReadWrite);
                fileStream.Write(bytes, 0, length);
                fileStream.Close();

                return Json("Esxiste", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json("false", JsonRequestBehavior.AllowGet);
            }




            //return string.Format("{0} bytes uploaded", bytes.Length);
        }



        [HttpPost]
        public IList<string> UploadFile(HttpPostedFileBase[] files)
        {
            var list = new List<string>();
            try
            {
                /*Lopp for multiple files*/
                foreach (HttpPostedFileBase file in files)
                {
                    /*Geting the file name*/
                    string filename = Path.GetFileName(file.FileName);
                    /*Saving the file in server folder*/
                    file.SaveAs(Server.MapPath("~/Upload/" + filename));
                    string filepathtosave = "Upload/" + filename;
                    /*HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE*/
                    list.Add(filepathtosave);
                }
                return list;
            }
            catch
            {
                ViewBag.Message = "Error mientras subia la imagen.";
            }
            return null;
        }



        public ActionResult UploadImagenToServer(HttpPostedFileBase file)
        {
            try
            {
                /*Lopp for multiple files*/
                /*Geting the file name*/
                string filename = Path.GetFileName(file.FileName);
                /*Saving the file in server folder*/
                file.SaveAs(Server.MapPath("~/Upload/" + filename));
                string filepathtosave = "Upload/" + filename;
                /*HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE*/


                return Json("File Uploaded successfully.");
            }
            catch
            {
                return Json("Error while uploading the files.");
            }

        }
























        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(int a)
        {
            if (Request.Files.AllKeys.Any())
            {
                var httpPostedFile = Request.Files["file"];
                bool folderExists = Directory.Exists(Server.MapPath("~/UploadedDocuments"));
                if (!folderExists)
                    Directory.CreateDirectory(Server.MapPath("~/UploadedDocuments"));
                var fileSavePath = Path.Combine(Server.MapPath("~/UploadedDocuments"),
                                                httpPostedFile.FileName);
                httpPostedFile.SaveAs(fileSavePath);

                if (System.IO.File.Exists(fileSavePath))
                {
                    ////AppConfig is static class used as accessor for SFTP configurations from web.config
                    //using (SftpClient sftpClient = new SftpClient(AppConfig.SftpServerIp,
                    //                                             Convert.ToInt32(AppConfig.SftpServerPort),
                    //                                             AppConfig.SftpServerUserName,
                    //                                             AppConfig.SftpServerPassword))
                    //{
                    //    sftpClient.Connect();
                    //    if (!sftpClient.Exists(AppConfig.SftpPath + "UserID"))
                    //    {
                    //        sftpClient.CreateDirectory(AppConfig.SftpPath + "UserID");
                    //    }

                    //    Stream fin = File.OpenRead(fileSavePath);
                    //    sftpClient.UploadFile(fin, AppConfig.SftpPath + "/" + httpPostedFile.FileName,
                    //                          true);
                    //    fin.Close();
                    //    sftpClient.Disconnect();
                    //}
                }
            }
            return View();
        }
    }
}
