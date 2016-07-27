personApp.factory('PersonService', function ($http, $q) {

    return {
        getPersons: function () {
            var deferred = $q.defer();
            $http.get('resourses/persons.json').success(function (response) {
                deferred.resolve(response);
            });
            return deferred.promise;
        }
    }
});