import initAlertMessage from "./alertMessage.js";
import initCartItemsIndicator from "./cartItemsIndicator.js";
import Item from "./createCartItem.js";
import initTotalCartValue from "./totalCartValue.js";
import { listItemsCart } from "../index.js";

export function initAddItemsToCart() {
    const buttonsAddItemToCart = document.querySelectorAll(".btnAddCart");
    function takeItemInformation({ target }) {
        const itemCart = target.parentElement.parentElement;
        const itemInformations = itemCart.querySelectorAll("[data-informations]");
        const itemImageSrc = itemInformations[0].getAttribute("src");
        const itemPrice = itemInformations[1].innerHTML;
        const itemName = itemInformations[2].innerHTML;
        addItemToCart(itemImageSrc, itemPrice, itemName);
    }
    buttonsAddItemToCart.forEach(button => button.addEventListener("click", takeItemInformation));
}
export function addItemToCart(itemImg, itemPrice, itemName) {
    const itemExistsInCart = listItemsCart.some((item) => item.name === itemName);
    if (!itemExistsInCart) {
        initAlertMessage(true);
    } else {
        initAlertMessage(false);
        return;
    }
    const newItemCart = new Item(itemImg, itemPrice, itemName);
    newItemCart.createItem();
    listItemsCart.push(newItemCart);
    initCartItemsIndicator(listItemsCart);
    initTotalCartValue();
}