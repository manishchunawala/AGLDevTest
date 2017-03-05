var url_GetAllCats = "/Api/Cats/GetAllCats";

app
.service("catsService", ['$http', function ($http) {
    // Get All Cats
    this.getAllCats = function () {
        return $http.get(url_GetAllCats);
    }
}]);