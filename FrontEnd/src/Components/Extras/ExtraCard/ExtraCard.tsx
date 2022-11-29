import  { useState } from 'react'
import './ExtraCard.css'
import { IExtra } from '../../../Interfaces/IExtra';
import { IOrderExtra } from '../../../Interfaces/IOrderExtra';

export function ExtraCard(props:{extra:IExtra, setExtras:Function}) {

  let {extra, setExtras} = { ...props};
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
              let newOrderExtra:IOrderExtra={"ExtraId": extra.id};
              setExtras((prevExtras:IOrderExtra[]) => [...prevExtras, newOrderExtra]);
            }
            else
            {
              setExtras((prevExtras:IOrderExtra[]) => prevExtras.filter((item) => (item.ExtraId !== extra.id)))
            }
            
          }}>
            <img className='cardImage' src={extra.imageFileName} alt="cccc" />
            <div className="discriptionContainer">
              <p className='cardTitle'>{extra.mealName}</p>
              <p className='cardDesription'>{extra.mealDescription}</p>
            </div>
        </div>
        
    </div>
  )
}