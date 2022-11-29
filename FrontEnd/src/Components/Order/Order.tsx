import { IBurger } from "../../Interfaces/IBurger";
import { IExtra } from "../../Interfaces/IExtra";
import { IOrderExtra } from "../../Interfaces/IOrderExtra";
import { IOrderSide } from "../../Interfaces/IOrderSide";
import { ISide } from "../../Interfaces/ISide";
import "./Order.css";
import { OrderCard } from "./OrderCard/OrderCard";
import  burgerLogo from '../../burger.svg'
import { useEffect, useState } from "react";
import { ITray } from "../../Interfaces/ITray";
import axios from "axios";
import { IOrderContent } from "../../Interfaces/IOrderContent";

export function Order(props: {
  burger: IBurger | undefined;
  extras: IOrderExtra[];
  extrasArr: IExtra[];
  sides: IOrderSide[];
  sidesArr: ISide[];
}) {

  let { burger, extras, extrasArr, sides, sidesArr } = { ...props };

  let [tray, setTray] = useState<ITray[]>([]);

  const addToTray = () => {
    setTray((arr:ITray[]) => [...arr, {"burger":burger,"extras":extras,"sides":sides}])
  };

  if (!burger && sides.length == 0) 
  {
    return <></>;
  }

  let price = 0;
  price += burger ? burger.price : 0;
  price += extras ? getPrices(extras, extrasArr) : 0;
  price += sides ? getPrices(sides, sidesArr) : 0;

  let names:string[] = [];

  if(burger)
  {
    names.push(burger.mealName);
  }
  
  if(extras)
  {
  names = [...names,...(getNames(extras,extrasArr))];
  }

  if(sides)
  {
  names = [...names, ...(getNames(sides,sidesArr))];
  }

  // ************************************* RETURN *************************************
  return(
    <>
      <div className="trayContainer" onClick={() => 
      {
        postData(burger,extras,sides);
      }}>
        <img className="tray-logo" src={burgerLogo} alt=""/>
        <p className='trayNumber'>{tray.length}</p>
      </div>
      <OrderCard addToTray={addToTray} burger={burger} names={names} price={price}/>
    </>
  );
}

// ************************************* FUNCTIONS *************************************

function getPrices(orders:IOrderExtra[]|IOrderSide[], arr: IExtra[]|ISide[]) : number
{
  let sum:number = 0;

  orders.map((order:any) => {
    arr.map((element) => {

      if(instanceOfIOExtra(order))
      {
        if(order.ExtraId == element.id)
        {
          sum += element.price;
        } 
      }
      else
      {
        if(order.SideId == element.id)
        {
          sum += element.price;
        }
      }
    })
  })

  return sum;
}

function getNames(orders:IExtra[]|IOrderSide[], arr: IExtra[]|ISide[]) : string[]
{
  let names:string[] = [];

  orders.map((order:any) => {
    arr.map((element) => {

      if(instanceOfIOExtra(order))
      {
        if(order.ExtraId == element.id)
        {
          names.push("- " + element.mealName + " " + element.price + "₪");
        } 
      }
      else
      {
        if(order.SideId == element.id)
        {
          names.push("* " + element.mealName + " " + element.price + "₪");
        }
      }
    })
  })
  
  return names;
}

function instanceOfIOExtra(object:any) : object is IOrderExtra
{
  return ('ExtraId' in object);
}

async function postData(burger:IBurger|undefined,extras:IOrderExtra[],sides:IOrderSide[]) 
{
  let orderContent:IOrderContent = {};

  orderContent.iOrderburger = burger;
  orderContent.iOrderExtras = extras;
  orderContent.iOrderSides = sides;

  const url = "https://localhost:7175/api/FoodOrders";
  try
  {
    axios.post(url,{
      iOrderburger:orderContent.iOrderburger,
      iOrderExtras:orderContent.iOrderExtras,
      iOrderSidesi:orderContent.iOrderSides,
      CustomerId:orderContent.CustomerId
    });
  }
  catch(err){console.log(err);}
};
