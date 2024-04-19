namespace CC.Core.Errors
{
    public enum ErrorCode
    {

        #region Spanish ServicioHospedaje 70xxx
        ServicioNoExisteAdd = 70001,
        ServiceNotExiste = 70002,
        ServicioNoExisteUpdate=70003,
        ServiciosUpdateIguales =70004,
        #endregion

        #region Spanish Agencia

        #region Agencia 80xxx
        AgenciaExiste = 80001,
        AgenciaNoExiste = 80002,
        AgenciaCreada = 80003,
        AgenciaEliminada = 80004,
        AgenciaModificada = 80005,
        AgenciaActualizada = 80006,
        #endregion
        #endregion

        #region  Spanish Categoria 90xxx
        /// <summary>
        /// La categoria existe
        /// </summary>
        CategoriaExiste = 90001,
        CategoriaAdicionada=90002,
        CategoriaNoExisteAgencia = 90003,
        /// <summary>
        /// Categoria no existe
        /// </summary>
        CategoriaNoExiste= 90004,
        #endregion

        #region   Spanish Servicio 91xxx
        ServicioExiste = 91001,
        ServicioAdd = 91002,
        #endregion


        #region Module 20xxx

        /// <summary>
        /// Module doesn't exist or isn't Deactivated
        /// </summary>
        ModuleNotExistOrDeactivated = 20101,

        /// <summary>
        /// The requested module is already active
        /// </summary>
        ModuleAlreadyActive = 20202,

        /// <summary>
        /// This module is already deactivated
        /// </summary>
        ModuleAlreadyDeactived = 20203,

        ModuleNotExist = 20102,

        /// <summary>
        /// Another existing module already use the same identification id provided
        /// </summary>
        ModuleDuplicatedById = 20200,
        #endregion

        #region Module's Service 21xxx
        /// <summary>
        /// Requested service doesn't exist
        /// </summary>
        ServiceNotExist = 21100,

        /// <summary>
        /// Service doesn't exist or isn't Deactivated
        /// </summary>
        ServiceNotExistOrNotDeactivated = 21101,

        /// <summary>
        /// Service doesn't exist or isn't activated
        /// </summary>
        ServiceNotExistOrNotActivated = 21102,

        /// <summary>
        /// El servicio no puede ser activado porque el modulo esta desactivado o porque no se a asignado el servicio a un modulo
        /// </summary>
        ServiceNotActivatedModuleDeactivated = 21200,

        /// <summary>
        /// This service is deactivated
        /// </summary>
        ServiceDeactivated = 21300,

        /// <summary>
        /// This service is activated
        /// </summary>
        ServiceActivated = 21301,
        #endregion

        #region Authentication 30xxx
        /// <summary>
        /// IT Staff doesn't exist
        /// </summary>
        ItStaffNotExist = 30100,
        /// <summary>
        /// Authentication failed, wrong Email or ApiKey
        /// </summary>
        AuthenticationFailedWrongEmailApiKey = 31200,
        #endregion

        #region Authorization 31xxx
        /// <summary>
        /// Client have not access granted to the requested service
        /// </summary>
        ClientApplicationAuthorizationDeniedToService = 31100,


        #endregion

        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 99000,

        /// <summary>
        /// In deep are status with mean only to human users
        /// </summary>
        HumanMeaning = 99001


    }
}