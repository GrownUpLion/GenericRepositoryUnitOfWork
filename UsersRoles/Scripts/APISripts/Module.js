var app;
(function () {
    app = angular.module("UserRole", ['ngRoute', "checklist-model", 'oc.lazyLoad'])
    var config = function ($routeProvider) {
        $routeProvider
        .when("/list",
            {
                templateUrl: "/AngularViews/UserIndex.html",
                resolve: {
                    lazy: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([{
                            name: 'UserRole',
                            files: ['../Scripts/APISripts/UserIndexController.js', , '../Scripts/APISripts/RolesService.js']
                        }]);
                    }]
                }
            })
        .when("/Create",
            {
                templateUrl: "/AngularViews/EditUser.html",
                resolve: {
                    lazy: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([{
                            name: 'UserRole',
                            files: ['../Scripts/APISripts/EditUserController.js', '../Scripts/APISripts/RolesService.js']
                        }]);
                    }]
                }
            })
        .when("/Edit/:id",
            {
                templateUrl: "/AngularViews/EditUser.html",
                resolve: {
                    lazy: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([{
                            name: 'UserRole',
                            files: ['../Scripts/APISripts/EditUserController.js', '../Scripts/APISripts/RolesService.js']
                        }]);
                    }]
                }
            })
        .when("/listRoles",
            {
                templateUrl: "/AngularViews/RolesIndex.html",
                resolve: {
                    lazy: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([{
                            name: 'RoleController',
                            files: ['../Scripts/APISripts/RolesService.js', '../Scripts/APISripts/RolesController.js']
                        }]);
                    }]
                }
            })
        .when("/CreateRole",
            {
                templateUrl: "/AngularViews/EditRole.html",
                resolve: {
                    lazy: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([{
                            name: 'CreateRole',
                            files: ['../Scripts/APISripts/RolesController.js', '../Scripts/APISripts/RolesService.js']
                        }]);
                    }]
                }
            })
        .when("/EditRole/:id",
            {
                templateUrl: "/AngularViews/EditRole.html",
                resolve: {
                    lazy: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([{
                            name: 'EditRole',
                            files: ['../Scripts/APISripts/RolesController.js', '../Scripts/APISripts/RolesService.js']
                        }]);
                    }]
                }
            })
        .otherwise(
            { redirectTo: "/list" });
    };

    app.config(config);
}());