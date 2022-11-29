import { ICustomer } from "../../../Interfaces/ICostumer"

export type cust = 
{
    currCustomer:ICustomer|undefined;
    logIn: (currCustomer:ICustomer) => void;
    logOut: () => void;
}