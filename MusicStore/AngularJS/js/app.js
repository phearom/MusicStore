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

        // route for the album page
        .when('/album', {
            templateUrl: 'pages/album.html',
            controller: 'albumController'
        })

        // route for the album-edit page
        .when('/album-edit', {
            templateUrl: 'pages/album-edit.html',
            controller: 'albumEditController'
        })

        // route for the author page
        .when('/author', {
            templateUrl: 'pages/author.html',
            controller: 'authorController'
        })

        // route for the author-edit page
        .when('/author-edit', {
            templateUrl: 'pages/author-edit.html',
            controller: 'authorEditController'
        });
});

// create the controller and inject Angular's $scope
scotchApp.controller('mainController', function ($scope) {
    // create a message to display in our view
    $scope.message = 'Everyone come and see how good I look!';
});

scotchApp.controller('albumController', function ($scope, $http) {

    $scope.currentPage = 1;
    $scope.pageSize = 7;

    $scope.loading = true; //show loading image
    $scope.Albums = GetAllAlbum(-1, -1, '2017-sep-01');
    function GetAllAlbum(rating, enable, releasedate) {
        //$http.get("/api/album/?rating=0")
        $http.get("/albums/GetAll?rating=" + rating + "&enable=" + enable + "&releasedate=" + releasedate)
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

    $scope.Ratings = GetRating();

    function GetRating() {
        $http.get("/albums/getrating")
        .then(function (response) {
            //First function handles success
            $scope.Ratings = response.data;
        }, function (response) {
            //Second function handles error
            $scope.Ratings = "Something went wrong";
        });
    }

    $scope.AlbumFilter = function (rating, enable, releasedate) {

        if (isNaN(rating) || rating == '') { rating = -1; }
        if (isNaN(enable) || enable == '') { enable = -1; }

        GetAllAlbum(rating, enable, releasedate);

        //$http({
        //    method: "get",
        //    url: "/albums/GetAllAlbum/?rating=" + rating + "&enable=" + enable,
        //    data: {},
        //    dataType: "json"
        //}).then(function (response) {
        //    $scope.Albums = response.data;
        //}, function (response) {
        //    alert(respone.data);
        //});

    }

    $scope.pageChangeHandler = function (num) {
        $scope.currentPage = num;
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
scotchApp.controller('authorEditController', function ($scope, $http, $routeParams) {
    $scope.loading = true; //show loading image
    var id = $routeParams.id;
    if (id == -1) {
        $scope.Author = {};
        $scope.loading = false;
    } else {
        $http.get("/api/author/" + id)
        .then(function (response) {
            //First function handles success
            $scope.Author = response.data;
            $scope.loading = false; //hide loading image
            if (id > 0) { $scope.a = true; }
            else { $scope.a = false; }
        }, function (response) {
            //Second function handles error
            $scope.Author = "Something went wrong. " + response.data;
            $scope.loading = false; //hide loading image
        });
    }

    $scope.AddAuthor = function (Author) {
        $http({
            method: "post",
            url: "/api/author",
            data: JSON.stringify(Author),
            dataType: "json"
        }).then(function (response) {
            alert(response.data);
            //$location.path('index.html#/album');
            window.location = 'index.html#!/author'
        }, function (response) {
            alert(respone.data);
        });
    }

    $scope.UpdateAuthor = function (Author) {
        $http({
            method: "put",
            url: "/api/author",
            data: JSON.stringify(Author),
            dataType: "json"
        }).then(function (response) {
            alert(response.data);
            window.location = 'index.html#!/author'
        }, function (response) {
            alert(respone.data);
        });
    }

    $scope.DeleteAuthor = function (id) {
        alert('xx');
        var con = confirm('sure to delete?');
        if (con) {
            $http({
                method: "delete",
                url: "/api/author/" + id,
                dataType: "json"
            }).then(function (response) {
                alert(response.data);
                GetAllAuthor();
            }, function (response) {
                alert(response.data);
            });
        }
    }
});