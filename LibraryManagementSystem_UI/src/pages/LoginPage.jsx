import { useState } from "react";
import { login } from "../services/authService";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
    const [formData, setFormData] = useState({ email: "", password: ""});
    const [error, setError] = useState("");
    const navigate = useNavigate();

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const result = await login(formData);
            console.log("Login successful:", result);
            navigate("/home");
        } catch /*(err)*/ {
            setError("Giriş başarısız. Lütfen bilgileri kontrol edin.");
        }
    };

    return (
        <div className="max-w-md mx-auto mt-20 p-6 bg-white rounded shadow">
          <h2 className="text-2xl font-bold mb-4">Giriş Yap</h2>
          <form onSubmit={handleSubmit}>
            <input
              className="w-full mb-3 p-2 border rounded"
              type="email"
              name="email"
              placeholder="Email"
              value={formData.email}
              onChange={handleChange}
            />
            <input
              className="w-full mb-3 p-2 border rounded"
              type="password"
              name="password"
              placeholder="Şifre"
              value={formData.password}
              onChange={handleChange}
            />
            {error && <p className="text-red-500 mb-2">{error}</p>}
            <button
              type="submit"
              className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600"
            >
              Giriş Yap
            </button>
          </form>
        </div>
      );
}

export default LoginPage;