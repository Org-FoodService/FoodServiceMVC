import { listItemsCart } from "../index.js";

export default function initTotalCartValue(newQuantity) {
    const totalItems = document.querySelector(".totalItems");
    const totalValue = document.querySelector(".totalValue");
    const formattedTotalValue = +totalValue.innerHTML.replace("R$", "");
    const totalQuantityOfItems = listItemsCart.reduce((accumulator, item) => {
        return accumulator + item.quantity;
    }, 0);

    if (newQuantity) {
        const newValue = +newQuantity.toFixed(2) + formattedTotalValue;
        totalValue.innerHTML = `R$${newValue.toFixed(2)}`;
    } else {
        const totalValueOfItems = listItemsCart.reduce((accumulator, item) => {
            const formattedValue = +item.price.replace("R$", "").replace(".", "").replace(",", ".");
            return accumulator + formattedValue;
        }, 0);
        totalValue.innerHTML = `R$${totalValueOfItems.toFixed(2)}`;
    }
    totalItems.innerHTML = `${totalQuantityOfItems} Itens`;
}
