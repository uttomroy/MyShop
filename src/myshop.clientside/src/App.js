import logo from "./logo.svg";
import "./App.css";
import Login from "./pages/Account/Login";
import Account from "./pages/Account/Account";
import ShopRoutes from "./routes/shoproutes";

function App() {
  return (
      <div className="App">
        <ShopRoutes />
      </div>
  );
}

export default App;
