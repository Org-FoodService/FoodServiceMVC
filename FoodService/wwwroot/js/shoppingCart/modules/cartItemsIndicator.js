const itemsIndicatorSpan = document.querySelector(".number_cart");
const emptyCartMessage = document.querySelector(".emptyCartMessage");
const totalCartContainer = document.querySelector(".totalCart");

export default function initItemsIndicator(listItems) {
    itemsIndicatorSpan.innerHTML = listItems.length;
    if (listItems.length >= 1) {
        emptyCartMessage.classList.add("hideContainer");
        totalCartContainer.classList.add("showContainer");
    } else {
        emptyCartMessage.classList.remove("hideContainer");
        totalCartContainer.classList.remove("showContainer");
    }
}
