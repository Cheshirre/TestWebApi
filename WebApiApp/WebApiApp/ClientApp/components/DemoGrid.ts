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
}

interface DemoGridData {
    sortKey: string;
    sortOrders: { [index: string]: number };
}

export default Vue.extend({
    template: '#demo-grid-template',
    props: ['rows', 'columns', 'filterKey', 'p1filterKey', 'p2filterKey', 'cfromfilterKey', 'ctofilterKey', 'sfromfilterKey', 'stofilterKey', 'boolfilterKey'],
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

            var order = thisData.sortOrders[sortKey] || 1
            var rows = thisProps.rows
            if (filterKey || p1filterKey || p2filterKey || cfromfilterKey || ctofilterKey || boolfilterKey || sfromfilterKey || stofilterKey || !boolfilterKey) {
                rows = rows.filter(function (row) {
                    return Object.keys(row).some(function (key) {
                        return (filterKey ? (key == 'name' && (String(row[key]).toLowerCase().indexOf(filterKey) > -1)) : true) &&
                            (p1filterKey ? (key == 'prop1Title' && (String(row[key]).toLowerCase().indexOf(p1filterKey) > -1)) : true) &&
                            (p2filterKey ? (key == 'prop2Title' && (String(row[key]).toLowerCase().indexOf(p2filterKey) > -1)) : true) &&
                            (cfromfilterKey || ctofilterKey ? (key == 'count' &&
                            (cfromfilterKey ? (row[key] > cfromfilterKey) : true) &&
                            (ctofilterKey ? (row[key] < ctofilterKey) : true)) : true) &&
                            (sfromfilterKey || stofilterKey ? (key == 'sum' &&
                                (sfromfilterKey ? (row[key] > sfromfilterKey) : true) &&
                                (stofilterKey ? (row[key] < stofilterKey) : true)) : true) &&
                            (boolfilterKey ? (key == 'flag' && (row[key] == boolfilterKey)) : true)
                        
                    })
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