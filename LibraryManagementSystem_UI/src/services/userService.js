import api from './api';

export const getUserById = async (userId) => {
  const response = await api.get(`/users/${userId}`);
  return response.data;
};

export const updateUser = async (userDto) => {
  const res = await api.put('/users/', userDto);
  return res.data;
};
