import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import bookService from "../services/bookService";

const BookDetail = () => {
  const { id } = useParams();
  const [book, setBook] = useState(null);
  const [copies, setCopies] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchDetails = async () => {
      try {
        const bookData = await bookService.getBookById(id);
        const copiesData = await bookService.getBookCopiesWithShelf(id);

        setBook(bookData);
        setCopies(copiesData);
      } catch (err) {
        console.error("Kitap detayları alınamadı", err);
      } finally {
        setLoading(false);
      }
    };

    fetchDetails();
  }, [id]);

  if (loading) return <p className="text-center mt-10 text-gray-600">Yükleniyor...</p>;
  if (!book) return <p className="text-center mt-10 text-red-500">Kitap bulunamadı.</p>;

  return (
    <div className="max-w-4xl mx-auto p-6 bg-white shadow-md rounded-xl mt-8">
      <h1 className="text-4xl font-bold text-gray-800 mb-6 border-b pb-2">{book.title}</h1>
      
      <div className="space-y-2 text-lg text-gray-700">
        <p><span className="font-semibold text-gray-800">Yazar:</span> {book.author?.name}</p>
        <p><span className="font-semibold text-gray-800">Yayınevi:</span> {book.publisher?.name}</p>
        <p><span className="font-semibold text-gray-800">Kategori:</span> {book.category?.name}</p>
        <p><span className="font-semibold text-gray-800">ISBN:</span> {book.isbn}</p>
        <p><span className="font-semibold text-gray-800">Yayın Tarihi:</span> {new Date(book.publicationDate).toLocaleDateString()}</p>
        <p className="mt-4"><span className="font-semibold text-gray-800">Açıklama:</span> {book.description}</p>
      </div>

      <h2 className="text-2xl font-semibold mt-10 mb-4 text-gray-800 border-b pb-1">Kopyalar</h2>
      {copies.length === 0 ? (
        <p className="text-gray-600">Bu kitaptan kopya bulunmuyor.</p>
      ) : (
        <div className="overflow-x-auto">
          <table className="w-full table-auto border-collapse shadow-sm">
            <thead>
              <tr className="bg-gray-200 text-left">
                <th className="px-4 py-2 border font-medium">Kopya No</th>
                <th className="px-4 py-2 border font-medium">Durum</th>
                <th className="px-4 py-2 border font-medium">Raf</th>
              </tr>
            </thead>
            <tbody>
              {copies.map((copy) => (
                <tr key={copy.id} className="hover:bg-gray-50">
                  <td className="px-4 py-2 border">{copy.copyNumber}</td>
                  <td className="px-4 py-2 border">{getCopyStatusLabel(copy.status)}</td>
                  <td className="px-4 py-2 border">{copy.shelf?.location}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
};

const getCopyStatusLabel = (status) => {
  switch (status) {
    case 0: return "Uygun";
    case 1: return "Ödünç Alındı";
    case 2: return "Rezerve";
    default: return "Bilinmiyor";
  }
};

export default BookDetail;
