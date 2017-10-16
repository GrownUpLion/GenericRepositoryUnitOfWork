(function (app) {
    var editController = function ($scope, UsersAPiService, APIRoleService, $routeParams, $location) {

        function GetUser(id) {
            return new Promise(function (resolve, reject) {
                UsersAPiService.GetUser(id).then(function (d) {
                    $scope.user = d.data;
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

        function parseErrors(response) {
            var errors = [];
            $.each(response, function (k, v) {
                if (v.$values)errors.push(v.$values[0])
            });
            return errors;
        }

        $scope.toggleSelection = function toggleSelection(event,role) {

            if (event.target.checked) {
                var newRole = {
                    Id: role.Id,
                    Name : role.Name
                }
                $scope.user.Roles.$values.push(newRole);

            }

            else {
                index =  $scope.user.Roles.$values.findIndex(x => x.Name == role.Name);
                $scope.user.Roles.$values.splice(index, 1);
            }
        };
    

        $scope.finUserRole = function finUserRole(name) {
            if (!$scope.user) return false;
            else return $scope.user.Roles.$values.findIndex(x => x.Name == name) > -1;
        }

        $scope.saveUser = function () {
            var user = {
                Id: $scope.user.Id,
                UserName: $scope.user.UserName,
                FirstName: $scope.user.FirstName,
                Email: $scope.user.Email,
                LastName: $scope.user.LastName,
                Active: $scope.user.Active,
                Roles: $scope.user.Roles,
            };
            var saveUser = UsersAPiService.saveUser(user);
            saveUser.then(function (d) {
                $location.url('/List');
            }, function (error) {
                $scope.errors = parseErrors(error.data.ModelState);
                console.log('Oops! Something went wrong while saving the data.')
            })
        };

        if ($routeParams.id) {
            GetUser($routeParams.id).then(GetRoles());
        }
        else {
            var user = {
                Id: 0,
                UserName: null,
                FirstName: null,
                Email: null,
                LastName: null,
                Active: null,
                Roles: {$values: []}
            }
            $scope.user = user;
            GetRoles();
            
    }
}

    app.controller("editController", editController);

}(angular.module("UserRole")));

