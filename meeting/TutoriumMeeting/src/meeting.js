//const fmin = require('./fmin');

//const LeastSquares = require("least-squares");

const maxPointForBezierCurve = 50;

const CHECK_STEPS = 5;

const MAX_BERR = 3;
const MAX_MERR = 1;

var pen_size = 2;
var pen_color = "0x000000";
var eraser_size = 10;
var text_size = 14;
var text_color = "0x000000";

var writing_on_board = false;

var textStyle = new PIXI.TextStyle({
    fontFamily: "Arial",
    fontSize: text_size,
    fill: text_color,
});

var p_text = new PIXI.Text("Hello, world!", textStyle);

const penSizeInput = document.getElementById("pen-size");

// listen for changes to the pen size input
penSizeInput.addEventListener("input", () => {
  // get the new pen size value
  pen_size = parseInt(penSizeInput.value);
  
});

const eraserSizeInput = document.getElementById("eraser-size");

// listen for changes to the pen size input
eraserSizeInput.addEventListener("input", () => {
  // get the new pen size value
  eraser_size = parseInt(eraserSizeInput.value);
  
});

// get the pen color select element
const penColorSelect = document.getElementById("pen-color");

// listen for changes to the pen color select
penColorSelect.addEventListener("change", () => {
  // get the new pen color value
  pen_color = parseInt(penColorSelect.value);
  
});

// get references to the pen-size input and the "Sample Text" element
const textSizeInput = document.getElementById("text-size");
const sampleTextPointer = document.getElementById("sample-text");
const textColorSelect = document.getElementById("text-color");

// add an event listener to the pen-size input
textSizeInput.addEventListener("input", () => {
  // update the text of the "Sample Text" element
  sampleTextPointer.textContent = "Sample Text";
  
  // update the font size of the "Sample Text" element based on the value of the pen-size input
  const fontSize = `calc(${textSizeInput.value}px + (16px - ${textSizeInput.min}px) * (${textSizeInput.value} / (${textSizeInput.max} - ${textSizeInput.min})))`;
  sampleTextPointer.style.fontSize = fontSize;

    text_size = textSizeInput.value;
    console.log(text_size);

  textStyle = new PIXI.TextStyle({
        fontFamily: "Arial",
        fontSize: text_size,
        fill: text_color,
    });
});

textColorSelect.addEventListener("change", () => {
    // get the selected option value
    const fontColor = textColorSelect.value;
    
    // update the color of the "Sample Text" element
    sampleTextPointer.style.color = fontColor;

    text_color = fontColor;

    textStyle = new PIXI.TextStyle({
        fontFamily: "Arial",
        fontSize: text_size,
        fill: text_color,
    });
  });

