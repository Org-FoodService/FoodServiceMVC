import changeValue from "./quantityAndPrice.js";
import initRemoveCartItem from "./removeCartItem.js";

const cartContainer = document.querySelector(".modal-cart");

export default class Item {
    constructor(imgSrc, price, name) {
        this.imgSrc = imgSrc;
        this.price = price;
        this.name = name;
        this.quantity = 1;
    }

    createItem() {
        const containerItem = document.createElement("li");
        containerItem.classList.add("item");
        containerItem.innerHTML = `
            <img src="${this.imgSrc}" alt="Product Image">
            <div>
                <h1 class="productName">${this.name}</h1>
                <div class="quantity">
                    <p class="productPrice">${this.price}</p>
                    <input type="number" value="1" class="numberOfItems">
                </div>
                <span class="material-symbols-outlined delete_button">close</span>
            </div>`;

        const inputQuantityOfItems = containerItem.querySelector(".numberOfItems");
        const buttonDeleteItem = containerItem.querySelector(".delete_button");

        inputQuantityOfItems.addEventListener("change", changeValue);
        buttonDeleteItem.addEventListener("click", initRemoveCartItem);

        cartContainer.appendChild(containerItem);
    }
}
