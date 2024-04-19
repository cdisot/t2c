using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain.T2C;
using Domain.T2C.Interface;
using Domain.T2C.Repository;


namespace CellService
{
    public class Service : IService
    {
        private readonly ICellRepository _repoCell;
        private readonly IUserRepository _repoUser;
        private readonly IImagenRepository _repoImagen;

        public Service(ICellRepository repoCell, IUserRepository repoUser, IImagenRepository repoImagen)
        {
            _repoCell = repoCell;
            _repoUser = repoUser;
            _repoImagen = repoImagen;
        }

        #region Celular
        public void AddCell(ICell cell)
        {
            //Comprobar que el celular no exista

            var lista = _repoCell.GetAll();
            var
                l =
                    lista.Any(
                        c => Equals(c.Price, cell.Price) && c.Company == cell.Company && c.Condition == cell.Condition
                             && c.Start == cell.Start);
            if (l)
            {
                return;
            }

            //Si el servicio no existe, crear el ID y adicionar

            _repoCell.Add((Cell)cell);
            foreach (var imagen in cell.Imagens)
            {
                _repoImagen.Add((Imagen)imagen);
            }
        }

        public ICell ExistCEll(Guid id)
        {
            var cell = _repoCell.GetById(id);
            if (cell != null)
                cell.Imagens = GetImagesNameType("Equipo").Where(c => c.IdEquipo == cell.Id).ToList();
            return cell;


        }

        public List<IImagen> DeleteImage(List<IImagen> imagesOld, List<IImagen> imagesActuales, string pathServer)
        {
            //recorro la listas, preguntando si la imagen en el nuevo esta en el viejo 
            //Si esta en el viejo no la borro, pero la elimino de la lista nueva
            //y solamente adiciono los que quedaron
            for (int i = 0; i < imagesActuales.Count; i++)
            {

                var existe = false;
                for (int j = 0; j < imagesOld.Count; j++)
                {
                    if (imagesActuales[i].PathImagen == imagesOld[j].PathImagen)
                    {
                        imagesOld.RemoveAt(j);
                        imagesActuales.RemoveAt(i);
                        break;
                    }
                }

            }
            for (int i = 0; i < imagesOld.Count; i++)
            {
                _repoImagen.Remove((Imagen)imagesOld[i]);
                imagesOld.RemoveAt(i);
            }
            return imagesActuales;
        }



        public void UpdateCell(ICell cell, string pathServer)
        {
            //Comprobar que el objeto por parametro no este vacio
            var cellOld = ExistCEll(cell.Id);
            if (cellOld != null)
            {
                //So el cell existe actualizar
                _repoCell.Update((Cell)cell);
                if (cell.Imagens != null && cell.Imagens.Any())
                {
                    var listImagenes = DeleteImage(cellOld.Imagens.ToList(), cell.Imagens.ToList(), pathServer);

                    foreach (var imagen in listImagenes)
                    {
                        imagen.IdEquipo = cell.Id;
                        //Antes de adicionar pregunto si existe en las imagenes para solamente actaulizar

                        _repoImagen.Add((Imagen)imagen);
                    }
                }
            }
            else
            {
                //Buscar el celular por el id
                //Si el cell no existe notificar
                throw new Exception("El celular no existe para actualizar");
            }


        }

        public void RemoveImageDeleteCell(List<IImagen> images, string pathServer)
        {
            foreach (var imagen in images)
            {
                _repoImagen.Remove((Imagen)imagen);
                File.Delete(pathServer + imagen.Name);
            }
        }

        public void RemoveCell(ICell cell, string pathServer)
        {
            //Comprobar que el celular existe
            if (ExistCEll(cell.Id) != null)
            {
                RemoveImageDeleteCell(cell.Imagens.ToList(), pathServer);
                //Si existe eliminarlo
                _repoCell.Remove((Cell)cell);
            }
            else
            {
                //Si no existe notificar    
                throw new Exception("El celular no existe para eliminar");
            }
        }

        public IEnumerable<ICell> Orderby(string order, IEnumerable<ICell> list)
        {

            if (!string.IsNullOrEmpty(order))
            {
                list = GetAll().ToList();
                switch (order)
                {
                    case "fecha":
                        list = list.OrderByDescending(e => e.Date).ToList();
                        break;
                    case "nombre":
                        list = list.OrderByDescending(e => e.Name).ToList();
                        break;
                    case "precio":
                        list = list.OrderByDescending(e => e.Price).ToList();
                        break;
                    case "modelo":
                        list = list.OrderByDescending(e => e.Model).ToList();
                        break;
                }
            }

            return list;
        }

