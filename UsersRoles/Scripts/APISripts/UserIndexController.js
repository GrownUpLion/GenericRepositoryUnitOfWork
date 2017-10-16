(function (app) {
    var userIndexController = function ($scope, $routeParams, UsersAPiService) {
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

        $scope.getNextUsers = function () {
            var dlt = UsersAPiService.getNext();
            dlt.then(function (d) {
                $scope.users = d.data.$values;
            }, function (error) {
                console.log('Oops! Something went wrong while deleting the data.')
            })
        };

        $scope.getPreviousUsers = function () {
            var dlt = UsersAPiService.getPrevious();
            dlt.then(function (d) {
                $scope.users = d.data.$values;
            }, function (error) {
                console.log('Oops! Something went wrong while deleting the data.')
            })
        };

    };
    app.controller("userIndexController", userIndexController);
}(angular.module("UserRole")));