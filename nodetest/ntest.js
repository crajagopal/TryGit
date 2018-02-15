var http = require('http');
var dt = require('./datemodule');
var url = require('url');
var fs = require('fs');
var uc= require('upper-case');

http.createServer(function(req, res){
   
    res.writeHead(200, {'Content-Type': 'text/html'});
    res.write(req.url);
    res.write('<br/>');
    res.write(uc('Hello world! Current Time: ') 
    + dt.myDateTime() );
    var q = url.parse(req.url, true).query;
    var txt = q.year + " " + q.month;
    res.write('<br/>');
    res.end(txt);
}).listen(8080);