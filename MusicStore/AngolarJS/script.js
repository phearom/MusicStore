// create the module and name it scotchApp
var scotchApp = angular.module('scotchApp', ['ngRoute']);

// configure our routes
scotchApp.config(function ($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'pages/home.html',
            controller: 'mainController'
        })

        // route for the about page
        .when('/album', {
            templateUrl: 'pages/album.html',
            controller: 'albumController'
        })

        // route for the contact page
        .when('/author', {
            templateUrl: 'pages/author.html',
            controller: 'authorController'
        });
});

// create the controller and inject Angular's $scope
scotchApp.controller('mainController', function ($scope) {
    // create a message to display in our view
    $scope.message = 'Everyone come and see how good I look!';
});

scotchApp.controller('albumController', function ($scope, $http) {
    $http.get("/api/album")
    .then(function (response) {
        //First function handles success
        $scope.Albums = response.data;
    }, function (response) {
        //Second function handles error
        $scope.Albums = "Something went wrong";
    });
});

scotchApp.controller('authorController', function ($scope,$http) {
    $http.get("/api/author")
    .then(function (response) {
        //First function handles success
        $scope.Authors = response.data;
    }, function (response) {
        //Second function handles error
        $scope.Authors = "Something went wrong";
    });
});