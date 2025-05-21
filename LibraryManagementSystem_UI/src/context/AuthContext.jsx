import React, { createContext, useState, useEffect } from "react";
import { parseJwt } from "../utils/jwtUtils";
import { getUserById } from "../services/userService";

export const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [isLoggedIn, setIsLoggedIn] = useState(null);
  const [user, setUser] = useState(null);
  const [role, setRole] = useState(null);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) {
      const decoded = parseJwt(token);
      if (!decoded) {
        console.error("Geçersiz token");
        setIsLoggedIn(false);
        return;
      }
      
      const userId = decoded?.nameid;
      const userRole = decoded?.role;
  
      setRole(userRole);
      setIsLoggedIn(true);
  
      getUserById(userId)
        .then((data) => setUser(data))
        .catch((err) => {
          console.error("Kullanıcı bilgisi alınamadı", err);
          setIsLoggedIn(false);
        });
    } else {
      setIsLoggedIn(false);
    }
  }, []);
  

  const login = (token) => {
    localStorage.setItem("token", token);
    const decoded = parseJwt(token);
    const userId = decoded?.nameid;
    const userRole = decoded?.role;

    setRole(userRole);
    setIsLoggedIn(true);

    getUserById(userId)
      .then((data) => setUser(data))
      .catch((err) => {
        console.error("Login sonrası kullanıcı bilgisi alınamadı", err);
        setIsLoggedIn(false);
      });
  };

  const logout = () => {
    localStorage.removeItem("token");
    setUser(null);
    setIsLoggedIn(false);
    setRole(null);
  };

  return (
    <AuthContext.Provider value={{ isLoggedIn, user, role, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};