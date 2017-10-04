var app;
(function () {
    app = angular.module("NNUsersApp", ["ngRoute"])
    var config = function ($routeProvider) {
        $routeProvider
        .when("/list",
            { templateUrl: "/AngularViews/Index.html" })
        .when("/Create",
            { templateUrl: "/AngularViews/Create.html"})
        .when("/Edit/:id",
            { templateUrl: "/AngularViews/Create.html" })
        .otherwise(
            { redirectTo: "/list"});
    };

    app.config(config);
}());