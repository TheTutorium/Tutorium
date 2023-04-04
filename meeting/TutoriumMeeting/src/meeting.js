//const fmin = require('./fmin');

//const LeastSquares = require("least-squares");

const maxPointForBezierCurve = 100;


//Whiteboard Initialization
const app = new PIXI.Application({
    antialias: true,
    background: "#1099bb",
    width: 400,
    height: 300,
});

window.addEventListener("resize", () => {
    app.resize(window.width * 2, window.height * 2);
});

const stage = new PIXI.Container();

app.stage.addChild(stage);

const container = document.querySelector(".white-board");

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

/* End of whiteboard Initialization */

let Peer = window.Peer;

let messagesEl = document.querySelector(".messages");
let peerIdEl = document.querySelector("#connect-to-peer");
let videoEl = document.querySelector(".remote-video");
let currentCall = null;

let logMessage = (message) => {
    let newMessage = document.createElement("div");
    newMessage.innerText = message;
    messagesEl.appendChild(newMessage);
};

let renderVideo = (stream) => {
    videoEl.srcObject = stream;
};

// Register with the peer server
let peer = new Peer({
    host: "/",
    port: 3000,
    path: "/peerjs/myapp",
});

let otherPeer = null;

let connectionInitiated = false;

peer.on("open", (id) => {
    logMessage("My peer ID is: " + id);
});
peer.on("error", (error) => {
    console.error(error);
});

// Handle incoming data connection
peer.on("connection", (conn) => {
    otherPeer = conn;
    conn.on("data", (data) => {
        if (!connectionInitiated) {
            connectionInitiated = true;
        } else {
            let splittedMessage = data.split("|");
            let initX = parseFloat(splittedMessage[0]);
            let initY = parseFloat(splittedMessage[1]);
            let finalX = parseFloat(splittedMessage[2]);
            let finalY = parseFloat(splittedMessage[3]);
            currentZIndex = parseFloat(splittedMessage[5]);

            sprite = new PIXI.Graphics();
            if (parseFloat(splittedMessage[4]) == 0) {
                sprite.lineStyle(2, 0xff0000, 1);
            } else if (parseFloat(splittedMessage[4]) == 1) {
                sprite.lineStyle(10, 0x1099bb, 1);
            }
            sprite.zIndex = currentZIndex;
            sprite.moveTo(initX, initY);
            sprite.lineTo(finalX, finalY);

            stage.addChild(sprite);
        }
    });
    conn.on("open", () => {
        conn.send("hello!");
    });
});

// Handle incoming voice/video connection
peer.on("call", (call) => {
    currentCall = call;
    navigator.mediaDevices
        .getUserMedia({ video: true, audio: true })
        .then((stream) => {
            call.answer(stream); // Answer the call with an A/V stream.
            call.on("stream", renderVideo);
        })
        .catch((err) => {
            console.error("Failed to get local stream", err);
        });
    navigator.mediaDevices
        .getUserMedia({ video: true, audio: false })
        .then((stream) => {
            document.getElementById("local-video").srcObject = stream;
        })
        .catch((err) => {
            console.error(err);
        });
});

