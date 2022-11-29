import { IBurger } from '../../../Interfaces/IBurger'
import { IOrderExtra } from '../../../Interfaces/IOrderExtra';
import logo from '../../../logo.svg'
import './OrderCard.css'

export function OrderCard(props:{ addToTray:Function, burger:IBurger | undefined, names:string[], price:number}) {

  let { burger, names, price,addToTray } = { ...props };

  // ************************************* RETURN *************************************
  return (
    <div className="orderContainer">
        <img className='orderImg' src={burger? burger.imageFileName : logo} alt="cccc" />
        <div className="names">
        {names.map((name,i)=>(
          <p className="singleName" key={i}>{name}</p>
        ))}
        </div>
        <div className="orderNow scale" onClick={() => {addToTray()}}>
          <p>Order Now </p>
        <p className='finalPrice scale'>{price + "₪"}</p>
        </div>
    </div>
  )
}
