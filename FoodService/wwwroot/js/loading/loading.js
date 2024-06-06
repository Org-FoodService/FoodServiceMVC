// Loading component to display a blank screen with loading spinner
export class LoadingComponent {
    constructor() {
        this.loadingSpinner = document.getElementById("loadingSpinner");

        // Log: Loading component initialized
        console.log("Loading component initialized.");
    }

    // Show loading component
    show() {
        this.loadingSpinner.style.display = 'flex';
        // Log: Loading spinner displayed
        console.log("Loading spinner displayed.");
    }

    // Hide loading component
    hide() {
        console.log(this.loadingSpinner);
        this.loadingSpinner.style.display = 'none';
        // Log: Loading spinner hidden
        console.log("Loading spinner hidden.");
    }

}
