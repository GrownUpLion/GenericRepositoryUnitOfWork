(function (app) {
    var rolesController = function ($scope, APIRoleService, $routeParams, $location) {

        GetRoles();

        function GetRole(id) {
            return new Promise(function (resolve, reject) {
                APIRoleService.GetRole(id).then(function (d) {
                    $scope.role = d.data;
                    resolve();
                }, function (error) {
                    $log.error(error)
                    reject(Error(error));
                })
            });
        }

        function GetRoles() {
            APIRoleService.getRoles().then(function (d) {
                $scope.roles = d.data.$values;
            }, function (error) {
                $log.error('Oops! Something went wrong while fetching the data.')
            })
        }

        $scope.saveRole = function () {
            var role = {
                Id: $scope.role.Id,
                Name: $scope.role.Name
            };
            var saveRole = APIRoleService.saveRole(role);
            saveRole.then(function (d) {
                $location.url('/listRoles');
            }, function (error) {
                console.log('Oops! Something went wrong while saving the data.')
            })
        };

        if ($routeParams.id) {
            GetRole($routeParams.id);
        }
        else {
            var role = {
                Id: 0,
                Name: null
            };
            $scope.role = role;
        }


        $scope.deleteRole = function (subID) {
            var dlt = APIRoleService.deleteRole(subID);
            dlt.then(function (d) {
                GetRoles();
            }, function (error) {
                console.log('Oops! Something went wrong while deleting the data.')
            })
        };

    };
    app.controller("rolesController", rolesController);
}(angular.module("UserRole")));