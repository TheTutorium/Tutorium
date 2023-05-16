import * as PIXI from 'pixi.js';
import React, { useRef} from 'react';

export function Canvas() {
  //const [value, setValue] = useState(0);

  const historyRef = useRef(null);
  const fileInputRef = useRef(null);
  let app = null;
  let text = null;




  let sprite_array = [];


  const handleFileInputChange = (event) => {
    const file = event.target.files[0];
    const reader = new FileReader();
    const stage = app.stage;

    reader.onload = (e) => {
      const loadedText = e.target.result;

      if (app) {

        let history = loadedText.split("\n");

        historyRef.current.min = 0;
        historyRef.current.max = history.length - 1; // Update the maximum value
        historyRef.current.value = 0;

        for(let i = 0; i < history.length; i++){
          let splittedMessage = history[i].split("|");
          console.log(history[i]);

          let tempPenType = parseInt(splittedMessage[0]);
          let currentZIndex = parseInt(splittedMessage[1]);

          if(tempPenType == 0){ // Pen
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

              sprite_array.push(tempSprite);
              tempSprite.alpha = 0;

              stage.addChild(tempSprite);
          }else if(tempPenType == 1){ // Eraser
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

              tempSprite.lineStyle(tempEraserSize, 0xffffff, 1);

              tempSprite.zIndex = currentZIndex;
              tempSprite.moveTo(initX, initY);
              tempSprite.bezierCurveTo(control1x, control1y, control2x, control2y, finalX, finalY);

              sprite_array.push(tempSprite);
              tempSprite.alpha = 0;

              stage.addChild(tempSprite);
          }else if(tempPenType == 2){ // Typing
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

              let tempPText = new PIXI.Text(tempText, tempStyle);
              tempPText.zIndex = currentZIndex;
              tempPText.x = tempX;
              tempPText.y = tempY;

              sprite_array.push(tempPText);
              tempPText.alpha = 0;

              stage.addChild(tempPText);
          }else if(tempPenType == 3){
              let temp_image = splittedMessage[2];
              let tempX = parseFloat(splittedMessage[3]);
              let tempY = parseFloat(splittedMessage[4]);

              const image_texture = PIXI.Texture.from(temp_image);
              const sprite = new PIXI.Sprite(image_texture);

              sprite.x = tempX;
              sprite.y = tempY;

              sprite_array.push(sprite);
              sprite.alpha = 0;

              stage.addChild(sprite);
          }
        }

      }
    };

    reader.readAsText(file);
  };

  const handleLoadButtonClick = () => {
    fileInputRef.current.click();
  };

  let container;

  let canvasCreated = false;

  const handleCanvasContainerRef = (element) => {
    if (element && !app && !canvasCreated) {

      canvasCreated =true;

      container = element;
      // Create a PixiJS application
      app = new PIXI.Application({
        antialias: true,
        backgroundColor: 0xffffff,
        width: window.innerWidth * 0.8,
        height: window.innerHeight * 0.6,
      });

      // Get the canvas element
      const canvas = app.view;

      // Add a 'wheel' event listener to the canvas
      canvas.addEventListener('wheel', onCanvasScroll);

      // Append the PixiJS canvas to the container element
      element.appendChild(app.view);

      container.addEventListener("mousemove", onMouseMove, 0);

      container.addEventListener("mousedown", onMouseDown, 0);

      container.addEventListener("mouseup", onMouseUp, 0);
    }
  };

  const SCALE_CONST = 0.1;
  var canvas_scale = 1.0;
  var canvas_translation = {x: 0.0, y: 0.0};

  function transformPoint(x,y){

    var newX = (x + canvas_translation.x) / canvas_scale;
    var newY = (y + canvas_translation.y) / canvas_scale;


    return {x: newX, y: newY};
  }

  function onCanvasScroll(event) {

    const stage = app.stage;
    // Get the scroll direction
    const delta = Math.sign(event.deltaY) * SCALE_CONST;

    // Do something with the scroll direction

    var middlePoint = transformPoint(app.view.width / 2, app.view.height / 2);

    const prev_scale = canvas_scale;

    stage.scale.set(stage.scale.x * (1 - delta));
    canvas_scale = stage.scale.x;

    const translation = {x: middlePoint.x * (canvas_scale - prev_scale), y: middlePoint.y * (canvas_scale - prev_scale)}

    canvas_translation = {x: canvas_translation.x + translation.x, y: canvas_translation.y + translation.y};
    stage.position.set(-canvas_translation.x, -canvas_translation.y);


    /*var newMiddlePoint = transformPoint(0,0);

    var temp_dist = {x: middlePoint.x - newMiddlePoint.x, y: middlePoint.y - newMiddlePoint.y};

    stage.position.set(stage.position.x + (temp_dist.x / canvas_scale), stage.position.y + (temp_dist.y / canvas_scale));

    canvas_translation = {x: canvas_translation.x + (temp_dist.x / canvas_scale), y: canvas_translation.y + (temp_dist.y / canvas_scale)};*/

  }

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

  let isMouseButtonDown = false;
  let initPointer = null;
  let mousePosRef;
  let last_mouse_button = 0;

  const onMouseMove = (e) => {
    if (!isMouseButtonDown) {
        return;
    }

    const curMousePosRef = getMousePos(e);

        const stage = app.stage;

        let translationOffset = { x: 0, y: 0 };
        translationOffset.x += curMousePosRef.x - initPointer.x;
        translationOffset.y += curMousePosRef.y - initPointer.y;

        

        stage.position.set(stage.position.x + translationOffset.x, stage.position.y + translationOffset.y);

        canvas_translation.x = -stage.position.x;
        canvas_translation.y = -stage.position.y;

        initPointer = curMousePosRef;

        return;
};

const onMouseDown = (e) => {
    mousePosRef = getMousePos(e);
    initPointer = mousePosRef;
    isMouseButtonDown = true;
    //sprite.moveTo(initPointer.x, initPointer.y);
    //sprite.lineTo(mousePosRef.x, mousePosRef.y);

    //stage.addChild(sprite);

    

    //console.log(mousePosRef);
};


const onMouseUp = (e) => {
    isMouseButtonDown = false;
};

let prev_value = 0;

const handleChangeRange = (event) => {

  let cur_value = parseInt(event.target.value);

  if(prev_value < cur_value){
    for(let i = prev_value; i < cur_value; i++){
      console.log(i);
      sprite_array[i].alpha = 1;
    }
    prev_value = cur_value;
  }else{
    
    for(let i = prev_value - 1; i >= cur_value; i--){
      console.log(i);
      sprite_array[i].alpha = 0;
    }
    prev_value = cur_value;
  }
  historyRef.current.value = prev_value;

};


 

  return (
    <div
      className="flex flex-col justify-center w-full h-full md:px-5 py-5 bg-yellow-200"
    >
      <input
        ref={fileInputRef}
        type="file"
        accept=".wb"
        style={{ display: 'none' }}
        onChange={handleFileInputChange}
      />
      <button onClick={handleLoadButtonClick}>Load Whiteboard</button>
      <div className="flex flex-col justify-center" id="canvas-container-1" ref={handleCanvasContainerRef}></div>
      <input type="range" ref={historyRef} onChange={handleChangeRange}/>

    </div>
  );
}
