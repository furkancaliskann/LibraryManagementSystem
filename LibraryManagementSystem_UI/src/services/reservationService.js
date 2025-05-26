import api from './api';

export const createReservation = async (bookCopyId) => {
  const res = await api.post('/reservations', {
    bookCopyId,
  });
  return res.data;
};
