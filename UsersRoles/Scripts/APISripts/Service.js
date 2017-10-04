app.service("APIService", function ($http,$q) {
    this.getUsers = function () {
        return $http.get("/api/UsersAPI")
    }

    this.saveUser = function (user) {

        if (!user.id) {

        var url = 'api/UsersAPI/';
        return $http({
            method: 'post',
            data: user,
            url: url
        });
            //$http.post('/api/UsersAPI/', user).success(function (data) {
            //    $location.path('/list');
            //}).error(function (data) {
            //    $scope.error = "An error has occured while adding employee! " + data.ExceptionMessage;
            //});
        }
        else {
            $http.put('/api/UsersAPI/', user).success(function (data) {
                $location.path('/list');
            }).error(function (data) {
                $scope.error = "An Error has occured while Saving customer! " + data.ExceptionMessage;
            });
        }
    }

   this.deleteUser = function (userID) {
       var url = 'api/UsersAPI/' + userID;
        return $http({
            method: 'delete',
            data: userID,
            url: url
        });
    }

    this.GetUser = function (id) {
        var deferred = $q.defer();
        $http.get("/api/UsersAPI/" + id).
        then(function (data, status, headers, config) {
            deferred.resolve(data)
        });

        return deferred;
    }
});