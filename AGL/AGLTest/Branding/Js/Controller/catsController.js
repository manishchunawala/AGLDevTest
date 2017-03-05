app
.controller('catsController', ['$scope', '$location', 'catsService', function ($scope, $location, catsService)
{
    $scope.IsSuccess = false;

    GetAllCats();

    function GetAllCats()
    {
        var getData = catsService.getAllCats();
        getData.then(
            function (result)
            {
                //  Get the Status Code
                $scope.StatusCode = result.data.StatusCode;
                if (result != null && typeof result != 'undefined' && result.data.StatusCode == 200)
                {
                    // if Success, Get Json
                    var jsonResult = JSON.parse(result.data.Model);

                    // Order cats in alphabetical order under a heading of the gender of their owner
                    $scope.AllCats =
                        _.groupBy(_.sortBy(_.flatMap(jsonResult, item =>
                            _(item.pets).filter({ type: 'Cat' })
                              .map(x => ({ catName: x.name, gender: item.gender }))
                              .value()
                                  ), 'catName'), 'gender');

                    $scope.IsSuccess = true;
                }
                else {
                    // If Error
                    $scope.Error = result.data.Model;
                }
            },
            function (err)
            {
                // Error
                $scope.StatusCode = 404;
                $scope.Error = err.data;
            });
    }
}]);