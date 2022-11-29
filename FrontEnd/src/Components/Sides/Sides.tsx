
import { Loading } from '../Assets/Loading/Loading';
import { ISide } from '../../Interfaces/ISide';
import { SideCard } from './SideCard/SideCard'
import './Sides.css'

export function Sides(props:{setSides:Function,sidesArr:ISide[],sideIsLoading:boolean}) {

  let { setSides, sidesArr, sideIsLoading } = { ...props };

  if (sideIsLoading) 
  {
    return <Loading />;
  }
  
  // ************************************* RETURN *************************************
  return (
    <div className="sides">
        {
          sidesArr.map((curr,i)=>(
            <SideCard side={curr} key={i} setSides={setSides}/>
          ))
        }
    </div>
  )
}
