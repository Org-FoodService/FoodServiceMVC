import { listItemsCart } from "../index.js";
import initCartItemsIndicator from "./cartItemsIndicator.js";
import initUpdateDeletedValue from "./updateDeletedValue.js";

export default function initRemoveCartItem({ target }) {
    const htmlItem = target.parentElement;
    const productName = htmlItem.querySelector(".productName").innerHTML;
    const filteredItem = listItemsCart.filter(item => item.name === productName);
    const indexToRemove = listItemsCart.findIndex(item => item.name === productName);

    listItemsCart.splice(indexToRemove, 1);
    htmlItem.parentElement.remove();
    initCartItemsIndicator(listItemsCart);
    initUpdateDeletedValue();
}
