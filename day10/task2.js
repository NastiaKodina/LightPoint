Array.prototype.each = function(callback){
    for(var i = 0; i < this.length; i++) {
        callback.call(this[i])
    }
};

 var a = [13, 32, 43,12];
  
  a.each(function() {
    console.log(this)
  });