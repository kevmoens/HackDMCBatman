
var assert = require('assert');
var mongodb = require('mongodb');
var express = require('express');
var mongoose = require('mongoose');
var bodyParser = require('body-parser');

var collectionName='test';
var host='127.0.0.1';
var mongoPort=27017;

var url = 'mongodb://localhost/test';

mongoose.connect(url);

var ValidationError = mongoose.Error.ValidationError;

var app = express();

//Enable CORS
app.all("/data*", function(req, res, next) {
  res.header("Access-Control-Allow-Origin", "*");
  res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
  next();
});

app.use(bodyParser.json());

app.use(bodyParser.urlencoded({
  extended: true
}));


var port = process.env.PORT || 9000;        // set our port

// Register routes
app.use('/data', require('./app/routes'));

// Start Server
app.listen(port);
console.log('Listening on ' + port);
