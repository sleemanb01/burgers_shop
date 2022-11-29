import { Loading } from '../Assets/Loading/Loading';
import { IBurger } from '../../Interfaces/IBurger';
import { IExtra } from '../../Interfaces/IExtra';
import { ExtraCard } from './ExtraCard/ExtraCard';
import './Extras.css'

export function Extras(props:{extrasArr:IExtra[], burger:IBurger|undefined, setExtras:Function, extraIsLoading:boolean}) {

  let { setExtras, extrasArr, burger, extraIsLoading } = { ...props };

  // ************************************* RETURN *************************************

  if(!burger)
  {
    return (<></>)
  }

  if (extraIsLoading) {
    return <Loading />;
  }

  return (
    <div className="burgers">
        {extrasArr.map((extra,i)=>(
          <ExtraCard extra={extra} key={i} setExtras={setExtras}/>
        ))}
    </div>
  )
}

