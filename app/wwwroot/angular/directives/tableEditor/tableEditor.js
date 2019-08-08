cassandraWeb.directive('tableEditor', function () {
    return {
        restrict: 'E',
        templateUrl: '/angular/directives/tableEditor/tableEditor.html',
        scope: {
            columns: '=columns',
            deleteClick: '&deleteClick',
            addClick: '&addClick'
        },        
        link: function($scope, elm, attrs) {
            $scope.newColumn = {};
            $scope.clearNewColumn = function () {
                $scope.newColumn = {
                    columnName: '',
                    dataType: ''
                };
            };
            $scope.fAddClick = function (newColumn) {
                $scope.addClick({newColumn: newColumn});
                $scope.clearNewColumn();
            };
            $scope.fDeleteClick = function (columnName) {
                $scope.deleteClick({columnName: columnName});
            };
            $scope.clearNewColumn();
        }
    };
});