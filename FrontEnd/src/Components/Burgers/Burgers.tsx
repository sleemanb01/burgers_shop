
import { Loading } from '../Assets/Loading/Loading';
import { IBurger } from '../../Interfaces/IBurger';
import { BurgerCard } from './BurgerCard/BurgerCard';
import './Burgers.css'

export function Burgers(props:{setBurger:Function, setExtras:Function ,burgersArr:IBurger[],burgerIsLoading:boolean, selectedBurger:IBurger|undefined}) {

  let { setBurger, burgersArr, burgerIsLoading, selectedBurger, setExtras } = { ...props };

  if (burgerIsLoading) 
  {
    return <Loading/>
  }
 
  // ************************************* RETURN *************************************
  return (
    <div className="burgers">
        {burgersArr.map((curr,i)=>(
          <BurgerCard burger={curr} key={i} setExtras={setExtras} setBurger={setBurger} selectedBurger={selectedBurger}/>
        ))}
    </div>
  );
}
