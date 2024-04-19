using System;
using System.Collections.Generic;
using Domain.T2C.Interface;

namespace CellService
{
    public interface IService
    {
       /// <summary>
        /// Adicionar Celular
       /// </summary>
       /// <param name="cell">celular</param>
        void AddCell(ICell cell);

        /// <summary>
        /// Comprobar si existe
        /// </summary>
        /// <param name="id">id del celular</param>
        /// <returns></returns>
        ICell ExistCEll(Guid id);

        /// <summary>
        /// Modificar celular
        /// </summary>
        /// <param name="cell">celular</param>
        /// <param name="pathServer"></param>
        void UpdateCell(ICell cell,string pathServer);

        /// <summary>
        /// Eliminar CElular
        /// </summary>
        /// <param name="cell">celular</param>
        /// <param name="pathServer"></param>
        void RemoveCell(ICell cell, string pathServer);

        IEnumerable<ICell> Orderby(string order, IEnumerable<ICell> list);
            //FIltrar Celular
        IList<ICell> ListCEll(string name, string model, string company, string condition, int price, int memory, string category, string type, string generation);
        
        /// <summary>
        /// Devolver celular
        /// </summary>
        /// <param name="idCell">id del celular</param>
        /// <returns></returns>
        ICell GetCell(Guid idCell);

        /// <summary>
        /// Devolver todos los celulares
        /// </summary>
        /// <returns></returns>
        IEnumerable<ICell> GetAll();

        /// <summary>
        /// Eliminar todos los celulares de una vez
        /// </summary>
        void RemoveAllCell(string pathServer);



//-----------------------------------------Usuario------------------------------

        //Adicionar Usuario
        void AddUser(IUser user);

        //Modificar Usuario
        void UpdateUser(IUser user);

        //Eliminar Usuario
        void RemoveUser(IUser user);

        IEnumerable<IUser> ListUsers();

        //Devolver Usuario
        IUser GetUser(Guid idUser);

        //devulve usuario segun usuario y contraseña
        IUser GetUser(string user, string password);
        


        //---------------------------------------Imagen--------------
        /// <summary>
        /// Adicionar Celular
        /// </summary>
        /// <param name="imagen"></param>
        void AddImagen(IImagen imagen);

        /// <summary>
        /// Comprobar si existe
        /// </summary>
        /// <param name="id">id del celular</param>
        /// <returns></returns>
        bool ExistImagen(Guid id);

        /// <summary>
        /// Modificar celular
        /// </summary>
        /// <param name="imagen"></param>
        /// <param name="pathServer"></param>
        void UpdateImagen(IImagen imagen, string pathServer);

        /// <summary>
        /// Eliminar CElular
        /// </summary>
        /// <param name="imagen"></param>
        void RemoveImagen(IImagen imagen);


        /// <summary>
        /// Devolver celular
        /// </summary>
        /// <param name="idImagen"></param>
        /// <returns></returns>
        IImagen GetImagen(Guid idImagen);

        /// <summary>
        /// Devolver todos los celulares
        /// </summary>
        /// <returns></returns>
        IEnumerable<IImagen> GetAllImagen();

        void RemoveAllImages();

//---------------------------------------------------otros meotos de interes -----
        IEnumerable<IImagen> GetImagesNameType(string type);
        List<IImagen> DeleteImage(List<IImagen> imagesOld, List<IImagen> imagesActuales, string pathServer);
        void RemoveImageDeleteCell(List<IImagen> images, string pathServer);

         List<string> ListMarca(string type);

         List<string> ListModel(string type, string category);
        IEnumerable<IImagen> GetImagesType(string type);

        IEnumerable<ICell> FilterComputers(double size, string processor, int year, string model, string category);
    }
 


}