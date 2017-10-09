var app;
(function () {
    app = angular.module("UserRole", ['ngRoute', "checklist-model", 'oc.lazyLoad'])
    var config = function ($routeProvider) {
        $routeProvider
        .when("/list",
            { templateUrl: "/AngularViews/Index.html" ,
            resolve: {
                lazy: ['$ocLazyLoad', function ($ocLazyLoad) {
                    return $ocLazyLoad.load([{
                        name: 'UserRole',
                        files: ['../Scripts/APISripts/MainController.js']
                    }]);
                }]
            }
            })
        .when("/Create",
            {
                templateUrl: "/AngularViews/Edit.html",
                resolve: {
                    lazy: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([{
                            name: 'UserRole',
                            files: ['../Scripts/APISripts/EditUserController.js']
                        }]);
                    }]
                }
            })
        .when("/Edit/:id",
            {
                templateUrl: "/AngularViews/Edit.html",
                resolve: {
                    lazy: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([{
                            name: 'UserRole',
                            files: ['../Scripts/APISripts/EditUserController.js']
                        }]);
                    }]
                }
            })
        .otherwise(
            { redirectTo: "/list" });
    };

    app.config(config);
}());