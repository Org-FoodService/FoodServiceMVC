/**
 * @typedef {Object} SiteSettings
 * @property {number} id
 * @property {string} primaryColor
 * @property {string} secondaryColor
 * @property {string} backgroundColor
 * @property {string} darkColor
 * @property {string} tertiaryColor
 * @property {string} greenColor
 * @property {string} successColor
 * @property {string} dangerColor
 * @property {string} serviceName
 * @property {string|null} icon
 * @property {string|null} lastUpdate
 */

/**
 * Function to get site settings
 * @returns {Promise<SiteSettings>} A promise that resolves to the site settings
 */
export function getSiteSettings() {
    return $.ajax({
        url: '/SiteSettings/GetSiteSettings',
        type: 'GET',
        dataType: 'json'
    });
}

/**
 * Function to save site settings
 * @param {SiteSettings} settings The site settings to save
 * @returns {Promise<any>} A promise that resolves when the save is complete
 */
export function saveSiteSettings() {
    const settings = {
        Id: 1,
        PrimaryColor: $('#primaryColor').val(),
        SecondaryColor: $('#secondaryColor').val(),
        BackgroundColor: $('#backgroundColor').val(),
        TertiaryColor: $('#tertiaryColor').val(),
        DarkColor: $('#darkColor').val(),
        greenColor: $('#greenColor').val(),
        successColor: $('#successColor').val(),
        dangerColor: $('#dangerColor').val(),
        serviceName: $('#serviceName').val()
    };
    console.log(JSON.stringify(settings))
    return $.ajax({
        url: '/SiteSettings/SaveSettings',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(settings),
        dataType: 'json'
    })
        .done(function () {
            window.location.href = '/SiteSettings?' + new Date().getTime();
        })
        .fail(function (error) {
            console.error("There was an error with the request", error);
        });
}


/**
 * Set inputs in page SiteSettings
 */
export function setInputs() {
    getSiteSettings().then(response => {
        // Set the input values based on the response
        $('#primaryColor').val(response.primaryColor);
        $('#secondaryColor').val(response.secondaryColor);
        $('#tertiaryColor').val(response.tertiaryColor);
        $('#backgroundColor').val(response.backgroundColor);
        $('#darkColor').val(response.darkColor);
        $('#greenColor').val(response.greenColor);
        $('#successColor').val(response.successColor);
        $('#dangerColor').val(response.dangerColor);
        $('#serviceName').val(response.serviceName);
    }).catch(error => {
        console.error("There was an error with the request", error);
    });
}

/**
 * Initialize site settings
 */
export function initSiteSettings() {
    return getSiteSettings().then(response => {
        $('#serviceName').html(response.serviceName);

        // Set the CSS variables based on the response
        document.documentElement.style.setProperty('--primary-color', response.primaryColor);
        document.documentElement.style.setProperty('--secondary-color', response.secondaryColor);
        document.documentElement.style.setProperty('--tertiary-color', response.tertiaryColor);
        document.documentElement.style.setProperty('--background-color', response.backgroundColor);
        document.documentElement.style.setProperty('--dark-color', response.darkColor);
        document.documentElement.style.setProperty('--green-color', response.greenColor);
        document.documentElement.style.setProperty('--success-color', response.successColor);
        document.documentElement.style.setProperty('--danger-color', response.dangerColor);
    }).catch(error => {
        console.error("There was an error with the request", error);
    });
}
