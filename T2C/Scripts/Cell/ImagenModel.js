var ImagenModel = (function () {
    function ImagenModel($scope) {
        this.path = $scope.Path;
        this.categoryName = $scope.CategoryName;
        this.typeName = $scope.TypeName;
    }
    ImagenModel.prototype.getPath = function () {
        return "";
    };
    return ImagenModel;
})();
//# sourceMappingURL=ImagenModel.js.map
