import { Route, Routes } from "react-router-dom";
import Account from "../pages/Account/Account";
import Login from "../pages/Account/Login";
import Register from "../pages/Account/Register";

function ShopRoutes() {
  return (
    <Routes>
      <Route path="/" element={<Account />}>
        <Route path="login" element={<Login />} />
        <Route path="register" element={<Register />} />
      </Route>
    </Routes>
  );
}
export default ShopRoutes;
