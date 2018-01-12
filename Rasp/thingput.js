function doStuff() {
// Thingworx REST GET example with node.js using node-rest-client library
var sensor = require('node-dht-sensor');
// lämpötila url
var url = 'https://aca-karelia01.elisaiot.com/Thingworx/Things/LTTNS15_G3_ToinenThing/Properties/numero';
// kosteus url
var urli = 'https://aca-karelia01.elisaiot.com/Thingworx/Things/LTTNS15_G3_ToinenThing/Properties/Log';

// console.log('Put value {FloatProperty:10.3} to Thingworx Thing property url = ' + url);

var Client = require('node-rest-client').Client;
sensor.read(22, 4, function(err, temperature, humidity){
        if(!err) {
		var muut = temperature.toFixed(1);
                console.log('temp: ' + temperature.toFixed(1) + 'C, ' + 'humidity: ' +   humidity.toFixed(1) + '%'
);
}
//});
//var muut = temperature.toFixed(1);
// configure basic http auth for every request
var options_auth={
	user:"un",
	password:"pw"
};

client = new Client(options_auth);
args ={
	headers:{"Content-Type":"application/json"},	// request headers
	data:{"numero":muut},					// set the property value
	requestConfig:{

		timeout:1000, 								//request timeout in milliseconds 
		keepAlive:false, 							//Enable/disable keep-alive functionalityidle socket. 
	}

};

argsit ={
	headers:{"Content-Type":"application/json"},	// request headers
	data:{"Log":humidity.toFixed(1)},					// set the property value
	requestConfig:{

		timeout:1000, 								//request timeout in milliseconds 
		keepAlive:false, 							//Enable/disable keep-alive functionalityidle socket. 
	}

};


client.put(url, args, function(data, response){
	// parsed response body as js object
	console.log("sent. Received: " + response + "\n");
			
}).on('error',function(err){
	console.log('something went wrong on the request', err.request.options);
});
client.put(urli, argsit, function(data, response){
	// parsed response body as js object
	console.log("sent. Received: " + response + "\n");
			
}).on('error',function(err){
	console.log('something went wrong on the request', err.request.options);
});
});
};
function run() {
  setInterval(doStuff, 10000);
};

run();