//Whiteboard Initialization
const app = new PIXI.Application({
    antialias: true,
    background: "#ffffff",
    width: window.innerWidth * 0.4,
    height: window.innerHeight * 0.5,
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

            let tempPenType = parseInt(splittedMessage[0]);
            currentZIndex = parseInt(splittedMessage[1]);

            if(tempPenType === 0){ // Pen
                let initX = parseFloat(splittedMessage[2]);
                let initY = parseFloat(splittedMessage[3]);
                let control1x = parseFloat(splittedMessage[4]);
                let control1y = parseFloat(splittedMessage[5]);
                let control2x = parseFloat(splittedMessage[6]);
                let control2y = parseFloat(splittedMessage[7]);
                let finalX = parseFloat(splittedMessage[8]);
                let finalY = parseFloat(splittedMessage[9]);
                let tempPenSize = parseInt(splittedMessage[10]);
                let tempPenColor = parseInt(splittedMessage[11]);

                let tempSprite = new PIXI.Graphics();

                tempSprite.lineStyle(tempPenSize, tempPenColor, 1);

                tempSprite.zIndex = currentZIndex;
                tempSprite.moveTo(initX, initY);
                tempSprite.bezierCurveTo(control1x, control1y, control2x, control2y, finalX, finalY);
    
                stage.addChild(tempSprite);
            }else if(tempPenType === 1){ // Eraser
                let initX = parseFloat(splittedMessage[2]);
                let initY = parseFloat(splittedMessage[3]);
                let control1x = parseFloat(splittedMessage[4]);
                let control1y = parseFloat(splittedMessage[5]);
                let control2x = parseFloat(splittedMessage[6]);
                let control2y = parseFloat(splittedMessage[7]);
                let finalX = parseFloat(splittedMessage[8]);
                let finalY = parseFloat(splittedMessage[9]);
                let tempEraserSize = parseInt(splittedMessage[10]);

                let tempSprite = new PIXI.Graphics();

                sprite.lineStyle(tempEraserSize, 0xffffff, 1);

                tempSprite.zIndex = currentZIndex;
                tempSprite.moveTo(initX, initY);
                tempSprite.bezierCurveTo(control1x, control1y, control2x, control2y, finalX, finalY);
    
                stage.addChild(tempSprite);
            }else if(tempPenType === 2){ // Typing
                let tempTextSize = parseInt(splittedMessage[2]);
                let tempTextColor = parseInt(splittedMessage[3]);
                let tempText = splittedMessage[4];
                let tempX = parseFloat(splittedMessage[5]);
                let tempY = parseFloat(splittedMessage[6]);
                
                let tempStyle = new PIXI.TextStyle({
                    fontFamily: "Arial",
                    fontSize: tempTextSize,
                    fill: tempTextColor,
                });

                let tempPText = PIXI.Text(tempText, tempStyle);
                tempPText.zIndex = currentZIndex;
                tempPText.moveTo(tempX, tempY);

                stage.addChild(tempPText);
            }

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

            let tempPenType = parseInt(splittedMessage[0]);
            currentZIndex = parseInt(splittedMessage[1]);

            if(tempPenType === 0){ // Pen
                let initX = parseFloat(splittedMessage[2]);
                let initY = parseFloat(splittedMessage[3]);
                let control1x = parseFloat(splittedMessage[4]);
                let control1y = parseFloat(splittedMessage[5]);
                let control2x = parseFloat(splittedMessage[6]);
                let control2y = parseFloat(splittedMessage[7]);
                let finalX = parseFloat(splittedMessage[8]);
                let finalY = parseFloat(splittedMessage[9]);
                let tempPenSize = parseInt(splittedMessage[10]);
                let tempPenColor = parseInt(splittedMessage[11]);

                let tempSprite = new PIXI.Graphics();

                tempSprite.lineStyle(tempPenSize, tempPenColor, 1);

                tempSprite.zIndex = currentZIndex;
                tempSprite.moveTo(initX, initY);
                tempSprite.bezierCurveTo(control1x, control1y, control2x, control2y, finalX, finalY);
    
                stage.addChild(tempSprite);
            }else if(tempPenType === 1){ // Eraser
                let initX = parseFloat(splittedMessage[2]);
                let initY = parseFloat(splittedMessage[3]);
                let control1x = parseFloat(splittedMessage[4]);
                let control1y = parseFloat(splittedMessage[5]);
                let control2x = parseFloat(splittedMessage[6]);
                let control2y = parseFloat(splittedMessage[7]);
                let finalX = parseFloat(splittedMessage[8]);
                let finalY = parseFloat(splittedMessage[9]);
                let tempEraserSize = parseInt(splittedMessage[10]);

                let tempSprite = new PIXI.Graphics();

                sprite.lineStyle(tempEraserSize, 0xffffff, 1);

                tempSprite.zIndex = currentZIndex;
                tempSprite.moveTo(initX, initY);
                tempSprite.bezierCurveTo(control1x, control1y, control2x, control2y, finalX, finalY);
    
                stage.addChild(tempSprite);
            }else if(tempPenType === 2){ // Typing
                let tempTextSize = parseInt(splittedMessage[2]);
                let tempTextColor = parseInt(splittedMessage[3]);
                let tempText = splittedMessage[4];
                let tempX = parseFloat(splittedMessage[5]);
                let tempY = parseFloat(splittedMessage[6]);
                
                let tempStyle = new PIXI.TextStyle({
                    fontFamily: "Arial",
                    fontSize: tempTextSize,
                    fill: tempTextColor,
                });

                let tempPText = PIXI.Text(tempText, tempStyle);
                tempPText.zIndex = currentZIndex;
                tempPText.moveTo(tempX, tempY);

                stage.addChild(tempPText);
            }

            
        
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
    
    const prevTools = document.querySelector(`#button-${currentPenType}-tools`);
    prevTools.classList.add('hidden');

    const currTools = document.querySelector(`#button-${type}-tools`);
    currTools.classList.remove('hidden');
    
    currentPenType = type;
    currentZIndex++;

    // Get the previously selected button and remove its selected status
    const prevButton = document.querySelector('.selected-button');
    prevButton.classList.remove('selected-button');

    // Get the currently selected button and add its selected status
    const currButton = document.querySelector(`#tool-button-${type}`);
    currButton.classList.add('selected-button');

    writing_on_board = false;

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
var currentSprites = [];
let pointCount = 0;
let curve;

const onMouseMove = (e) => {
    if (!isMouseButtonDown) {
        return;
    }

    // clearSpriteRef(annoRef)
    if (initPointer == null) return;


    /// Drawing
    const curMousePosRef = getMousePos(e);
    curDistance = Math.sqrt((curMousePosRef.x - mousePosRef.x) * (curMousePosRef.x - mousePosRef.x) + (curMousePosRef.y - mousePosRef.y) * (curMousePosRef.y - mousePosRef.y));

    while (putDistance <= curDistance) {
        sprite = new PIXI.Graphics();

        if (currentPenType === 0) {
            sprite.lineStyle(pen_size, pen_color, 1);
        } else if (currentPenType === 1) {
            sprite.lineStyle(eraser_size, 0xffffff, 1);
        }
        sprite.moveTo(initPointer.x, initPointer.y);
        sprite.zIndex = currentZIndex;

        //Translate Towards a point
        const translate_direction = {
            x: curMousePosRef.x - mousePosRef.x,
            y: curMousePosRef.y - mousePosRef.y,
        }

        const translate_length = Math.sqrt(translate_direction.x * translate_direction.x + translate_direction.y * translate_direction.y);

        const translate_unitDirection = {
            x: translate_direction.x / translate_length,
            y: translate_direction.y / translate_length,
          };

        const translate_displacement = {
            x: translate_unitDirection.x * putDistance,
            y: translate_unitDirection.y * putDistance,
          };

        mousePosRef = { x: mousePosRef.x + translate_displacement.x,
                        y: mousePosRef.y + translate_displacement.y,}

        //********************** */
        

        currentPoints.push(initPointer);
        pointCount += 1;

        //Change to look each time after a number of points are placed
        if(pointCount % CHECK_STEPS == 0){
            //map to bezier curve
            curve = findBestFitCurve(currentPoints);
            /*
            console.log("berr" + (curve[0].bErr + curve[1].bErr));
            console.log("merr" + (curve[0].mErr + curve[1].mErr));*/
            var curve_sprite = new PIXI.Graphics();
            if (currentPenType === 0) {
                curve_sprite.lineStyle(pen_size, pen_color, 1);
            } else if (currentPenType === 1) {
                curve_sprite.lineStyle(eraser_size, 0xffffff, 1);
            }
            //curve_sprite.lineStyle(4, 0x000000, 0.5);

            if(curve[0].bErr + curve[1].bErr > MAX_BERR || curve[0].mErr + curve[1].mErr > MAX_MERR){
                curve_sprite.moveTo(currentPoints[0].x, currentPoints[0].y);
                curve_sprite.bezierCurveTo(curve[0].b, curve[1].b, curve[0].m, curve[1].m, currentPoints[currentPoints.length - 1].x,  currentPoints[currentPoints.length - 1].y);
                stage.addChild(curve_sprite);
                //-------------------
                //Send curve info
                if (currentPenType === 0) {
                    otherPeer.send(
                        currentPenType +
                        "|" +
                        currentZIndex +
                        "|" +
                        currentPoints[0].x +
                        "|" +
                        currentPoints[0].y +
                        "|" +
                        curve[0].b +
                        "|" +
                        curve[1].b +
                        "|" +
                        curve[0].m +
                        "|" +
                        curve[1].m +
                        "|" +
                        currentPoints[currentPoints.length - 1].x +
                        "|" +
                        currentPoints[currentPoints.length - 1].y +
                        "|" +
                        pen_size +
                        "|" +
                        pen_color
                    );
                } else if (currentPenType === 1) {
                    otherPeer.send(
                        currentPenType +
                        "|" +
                        currentZIndex +
                        "|" +
                        currentPoints[0].x +
                        "|" +
                        currentPoints[0].y +
                        "|" +
                        curve[0].b +
                        "|" +
                        curve[1].b +
                        "|" +
                        curve[0].m +
                        "|" +
                        curve[1].m +
                        "|" +
                        currentPoints[currentPoints.length - 1].x +
                        "|" +
                        currentPoints[currentPoints.length - 1].y +
                        "|" +
                        eraser_size
                    );
                }
                
                //delete previous drawing
                currentSprites.forEach(element => {
                    stage.removeChild(element);
                });
    
                currentPoints = [initPointer];
                currentSprites = [];
                pointCount = 1;
            }
            
        }
        //*************************************** */

        initPointer = mousePosRef;
        sprite.lineTo(mousePosRef.x, mousePosRef.y);
        stage.addChild(sprite);
        currentSprites.push(sprite);

        curDistance = Math.sqrt((curMousePosRef.x - mousePosRef.x) * (curMousePosRef.x - mousePosRef.x) + (curMousePosRef.y - mousePosRef.y) * (curMousePosRef.y - mousePosRef.y));
    }
    /// Drawing End
};

const onMouseDown = (e) => {
    mousePosRef = getMousePos(e);
    initPointer = mousePosRef;

    sprite = new PIXI.Graphics();
    if (currentPenType === 0) {
        sprite.lineStyle(parseInt(pen_size), parseInt(pen_color), 1);
    } else if (currentPenType === 1) {
        sprite.lineStyle(eraser_size, 0xffffff, 1);
    } else if (currentPenType === 2){ // Typing
        console.log("Typing");
        const mouseX = e.clientX - app.renderer.view.offsetLeft;
        const mouseY = e.clientY - app.renderer.view.offsetTop;
        p_text = new PIXI.Text("", textStyle);
        p_text.zIndex = currentZIndex;
        p_text.x = mouseX;
        p_text.y = mouseY;
        //text.moveTo(initPointer.x, initPointer.y);
        stage.addChild(p_text);
        writing_on_board = true;
    }
    //sprite.moveTo(initPointer.x, initPointer.y);
    //sprite.lineTo(mousePosRef.x, mousePosRef.y);

    //stage.addChild(sprite);

    isMouseButtonDown = true;

    //console.log(mousePosRef);
};


const onMouseUp = (e) => {
    isMouseButtonDown = false;

    if(pointCount > 0){
        //map to bezier curve
        curve = findBestFitCurve(currentPoints);
        /*
        console.log("berr" + (curve[0].bErr + curve[1].bErr));
        console.log("merr" + (curve[0].mErr + curve[1].mErr));*/
        var curve_sprite = new PIXI.Graphics();
        if (currentPenType === 0) {
            curve_sprite.lineStyle(pen_size, pen_color, 1);
        } else if (currentPenType === 1) {
            curve_sprite.lineStyle(eraser_size, 0xffffff, 1);
        }
        //curve_sprite.lineStyle(4, 0x000000, 0.5);
        curve_sprite.moveTo(currentPoints[0].x, currentPoints[0].y);
        curve_sprite.bezierCurveTo(curve[0].b, curve[1].b, curve[0].m, curve[1].m, currentPoints[currentPoints.length - 1].x,  currentPoints[currentPoints.length - 1].y);
        stage.addChild(curve_sprite);
        //-------------------
        //Send curve info
        if (currentPenType === 0) {
            otherPeer.send(
                currentPenType +
                "|" +
                currentZIndex +
                "|" +
                currentPoints[0].x +
                "|" +
                currentPoints[0].y +
                "|" +
                curve[0].b +
                "|" +
                curve[1].b +
                "|" +
                curve[0].m +
                "|" +
                curve[1].m +
                "|" +
                currentPoints[currentPoints.length - 1].x +
                "|" +
                currentPoints[currentPoints.length - 1].y +
                "|" +
                pen_size +
                "|" +
                pen_color
            );
        } else if (currentPenType === 1) {
            otherPeer.send(
                currentPenType +
                "|" +
                currentZIndex +
                "|" +
                currentPoints[0].x +
                "|" +
                currentPoints[0].y +
                "|" +
                curve[0].b +
                "|" +
                curve[1].b +
                "|" +
                curve[0].m +
                "|" +
                curve[1].m +
                "|" +
                currentPoints[currentPoints.length - 1].x +
                "|" +
                currentPoints[currentPoints.length - 1].y +
                "|" +
                eraser_size
            );
        }
        
        //delete previous drawing
        currentSprites.forEach(element => {
            stage.removeChild(element);
        });

        pointCount = 0;
        currentPoints = [];
        currentSprites = [];
    }
};

document.addEventListener("keydown", (event) => {
    if(writing_on_board){
        const alphanumericKey = /^[a-zA-Z0-9!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]*$/.test(event.key);
        if(event.key === "Enter"){
            writing_on_board = false;
        }
        else if(alphanumericKey && event.key.length === 1){
            p_text.text += event.key;
        }
    }
    
});


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
        Yx.push((points[i].x - (1-t) * (1-t) * (1-t) * P0.x - t * t * t * P3.x)/(3 * (1-t) * (1-t) * t));
        Yy.push((points[i].y - (1-t) * (1-t) * (1-t) * P0.y - t * t * t * P3.y)/(3 * (1-t) * (1-t) * t));
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
    return result;
}

  //End of Bezier Curve Functions

container.addEventListener("mousemove", onMouseMove, 0);

container.addEventListener("mousedown", onMouseDown, 0);

container.addEventListener("mouseup", onMouseUp, 0);

