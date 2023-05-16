import React from "react";
import { createRoot } from "react-dom/client";
import { ThemeProvider } from "./utils/ThemeContext";
import { MobileMenuProvider } from "./utils/MobileMenuContext";
import App from "./App";
import "./index.css";

createRoot(document.getElementById("root")).render(
  <React.StrictMode>
    <MobileMenuProvider>
      <ThemeProvider>
        <App />
      </ThemeProvider>
    </MobileMenuProvider>
  </React.StrictMode>
);
