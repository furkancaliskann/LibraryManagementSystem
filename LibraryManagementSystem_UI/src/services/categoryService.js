import api from './api';

export const getCategories = async (includeDeleted = false) => {
  const response = await api.get('/categories', {
    params: { includeDeleted },
  });
  return response.data;
};

export const getCategoryById = async (id) => {
  const response = await api.get(`/categories/${id}`);
  return response.data;
};

export const addCategory = async (categoryData) => {
  const response = await api.post(`/categories`, categoryData);
  return response.data;
};

export const updateCategory = async (id, categoryData) => {
  const response = await api.put(`/categories/${id}`, categoryData);
  return response.data;
};

export const deleteCategory = async (id) => {
  const response = await api.delete(`/categories/${id}`);
  return response.data;
};
