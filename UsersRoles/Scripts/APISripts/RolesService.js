app.service("APIRoleService", function ($http) {
    this.getRoles = function () {
        return $http.get("/api/RolesAPI")
    }

    this.saveRole = function (role) {
        var url = 'api/RolesAPI/';
        if (role.Id == 0) {
            return $http({ method: 'post', data: role, url: url });
        }
        else {
            return $http.put(url, role);
        }
    }

    this.deleteRole = function (roleID) {
        var url = 'api/RolesAPI/' + roleID;
        return $http({
            method: 'delete',
            data: roleID,
            url: url
        });
    }

    this.GetRole = function (id) {
        return $http.get("/api/RolesAPI/" + id);
    }
});