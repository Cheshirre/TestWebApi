// ClientApp/components/DemoGrid.ts
import Vue from "vue";

interface DemoGridProps {
    rows: Array<any>;
    columns: Array<string>;
    filterKey: string;
    p1filterKey: string;
    p2filterKey: string;
    cfromfilterKey: number;
    ctofilterKey: number;
    sfromfilterKey: number;
    stofilterKey: number;
    boolfilterKey: boolean;
    enablefilterKey: boolean;
}

interface DemoGridData {
    sortKey: string;
    sortOrders: { [index: string]: number };
}

export default Vue.extend({
    template: '#demo-grid-template',
    props: ['rows', 'columns', 'filterKey', 'p1filterKey', 'p2filterKey', 'cfromfilterKey', 'ctofilterKey', 'sfromfilterKey', 'stofilterKey', 'boolfilterKey', 'enablefilterKey'],
    data: function () {
        var sortOrders: any = {};
        (this.$props as DemoGridProps).columns.forEach(function (key) {
            sortOrders[key] = 1
        })
        return {
            sortKey: '',
            sortOrders: sortOrders
        } as DemoGridData
    },
    computed: {
        filteredData: function () {
            var thisData = (this.$data as DemoGridData);
            var thisProps = (this.$props as DemoGridProps);

            var sortKey = thisData.sortKey
            var filterKey = thisProps.filterKey && thisProps.filterKey.toLowerCase()
            var p1filterKey = thisProps.p1filterKey && thisProps.p1filterKey.toLowerCase()
            var p2filterKey = thisProps.p2filterKey && thisProps.p2filterKey.toLowerCase()
            var cfromfilterKey = thisProps.cfromfilterKey
            var ctofilterKey = thisProps.ctofilterKey
            var sfromfilterKey = thisProps.sfromfilterKey
            var stofilterKey = thisProps.stofilterKey
            var boolfilterKey = thisProps.boolfilterKey
            var enablefilterKey = thisProps.enablefilterKey

            var order = thisData.sortOrders[sortKey] || 1
            var rows = thisProps.rows
            if (enablefilterKey) {
                rows = rows.filter(function (row) {
                    return (String(row.name).toLowerCase().indexOf(filterKey) > -1) && 
                        (String(row.prop1Title).toLowerCase().indexOf(p1filterKey) > -1) &&
                        (String(row.prop2Title).toLowerCase().indexOf(p2filterKey) > -1) &&
                        (Number(cfromfilterKey) ? (row.count > cfromfilterKey) : true) &&
                        (Number(ctofilterKey) ? (row.count < ctofilterKey) : true) &&
                        (Number(sfromfilterKey) ? (row.sum > sfromfilterKey) : true) &&
                        (Number(stofilterKey) ? (row.sum < stofilterKey) : true) && (row.flag == boolfilterKey)                       
                })
            }
            if (sortKey) {
                rows = rows.slice().sort(function (a, b) {
                    a = a[sortKey]
                    b = b[sortKey]
                    return (a === b ? 0 : a > b ? 1 : -1) * order
                })
            }
            return rows
        }
    },
    filters: {
        capitalize: function (str: string) {
            return str.charAt(0).toUpperCase() + str.slice(1)
        }
    },
    methods: {
        sortBy: function (key: string) {
            var thisData = (this.$data as DemoGridData);

            thisData.sortKey = key
            thisData.sortOrders[key] = thisData.sortOrders[key] * -1
        }
    }
});