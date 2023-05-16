import { createContext, useState, useContext, useEffect } from "react";
import { useAuth } from "@clerk/clerk-react";
const UserTypeContext = createContext();

export function UserTypeProvider({ children }) {
  const [isTutor, setIsTutor] = useState(null);
  const [typeLoading, setTypeLoading] = useState(true);
  const { getToken } = useAuth();
  // get user
  const { user } = useAuth();

  useEffect(() => {
    // is signed in?
    if (!user) {
      setTypeLoading(false);
      return;
    }
    setTypeLoading(true);
    const fetchTutorStatus = async () => {
      const token = await getToken();
      const response = await fetch(
        `${import.meta.env.VITE_API_URL}/users/is-tutor`,
        {
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
          },
          // redirect: "follow",
        }
      );
      if (response.ok) {
        const data = await response.json();
        setIsTutor(data.isTutor);
        setTypeLoading(false);
      } else {
        console.error("Failed to fetch tutor status");
      }
    };
    fetchTutorStatus();
  }, []);

  return (
    <UserTypeContext.Provider value={{ isTutor, typeLoading }}>
      {children}
    </UserTypeContext.Provider>
  );
}

export function useUserType() {
  const context = useContext(UserTypeContext);
  if (context === undefined) {
    throw new Error("useUserType must be used within a UserTypeProvider");
  }
  return context;
}
