export default function initUpdateDeletedValue() {
    const totalValueCart = document.querySelector(".totalValue");
    const totalNumberItems = document.querySelector(".totalItems");
    const cartItems = document.querySelectorAll('.item');
    const itemsArray = Array.from(cartItems);

    const takeAndFormatInformation = () => {
        const informationArray = itemsArray.map((item) => {
            const itemPrice = item.querySelector('.productPrice');
            const itemQuantity = +item.querySelector('.numberOfItems').value;
            const formattedPrice = +itemPrice.innerHTML.replace('R$', '').replace('.', '').replace(',', '.');
            return { itemQuantity, formattedPrice };
        });
        return informationArray;
    };

    const putTotalPriceAndQuantity = () => {
        const totalPrice = takeAndFormatInformation().reduce((accumulator, item) => {
            return +(accumulator + item.formattedPrice).toFixed(2);
        }, 0);

        const totalQuantity = takeAndFormatInformation().reduce((accumulator, item) => {
            return accumulator + item.itemQuantity;
        }, 0);

        totalValueCart.innerText = `R$${totalPrice}`;
        totalNumberItems.innerText = `${totalQuantity} Products`;
        return { totalPrice, totalQuantity };
    };

    putTotalPriceAndQuantity();
}
