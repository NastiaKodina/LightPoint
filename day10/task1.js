	function iterator(){
		var numberOfCalls=0;
		var myArguments = arguments;
		return {
			next: function(){
					if (numberOfCalls==myArguments.length) {
						return "That is all!";
					}else{
						return myArguments[numberOfCalls++];
					}
			}
		}
	}

	var it = iterator();
	it.next();
	it.next();