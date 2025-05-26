import api from './api';

export const getAuthors = async (includeDeleted = false) => {
  const response = await api.get('/authors', {
    params: { includeDeleted },
  });
  return response.data;
};

export const getAuthorById = async (id) => {
  const response = await api.get(`/authors/${id}`);
  return response.data;
};

export const addAuthor = async (authorData) => {
  const response = await api.post(`/authors`, authorData);
  return response.data;
};

export const updateAuthor = async (id, authorData) => {
  const response = await api.put(`/authors/${id}`, authorData);
  return response.data;
};

export const deleteAuthor = async (id) => {
  const response = await api.delete(`/authors/${id}`);
  return response.data;
};
