personApp.filter('searchFor',function(){
	return function(arr, searchString){
		if(!searchString){
			return arr;
		}

		var result = [];
		searchString = searchString.toLowerCase();
		angular.forEach(arr, function(person){
			firstAndLast = person.firstName + " " + person.lastName;
			lastAndFirst = person.lastName + " "+ person.firstName;
			if(firstAndLast.toLowerCase().indexOf(searchString) !== -1 || lastAndFirst.toLowerCase().indexOf(searchString) !== -1){
				result.push(person);
			}
		});
		return result;
	};
});