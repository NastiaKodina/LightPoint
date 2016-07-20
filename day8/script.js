var basketModule = (function() {
    var basket = [{item:'table', price:200,count:7},
                 {item:'lamp', price:10,count:6},
                 {item:'pencil', price:2,count:15},
                 {item:'sofa', price:500,count:1},
                 {item:'pillow', price:50,count:8}]; 
    return { 
        addItem: function(values) {
            basket.push(values);
        },
        getItemCount: function() {
            return basket.length;
        },
        deleteItem: function(id) {
            basket.splice(id,1);
        },
        getTotalItemsCount: function() {
           var itemCount = this.getItemCount(),totalCount=0;
            while(itemCount--){
                totalCount+= basket[itemCount].count; 
            }
            return totalCount;
        },
        sortByAlphabetAndItemName: function(){
            basket.sort(function(obj1, obj2) {
                            if (obj1.item < obj2.item) return -1;
                            if (obj1.item > obj2.item) return 1;
                             return 0;});
        }, 
        sortByPrice: function(){
            basket.sort(function(obj1, obj2) {
                return obj1.price-obj2.price;});
        }
    }
}());



