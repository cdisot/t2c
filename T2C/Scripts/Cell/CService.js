app.service("angularService", function ($http) {


    //------------------------------------------------------------



    //------------------------------------------------------------  // 

    /*
        //Filter 
        this.Filter = function (name, model, company, condition, price, memory, category) {
    
            var response = $http({
                method: "post",
                url: "/Page/Index",
                params: {
                    name: name,
                    model: model,
                    company: company,
                    price: price,
                    condition: condition,
                    memory: memory,
                    category: category
                }
            });
            return response;
        }
    
    
      
      */
    ///Upload File ----Funciona perfectamente
    this.UploadFileIndividual = function (fileToUpload, name, type, size,i) {

        //Create XMLHttpRequest Object
        var reqObj = new XMLHttpRequest();

        //open the object and set method of call(get/post), url to call, isAsynchronous(true/False)
        reqObj.open("GET", "/Imagen/UploadFiles", true);

        //set Content-Type at request header.for file upload it's value must be multipart/form-data
        reqObj.setRequestHeader("Content-Type", "multipart/form-data");

        reqObj.setRequestHeader("dataType", "json");

        //Set Other header like file name,size and type
        reqObj.setRequestHeader("X-File-Name", name);
        reqObj.setRequestHeader("X-File-Type", type);
        reqObj.setRequestHeader("X-File-Size", size);


        // send the file
        var pathImage=reqObj.send(fileToUpload);

        return pathImage;
    }
    this.AddUploadImagen = function (imagen) {

        var response = $http({
            method: "post",
            url: "/Imagen/Create",
            data: JSON.stringify(imagen),
            dataType: "json"

        });

        return response;
    }


    this.UploadImagenToServer = function (imgen) {
        var response = $http({
            method: "post",
            url: "/Imagen/UploadImagenToServer",
            data: JSON.stringify(imgen),
            dataType: "json"

        });

        return response;

    }
    //devuelve la lista e compañiaa
    this.ListCompanies = function (nameCompanies) {
       
        var response = $http({
            method: "post",
            url: "/Page/ListCompanAndMarca",
            params: {
                name: nameCompanies
            }

        });

        return response;
    }

    //Deveulve todas las marcas
    this.ListMarcas = function (m) {

        var response = $http({
            method: "post",
            url: "/Page/ListCompanAndMarca",
            params: {
                name: m
            }
        });

        return response;
    }

    //Deveulve todas las marcas
    this.getListImagenToType = function (type) {

        var response = $http({
            method: "post",
            url: "/Page/ListImageToType",
            params: {
                tipo: type
            }
        });

        return response;
    }
    
    //Devuelve la lista de todos los celulares, laptp, etc.
    this.ListAllDivice = function () {
        var response = $http({
            method: "post",
            url: "/Page/ListAllDivice"
        });

        return response;
    }


    //Cargar la pagina de detalles del equipo

    this.getDetailsDivice = function (idDivice) {
        var response = $http({
            method: "post",
            url: "/Page/Details",
            params: {
                id: idDivice
            }
        });

        return response;
    }
    

    this.getListComputers = function (sizeComputers, processorComputers, yearComputers, modelComputers, categoryComputers) {

     
        var response = $http({
            method: "post",
            url: "/Page/ListComputers",
            params: {
                size: sizeComputers,
                processor: processorComputers,
                year: yearComputers,
                model: modelComputers,
                category: categoryComputers
            }
        });

        

        return response;
    }


    ////filter Computers
    //this.getListComputers = function (sizeComputers, processorComputers, yearComputers, modelComputers, categoryComputers) {

    //    alert("Service");
    //    var response = $http({
    //        method: "post",
    //        url: "/Page/ListComputers",
    //        params: {
    //            size: sizeComputers,
    //            processor: processorComputers,
    //            year: yearComputers,
    //            model: modelComputers,
    //            category: categoryComputers
    //        }
    //    });
    //    return response;
    //}


    //Filtrar equipos
    this.getListDivice = function (nameDivice, modelDivice, companyDivice, conditionDivice, priceDivice, memoryDivice, categoryDivice, typeDevice,genDivice) {

      
        var response = $http({
            method: "post",
            url: "/Page/FilterDivice",
            params: {
                name: nameDivice,
                model: modelDivice,
                company: companyDivice,
                condition: conditionDivice,
                price: priceDivice,
                memory: memoryDivice,
                category: categoryDivice,
                type: typeDevice,
                generation: genDivice
            }
        });
        return response;
    }

    this.getListCategories = function (imageType) {


        var response = $http({
            method: "post",
            url: "/Cell/ListMarca",
            params: {
                type: imageType
            }
        });
        return response;
    }

    this.getListModelToCategory = function (imageType,marca) {

        var response = $http({
            method: "post",
            url: "/Cell/ListModel",
            params: {
                type: imageType,
                category: marca
            }
        });
        return response;
    }

    

    this.getListPageIphone = function () {

         $http({
            method: "post",
            url: "/Page/Iphone"
           
        });
    }

    //--------------------------Equipos--------------------------
    //Delete equipo
    /*  this.Delete = function (empId) {
          var response = $http({
              method: "post",
              url: "/Cell/Delete",
              params: {
                  id: empId
              }
          });
          return response;
      }*/

    //Add equipo
    this.Add = function (cell) {

        var response = $http({
            method: "post",
            url: "/Cell/Create",
            data: JSON.stringify(cell),
            dataType: "json"

        });

        return response;
    }
    /*

    //Save (Update)  equipo
    this.update = function (cell) {
        var response = $http({
            method: "post",
            url: "/Cell/Edit",
            data: JSON.stringify(cell),
            dataType: "json"
        });
        return response;
    }
    */
});
