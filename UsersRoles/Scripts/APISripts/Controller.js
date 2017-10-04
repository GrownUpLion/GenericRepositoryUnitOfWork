(function (app) {
    var mainController = function ($scope, APIService) {
        getAll();

        //GetUser(1);


        function getAll() {
            APIService.getUsers().then(function (d) {
                $scope.users = d.data.$values;
            }, function (error) {
                $log.error('Oops! Something went wrong while fetching the data.')
            })
        }
        $scope.saveUser = function () {
            var user = {
                UserName: $scope.user.UserName,
                FirstName: $scope.user.FirstName,
                Email: $scope.user.Email,
                LastName: $scope.user.LastName,
                Active: $scope.user.Active,
            };
            var saveUser = APIService.saveUser(user);
            saveUser.then(function (d) {
            }, function (error) {
                console.log('Oops! Something went wrong while saving the data.')
            })
        };

        $scope.deleteUser = function (subID) {
            var dlt = APIService.deleteUser(subID);
            dlt.then(function (d) {
                getAll();
            }, function (error) {
                console.log('Oops! Something went wrong while deleting the data.')
            })
        };

        function GetUser(id) {
            var servCall = APIService.GetUser(id);
            servCall.then(function (d) {
                $scope.user = d.data.$values;
            }, function (error) {
                $log.error('Oops! Something went wrong while fetching the data.')
            })
        }
    };


    app.controller("mainController", mainController);

    var editController = function ($scope, APIService, $routeParams) {
        function GetUser(id) {

            APIService.GetUser(id).then(function (d) {
                $scope.user = d.data;
            }, function (error) {
                $log.error('Oops! Something went wrong while fetching the data.')
            })
            //var servCall = APIService.GetUser(id);
            //servCall.then(function (d) {
            //    $scope.user =d.data.__interceptor._target;
            //}, function (error) {
            //    $log.error('Oops! Something went wrong while fetching the data.')
            //})
        }

        $scope.saveUser = function () {
            var user = {
                id: $scope.user.Id,
                UserName: $scope.user.UserName,
                FirstName: $scope.user.FirstName,
                Email: $scope.user.Email,
                LastName: $scope.user.LastName,
                Active: $scope.user.Active,
                Roles: $scope.user.Roles,
            };
            var saveUser = APIService.saveUser(user);
            saveUser.then(function (d) {
            }, function (error) {
                console.log('Oops! Something went wrong while saving the data.')
            })
        };

        if ($routeParams.id) {
            GetUser($routeParams.id)
        }
    }

    app.controller("editController", editController);

}(angular.module("NNUsersApp")));