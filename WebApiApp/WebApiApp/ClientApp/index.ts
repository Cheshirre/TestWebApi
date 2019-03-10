// ClientApp/index.ts
import Vue from "vue";
import AppGrid from "./components/AppGrid";

let v = new Vue({
    el: "#app-root",
    render: h => h(AppGrid),
    components: {
        AppGrid
    }
});