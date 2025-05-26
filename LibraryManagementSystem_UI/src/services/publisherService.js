import api from './api';

export const getPublishers = async (includeDeleted = false) => {
  const response = await api.get('/publishers', {
    params: { includeDeleted },
  });
  return response.data;
};

export const addPublisher = async (publisherData) => {
  const response = await api.post('/publishers', publisherData);
  return response.data;
};

export const deletePublisher = async (id) => {
  const response = await api.delete(`/publishers/${id}`);
  return response.data;
};