// Initiate outgoing connection
let connectToPeer = () => {
    let peerId = peerIdEl.value;

    let conn = peer.connect(peerId);
    otherPeer = conn;
    conn.on("data", (data) => {
        if (!connectionInitiated) {
            connectionInitiated = true;
        } else {
            let splittedMessage = data.split("|");
            let initX = parseFloat(splittedMessage[0]);
            let initY = parseFloat(splittedMessage[1]);
            let finalX = parseFloat(splittedMessage[2]);
            let finalY = parseFloat(splittedMessage[3]);
            currentZIndex = parseFloat(splittedMessage[5]);

            sprite = new PIXI.Graphics();
            if (parseFloat(splittedMessage[4]) == 0) {
                sprite.lineStyle(2, 0xff0000, 1);
            } else if (parseFloat(splittedMessage[4]) == 1) {
                sprite.lineStyle(10, 0x1099bb, 1);
            }
            sprite.zIndex = currentZIndex;
            sprite.moveTo(initX, initY);
            sprite.lineTo(finalX, finalY);

            stage.addChild(sprite);
        }
    });

    /*navigator.mediaDevices
        .getUserMedia({
            video: {
                mediaSource: "screen",
            },
        })
        .then((stream) => {
            // Use the stream in your PeerJS connection
            conn.addStream(stream);
        });*/
    navigator.mediaDevices
        .getUserMedia({ video: true, audio: false })
        .then((stream) => {
            document.getElementById("local-video").srcObject = stream;
        })
        .catch((err) => {
            console.error(err);
        });

    conn.on("open", () => {
        conn.send("hi!");
    });

    navigator.mediaDevices
        .getUserMedia({ video: true, audio: true })
        .then((stream) => {
            let call = peer.call(peerId, stream);
            currentCall = call;
            call.on("stream", renderVideo);
        })
        .catch((err) => {
            logMessage("Failed to get local stream", err);
        });
};

// Close the connection for both peers
let disconnectFromPeer = () => {
    logMessage("Disconnecting from peer");
    currentCall.close();
    peer.disconnect();
};

window.connectToPeer = connectToPeer;
window.disconnectFromPeer = disconnectFromPeer;

/*navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia;

navigator.mediaDevices.getUserMedia(
    { video: true, audio: false },
    function (stream) {
        // Set the source of the video element to the stream
        
    },
    function (err) {
        console.error(err);
    }
);*/

// Whiteboard Part

let currentZIndex = 0;
let currentPenType = 0;

const changePenType = (type) => {
    currentPenType = type;
    currentZIndex++;
    console.log(currentPenType);
    console.log(currentZIndex);
};

window.changePenType = changePenType;

const getMousePos = (event) => {
    const pos = { x: 0, y: 0 };
    if (container) {
        // Get the position and size of the component on the page.
        const holderOffset = app.view.getBoundingClientRect();
        pos.x = event.pageX - holderOffset.x;
        pos.y = event.pageY - holderOffset.y;
    }
    return pos;
};

var currentPoints = [];
let pointCount = 0;
let curve;

const onMouseMove = (e) => {
    if (!isMouseButtonDown) {
        return;
    }

    // clearSpriteRef(annoRef)
    if (initPointer == null) return;

    const curMousePosRef = getMousePos(e);
    curDistance -= Math.abs(curMousePosRef.x - mousePosRef.x) + Math.abs(curMousePosRef.y - mousePosRef.y);

    if (curDistance > 0) {
        sprite.clear();
        if (currentPenType === 0) {
            sprite.lineStyle(2, 0xff0000, 1);
        } else if (currentPenType === 1) {
            sprite.lineStyle(10, 0x1099bb, 1);
        }
        sprite.zIndex = currentZIndex;
        sprite.moveTo(initPointer.x, initPointer.y);

        mousePosRef = curMousePosRef;
        sprite.lineTo(mousePosRef.x, mousePosRef.y);
    } else {
        curDistance = putDistance;
        sprite = new PIXI.Graphics();
        if (currentPenType === 0) {
            sprite.lineStyle(2, 0xff0000, 1);
        } else if (currentPenType === 1) {
            sprite.lineStyle(10, 0x1099bb, 1);
        }
        sprite.moveTo(initPointer.x, initPointer.y);
        sprite.zIndex = currentZIndex;
        mousePosRef = curMousePosRef;
        otherPeer.send(
            initPointer.x +
                "|" +
                initPointer.y +
                "|" +
                mousePosRef.x +
                "|" +
                mousePosRef.y +
                "|" +
                currentPenType +
                "|" +
                currentZIndex
        );

        currentPoints.push(initPointer);
        pointCount += 1;

        if(pointCount >= maxPointForBezierCurve){
            //map to bezier curve
            curve = findBestFitCurve(currentPoints);

            //-------------------
            currentPoints = [initPointer];
            pointCount = 1;
        }

        initPointer = curMousePosRef;
        sprite.lineTo(mousePosRef.x, mousePosRef.y);
        stage.addChild(sprite);
    }
};

