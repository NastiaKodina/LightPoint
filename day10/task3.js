var Observer = function() {
    this.subscribers = [];
}
 
Observer.prototype = {
    subscribe: function(callback) {
        this.subscribers.push(callback);
    },
    unsubscribe: function(callback) {
        var len = this.subscribers.length;
        for (var i=0; i < len; i++) {
            if (this.subscribers[i] === callback) {
                this.subscribers.splice(i, 1);
                return;
            }
        }
    },
    publish: function(data) {
        var len = this.subscribers.length;
        for (var i=0; i < len; i++) {
            this.subscribers[i](data);
        }        
    }
};
 
var observer = function (data) {
    console.log(data);
}
 
var observable = new Observer();
observable.subscribe(observer);
observable.publish('Опубликовано!');