import axios from "axios";
import React from "react";
import { useEffect, useState } from "react";
import { ICustomer } from "../../Interfaces/ICustomer";
import { cust } from '../Context/@types/cust';
import { CustContext } from '../Context/CustContext';
import "./SignIn.css";

export function SignIn() {

  const [customer, setCustomer] = useState<ICustomer | undefined>(undefined);

  const custContext = React.useContext(CustContext) as cust;

  const {logIn} = { ...custContext };

    if(customer != undefined)
    {
        logIn(customer);
        window.location.href = 'http://localhost:3000/';
    }

  // ************************************* RETURN *************************************

  return (
    <div className="signIn">
      <div id="nameDiv">
        <input
          className="emptyInput"
          name="checkName"
          id="checkName"
          type="text"
          placeholder="email"
        />
      </div>
      <div id="passwordDiv">
        <input
          className="emptyInput"
          name="checkPass"
          id="checkPass"
          type="password"
          placeholder="password"
        />
      </div>
      <div>
        <button
          onClick={() => {
            authenticate(setCustomer);
          }}
        >
          submit
        </button>
      </div>
    </div>
  );
}

// ************************************* FUNCTIONS *************************************

async function authenticate(setCustomer: Function) {
  let checkName = (document.querySelector("#checkName") as HTMLInputElement)
    .value;
  let checkPass = (document.querySelector("#checkPass") as HTMLInputElement)
    .value;

  let tempCheck = await axios.get("https://localhost:7175/api/Customers/");

  for (const key in tempCheck.data) {
    if (
      checkName == tempCheck.data[key]["email"] &&
      checkPass == tempCheck.data[key]["pass"]
    ) {
      setCustomer((tempCheck.data[key] as ICustomer));
      break;
    }
  }
}
