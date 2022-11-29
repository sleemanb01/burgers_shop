import axios from "axios";
import { useEffect, useState } from "react";
import { Burgers } from "../Burgers/Burgers";
import { Extras } from "../Extras/Extras";
import { IBurger } from "../../Interfaces/IBurger";
import { IExtra } from "../../Interfaces/IExtra";
import { IOrderExtra } from "../../Interfaces/IOrderExtra";
import { IOrderSide } from "../../Interfaces/IOrderSide";
import { ISide } from "../../Interfaces/ISide";
import { Order } from "../Order/Order";
import { Sides } from "../Sides/Sides";
import { IOrderBurger } from "../../Interfaces/IOrderBurger";
import "./Menu.css";

export function Menu() {
  
  const [currBurger, setCBurger] = useState<IBurger|undefined>(undefined);

  const [extras, setExtras] = useState<IOrderExtra[]>([]);
  const [sides, setSides] = useState<IOrderSide[]>([]);

  const [burgerIsLoading, setBurgerLoading] = useState(true);
  const [extraIsLoading, setExtraLoading] = useState(true);
  const [sideIsLoading, setSideLoading] = useState(true);

  const [burgersArr, setBurgersArr] = useState<IBurger[]>([]);
  const [extrasArr, setExtrasArr] = useState<IExtra[]>([]);
  const [sidesArr, setSidesArr] = useState<ISide[]>([]);

  useEffect(() => {
    fetchData("burger", setBurgersArr,setBurgerLoading);
    fetchData("extra", setExtrasArr,setExtraLoading);
    fetchData("side", setSidesArr,setSideLoading);
  },[]);

// ************************************* RETURN *************************************

  return (
    <div className="Menu">
      <div className="menuContainer">
        <div className="outletContainer">
          <Burgers burgersArr={burgersArr} setBurger={setCBurger} setExtras={setExtras} burgerIsLoading={burgerIsLoading} selectedBurger={currBurger}/>
        </div>
        <div className="secondColumn">
          <Extras extrasArr={extrasArr} burger={currBurger} setExtras={setExtras} extraIsLoading={extraIsLoading} />
        </div>
        <div className="thirdColumn">
          <Sides sidesArr={sidesArr} setSides={setSides} sideIsLoading={sideIsLoading} />
        </div>
      </div>
        <div className="fourthColumn">
          <Order burger={currBurger} extras={extras} extrasArr={extrasArr} sidesArr={sidesArr} sides={sides} />
        </div>

    </div>
  );
}

// ************************************* FUNCTIONS *************************************

async function fetchData(who:string,setArr:Function,setLoading:Function)
{
  const url = "https://localhost:7175/api/";
  try
  {
    const result = await axios.get(url + who);
    let data = result.data;
    setArr(data);
  }
  catch(err)
  {
    console.log(err);
  }
  finally
  {
    setLoading(false);
  }
}