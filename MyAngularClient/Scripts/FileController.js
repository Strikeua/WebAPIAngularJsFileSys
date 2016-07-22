var myApp = angular.module("myApp", []);
    
myApp.controller("FilesController", function ($scope, $http) {
    $http.get("http://localhost:63217/api/File?path").success(function (response) {
        
        $scope.result = response;

        $scope.GetNewData = function(path) { 
            $http.get("http://localhost:63217/api/File?path=" + path).success(function (response) {
                $scope.result = response;
            });
        }
        
    });

   
});