        public IEnumerable<ICell> FilterComputers(double size, string processor, int year, string model, string category)
        {
            var list = GetAll().ToList();
            if (!string.IsNullOrEmpty(processor))
            {
                list = list.Where(l => l.FrecuencyProcessor == processor).ToList();
            }
            if (!string.IsNullOrEmpty(model))
            {
                list = list.Where(l => l.Model == model).ToList();
            }
            if (!string.IsNullOrEmpty(category))
            {
                list = list.Where(l => l.Category == category).ToList();
            }
            if (size>0)
            {
                list = list.Where(l => l.Size == size).ToList();
            }

            return list;
        }

        public IList<ICell> ListCEll(string name, string model, string company, string condition, int price, int memory, string category, string type, string generation)
         {
            var list = GetAll().ToList();
            if (!string.IsNullOrEmpty(type))
            {
                list = list.Where(l => l.Type == type).ToList();
            }
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(l => l.Name == name).ToList();
            }
            if (!string.IsNullOrEmpty(model))
            {
                list = list.Where(m => m.Model == model).ToList();
            }
            if (!string.IsNullOrEmpty(company))
            {
                list = list.Where(c => c.Company == company).ToList();
            }
            if (!string.IsNullOrEmpty(generation))
            {
                list = list.Where(c => c.Generation == generation).ToList();
            }

            if (!string.IsNullOrEmpty(condition))
            {

                list = list.Where(c => c.Condition == condition).ToList();

            }
            if (memory > 0)
            {

                list = list.Where(c => c.Memory == memory).OrderByDescending(cc => cc.Memory).ToList();

            }
            if (price > 0)
            {
                if (price == 1)
                    list = list.Where(c => c.Price >= 10 && c.Price <= 20).ToList();
                if (price == 2)
                    list = list.Where(c => c.Price > 20 && c.Price <= 100).ToList();
                if (price == 3)
                    list = list.Where(c => c.Price > 100 && c.Price <= 300).ToList();
                if (price == 4)
                    list = list.Where(c => c.Price > 300).ToList();
            }
            if (!string.IsNullOrEmpty(category))
            {
                list = list.Where(c => c.Category == category).ToList();
            }
            return list;
        }

        public ICell GetCell(Guid idCell)
        {
            //Comprobar que el celular existe
            return _repoCell.GetById(idCell);

        }

        public IEnumerable<ICell> GetAll()
        {

            return _repoCell.GetAll();
        }

        public void RemoveAllCell(string pathServer)
        {
            var cells = GetAll().ToList();
            foreach (var cell in cells)
            {
                cell.Imagens = GetImagesNameType("Equipo").Where(c => c.IdEquipo == cell.Id).ToList(); ;
                RemoveImageDeleteCell(cell.Imagens.ToList(), pathServer);
                _repoCell.Remove((Cell)cell);
            }
        }

        #endregion

        #region Usuario

        public void AddUser(IUser user)
        {
            //Preguntar si el user existe por el userName


            var us = ListUsers().FirstOrDefault(u => u.UserName == user.UserName);
            if (us == null)
            {
                user.Name = user.UserName;
                _repoUser.Add((UserCell)user);
            }
            else
            {
                throw new Exception(string.Format("El usuario {0} no existe", user.UserName));
            }

        }

        public void UpdateUser(IUser user)
        {
            //Preguntar si existe por el Id
            var us = GetUser(user.Id);
            if (us != null)
            {
                if (user != us)
                {
                    user.Name = us.Name;
                    _repoUser.Update((UserCell)user);
                }
            }
            else
            {
                throw new Exception(string.Format("El usuario {0} no existe.", user.UserName));
            }
        }

        public void RemoveUser(IUser user)
        {
            var us = GetUser(user.Id);
            if (us != null)
            {
                _repoUser.Remove((UserCell)user);
            }
            else
            {
                throw new Exception(string.Format("El usuario {0} no existe.", user.UserName));
            }
        }

