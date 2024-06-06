import { initSiteSettings } from "./siteSettings.js";
import { LoadingComponent } from "./loading/loading.js"


var loading = new LoadingComponent()

// Show loading spinner immediately
loading.show();

// Call initSiteSettings and hide loading spinner when done
initSiteSettings().then(() => {
    // Log: initSiteSettings completed successfully
    console.log("initSiteSettings completed successfully.");
    loading.hide();
}).catch(error => {
    // Log: Error initializing site settings
    console.error("Error initializing site settings:", error);
    loading.hide();
});
