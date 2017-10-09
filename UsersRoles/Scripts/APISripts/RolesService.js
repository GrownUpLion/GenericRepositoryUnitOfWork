app.service("APIRoleService", function ($http) {
    this.getRoles = function () {
        return $http.get("/api/RolesAPI")
    }
});