import React from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { ICustomer } from '../../Interfaces/ICustomer';
import secondaryLogo from '../../secondarylogo.svg'
import { cust } from '../Context/@types/cust';
import { CustContext } from '../Context/CustContext';
import "./NavBar.css";

export function NavBar() 
{
  const navigate = useNavigate();

  const custContext = React.useContext(CustContext) as cust;

  const {currCustomer, logOut} = { ...custContext };
  
// ************************************* RETURN *************************************
  return (
    <div className="navbar">
      <img className="logo"src={secondaryLogo} alt=""/>
      <div className="linksDiv">
        <div className="navLink scale" onClick={() => {navigate('/')}}>Menu</div>
        <div className="navLink scale" onClick={() => {navigate('/Branches')}}>Branches</div>
      </div>
      <div className='rightSide'>
        <div>
         {getAppropriateDiv(currCustomer, navigate, logOut)}
        </div>
        <img className="logo"src={secondaryLogo} alt=""/>
      </div>
    </div>
  );
}

// ************************************* FUNCTIONS *************************************

function getAppropriateDiv(customer:ICustomer|undefined, navigate:Function, logOut:Function)
{
  if(customer == undefined)
  {
    return(
      <>
        <div className="signUp navLink scale" onClick={() => {navigate('/signUp')}}>Register</div>
        <div className="signUp navLink scale" onClick={() => {navigate('/signIn')}}>Sign In</div>
      </>
    )
  }
  else
  {
    return <div className="signUp navLink scale" onClick={() => {logOut(undefined)}}>Sign Out</div>
  }
}

