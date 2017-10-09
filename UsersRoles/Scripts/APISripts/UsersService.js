app.service("UsersAPiService", function ($http) {
    this.getUsers = function () {
        return $http.get("/api/UsersAPI")
    }

    this.saveUser = function (user) {

        if (user.id!=0) {
            var url = 'api/UsersAPI/';
            return $http({method: 'post',data: user,url: url});
        }
        else {
            return $http.put('/api/UsersAPI/', user);
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
        return $http.get("/api/UsersAPI/" + id);
    }
});