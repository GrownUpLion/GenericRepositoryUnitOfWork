app.service("UsersAPiService", function ($http) {
    var pageNo = 0;
    var pageSize = 5;
    var url = 'api/UsersAPI/';
    this.getUsers = function () {
        return $http.get(url + pageNo + '/' + pageSize);
    }

    this.saveUser = function (user) {
        if (user.Id == 0) {
            return $http({ method: 'post', data: user, url: url });
        }
        else {
            return $http.put(url, user);
        }
    }

    this.getNext = function () {
        pageNo = pageNo + pageSize;
        return this.getUsers();
    }
    this.getPrevious = function () {
        if (pageNo - pageSize < 0) page = 0;
        else pageNo = pageNo - pageSize;
        return this.getUsers();
    }

    this.deleteUser = function (userID) {
        return $http.delete(url + userID);
    }

    this.GetUser = function (id) {
        return $http.get(url + id);
    }
});