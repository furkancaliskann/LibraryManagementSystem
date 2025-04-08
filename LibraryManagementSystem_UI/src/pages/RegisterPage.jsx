import { useState } from "react";
import { register } from "../services/authService";
import { useNavigate } from "react-router-dom";

const RegisterPage = () => {
  const [formData, setFormData] = useState({
    name: "",
    surname: "",
    email: "",
    password: "",
    phone: "",
    address: "",
  });
  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");
  const navigate = useNavigate();

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const result = await register(formData);
      setSuccess("Kayıt başarılı! Giriş yapabilirsiniz." + result.data);
      navigate("/login")
      setError("");
    } catch (err) {
      setError("Kayıt başarısız. Bilgileri kontrol edin." + err.message);
      setSuccess("");
    }
  };

  return (
    <div className="max-w-md mx-auto mt-20 p-6 bg-white rounded shadow">
      <h2 className="text-2xl font-bold mb-4">Kayıt Ol</h2>
      <form onSubmit={handleSubmit}>
        <input
          className="w-full mb-2 p-2 border rounded"
          type="text"
          name="name"
          placeholder="Ad"
          value={formData.name}
          onChange={handleChange}
        />
        <input
          className="w-full mb-2 p-2 border rounded"
          type="text"
          name="surname"
          placeholder="Soyad"
          value={formData.surname}
          onChange={handleChange}
        />
        <input
          className="w-full mb-2 p-2 border rounded"
          type="email"
          name="email"
          placeholder="Email"
          value={formData.email}
          onChange={handleChange}
        />
        <input
          className="w-full mb-2 p-2 border rounded"
          type="password"
          name="password"
          placeholder="Şifre"
          value={formData.password}
          onChange={handleChange}
        />
        <input
          className="w-full mb-2 p-2 border rounded"
          type="text"
          name="phone"
          placeholder="Telefon"
          value={formData.phone}
          onChange={handleChange}
        />
        <input
          className="w-full mb-2 p-2 border rounded"
          type="text"
          name="address"
          placeholder="Adres"
          value={formData.address}
          onChange={handleChange}
        />
        {error && <p className="text-red-500 mb-2">{error}</p>}
        {success && <p className="text-green-500 mb-2">{success}</p>}
        <button
          type="submit"
          className="w-full bg-green-500 text-white py-2 rounded hover:bg-green-600"
        >
          Kayıt Ol
        </button>
      </form>
    </div>
  );
};

export default RegisterPage;