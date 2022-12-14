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

    navigator.mediaDevices
        .getUserMedia({
            video: {
                mediaSource: "screen",
            },
        })
        .then((stream) => {
            // Use the stream in your PeerJS connection
            conn.addStream(stream);
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

navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia;

navigator.getUserMedia(
    { video: true, audio: false },
    function (stream) {
        // Set the source of the video element to the stream
        document.getElementById("local-video").srcObject = stream;
    },
    function (err) {
        console.error(err);
    }
);

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
};

container.addEventListener("mousemove", onMouseMove, 0);

container.addEventListener("mousedown", onMouseDown, 0);

container.addEventListener("mouseup", onMouseUp, 0);
