import { Header } from "./components/Header/Header";
import { Footer } from "./components/Footer";
import {
  ClerkProvider,
  RedirectToSignIn,
  SignedIn,
  SignedOut,
  SignUp,
  UserProfile,
} from "@clerk/clerk-react";
import { BrowserRouter, Route, Routes, useNavigate } from "react-router-dom";
import { Home } from "./pages/Home";
import { Login } from "./components/auth/Login";
import { Dashboard } from "./pages/Dashboard";
import { dark, light } from "@clerk/themes";
import { useTheme } from "./utils/ThemeContext";
import { Team } from "./pages/Team";
import { Contact } from "./pages/Contact";
import { Stack } from "./pages/Stack";
import { Meetings } from "./pages/Meetings";
import Tutor from "./pages/Tutor";
import { UserTypeProvider } from "./utils/UserTypeContext";
import { Canvas } from "./pages/Canvas";

const clerk_pub_key = import.meta.env.VITE_CLERK_PUBLISHABLE_KEY;

function ClerkProviderWithRoutes() {
  const navigate = useNavigate();
  const theme = useTheme();

  const clerkTheme = {
    baseTheme: theme.darkMode ? dark : light,
  };

  return (
    <ClerkProvider
      appearance={{
        baseTheme: clerkTheme.baseTheme,
      }}
      publishableKey={clerk_pub_key}
      navigate={(to) => navigate(to)}
    >
      <UserTypeProvider>
        <Header />
        <main className="min-h-[70vh] md:min-h-[80vh] grid">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route
              path="/sign-in/*"
              element={<Login routing="path" path="/sign-in" />}
            />
            <Route
              path="/sign-up/*"
              element={<SignUp routing="path" path="/sign-up" />}
            />
            <Route path="/team" element={<Team />} />
            <Route path="/contact" element={<Contact />} />
            <Route path="/stack" element={<Stack />} />
            <Route
              path="/dashboard/*"
              element={
                <>
                  <SignedIn path="/sign-in">
                    <Dashboard />
                  </SignedIn>
                  <SignedOut>
                    <RedirectToSignIn to="/sign-in" />
                  </SignedOut>
                </>
              }
            />
            <Route
              path="/profile/*"
              element={
                <>
                  <SignedIn>
                    <UserProfile />
                  </SignedIn>
                  <SignedOut>
                    <RedirectToSignIn />
                  </SignedOut>
                </>
              }
            />
            <Route
              path="/tutors/:id"
              element={
                <>
                  <SignedIn>
                    <Tutor />
                  </SignedIn>
                  <SignedOut>
                    <RedirectToSignIn />
                  </SignedOut>
                </>
              }
            />
            <Route
              path="/meetings"
              element={
                <>
                  <SignedIn>
                    <Meetings />
                  </SignedIn>
                  <SignedOut>
                    <RedirectToSignIn />
                  </SignedOut>
                </>
              }
            />

            <Route
              path="/canvas"
              element={
                <>
                  {/* <SignedIn> */}
                  <Canvas />
                  {/* </SignedIn>
                  <SignedOut>
                    <RedirectToSignIn />
                  </SignedOut> */}
                </>
              }
            />
            <Route
              path="*"
              element={
                <h1
                  className={
                    "text-center text-7xl h-inherit flex justify-center items-center pt-40"
                  }
                >
                  DORT YUZ DORT
                </h1>
              }
            />
          </Routes>
        </main>
        <Footer />
      </UserTypeProvider>
    </ClerkProvider>
  );
}

function App() {
  return (
    <BrowserRouter>
      <ClerkProviderWithRoutes />
    </BrowserRouter>
  );
}

export default App;
