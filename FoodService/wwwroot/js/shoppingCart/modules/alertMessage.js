export default function initAlertMessage(result) {
    const alertMessage = document.querySelector(".alert_message");

    if (!alertMessage) {
        console.error("Alert message element not found");
        return;
    }

    if (result) {
        alertMessage.classList.remove("alertMessageOn");
    } else {
        alertMessage.classList.add("alertMessageOn");
    }
}
