import { Outlet, Route, Routes} from 'react-router-dom'
import { NavBar } from './Components/NavBar/NavBar';
import { Menu } from './Components/Menu/Menu';
import { Branches } from './Components/Branches/Branches';
import { About } from './Components/About/About';
import { Footer } from './Components/Footer/Footer';
import { SignIn } from './Components/SignIn/SignIn';
import { SignUp } from './Components/SignUp/SignUp';
import {CustProvider}  from './Components/Context/CustContext';

function App() {

  return (
    <div className="App">
      {/* <CustProvider> */}
        <div className="allButFooter">
            <NavBar/> 
          <Outlet />
          <Routes>
            <Route path="/" element={<Menu/>} />
            <Route path="/Branches" element={<Branches />} />
            <Route path="/register" element={<SignUp />}/>
              <Route path="/SignIn" element={<SignIn />} />
              <Route path="/SignUp" element={<SignUp />} />
            <Route path="/About" element={<About />} />
          </Routes>
        </div>
      {/* </CustProvider> */}
      <Footer />
      </div>
  );
}

export default App;
