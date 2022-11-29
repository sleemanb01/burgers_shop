import { IBurger } from "./IBurger";
import { IOrderExtra } from "./IOrderExtra";
import { IOrderSide } from "./IOrderSide";

export interface ITray
{
    burger?:IBurger|undefined,
    extras?:IOrderExtra[],
    sides?:IOrderSide[]
}