import axios, { AxiosError } from 'axios';
import React from 'react';
import { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { ICustomer } from '../../Interfaces/ICustomer';
import { cust } from '../Context/@types/cust';
import {CustContext} from '../Context/CustContext';
import './SignUp.css'

export function SignUp() {

    // **************** GLOBAL CONFIGURATIONS ***************
const awareColor = "#FFA500";
const invColor = "red";
const vColor = "green";

const minPassLength = 10;
const tellLength = 10;
const minNames = 2;

// **************** PASSWORD VALIDATION ***************
function valPass()
{
    const password = (document.querySelector("#password")as HTMLInputElement).value;

    let passwordLength = document.querySelector("#passwordLength") as HTMLDivElement;
    let passwordUpper = document.querySelector("#passwordUpper") as HTMLDivElement;
    let passwordLower = document.querySelector("#passwordLower") as HTMLDivElement;
    let passwordSpecial = document.querySelector("#passwordSpecial") as HTMLDivElement;
    let passwordDigit = document.querySelector("#passwordDigit") as HTMLDivElement;
    
    let flags = [false,false,false,false,false];
    let vldContext = [passwordLength,passwordUpper,passwordLower,passwordSpecial,passwordDigit];

    if(password.length > minPassLength)
    {
        flags[0] = true;
    }

    for(let i=0; i < password.length; i++)
    {
        if(/[A-Z]/.test(password))
        {
            flags[1] = true;
        }

        if(/[a-z]/.test(password))
        {
            flags[2] = true;
        }

        if(/[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/.test(password))
        {
            flags[3] = true;
        }

        if(/[0-9]/.test(password))
        {
            flags[4] = true;
        }
    }

    for(let i = 0; i < flags.length; i++)
    {
        changeStyle(vldContext[i], flags[i]);
    }
    
    checkrePassword();
}

// **************** RE-PASSWORD VALIDATION ***************
function valRePass ()
{
    checkrePassword();
}

// **************** CHECK REPASSWORD ***************
function checkrePassword()
{
    const password = (document.querySelector("#password") as HTMLInputElement).value;
    const repassword = (document.querySelector("#repassword")as HTMLInputElement).value;

    let passwordMatched = document.querySelector("#passwordMatched") as HTMLDivElement;
    let isValid = false;

    if(
        (password.substring(0,repassword.length) === repassword) && 
        (password.length > 0) &&
        (repassword.length > 0) &&
        (password.length >= repassword.length) 
        )
    {
        isValid = true;
    }

    changeStyle(passwordMatched, isValid);
}

// **************** EMAIL VALIDATION ***************
function valEmail()
{

    const email = (document.querySelector("#email") as HTMLInputElement).value;

    let emailDiv = document.querySelector("#emailDiv") as HTMLInputElement;

    changeStyle(emailDiv, validateEmail(email));
}

// **************** VALIDATE EMAIL ***************
function validateEmail(email:string)
{
    const regexp = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);

    return regexp.test(email);
}

// **************** PHONE VALIDATION ***************
function valTelNo()
{

    const telNo = (document.querySelector("#telNo") as HTMLInputElement).value;

    let telNoDiv = document.querySelector("#telNoDiv") as HTMLInputElement;

    changeStyle(telNoDiv, /^\d{10}$/.test(telNo));
}

// **************** NAME VALIDATION ***************
function nameValidation()
{
    const fName = (document.querySelector("#fName") as HTMLInputElement).value;
    const lName = (document.querySelector("#lName") as HTMLInputElement).value;

    let nameDiv = (document.querySelector("#nameDiv") as HTMLDivElement);

    changeStyle(nameDiv, ((fName.length > minNames) && (lName.length > minNames)) ? true: false);
}

// **************** GENDER VALIDATION ***************
function genderValidation()
{
    const genderSelect = document.querySelector("#genderSelect") as HTMLSelectElement;
    const genderSelectDiv = document.querySelector("#genderSelectDiv") as HTMLElement;

    changeStyle(genderSelectDiv, (genderSelect.value !== "I am...") ? true: false);
}

// **************** BIRTHDAY VALIDATION ***************
function birthdayValidation()
{
    const currYear = parseInt(new Date().getFullYear().toString());

    const day = parseInt((document.querySelector("#day") as HTMLInputElement).value);
    const month = (document.querySelector("#monthSelect") as HTMLSelectElement).value;
    const year = parseInt((document.querySelector("#year") as HTMLInputElement).value);

    let birthdayDiv = document.querySelector("#birthdayDiv") as HTMLDivElement;

    changeStyle(birthdayDiv, ((day > 0) && (day < 32) && (year < currYear) && (year > (currYear - 100))) ? true : false);
}

// **************** FORM SUBMIT ***************
function formSubmit(setCustomer:Function)
{   
    let isValid = true;

    nameValidation();
    genderValidation();
    birthdayValidation();

    const children = document.querySelectorAll(".instructions");

    children.forEach((child) => {
        let currColor = (child as HTMLElement).style.color;
        if((currColor === invColor) || (currColor === ''))
        {
            isValid = false;
        }
    })
    
    if(isValid)
    {
        uploadData(setCustomer);
    }
}

// **************** CHANGE STYLE ***************
function changeStyle(htmlElement:HTMLElement, isValid:boolean)
{
    if(isValid)
    {
        htmlElement.innerHTML = htmlElement.innerHTML.replace('✗','✓');
        htmlElement.style.color = vColor;   
    }
    else
    {
        htmlElement.innerHTML = htmlElement.innerHTML.replace('✓', '✗');
        htmlElement.style.color = invColor;
    }
}

const [customer, setCustomer] = useState<ICustomer | undefined>(undefined);

const custContext = React.useContext(CustContext) as cust;

const { logIn } = { ...custContext };

if(customer != undefined)
{
    logIn(customer);
    window.location.href = 'http://localhost:3000/';
}


// ************************************* RETURN *************************************

  return (
<div className="container">

  <label>Name</label>
  <div className="instructions" id="nameDiv">First & Last name must be 2-10 letters</div>

  <div className="block">
    <input className="halfBlock" id="fName" type="text" placeholder="First" /> 
    <input className="halfBlock" id="lName" type="text" placeholder="Last" />
  </div>

  <label>Choose your username</label>
  <div className="instructions" id="emailDiv">Email must be valid</div>

  <div className="block">
    <input className="email" type="email" placeholder="@gmail.com" id="email" onBlur={() => {valEmail()}}/>
  </div>

  <label>Create a password</label>

  <div className="block">
    <input type="password" placeholder="**********" id="password" onInput={() => {valPass()}}/>
  </div>

  <label >Confirm your password</label>

  <div className="block">
    <input type="password" placeholder="**********" id="repassword" onInput={() => {valRePass()}}/>
    <div className="instructions" id="passwordLength">✗ At least 10 characters and maximum 12</div>
    <div className="instructions" id="passwordUpper">✗ At least one UPPER case</div>
    <div className="instructions" id="passwordLower">✗ At least one lower case</div>
    <div className="instructions" id="passwordSpecial">✗ A special character</div>
    <div className="instructions" id="passwordDigit">✗ At least one digit (0-9)</div>
    <div className="instructions" id="passwordMatched">✗ Passwords must match</div>
  </div>

  <label>Birthday</label>
  <div className="instructions" id="birthdayDiv">Date must be valid</div>

  <div className="block">
    <select id="monthSelect" className="threeBlocks">
    <option value="January">January</option>
    <option value="February">February</option>
    <option value="March">March</option>
    <option value="April">April</option>
    <option value="May">May</option>
    <option value="June">June</option>
    <option value="July">July</option>
    <option value="August">August</option>
    <option value="September">September</option>
    <option value="October">October</option>
    <option value="November">November</option>
    <option value="December">December</option>
    </select>

    <input className="threeBlocks"  type="number" placeholder="Day" name="day" min="1" max="31" id="day"/>
    <input className="threeBlocks" type="number" placeholder="Year" min="1919" max="2019" step="1" id="year"/>
  </div>

  <label>Gender</label>
  <div className="instructions" id="genderSelectDiv">Select gender</div>

  <div className="block">
    <select id="genderSelect" name="gender">
    <option value="Male">Male</option>
    <option value="Female">Female</option>
    </select>
  </div>

  <label>Mobile phone</label>
  <div className="instructions" id="telNoDiv">Phone must be 10 digits</div>

  <div className="block">
    <input id="telNo" name="telNo" type="tel" placeholder="123 123 1234" onBlur={() => {valTelNo()}}/> 
  </div>

<div className="block">
<input type="button" value={"submit"} onClick={() => {formSubmit(setCustomer)}}/>
</div>

</div>
  )
}

// ************************************* FUNCTIONS *************************************

async function uploadData(setCustomer:Function)
{

    let dateString = (document.querySelector("#year") as HTMLInputElement).value +
    "-" +
    (document.querySelector("#monthSelect") as HTMLInputElement).value +
    "-" + "" +
    (document.querySelector("#day") as HTMLInputElement).value;

    let tempUser: ICustomer = {
        Fname: (document.querySelector("#fName") as HTMLInputElement).value,
        Lname: (document.querySelector("#lName") as HTMLInputElement).value,
        Phone: (document.querySelector("#telNo") as HTMLInputElement).value,
        Pass: (document.querySelector("#password") as HTMLInputElement).value,
        Email: (document.querySelector("#email") as HTMLInputElement).value,
        Bdate: new Date(dateString)
      };

      const url = "https://localhost:7175/api/Customers";
      try
      {
        let response = await axios.post<ICustomer>(url,
            {
                Fname:tempUser.Fname,
                Lname:tempUser.Lname,
                Phone:tempUser.Phone,
                Pass:tempUser.Pass,
                Email:tempUser.Email,
                Bdate:tempUser.Bdate
            });
            
            setCustomer(response.data as ICustomer);
            }
            catch(error)
            {
                const err = error as AxiosError
                console.log(err.response?.data)
            }
}
