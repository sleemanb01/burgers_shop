import {  useState } from 'react'
import { ISide } from '../../../Interfaces/ISide'
import { IOrderSide } from '../../../Interfaces/IOrderSide';
import './SideCard.css'

export function SideCard(props:{side:ISide, setSides:Function}) {

  let {side,setSides} = { ...props};
  const [isActive, setActive] = useState(false);

  // ************************************* RETURN *************************************

  return (
    <div>
        <div className={isActive ? 'card active': "card"} 
         onClick={() => 
        {
          setActive(!isActive);
          if(!isActive)
          {
            let newOrderSide:IOrderSide={"SideId": side.id};
            setSides((prevSides:IOrderSide[]) => [...prevSides, newOrderSide]);
          }
          else
          {
            setSides((prevSides:IOrderSide[]) => prevSides.filter((item) => (item.SideId !== side.id)))
          }

        }}>
            <img className='cardImage' src={side.imageFileName} alt="cccc" />
            <div className="discriptionContainer">
              <p className='cardTitle'>{side.mealName}</p>
              <p className='cardDesription'>{side.mealDescription}</p>
            </div>
        </div>
    </div>
  )
}