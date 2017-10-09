(function (app) {
    var mainController = function ($scope, UsersAPiService) {
        getAll();
        function getAll() {
            UsersAPiService.getUsers().then(function (d) {
                $scope.users = d.data.$values;
            }, function (error) {
                $log.error('Oops! Something went wrong while fetching the data.')
            })
        }
        $scope.deleteUser = function (subID) {
            var dlt = UsersAPiService.deleteUser(subID);
            dlt.then(function (d) {
                getAll();
            }, function (error) {
                console.log('Oops! Something went wrong while deleting the data.')
            })
        };
    };
    app.controller("mainController", mainController);
}(angular.module("UserRole")));