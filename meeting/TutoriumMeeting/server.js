// server.js
// where your node app starts

// we've started you off with Express (https://expressjs.com/)
// but feel free to use whatever libraries or frameworks you'd like through `package.json`.
var fs = require("fs");
var https = require("https");
var http = require("http");
var privateKey = fs.readFileSync("key.pem", "utf8");
var certificate = fs.readFileSync("cert.pem", "utf8");

var credentials = { key: privateKey, cert: certificate };

const express = require("express");

const { ExpressPeerServer } = require("peer");

const app = express();

const PORT = 3000;

// make all the files in 'public' available
// https://expressjs.com/en/starter/static-files.html
app.use("/scripts", express.static(__dirname + "/node_modules"));
app.use(express.static(__dirname + "/src"));
app.use("/public", express.static(__dirname + "/public"));
//app.use(express.static("src"));

// https://expressjs.com/en/starter/basic-routing.html
app.get("/", (request, response) => {
    response.sendFile(__dirname + "/public/index.html");
});

var server = https.createServer(credentials, app);
//server = http.createServer(app);

app.use(function (req, res, next) {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
});

// listen for requests :)
const listener = server.listen(PORT, () => {
    console.log("Your app is listening on port " + listener.address().port);
});

// peerjs server
const peerServer = ExpressPeerServer(listener, {
    debug: true,
    path: "/myapp",
});

app.use("/peerjs", peerServer);
