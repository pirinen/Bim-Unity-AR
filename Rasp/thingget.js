// Thingworx REST API GET method example using node-rest-client example

// thing property URI example
var url = 'https://aca-karelia01.elisaiot.com/Thingworx/Things/LTTNS15_G3_ToinenThing/Properties/LED';

// console.log('Get value from Thingworx Thing property url = ' + url);
var Gpio = require('onoff').Gpio;
var led = new Gpio(26, 'out');
var Client = require('node-rest-client').Client;
function doStuff() {
// configure basic http auth for every request
var options_auth={
	user:"un",
	password:"pw"
};

client = new Client(options_auth);

args ={
	headers:{"Accept":"application/json"} // request headers
};

client.get(url, args, function(data, response){
	// parsed response body as js object
//	console.log(data);

	if (data.dataShape.fieldDefinitions.LED.baseType == "BOOLEAN") {
		floatValue = data.rows[0].LED;
		if (floatValue == true){
			led.writeSync(1);
		} else {
			led.writeSync(0);
		}
console.log('led: ', floatValue);
	} else {
		console.log('Could not get FloatProperty');
	}
}).on('error',function(err){
	console.log('something went wrong on the request', err.request.options);
});
};
function run(){
	setInterval(doStuff, 10000);
};
run();
