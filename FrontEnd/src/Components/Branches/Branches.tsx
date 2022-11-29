import React, { useEffect, useState } from "react";
import "./Branches.css";

import { BranchCard } from "./BranchCard/BranchCard";
import { IBranch } from "../../Interfaces/IBranch";
import axios from "axios";

export function Branches() {

 const [branchesArr, setBranchesArr] = useState<IBranch[]>([]);

 useEffect(() => {
  axios.get("https://localhost:7175/api/branch")
  .then((response)=>
  {
    setBranchesArr(response.data);
  })
 },[]);

 // ************************************* RETURN *************************************
  return (
    <div className="Branch">
      <h1>Branches</h1>
      <div className="branchContainer">
        {branchesArr.map((curr,i)=>(
          <BranchCard branch={curr} key={i} />
        ))}
      </div>
    </div>
  );
}
