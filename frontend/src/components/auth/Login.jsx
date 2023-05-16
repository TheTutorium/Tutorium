import React from "react";
import CustomSignIn from "./CustomSignIn";

export function Login({ routing, path }) {
  const onSignInRendered = () => {
    console.log("Sign-in component rendered.");
    deleteElement();
    addBackground();
    // Add any additional logic you want to run after the sign-in component is rendered.
  };

  return (
    <div className="flex justify-center">
      <CustomSignIn
        routing={routing}
        path={path}
        onSignInRendered={onSignInRendered}
      />
    </div>
  );
}

function deleteElement() {
  console.log("deleteElement");
  const element = document.querySelector(
    "#root main div div div div:nth-child(5)"
  );
  if (element) {
    element.remove();
  }
}

function addBackground() {
  // document
  //   .querySelector("#root > main > div > div > div")
  //   .classList.add("bg-gray-100");
}