const onMouseDown = (e) => {
    mousePosRef = getMousePos(e);
    initPointer = mousePosRef;

    sprite = new PIXI.Graphics();
    if (currentPenType === 0) {
        sprite.lineStyle(2, 0xff0000, 1);
    } else if (currentPenType === 1) {
        sprite.lineStyle(10, 0x1099bb, 1);
    }
    sprite.moveTo(initPointer.x, initPointer.y);
    sprite.lineTo(mousePosRef.x, mousePosRef.y);

    stage.addChild(sprite);

    isMouseButtonDown = true;

    console.log(mousePosRef);
};
const onMouseUp = (e) => {
    otherPeer.send(
        initPointer.x +
            "|" +
            initPointer.y +
            "|" +
            getMousePos(e).x +
            "|" +
            getMousePos(e).y +
            "|" +
            currentPenType +
            "|" +
            currentZIndex
    );
    isMouseButtonDown = false;

    if(pointCount > 0){
        //map to bezier curve

        //------------------
        pointCount = 0;
        currentPoints = [];
    }
};


//Bezier Curve Functions

function cubicBezier(p0, p1, p2, p3, t) {
    const cx = 3 * (p1.x - p0.x);
    const cy = 3 * (p1.y - p0.y);
    const bx = 3 * (p2.x - p1.x) - cx;
    const by = 3 * (p2.y - p1.y) - cy;
    const ax = p3.x - p0.x - cx - bx;
    const ay = p3.y - p0.y - cy - by;
    const x = ax * t * t * t + bx * t * t + cx * t + p0.x;
    const y = ay * t * t * t + by * t * t + cy * t + p0.y;
    return { x, y };
  }
  
  function distance(point, curve) {
    let minDist = Infinity;
    for (let i = 0; i < 100; i++) { // divide the curve into 100 segments
      const t = i / 100;
      const curvePoint = cubicBezier(curve[0], curve[1], curve[2], curve[3], t);
      const dist = Math.sqrt((point.x - curvePoint.x) ** 2 + (point.y - curvePoint.y) ** 2);
      if (dist < minDist) {
        minDist = dist;
      }
    }
    return minDist;
  }
  
  function totalDistance(points, curve) {
    let totalDist = 0;
    for (const point of points) {
      const dist = distance(point, curve);
      totalDist += dist;
    }
    return totalDist;
  }
  
  function minimizeLoss(points){
    let P0 = points[0];
    let P3 = points[points.length - 1];
    let X = [];
    let Yx = [];
    let Yy = [];
    let delta = 1 / points.length;
    let t = delta;
    for (let i = 1; i < points.length - 1; i++){
        X.push(t/(1-t));
        Yx.push(points[1].x - (1-t) * (1-t) * (1-t) * P0.x - t * t * t * P3.x);
        Yy.push(points[1].y - (1-t) * (1-t) * (1-t) * P0.y - t * t * t * P3.y);
        t+=delta;
    }

    let Xlsq = {};
    let Ylsq = {};

    lsq(X,Yx, true, Xlsq);
    lsq(X, Yy, true, Ylsq);

    return [Xlsq, Ylsq];
  }

  function findBestFitCurve(points) {
    const result = minimizeLoss(points);
    console.log(result);
    return result.solution;
  }

  //End of Bezier Curve Functions

container.addEventListener("mousemove", onMouseMove, 0);

container.addEventListener("mousedown", onMouseDown, 0);

container.addEventListener("mouseup", onMouseUp, 0);

/********************** */

sprite = new PIXI.Graphics();
sprite.lineStyle(2, 0xff0000, 1);
sprite.moveTo(200, 150);
sprite.bezierCurveTo(200, 50, 300, 150, 100, 100);
stage.addChild(sprite);

/********************** */
