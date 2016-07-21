  shop = (function() {
    var initialization = [{name:'table',description:'Something', price:200,count:7},
                 {name:'lamp',description:'Something', price:10,count:6},
                 {name:'pencil',description:'Something', price:2,count:15},
                 {name:'sofa',description:'Something', price:500,count:1},
                 {name:'pillow',description:'Something', price:50,count:8}]; 
    var basket = [];

    /*if (localStorage.length == 0) {
        fromArrayToLocalStorage(initialization);
    }*/

    function fromArrayToLocalStorage(arr){
        localStorage.clear();
        for (var i = 0; i < arr.length; i++) {                
            var item = JSON.stringify({name: arr[i].name, 
                                        description: arr[i].description,
                                        price: arr[i].price,
                                        count: arr[i].count});
            localStorage.setItem(i, item);
        }

    };

    function fromLocalStorageToArray(){
        for(var item in localStorage){
            var name = JSON.parse(localStorage.getItem(item)).name;
            var description = JSON.parse(localStorage.getItem(item)).description;
            var price =JSON.parse(localStorage.getItem(item)).price;
            var count =JSON.parse(localStorage.getItem(item)).count;
            var product = {name: name, description: description, price: price, count: count};
            basket.push(product);
        }

    };

    function editItemFunction(id,item){
         basket[id].name = item.name;
         basket[id].description = item.description;
         basket[id].price = item.price;
         basket[id].count = item.count;
         fromArrayToLocalStorage(basket);
    };

    function getItemFunction(id){
        return basket[id];
    };

    function getItemsFunction(){
        fromLocalStorageToArray();
        return basket;
    };

    function addItemFunction(item){
        basket.push(item);
        fromArrayToLocalStorage(basket);
    };
    function  getItemCountFunction() {
        return basket.length;
    };
    function deleteItemFunction(id) {
        basket.splice(id,1);
        fromArrayToLocalStorage(basket);
    };

    function getTotalItemsCountFunction() {
        var itemCount = this.getItemCount(),totalCount=0;
        while(itemCount--){
            totalCount+= basket[itemCount].count; 
        }
        return totalCount;
    };
    function sortByAlphabetAndItemNameFunction(){
        fromLocalStorageToArray();
        basket.sort(function(obj1, obj2) {
                        if (obj1.name < obj2.name) return -1;
                        if (obj1.name > obj2.name) return 1;
                        return 0;});
    };
    function sortByPriceFuction(){
        fromLocalStorageToArray();
        basket.sort(function(obj1, obj2) {
            return obj1.price-obj2.price;});
    };


    return { 
        getItems: getItemsFunction,
        addItem: addItemFunction,
        editItem: editItemFunction,
        getItem: getItemFunction,
        getItemCount: getItemCountFunction,
        deleteItem: deleteItemFunction,
        getTotalItemsCount: getTotalItemsCountFunction,
        sortByAlphabetAndItemName: sortByAlphabetAndItemNameFunction, 
        sortByPrice: sortByPriceFuction
    }
}());



