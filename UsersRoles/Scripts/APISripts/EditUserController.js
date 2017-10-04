(function(app) {
    var EditController = function ($scope, APIService) {
        GestUser(1);

        function GestUser() {
            var servCall = APIService.GestUser();
            servCall.then(function (d) {
                $scope.user = d.data.$values;
            }, function (error) {
                $log.error('Oops! Something went wrong while fetching the data.')
            })
        }

        $scope.isEditable = function () {
            return $scope.edit && $scope.edit.music;
        };

        $scope.cancel = function() {
            $scope.edit.music = null;
        };

        $scope.save = function () {
            if ($scope.edit.music.Id) {
                updateMusic();
            } else {
                createMusic();
            }
        };
        $scope.musics = [];
        var updateMusic = function() {
            musicService.update($scope.edit.music)
                    .then(function () {
                    angular.extend($scope.music, $scope.edit.music);
                    $scope.edit.music = null;
                });
        };

        var createMusic = function () {
            musicService.create($scope.edit.music)
                .then(function () {
                    $scope.musics.push($scope.edit.music);
                    $scope.edit.music = null;
                });
        };
    };
    app.controller("EditUserController", EditUserController);
}(angular.module("theMusic")));