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
            searchDataQuery: '',
            searchP1Query: '',
            searchP2Query: '',
            countFromQuery: '',
            countToQuery: '',
            sumFromQuery: '',
            sumToQuery: '',
            boolQuery: '',
            enableQuery: false,
            gridColumns: ['id', 'name', 'count', 'flag', 'sum', 'prop1Title', 'prop2Title', 'sumSubDataValues'],
            gridRows: [
            ]
        }
    },
    mounted() {
        axios.get("/api/testdata")
            .then(response => { this.gridRows = response.data }).catch(error => console.log(error));
    },
});