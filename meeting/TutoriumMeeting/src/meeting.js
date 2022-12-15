
let Peer = window.Peer;



let messagesEl = document.querySelector('.messages');
let peerIdEl = document.querySelector('#connect-to-peer');
let videoEl = document.querySelector('.remote-video');
let currentCall = null;

let logMessage = (message) => {
  let newMessage = document.createElement('div');
  newMessage.innerText = message;
  messagesEl.appendChild(newMessage);
};

let renderVideo = (stream) => {
  videoEl.srcObject = stream;
};

// Register with the peer server
let peer = new Peer({
  host: '/',
  port: 3000,
  path: '/peerjs/myapp'
});

peer.on('open', (id) => {
  logMessage('My peer ID is: ' + id);
});
peer.on('error', (error) => {
  console.error(error);
});

// Handle incoming data connection
peer.on('connection', (conn) => {
  logMessage('incoming peer connection!');
  conn.on('data', (data) => {
    logMessage(`received: ${data}`);
  });
  conn.on('open', () => {
    conn.send('hello!');
  });
});

// Handle incoming voice/video connection
peer.on('call', (call) => {
  currentCall = call;
  navigator.mediaDevices.getUserMedia({video: true, audio: true})
    .then((stream) => {
      call.answer(stream); // Answer the call with an A/V stream.
      call.on('stream', renderVideo);
    })
    .catch((err) => {
      console.error('Failed to get local stream', err);
    });
});


// Initiate outgoing connection
let connectToPeer = () => {
  let peerId = peerIdEl.value;
  logMessage(`Connecting to ${peerId}...`);
  
  let conn = peer.connect(peerId);
  conn.on('data', (data) => {
    logMessage(`received: ${data}`);
  });
  conn.on('open', () => {
    conn.send('hi!');
  });
  
  navigator.mediaDevices.getUserMedia({video: true, audio: true})
    .then((stream) => {
      let call = peer.call(peerId, stream);
      currentCall = call;
      call.on('stream', renderVideo);
    })
    .catch((err) => {
      logMessage('Failed to get local stream', err);
    });
};

// Close the connection for both peers
let disconnectFromPeer = () => {
  logMessage('Disconnecting from peer');
  currentCall.close();
  peer.disconnect();
};

window.connectToPeer = connectToPeer;
window.disconnectFromPeer = disconnectFromPeer;


// Whiteboard Part


const app = new PIXI.Application({
    antialias: true,
    background: '#1099bb',
});


const stage = new PIXI.Container();

app.stage.addChild(stage);

const container = document.querySelector('.white-board');

container.appendChild(app.view);

/*const whiteboard = new PIXI.Graphics();
whiteboard.beginFill(0xffffff);
whiteboard.drawRect(0, 0, 800, 600);
whiteboard.endFill();
stage.addChild(whiteboard);*/

var sprite = new PIXI.Graphics();

let initPointer = null;

let isMouseButtonDown = false;

const putDistance = 1;
var curDistance = 1;

var mousePosRef;

const getMousePos = (event) => {
    const pos = { x: 0, y: 0 };
    if (container) {
      // Get the position and size of the component on the page.
      const holderOffset = container.getBoundingClientRect();
      pos.x = event.pageX - holderOffset.x;
      pos.y = event.pageY - holderOffset.y;
    }
    return pos;
  };

  const onMouseMove = (e) => {
    if (!isMouseButtonDown) {
      return;
    }
    
    // clearSpriteRef(annoRef)
    if (initPointer == null) return;
  
    const curMousePosRef = getMousePos(e);
    curDistance-= (Math.abs(curMousePosRef.x - mousePosRef.x) + Math.abs(curMousePosRef.y - mousePosRef.y));

    console.log(curDistance);

    if(curDistance>0){
        sprite.clear();
        sprite.lineStyle(2, 0xff0000, 1);
        sprite.moveTo(initPointer.x, initPointer.y);
    
        mousePosRef = curMousePosRef;
        sprite.lineTo(mousePosRef.x, mousePosRef.y);
    }else{
        curDistance = putDistance;
        sprite = new PIXI.Graphics();
        sprite.lineStyle(2, 0xff0000, 1);
        sprite.moveTo(initPointer.x, initPointer.y);
        mousePosRef = curMousePosRef;
        initPointer = curMousePosRef;
        sprite.lineTo(mousePosRef.x, mousePosRef.y);
        stage.addChild(sprite); 
    }
    
    
  };

  const onMouseDown = (e) => {
    mousePosRef = getMousePos(e);
    initPointer = mousePosRef;
  
    sprite = new PIXI.Graphics();
    sprite.lineStyle(2, 0xff0000, 1);
    sprite.moveTo(initPointer.x, initPointer.y);
    sprite.lineTo(mousePosRef.x, mousePosRef.y);
  
    stage.addChild(sprite);
    
    isMouseButtonDown = true;

    console.log(mousePosRef);
  };
  const onMouseUp = (e) => {
    isMouseButtonDown = false;
  };
  
  container
    .addEventListener("mousemove", onMouseMove, 0);
  
  container
    .addEventListener("mousedown", onMouseDown, 0);
  
  container
    .addEventListener("mouseup", onMouseUp, 0);
