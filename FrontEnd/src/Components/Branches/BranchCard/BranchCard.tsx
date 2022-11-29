import React from 'react'
import './BranchCard.css'

import { IBranch } from '../../../Interfaces/IBranch';

export function BranchCard(props:{branch:IBranch}) {

  let {branch} = { ...props};

  // ************************************* RETURN *************************************
  
  return (
    <div className='BranchCard'>
      <p className='title'>{branch.branchName}</p>
      <p className='address'>{branch.city + " " +branch.street + " " + branch.houseNum}</p>
      <p className='phone'>{branch.phone}</p>
      <p className='openingHrs'>{branch.openingHrs}</p>
    </div>
  )
}
