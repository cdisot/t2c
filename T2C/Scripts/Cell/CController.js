app.controller("AngularCtrl", function ($scope, angularService) {



    //------------------------------------Gestionar Filtro  Pagina Principal---------

    $scope.divSelectGeneration = false;

    //Cargar Lista de Marcas
    //Devulve toda las marcas
    function listMarcas(name) {
        angularService.ListMarcas(name).
            success(function (m) {
                $scope.marcas = m;

            });
    }
    listMarcas("Marca");




    //Cargar lista de compañia 
    $scope.NameType = "s";
    function listCompany(name) {

        angularService.ListCompanies(name).
            success(function (cmpany) {
                $scope.companies = cmpany;
                $scope.ListCompany = cmpany;
            });
    }
    listCompany("Compañía");


    $scope.listImagenesMarca = function (type) {
       
        angularService.getListImagenToType(type).
            success(function (image) {
                $scope.imagenesListFromType = image;
                if (type === "Ipad") {
                    $scope.divSelectModelo = false;
                    $scope.divSelectModeloImage = false;

                    $scope.divSelectMarca = true;
                    $scope.divSelectMarcaImage = true;
                } else {
                    $scope.divSelectModelo = true;
                    $scope.divSelectModeloImage = true;

                    $scope.divSelectMarca = false;
                    $scope.divSelectMarcaImage = false;
                }

            });
    }


    ////Filtrar por privera vez teniendo en cuenta la compañia
    function divices(name, model, company, condition, price, memory, category, type, generation, option) {

        var marca = new Array();
        var comapania = new Array();
        var models = new Array();
        var capacidad = new Array();
        var gen = new Array();




        if (model != null && model !== "") {

            $scope.Model = model;
        }

        if (company != null && company !== "") {
            $scope.Company = company;
        }

        if (condition != null && condition !== "") {
            $scope.Condition = condition;
        }
        if (memory != null && memory !== "") {
            $scope.Memory = memory;
        }

        if (category != null && category !== "") {

            $scope.Category = category;
        }



        angularService.getListDivice(name, model, company, condition, price, memory, category, type, generation).
            success(function (divice) {

                $scope.getlistDivice = divice;
                //Preguntar si que opcion es (1-compañia, 2-marca, 3-otras opciones)
                var j;
                var existe;
                var k;
                var i;
                switch (option) {
                    case 1:
                        if (type === "Iphone" && category === "Apple") {

                        }
                        //Aqui cargo la compañia segun a lista de equipos existente
                        for (i = 0; i < divice.length; i++) {
                            for (j = 0; j < $scope.companies.length; j++) {
                                if (divice[i].Company === $scope.companies[j].NameType) {
                                    existe = false;
                                    for (k = 0; k < comapania.length; k++) {
                                        if (comapania[k].NameType === divice[i].Company) {
                                            existe = true;
                                            break;
                                        }
                                    }
                                    if (existe === false) {
                                        comapania.push($scope.companies[j]);
                                    }
                                    break;

                                }
                            }
                        }

                        $scope.ListCompany = comapania;
                        //Desactivo la Fila de la nmarca y las otrs pciones
                        $scope.divSelectCompania = true;
                        $scope.divSelectCompaniaImage = true;
                        $scope.divSelectMarca = false;
                        $scope.divSelectMarcaImage = true;
                        $scope.divSelectOtherOpcion = false;

                        if ($scope.divSelectGeneration === false) {
                            $scope.divSelectModelo = true;
                            $scope.divSelectModeloImage = true;
                        } else {
                            $scope.divSelectModelo = false;
                            $scope.divSelectModeloImage = false;
                        }


                        $scope.divSelectMemory = false;
                        $scope.divSelectPhone = false;
                        $scope.selectDivBottonComputer = false;
                      
                        break;
                    case 2:
                        //Cargo la marca teniendo en cuenta la compañia seleccionada

                       
                        for (i = 0; i < divice.length; i++) {
                            for (j = 0; j < $scope.marcas.length; j++) {
                                if (divice[i].Category === $scope.marcas[j].NameType) {
                                    existe = false;
                                    for (k = 0; k < marca.length; k++) {
                                        if (marca[k].NameType === divice[i].Category) {
                                            existe = true;
                                            break;
                                        }

                                    }
                                    if (existe === false) {
                                        marca.push(divice[i]);

                                    }
                                    break;
                                }
                            }
                        }
                        $scope.ListMarcas = marca;
                        //Activo la fila de la marca si hay marcasif()
                        if (marca.length > 0) {
                            $scope.divSelectMarca = true;
                            $scope.divSelectMarcaImage = true;
                        }
                        else {
                            $scope.divSelectMarca = false;
                            $scope.divSelectMarcaImage = false;
                        }
                        $scope.divSelectModelo = true;
                        $scope.divSelectModeloImage = true;
                        $scope.divSelectOtherOpcion = false;
                        $scope.divSelectMemory = false;

                        $scope.divSelectCompania = false;
                        $scope.divSelectCompaniaImage = false;
                        $scope.divSelectPhone = false;

                        $scope.divSelectGeneration = false;
                        break;
                    case 3:
                        //buscar los mdelos existentes en la lista de equipos 
                        //jo repetir ninguno 

                        for (i = 0; i < divice.length; i++) {
                            existe = false;
                            for (j = 0; j < models.length; j++) {
                                if (divice[i].Model === models[j].Model) {
                                    existe = true;
                                    break;
                                }
                            }
                            if (existe === false) {
                                models.push(divice[i]);

                            }

                        }
                        $scope.modelos = models;


                        if (category === "iPad" || category === "iPad Air") {
                            $scope.divSelectModelo = false;
                            $scope.divSelectModeloImage = false;
                            $scope.divSelectGeneration = true;
                            for (i = 0; i < divice.length; i++) {
                                var exist = false;
                                for (j = 0; i < gen.length; i++) {
                                    //Comprobar que no existe la generacion para adicionar

                                    if (divice[i].Generation === gen[j]) {
                                        exist = true;
                                        break;
                                    }
                                }
                                if (exist === false) {
                                    gen.push(divice[i].Generation);

                                }
                            }


                            $scope.Generations = gen;

                        } else {

                            $scope.divSelectGeneration = false;
                            if (models.length > 0) {

                                $scope.divSelectModelo = true;
                                $scope.divSelectModeloImage = true;
                            }
                            else {

                                $scope.divSelectModelo = false;
                                $scope.divSelectModeloImage = false;

                            }
                        }
                        //Desactivo la tercera fila de las otras opciones

                        $scope.divSelectOtherOpcion = false;
                        $scope.divSelectMemory = false;
                        $scope.divSelectCompania = false;
                        $scope.divSelectCompaniaImage = false;
                        $scope.divSelectMarca = true;
                        $scope.divSelectMarcaImage = true;
                        $scope.divSelectPhone = false;
                        $scope.selectDivProcessor = false;
                        $scope.selectDivYear = false;
                        $scope.selectDivSize = false;
                        $scope.selectDivBottonComputer = false;
                        break;
                    case 4:

                        for (i = 0; i < divice.length; i++) {
                            existe = false;
                            for (j = 0; j < capacidad.length; j++) {
                                if (divice[i].Memory === capacidad[j].Memory) {
                                    existe = true;
                                    break;
                                }
                            }
                            if (existe === false) {
                                capacidad.push(divice[i]);
                            }
                        }

                        $scope.Capacidad = capacidad;
                        if (capacidad.length > 0) {

                            $scope.divSelectMemory = true;
                        } else {

                            $scope.divSelectMemory = false;
                        }
                        $scope.divSelectOtherOpcion = false;
                        $scope.divSelectCompania = true;
                        $scope.divSelectCompaniaImage = true;
                        $scope.divSelectModelo = true;
                        $scope.divSelectModeloImage = true;
                        $scope.divSelectMarca = false;
                        $scope.divSelectMarcaImage = true;
                        $scope.divSelectPhone = false;
                        break;
                    case 5:

                        $scope.divSelectOtherOpcion = true;
                        $scope.divSelectCompania = true;
                        $scope.divSelectCompaniaImage = true;
                        $scope.divSelectModelo = false;
                        $scope.divSelectModeloImage = true;
                        $scope.divSelectMarca = false;
                        $scope.divSelectMarcaImage = true;
                        $scope.divSelectPhone = true;
                        if (category === "iPad" || category === "iPad Air") {
                            $scope.divSelectModelo = false;
                            $scope.divSelectModeloImage = false;
                        } else {
                            $scope.divSelectModelo = false;
                            $scope.divSelectModeloImage = true;
                        }

                        break;
                    case 6:


                        for (i = 0; i < divice.length; i++) {
                            var exist = false;
                            for (j = 0; i < gen.length; i++) {
                                //Comprobar que no existe la generacion para adicionar

                                if (divice[i].Generation === gen[j]) {
                                    exist = true;
                                    break;
                                }
                            }
                            if (exist === false) {
                                gen.push(divice[i].Generation);

                            }
                        }


                        $scope.Generations = gen;
                        $scope.divSelectGeneration = true;

                        break;

                }

            });

    }
    //divices("", "", "", "", 0, 0, "", 1);

    $scope.ClicGetkDivices = function (name, model, company, condition, price, memory, category, type, generation, option) {

        divices(name, model, company, condition, price, memory, category, type, generation, option);

    }



    //Filtrar las computadoras por  Size \, processor and year
    $scope.LisComputer = function (size, processor, year, model, category, option) {
       
        var sizeArray = new Array();
        var processorArray = new Array();
        var yearArray = new Array();

       

        $scope.Model = model;
        $scope.Processor = processor;
        $scope.Size = size;
        $scope.Year = year;

        //Si es la primera opcion entonces es size y activo size

        //Si es la segunda opcion es porque marque size para carcr alguno de los dos restante processor o year
        //en lo\a segunda opcion si processor no exist entonces cargo year y termino 

        //tercera opciones es porque existe el procesador y activo el year.


      
        angularService.getListComputers(size, processor, year, model, category).
            success(function (computer) {
                 
                $scope.ListComputers = computer;
                var exist;
                var i;
                var j;
                switch (option) {
                    case 1:
                        for (i = 0; i < computer.length; i++) {
                            exist = false;
                            for (j = 0; j < sizeArray.length; j++) {
                                if (computer[i].Size === sizeArray[j]) {
                                    exist = true;
                                    break;
                                }

                            }
                            if (exist === false) {
                                sizeArray.push(computer[i].Size);
                            }
                        }
                        $scope.sizeComputersList = sizeArray;

                        if (sizeArray.length > 0) {
                            $scope.selectDivSize = true;
                        } else {
                            $scope.selectDivSize = false;
                        }
                        $scope.selectDivProcessor = false;
                        $scope.selectDivYear = false;
                        $scope.divSelectPhone = false;
                        break;
                    case 2:
                       
                        for (i = 0; i < computer.length; i++) {
                            exist = false;
                            for (j = 0; j < processorArray.length; j++) {
                                if (computer[i].FrecuencyProcessor === processorArray[j]) {
                                    exist = true;
                                    break;
                                }

                            }
                            if (exist === false) {
                                processorArray.push(computer[i].FrecuencyProcessor);
                            }
                        }
                        $scope.selectDivYear = false;
                        $scope.selectDivBottonComputer = false;
                      
                        if (processorArray.length > 0) {
                            $scope.selectDivProcessor = true;
                            $scope.processorComputersList = processorArray;
                           
                        } else {
                            $scope.selectDivBottonComputer = true;
                            $scope.selectDivProcessor = false;
                            for (i = 0; i < computer.length; i++) {
                                exist = false;
                                for (j = 0; j < yearArray.length; j++) {
                                    if (computer[i].Year === yearArray[j]) {
                                        exist = true;
                                        break;
                                    }

                                }
                                if (exist === false) {
                                    yearArray.push(computer[i].Year);
                                }
                            }
                            if (yearArray.length > 0) {
                                $scope.yearComputersList = yearArray;
                                $scope.selectDivYear = true;
                            } else {
                                $scope.selectDivYear = false;
                            }
                        }
                        $scope.selectDivSize = true;
                        $scope.divSelectPhone = false;
                     
                        break;
                    case 3:
                        for (i = 0; i < computer.length; i++) {
                            exist = false;
                            for (j = 0; j < yearArray.length; j++) {
                                if (computer[i].Year === yearArray[j]) {
                                    exist = true;
                                    break;
                                }

                            }
                            if (exist === false) {
                                yearArray.push(computer[i].Year);
                            }
                        }
                        if (yearArray.length > 0) {
                            $scope.selectDivYear = true;
                            $scope.yearComputersList = yearArray;
                            $scope.selectDivBottonComputer = false;
                        } else {
                            $scope.selectDivYear = false;
                            $scope.selectDivBottonComputer = true;
                        }
                        $scope.selectDivSize = true;
                        $scope.selectDivProcessor = true;
                        
                        
                        $scope.divSelectPhone = false;
                        break;

                    case 4:
                        $scope.selectDivBottonComputer = true;
                        //$scope.divSelectPhone = true;
                        break;
                    case 5:
                        
                        $scope.divSelectPhone = true;
                        break;
                }


            });

    }


    //Devulve la lista de equipos(Telefonos, laptopl, etc)
    function getAllDivice() {
        angularService.ListAllDivice().
           success(function (divice) {
               $scope.listDivice = divice;


           });
    }
    getAllDivice();

    //cargar pagina de detalles
    $scope.DetailsDivice = function (idDivice) {
        angularService.getDetailsDivice(idDivice);

    }



    $scope.isActivate = -1;
    $scope.isActivateMarca = -1;
    $scope.isActivateModelo = -1;

    $scope.nombreCompania = "";
    $scope.nombreModelo = "";

    $scope.selectActivate = function ($index, name) {

        $scope.isActivate = $index;
        $scope.isActivateMarca = -1;
        $scope.nombreCompania = name;
    };

    $scope.selectActivateMarca = function ($index) {
        $scope.isActivateMarca = $index;
        $scope.isActivateModelo = -1;
    };
    $scope.selectActivateModelo = function ($index) {
        $scope.isActivateModelo = $index;

    };
    $scope.Iphone6Splus = "";
    $scope.Iphone6plus = "";
    $scope.Iphone6S = "";
    $scope.Iphone6 = "";
    $scope.Iphone5S = "";
    $scope.Iphone5C = "";
    $scope.Iphone5 = "";
    $scope.Iphone4S = "";



    $scope.modelIphone = "";
    $scope.modelAndroide = "";


    $scope.Activate = function (name) {
        switch (name) {
            case "Iphone6Splus":
                $scope.Iphone6Splus = "act";
                $scope.Iphone6plus = "desactivate";
                $scope.Iphone6S = "desactivate";
                $scope.Iphone6 = "desactivate";
                $scope.Iphone5S = "desactivate";
                $scope.Iphone5C = "desactivate";
                $scope.Iphone5 = "desactivate";
                $scope.Iphone4S = "desactivate";
                $scope.modelIphone = "Iphone 6S Plus";
                $scope.modelAndroide = "";
                break;
            case "Iphone6plus":
                $scope.Iphone6Splus = "desactivate";
                $scope.Iphone6plus = "act";
                $scope.Iphone6S = "desactivate";
                $scope.Iphone6 = "desactivate";
                $scope.Iphone5S = "desactivate";
                $scope.Iphone5C = "desactivate";
                $scope.Iphone5 = "desactivate";
                $scope.Iphone4S = "desactivate";
                $scope.modelIphone = "Iphone 6 Plus";
                $scope.modelAndroide = "HTC";
                break;
            case "Iphone6S":
                $scope.Iphone6Splus = "desactivate";
                $scope.Iphone6plus = "desactivate";
                $scope.Iphone6S = "act";
                $scope.Iphone6 = "desactivate";
                $scope.Iphone5S = "desactivate";
                $scope.Iphone5C = "desactivate";
                $scope.Iphone5 = "desactivate";
                $scope.Iphone4S = "desactivate";
                $scope.modelIphone = "Iphone 6S";
                $scope.modelAndroide = "BlackBerry";

                break;
            case "Iphone6":
                $scope.Iphone6Splus = "desactivate";
                $scope.Iphone6plus = "desactivate";
                $scope.Iphone6S = "desactivate";
                $scope.Iphone6 = "act";
                $scope.Iphone5S = "desactivate";
                $scope.Iphone5C = "desactivate";
                $scope.Iphone5 = "desactivate";
                $scope.Iphone4S = "desactivate";
                $scope.modelIphone = "Iphone 6";
                $scope.modelAndroide = "LG";
                break;
            case "Iphone5S":
                $scope.Iphone6Splus = "desactivate";
                $scope.Iphone6plus = "desactivate";
                $scope.Iphone6S = "desactivate";
                $scope.Iphone6 = "desactivate";
                $scope.Iphone5S = "act";
                $scope.Iphone5C = "desactivate";
                $scope.Iphone5 = "desactivate";
                $scope.Iphone4S = "desactivate";
                $scope.modelIphone = "Iphone 5S";
                $scope.modelAndroide = "Motorola";
                break;
            case "Iphone5C":
                $scope.Iphone6Splus = "desactivate";
                $scope.Iphone6plus = "desactivate";
                $scope.Iphone6S = "desactivate";
                $scope.Iphone6 = "desactivate";
                $scope.Iphone5S = "desactivate";
                $scope.Iphone5C = "act";
                $scope.Iphone5 = "desactivate";
                $scope.Iphone4S = "desactivate";
                $scope.modelIphone = "Iphone 5C";
                $scope.modelAndroide = "Nokia";
                break;
            case "Iphone5":
                $scope.Iphone6Splus = "desactivate";
                $scope.Iphone6plus = "desactivate";
                $scope.Iphone6S = "desactivate";
                $scope.Iphone6 = "desactivate";
                $scope.Iphone5S = "desactivate";
                $scope.Iphone5C = "desactivate";
                $scope.Iphone5 = "act";
                $scope.Iphone4S = "desactivate";
                $scope.modelIphone = "Iphone 5";
                $scope.modelAndroide = "Samsung";
                break;
            case "Iphone4S":
                $scope.Iphone6Splus = "desactivate";
                $scope.Iphone6plus = "desactivate";
                $scope.Iphone6S = "desactivate";
                $scope.Iphone6 = "desactivate";
                $scope.Iphone5S = "desactivate";
                $scope.Iphone5C = "desactivate";
                $scope.Iphone5 = "desactivate";
                $scope.Iphone4S = "act";
                $scope.modelIphone = "Iphone 4S";
                $scope.modelAndroide = "";
                break;

        }
    }


    ///------------Muestra el combo de los modelos si selecciones la marca apple

    //Variables para activar el div si quiero adicionar un nuevo modelo
    $scope.divSelectNewModel = true;
    $scope.divSelelectModel = false;
    $scope.nameClose = "";

    $scope.ClickNewClose = function (newClose) {

        if (newClose === "Nuevo") {
            $scope.divSelectNewModel = true;
            $scope.divSelelectModel = false;
            $scope.nameClose = "Cerrar";
        } else {
            $scope.divSelectNewModel = false;
            $scope.divSelelectModel = true;
            $scope.nameClose = "Nuevo";
        }
    }

    //Metodo para buscar el listado de modelos perteneciente a una marca y a un tipo
    $scope.clickMarca = function (marca) {

        if (marca === "iPad" || marca === "iPad Air" || $scope.SelectedType==="Ipod") {
            $scope.divSelectNewModel = false;
            $scope.divSelelectModel = false;
            $scope.Generation = true;
            $scope.ModelType = false;
        } else {
            angularService.getListModelToCategory($scope.SelectedType, marca).
                              success(function (models) {
                                  $scope.listModelos = models;

                                  if (models != null && models.length !== 0) {
                                      $scope.divSelectNewModel = false;
                                      $scope.divSelelectModel = true;
                                      $scope.nameClose = "Nuevo";
                                  } else {
                                      $scope.divSelectNewModel = true;
                                      $scope.divSelelectModel = false;
                                      $scope.nameClose = "";
                                  }

                              });
            $scope.Generation = false;
            $scope.ModelType = true;
        }



    }


    $scope.divDisableTypeDivice = false;
    $scope.selectDivTypeDivice = false;
    //Seleccionar un categoria cuando creo la imagen  y si es marca entonces cargo la lista de tipos de equipos
    $scope.SelectCategoryImagen = function (category) {
        if (category === "Marca") {
            $scope.selectDivTypeDivice = true;
            $scope.divDisableTypeDivice = false;
        } else {
            $scope.selectDivTypeDivice = false;
            $scope.divDisableTypeDivice = true;
        }
    }


    //$scope.hover = function (hovered) {

    //    if (hovered) {
    //        Element.addClass('over');
    //    }
    //    else {
    //        element.removeClass('over');
    //    }

    //}

    $scope.NameType = false;
    $scope.ModelType = false;
    $scope.CategoryType = false;
    $scope.CompanyType = false;
    $scope.PriceType = false;
    $scope.StartType = false;
    $scope.ConditionType = false;
    $scope.MemoryType = false;
    $scope.ImagesType = false;
    $scope.btnTypeCrear = false;


    $scope.SelectedType = "";

    $scope.selectTypeDiviceToCreateDivice = function (type) {

        $scope.SelectedType = type;
        angularService.getListCategories(type).
                  success(function (imageType) {

                      $scope.listmarcas = imageType;
                  });
        switch (type) {
            case "Iphone":
                $scope.NameType = true;
                $scope.ModelType = true;
                $scope.CategoryType = true;
                $scope.CompanyType = true;
                $scope.PriceType = true;
                $scope.StartType = true;
                $scope.ConditionType = true;
                $scope.MemoryType = true;
                $scope.ImagesType = true;
                $scope.btnTypeCrear = true;
                $scope.SizeComputers = false;
                $scope.ProcessorComputers = false;
                $scope.YearComputers = false;

                break;
            case "Phone":
                $scope.NameType = true;
                $scope.ModelType = true;
                $scope.CategoryType = true;
                $scope.CompanyType = true;
                $scope.PriceType = true;
                $scope.StartType = true;
                $scope.ConditionType = true;
                $scope.MemoryType = true;
                $scope.ImagesType = true;
                $scope.btnTypeCrear = true;
                $scope.SizeComputers = false;
                $scope.ProcessorComputers = false;
                $scope.YearComputers = false;


                break;
            case "Ipad":
                $scope.NameType = true;
                $scope.ModelType = true;
                $scope.CategoryType = true;
                $scope.CompanyType = true;
                $scope.PriceType = true;
                $scope.StartType = true;
                $scope.ConditionType = true;
                $scope.MemoryType = true;
                $scope.ImagesType = true;
                $scope.btnTypeCrear = true;
                $scope.Generation = false;
                $scope.SizeComputers = false;
                $scope.ProcessorComputers = false;
                $scope.YearComputers = false;
                break;
            case "Tablets":
                $scope.NameType = true;
                $scope.ModelType = true;
                $scope.CategoryType = true;
                $scope.CompanyType = true;
                $scope.PriceType = true;
                $scope.StartType = true;
                $scope.ConditionType = true;
                $scope.MemoryType = true;
                $scope.ImagesType = true;
                $scope.btnTypeCrear = true;
                $scope.Generation = false;
                $scope.SizeComputers = false;
                $scope.ProcessorComputers = false;
                $scope.YearComputers = false;
                break;
            case "Ipod":
                $scope.NameType = true;
                $scope.ModelType = false;
                $scope.CategoryType = true;
                $scope.CompanyType = false;
                $scope.PriceType = true;
                $scope.StartType = true;
                $scope.ConditionType = true;
                $scope.MemoryType = true;
                $scope.ImagesType = true;
                $scope.btnTypeCrear = true;
                $scope.Generation = true;
                $scope.SizeComputers = false;
                $scope.ProcessorComputers = false;
                $scope.YearComputers = false;
                break;
            case "Computers":
                $scope.NameType = true;
                $scope.ModelType = true;
                $scope.CategoryType = true;
                $scope.CompanyType = false;
                $scope.PriceType = true;
                $scope.StartType = true;
                $scope.ConditionType = true;
                $scope.MemoryType = true;
                $scope.ImagesType = true;
                $scope.btnTypeCrear = true;
                $scope.Generation = false;

                $scope.SizeComputers = true;
                $scope.ProcessorComputers = true;
                $scope.YearComputers = true;
                break;
            case "Other":
                $scope.NameType = false;
                $scope.ModelType = false;
                $scope.CategoryType = false;
                $scope.CompanyType = false;
                $scope.PriceType = false;
                $scope.StartType = false;
                $scope.ConditionType = false;
                $scope.MemoryType = false;
                $scope.ImagesType = true;
                $scope.btnTypeCrear = true;
                $scope.Generation = false;
                $scope.SizeComputers = false;
                $scope.ProcessorComputers = false;
                $scope.YearComputers = false;
                break;

        }
    }

    //$scope.SelectSpecifications= function(specifications,combo) {
    //    if()
    //}

});

