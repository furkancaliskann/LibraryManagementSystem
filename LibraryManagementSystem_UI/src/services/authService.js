import api from './api';

export const login = async (userData) => {
  const response = await api.post(`/auth/login`, userData);
  return response.data;
};

export const register = async (userData) => {
  const response = await api.post(`/auth/register`, userData);
  return response.data;
};

export const validateToken = async () => {
  try {
    const res = await api.get(`/auth/validate`);
    return res.data?.isValid === true;
  } catch {
    return false;
  }
};
