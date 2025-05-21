import api from './api';

export const getBooks = async (includeDeleted) => {
  const res = await api.get(`/books?includeDeleted=${includeDeleted}`);
  return res.data;
};

const getBookById = async (id) => {
  const res = await api.get(`/books/${id}`);
  return res.data.data;
};

const getAllBookCopies = async () => {
  const res = await api.get('/book-copies');
  return res.data.data;
};

const getShelfById = async (id) => {
  const res = await api.get(`/shelves/${id}`);
  return res.data.data;
};

export const getBookCopiesWithShelf = async (bookId) => {
  const allCopiesRes = await api.get('/book-copies');

  const allCopies = Array.isArray(allCopiesRes.data.data)
    ? allCopiesRes.data.data
    : [];

  const filteredCopies = allCopies.filter(
    (copy) => copy.bookId === parseInt(bookId)
  );

  const copiesWithShelf = await Promise.all(
    filteredCopies.map(async (copy) => {
      const shelfRes = await api.get(`/shelves/${copy.shelfId}`);
      return { ...copy, shelf: shelfRes.data.data };
    })
  );

  return copiesWithShelf;
};

export default {
  getBookById,
  getAllBookCopies,
  getShelfById,
  getBookCopiesWithShelf,
};
