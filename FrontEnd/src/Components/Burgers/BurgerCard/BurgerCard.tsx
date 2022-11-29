import { useEffect } from "react";
import { IBurger } from "../../../Interfaces/IBurger";
import "./BurgerCard.css";

export function BurgerCard(props: {
  burger: IBurger;
  setExtras: Function;
  setBurger: Function;
  selectedBurger: IBurger | undefined;
}) {
  let { burger, setBurger, selectedBurger, setExtras } = { ...props };

  useEffect(() => {
    if (selectedBurger == undefined) {
      setExtras([]);
    }
  }, [selectedBurger]);

  // ************************************* RETURN *************************************
  return (
    <div>
      <div
        className={selectedBurger?.id == burger.id ? "card active" : "card"}
        onClick={() => {
          setBurger(() =>
            selectedBurger?.id != burger.id ? burger : undefined
          );
        }}
      >
        <img className="cardImage" src={burger.imageFileName} alt="cccc" />
        <div className="discriptionContainer">
          <p className="cardTitle">{burger.mealName}</p>
          <p className="cardDesription">{burger.mealDescription}</p>
        </div>
      </div>
    </div>
  );
}
