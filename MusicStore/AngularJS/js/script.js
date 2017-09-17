// create the module and name it scotchApp
var scotchApp = angular.module('scotchApp', ['ngRoute', 'angularUtils.directives.dirPagination']);

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

        // route for the about page
        .when('/album-edit', {
            templateUrl: 'pages/album-edit.html',
            controller: 'albumEditController'
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

    $scope.currentPage = 1;
    $scope.pageSize = 5;

    $scope.loading = true; //show loading image
    $scope.Albums = GetAllAlbum();
    function GetAllAlbum() {
        $http.get("/api/album")
        .then(function (response) {
            //First function handles success
            $scope.Albums = response.data;
            $scope.loading = false; //hide loading image
        }, function (response) {
            //Second function handles error
            $scope.Albums = "Something went wrong";
            $scope.loading = false; //hide loading image
        });
    }
    $scope.DeleteAlbum = function (id) {
        var con = confirm('sure to delete?');
        if (con) {
            $http({
                method: "delete",
                url: "/api/album/" + id,
                dataType: "json"
            }).then(function (response) {
                alert(response.data);
                GetAllAlbum();
            }, function (response) {
                alert(response.data);
            });
        }
    }

    $scope.Authors = GetAllAuthors();
    function GetAllAuthors() {
        $http.get("/api/author")
        .then(function (response) {
            //First function handles success
            $scope.Authors = response.data;
        }, function (response) {
            //Second function handles error
            $scope.Authors = "Something went wrong. " + response.data;
        });
    }

    $scope.AlbumFilter = function (ax) {

        var data = { Id: 3, Name: 'Phearom Neang', Age: 24 }
        $http({
            method: "post",
            url: "/albums/xxx",
            data: JSON.stringify(data),
            dataType: "json"
        }).then(function (response) {
            alert(response.data);
        }, function (response) {
            alert(respone.data);
        });

        //get method
        //$http({
        //    method: "get",
        //    url: "/albums/xxx/?id=3&name=phearom&age=24",
        //    //data: JSON.stringify(dx),
        //    dataType: "json"
        //}).then(function (response) {
        //    alert(response.data);
        //}, function (response) {
        //    alert(respone.data);
        //});

    }

    $scope.pageChangeHandler = function (num) {
        $scope.currentPage = num;
        GetAllAlbum();
        console.log('Page changed to ' + num);
    };
});

// create the controller and inject Angular's $scope
scotchApp.controller('albumEditController', function ($scope, $http, $routeParams) {
    // create a message to display in our view
    $scope.loading = true; //show loading image
    var id = $routeParams.id;
    if (id == -1) {
        $scope.Album = {};
        $scope.loading = false;
    } else {
        $http.get("/api/album/" + id)
        .then(function (response) {
            //First function handles success
            $scope.Album = response.data;
            $scope.loading = false; //hide loading image
            if (id > 0) { $scope.a = true; }
            else { $scope.a = false; }
        }, function (response) {
            //Second function handles error
            $scope.Album = "Something went wrong. " + response.data;
            $scope.loading = false; //hide loading image
        });
    }

    $scope.AddAlbum = function (Album) {
        $http({
            method: "post",
            url: "/api/album",
            data: JSON.stringify(Album),
            dataType: "json"
        }).then(function (response) {
            alert(response.data);
            //$location.path('index.html#/album');
            window.location = 'index.html#!/album'
        }, function (response) {
            alert(respone.data);
        });
    }

    $scope.UpdateAlbum = function (Album) {
        $http({
            method: "put",
            url: "/api/album",
            data: JSON.stringify(Album),
            dataType: "json"
        }).then(function (response) {
            alert(response.data);
            window.location = 'index.html#!/album'
        }, function (response) {
            alert(respone.data);
        });
    }

    $scope.Authors = GetAllAuthors();
    function GetAllAuthors() {
        $http.get("/api/author")
        .then(function (response) {
            //First function handles success
            $scope.Authors = response.data;
        }, function (response) {
            //Second function handles error
            $scope.Authors = "Something went wrong. " + response.data;
        });
    }
});

scotchApp.controller('authorController', function ($scope, $http) {
    $scope.loading = true; //show loading image
    $http.get("/api/author")
    .then(function (response) {
        //First function handles success
        $scope.Authors = response.data;
        $scope.loading = false; //hide loading image
    }, function (response) {
        //Second function handles error
        $scope.Authors = "Something went wrong";
        $scope.loading = false; //hide loading image
    });
});