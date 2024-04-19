
class ImagenModel {
    path: string;
    categoryName: string;
    typeName: string;

    constructor($scope) {
        this.path = $scope.Path;
        this.categoryName = $scope.CategoryName;
        this.typeName = $scope.TypeName;
    }

      public getPath() {
        return "";
    }
} 