import initAlertMessage from "./alertMessage.js";

export default function initAccessCart() {
    const cartContainer = document.querySelector(".modal-cart");
    const cartButton = document.querySelector(".cart-button");
    function openOrCloseCart() {
        cartContainer.classList.toggle("cart-open")
        initAlertMessage(true)
    }
    cartButton.addEventListener("click", openOrCloseCart)
}