        public IEnumerable<IUser> ListUsers()
        {

            return _repoUser.GetAll();
        }

        public IUser GetUser(Guid idUser)
        {
            return _repoUser.GetById(idUser);
        }

        public IUser GetUser(string user, string password)
        {
            var listuser = ListUsers().ToList();
            if (listuser.Count > 0)
            {
                return ListUsers().FirstOrDefault(u => u.UserName == user && password == u.Password);
            }
            if (user != "admin" || password != "adminT2C") return null;
            var usuario = new UserCell()
            {
                Id = Guid.NewGuid(),
                UserName = user,
                Password = password,
                Name = user

            };
            AddUser(usuario);
            return usuario;
        }

        #endregion

        #region Imagenes
        public void AddImagen(IImagen imagen)
        {
            if (string.IsNullOrEmpty(imagen.NameType) || string.IsNullOrEmpty(imagen.Category)) return;
            var i = GetAllImagen().FirstOrDefault(e => e.NameType == imagen.NameType && e.Category == imagen.Category);

            if (i == null)
            {
                _repoImagen.Add((Imagen)imagen);
            }

            else
                throw new Exception("Existe");
        }

        public void RemoveAllImages()
        {
            var images = GetAllImagen().ToList();
            foreach (var iamge in images)
            {
                _repoImagen.Remove((Imagen)iamge);
            }
        }
        public bool ExistImagen(Guid id)
        {
            return GetImagen(id) != null;
        }

        public void UpdateImagen(IImagen imagen, string pathServer)
        {
            //Busco la imagen anterior antes de cambiar para guardarla
            var i = GetImagen(imagen.Id);
            imagen.Name = imagen.NameType;


            _repoImagen.Update((Imagen)imagen);

            var equipos = GetAll().ToList();

            //Compruebo con la imagen vieja y la lista de equipos
            //Si coincide las imagen entonces la reemplazo por la nueva.
            foreach (var equipo in equipos)
            {
                if (equipo.Company == i.NameType)
                {
                    equipo.Company = imagen.NameType;
                    equipo.Imagens = GetImagesNameType("Equipo").Where(c => c.Name == equipo.Name).ToList();
                    UpdateCell(equipo, pathServer);
                    continue;
                }
                if (equipo.Model == i.NameType)
                {
                    equipo.Model = imagen.NameType;
                    UpdateCell(equipo, pathServer);
                    continue;
                }
                if (equipo.Category != i.NameType) continue;
                equipo.Category = imagen.NameType;
                UpdateCell(equipo, pathServer);
            }

        }

        public void RemoveImagen(IImagen imagen)
        {
            _repoImagen.Remove(imagen.Id);
        }

        public IImagen GetImagen(Guid idImagen)
        {
            return _repoImagen.GetById(idImagen);
        }

        public IEnumerable<IImagen> GetAllImagen()
        {
            return _repoImagen.GetAll();
        }
        #endregion



        #region Otros metodos encesarios
        /// <summary>
        /// Devuelve la lista de categorias segun el tipo que se 
        /// esto es para conformar los combobox para escoger en 
        /// la admnistracion 
        /// </summary>
        /// <param name="type">tipo por el que voy a buscar</param>
        /// <returns></returns>
        public IEnumerable<IImagen> GetImagesNameType(string type)
        {
            return _repoImagen.GetAll().Where(i => i.Category == type);
        }

        public IEnumerable<IImagen> GetImagesType(string type)
        {
            return _repoImagen.GetAll().Where(i => i.Type == type);
        }
        public List<string> ListMarca(string type)
        {
            var listCellToType = GetAllImagen().Where(c => c.Type == type).ToList();

            var listType = new List<string>();

            foreach (var imagen in from imagen in listCellToType let exist = listType.Any(imagenType => imagenType == imagen.NameType) where exist == false select imagen)
            {
                listType.Add(imagen.NameType);
            }

            return listCellToType.Select(t => t.NameType).ToList();
        }

        public List<string> ListModel(string type, string category)
        {
            var listCellType = GetAll().Where(c => c.Type == type && c.Category == category);
            var listModel = new List<string>();
            foreach (var cell in from cell in listCellType let exist = listModel.Any(model => model == cell.Model) where !exist select cell)
            {
                listModel.Add(cell.Model);
            }
            return listModel;
        }

      

        #endregion
    }
}
