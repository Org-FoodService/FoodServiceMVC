const alertMessage = document.querySelector(".alert_message");
export default function initAlertMessage(result) {
    if (result) {
        alertMessage.classList.remove("alertMessageOn");
    } else {
        alertMessage.classList.add("alertMessageOn");
    }
}
