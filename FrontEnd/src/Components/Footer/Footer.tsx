import React from 'react'
import { useNavigate } from 'react-router-dom';
import SocialFlow from '../Assets/SocialFlow/SocialFlow';
import './Footer.css'

export function Footer() {
  
  const navigate = useNavigate();

  // ************************************* RETURN *************************************

  return (
    <div className='footer'>
      <div className="icons">
         <SocialFlow />
      </div>
      <div className="discreption">
      <p> Contact us: 054-88-795-22</p>
      </div>
      <div className="routers">
        <div className="navLink scale" onClick={() => {navigate('/About')}}>About</div>
        </div>
      </div>
  )
}
