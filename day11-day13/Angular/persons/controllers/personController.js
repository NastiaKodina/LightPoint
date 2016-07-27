personApp.controller("personController", function ($scope,PersonService,$modal,$alert,$http) {

    $scope.sortType     = 'lastName';
    $scope.sortReverse  = false;

    var promise = PersonService.getPersons();
    promise.then(function (resolve) {
        $scope.list = resolve;
    });

    var sucessAlert = $alert({ content: 'Update was successful!', container: '#divForAlert', placement: 'top', type: 'success', show: false });
    $scope.activePhone='home';

    $scope.deletePerson = function(person){
    	$scope.list.splice( $scope.list.indexOf(person), 1 );
       sucessAlert.show();

    };

    $scope.editPerson = function(){
      $scope.list[$scope.list.indexOf($scope.personToEdit)]=$scope.editedPerson;
      sucessAlert.show();
    };

    $scope.addPerson = function(person){
      person.phoneNumber[0].type = 'home';
      person.phoneNumber[1].type = 'fax';
      $scope.list.push(person);
      sucessAlert.show();
    };

    $scope.showDeletePopUp = function (person){
      $scope.personToDelete = person;
      $modal({ scope: $scope, template: './persons/templates/deleteModalPopUp.html', show: true });
    };

    $scope.showEditPopUp = function (person){
      $scope.personToEdit = person;
      $scope.editedPerson = angular.copy(person);
      $modal({ scope: $scope, template: './persons/templates/editModalPopUp.html', show: true });
    };

    $scope.showAddPopUp = function (){
      $scope.personToAdd = {};
      $modal({ scope: $scope, template: './persons/templates/addModalPopUp.html', show: true });
    };




});