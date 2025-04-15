import axios from "./api";

const API_URL = "https://localhost:7175/api/auth";

export const login = async (userData) => {
    const response = await axios.post(`${API_URL}/login`, userData);
    return response.data;
};

export const register = async (userData) => {
    const response = await axios.post(`${API_URL}/register`, userData);
    return response.data;
};

export const validateToken = async () => {
    try {
      const res = await axios.get(`${API_URL}/validate`);
      return res.data?.isValid === true;
    } catch {
      return false;
    }
  };