import Vue from "vue";
import axios from "axios";
import DemoGrid from "./DemoGrid";

export default Vue.extend({
    template: '#app-grid-template',
    components: {
        DemoGrid
    },
    data: function () {
        return {
            searchQuery: '',
            gridColumns: ['id', 'name', 'count', 'flag', 'sum'],
            gridRows: [
            ]
        }
    },
    mounted() {
        axios.get("/api/testdata")
            .then(response => { this.gridRows = response.data }).catch(error => console.log(error));
    },
});