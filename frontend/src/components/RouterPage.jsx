import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from "./Login";
import Registration from "./Registration";
import Dashboard from "./users/Dashboard";
import Cart from "./users/Cart";
import Header from "./users/Header";
import MedicineDisplay from "./users/MedicineDisplay";
import Orders from "./users/Orders";
import Profile from "./users/Profile";
import AdminDashboard from "./admin/AdminDashboard";
// import AdminHeader from "./admin/AdminHeader";
import AdminOrders from "./admin/AdminOrders";
import CustomerList from "./admin/CustomerList";
import Medicine from "./admin/Medicine";

const RouterPage = () => {
  return (
    <div>
      <Router>
        <Routes>
          <Route path="/" element={<Login />} />
          <Route path="/registration" element={<Registration />} />
          <Route path="/dashboard" element={<Dashboard />} />
          <Route path="/cart" element={<Cart />} />
          <Route path="/header" element={<Header />} />
          <Route path="/products" element={<MedicineDisplay />} />
          <Route path="/orders" element={<Orders />} />
          <Route path="/profile" element={<Profile />} />

          <Route path="/admindashboard" element={<AdminDashboard />} />
          <Route path="/adminorders" element={<AdminOrders />} />
          <Route path="/customers" element={<CustomerList />} />
          <Route path="/medicine" element={<Medicine />} />
        </Routes>
      </Router>
    </div>
  );
};

export default RouterPage;
