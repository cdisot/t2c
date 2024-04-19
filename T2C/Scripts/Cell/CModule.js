var app = angular.module("MyApp", ["ngRoute"]);
    app.config(["$routeProvider", function ($routeprovider) {
    $routeprovider.
        when("/index", {
            templateurl: "/Views/Cell/Index.cshtml",
            controller: "AngularCtrl"
        }).when("/details",
        {
            templateurl: "/Views/Page/Details.cshtml",
            controller: "AngularCtrl"
        });
}]);