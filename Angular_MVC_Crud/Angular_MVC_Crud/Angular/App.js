//define aplicação angular e o controller
var app = angular.module("livrosApp", []);
//registra o controller e cria a função para obter os dados do Controlador MVC
app.controller("livrosCtrl", function ($scope, $http) {
    $http.get('/home/GetTodosLivros/')
    .success(function (result) {
        $scope.livros = result;
    })
    .error(function (data) {
        console.log(data);
    });


    $scope.livro = $scope.livros;
    $scope.SelecionaLivro = function (livro) {
        $scope.livro = livro;
    }

    //chama o  método AdicionarLivro do controlador
    $scope.IncluiLivro = function (livro) {
        $http.post('/home/AdicionarLivro/', { livro })
        .success(function (result) {
            $scope.livros = result;
            delete $scope.livro;
            $scope.TodosLivros();
    })
        .error(function (data) {
            console.log(data);
    });
    }

    //chama o  método AtualizarLivro do controlador
    $scope.AlteraLivro = function (livro) {
        $http.post('/home/AtualizarLivro/', { livro })
        .success(function (result) {
            $scope.livros = result;
            $scope.TodosLivros();
        })
        .error(function (data) {
            console.log(data);
        });
    }

    //chama o  método DeletarLivro do controlador
    $scope.DeletaLivro = function (livro) {
        $http.post('/home/DeletarLivro/', { livro })
        .success(function (result) {
            $scope.livros = result;
            $scope.TodosLivros();
        })
        .error(function (data) {
            console.log(data);
        });
    }

    //retorna todos os livros
    $scope.TodosLivros = function () {
        $http.get('/home/GetTodosLivros/')
        .success(function (result) {
            $scope.livros = result;
            

        })
        .error(function (data) {
            console.log(data);
        });
    }

});
