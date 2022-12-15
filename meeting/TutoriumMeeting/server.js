// server.js
// where your node app starts

// we've started you off with Express (https://expressjs.com/)
// but feel free to use whatever libraries or frameworks you'd like through `package.json`.
const express = require("express");

const { ExpressPeerServer } = require("peer");

const app = express();

const PORT = 3000;

// make all the files in 'public' available
// https://expressjs.com/en/starter/static-files.html
app.use('/scripts', express.static(__dirname + '/node_modules'));
app.use(express.static(__dirname + '/src'));
app.use('/public', express.static(__dirname + '/public'));
//app.use(express.static("src"));


// https://expressjs.com/en/starter/basic-routing.html
app.get("/", (request, response) => {
  response.sendFile(__dirname + "/public/index.html");
});

// listen for requests :)
const listener = app.listen(PORT, () => {
  console.log("Your app is listening on port " + listener.address().port);
});

// peerjs server
const peerServer = ExpressPeerServer(listener, {
  debug: true,
  path: '/myapp'
});

app.use('/peerjs', peerServer);



// Whiteboard Part



