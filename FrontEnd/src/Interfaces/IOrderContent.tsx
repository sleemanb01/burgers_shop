
import { IBurger } from './IBurger';
import { IExtra } from './IExtra';
import { IOrderExtra } from './IOrderExtra';
import { IOrderSide } from './IOrderSide';
import { ISide } from './ISide';

export interface IOrderContent
{
    CustomerId?:number
    iOrderburger?:IBurger,
    iOrderExtras?:IOrderExtra[],
    iOrderSides?:IOrderSide[],
}
