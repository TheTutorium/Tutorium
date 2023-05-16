import React from "react";
import { SignIn } from "@clerk/clerk-react";

const CustomSignIn = ({ routing, path, onSignInRendered }) => {
  React.useEffect(() => {
    // Replace the selector with a specific element related to the SignIn component
    //  //*[@id="root"]/main/div/div
    const selector = "#root main div div div div:nth-child(5)";
    return waitForElement(selector, onSignInRendered);
  }, [onSignInRendered]);

  return <SignIn routing={routing} path={path} />;
};

export default CustomSignIn;

const waitForElement = (selector, callback) => {
  const observer = new MutationObserver((mutations) => {
    mutations.forEach((mutation) => {
      if (document.querySelector(selector)) {
        observer.disconnect();
        callback();
      }
    });
  });

  observer.observe(document.body, {
    childList: true,
    subtree: true,
  });

  // Clean up the observer when the target element is found
  return () => {
    observer.disconnect();
  };
};
