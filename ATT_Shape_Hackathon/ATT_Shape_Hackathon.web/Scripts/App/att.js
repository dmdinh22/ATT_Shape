var att = {
    utilities: {}
    , layout: {}
    , page: {
        handlers: {
        }
        , startUp: null
    }
    , services: {}
    , ui: {}
};

att.moduleOptions = {
    APPNAME: "attApp"
    , extraModuleDependencies: []
    , runners: []
    , page: att.page//we need this object here for later use
};

att.layout.startUp = function () {

    console.debug("att.layout.startUp");

    //this does a null check on sabio.page.startUp
    if (att.page.startUp) {
        console.debug("att.page.startUp");
        att.page.startUp();
    }
};

att.APPNAME = "attApp";//legacy
$(document).ready(att.layout.startUp);