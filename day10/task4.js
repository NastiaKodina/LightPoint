function reverseArrayInPlace(arr){
	arr.sort(function(){
		return 1;
	});
};

function reverseArray(arr){
	var newArr=[];
	for(var i=arr.length-1; i>=0; i--){
		newArr.push(arr[i]);
	}
	return newArr;
};

// быстрее работает reverseArray

function getRandomInt(min, max){
  return Math.floor(Math.random() * (max - min + 1)) + min;
}

function a(arr){	
	console.log(Date());
	reverseArrayInPlace(arr);
	console.log(Date());
};

function b(arr,newArr){
	console.log(Date());
	newArr = reverseArray(arr);
	console.log(Date());
};


var arr = [];
for (var i=0;i<10000;i++){
	arr[i]=getRandomInt(1,50);
}

a(arr);
var newArr = [];
b(arr,newArr);



