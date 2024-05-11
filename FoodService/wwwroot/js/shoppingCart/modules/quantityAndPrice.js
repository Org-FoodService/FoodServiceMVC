import { listItemsCart } from "../index.js";
import initTotalCartValue from "./totalCartValue.js";

export default function changeValue({ target }) {
    const inputParent = target.parentElement;
    const valueItem = inputParent.querySelector(".productPrice");
    const inputItem = inputParent.querySelector("input");
    const productName = inputParent.parentElement.querySelector(".productName").innerHTML;
    const itemInObjectList = listItemsCart.filter(item => item.name === productName);
    const formattedValue = +itemInObjectList[0].price.replace("R$", "").replace(".", "").replace(",", ".");
    let result = (formattedValue * (+inputItem.value)).toFixed(2);

    if (+inputItem.value <= 1) {
        valueItem.innerHTML = itemInObjectList[0].price;
        inputItem.value = 1;
        itemInObjectList[0].quantity = 1;
        initTotalCartValue();
    } else {
        valueItem.innerHTML = `R$${result.replace(/\./g, ",")}`;
        itemInObjectList[0].quantity = +inputItem.value;
        initTotalCartValue(result - formattedValue);
    }
}
