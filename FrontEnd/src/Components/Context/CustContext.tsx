import React, { Children, createContext, useState } from "react";
import { ICustomer } from "../../Interfaces/ICustomer";
import { cust } from "./@types/cust";

export const CustContext = createContext<cust | null>(null);

export const CustProvider: React.FC<React.ReactNode> = (props:any) => {
  const [currCustomer, setCurrCustomer] = useState<ICustomer | undefined>(
    undefined
  );

  const logIn = (currCustomer:ICustomer|undefined) => {
    setCurrCustomer(currCustomer);
  };

  const logOut = () => {
    setCurrCustomer(undefined);
  };

  return (
    <CustContext.Provider value={{ currCustomer, logIn, logOut }}>
      {props.children}
    </CustContext.Provider>
  );
};

// export CustProvider;
