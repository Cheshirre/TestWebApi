System.register("components/DemoGrid", ["vue"], function (exports_1, context_1) {
    "use strict";
    var vue_1;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [
            function (vue_1_1) {
                vue_1 = vue_1_1;
            }
        ],
        execute: function () {
            exports_1("default", vue_1.default.extend({
                template: '#demo-grid-template',
                props: ['rows', 'columns', 'filterKey', 'p1filterKey', 'p2filterKey', 'cfromfilterKey', 'ctofilterKey', 'sfromfilterKey', 'stofilterKey', 'boolfilterKey'],
                data: function () {
                    var sortOrders = {};
                    this.$props.columns.forEach(function (key) {
                        sortOrders[key] = 1;
                    });
                    return {
                        sortKey: '',
                        sortOrders: sortOrders
                    };
                },
                computed: {
                    filteredData: function () {
                        var thisData = this.$data;
                        var thisProps = this.$props;
                        var sortKey = thisData.sortKey;
                        var filterKey = thisProps.filterKey && thisProps.filterKey.toLowerCase();
                        var p1filterKey = thisProps.p1filterKey && thisProps.p1filterKey.toLowerCase();
                        var p2filterKey = thisProps.p2filterKey && thisProps.p2filterKey.toLowerCase();
                        var cfromfilterKey = thisProps.cfromfilterKey;
                        var ctofilterKey = thisProps.ctofilterKey;
                        var sfromfilterKey = thisProps.sfromfilterKey;
                        var stofilterKey = thisProps.stofilterKey;
                        var boolfilterKey = thisProps.boolfilterKey;
                        var order = thisData.sortOrders[sortKey] || 1;
                        var rows = thisProps.rows;
                        if (filterKey || p1filterKey || p2filterKey || cfromfilterKey || ctofilterKey || boolfilterKey || !boolfilterKey) {
                            rows = rows.filter(function (row) {
                                return Object.keys(row).some(function (key) {
                                    return (filterKey ? (key == 'name' && (String(row[key]).toLowerCase().indexOf(filterKey) > -1)) : true) &&
                                        (p1filterKey ? (key == 'prop1Title' && (String(row[key]).toLowerCase().indexOf(p1filterKey) > -1)) : true) &&
                                        (p2filterKey ? (key == 'prop2Title' && (String(row[key]).toLowerCase().indexOf(p2filterKey) > -1)) : true) &&
                                        (cfromfilterKey || ctofilterKey ? (key == 'count' &&
                                            (cfromfilterKey ? (row[key] > cfromfilterKey) : true) &&
                                            (ctofilterKey ? (row[key] < ctofilterKey) : true)) : true) &&
                                        (sfromfilterKey ? (key == 'sum' && (row[key] > sfromfilterKey)) : true) &&
                                        (boolfilterKey ? (key == 'flag' && (row[key] == boolfilterKey)) : true);
                                });
                            });
                        }
                        if (sortKey) {
                            rows = rows.slice().sort(function (a, b) {
                                a = a[sortKey];
                                b = b[sortKey];
                                return (a === b ? 0 : a > b ? 1 : -1) * order;
                            });
                        }
                        return rows;
                    }
                },
                filters: {
                    capitalize: function (str) {
                        return str.charAt(0).toUpperCase() + str.slice(1);
                    }
                },
                methods: {
                    sortBy: function (key) {
                        var thisData = this.$data;
                        thisData.sortKey = key;
                        thisData.sortOrders[key] = thisData.sortOrders[key] * -1;
                    }
                }
            }));
        }
    };
});
System.register("components/AppGrid", ["vue", "axios", "components/DemoGrid"], function (exports_2, context_2) {
    "use strict";
    var vue_2, axios_1, DemoGrid_1;
    var __moduleName = context_2 && context_2.id;
    return {
        setters: [
            function (vue_2_1) {
                vue_2 = vue_2_1;
            },
            function (axios_1_1) {
                axios_1 = axios_1_1;
            },
            function (DemoGrid_1_1) {
                DemoGrid_1 = DemoGrid_1_1;
            }
        ],
        execute: function () {
            exports_2("default", vue_2.default.extend({
                template: '#app-grid-template',
                components: {
                    DemoGrid: DemoGrid_1.default
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
                        gridColumns: ['id', 'name', 'count', 'flag', 'sum', 'prop1Title', 'prop2Title', 'sumSubDataValues'],
                        gridRows: []
                    };
                },
                mounted: function () {
                    var _this = this;
                    axios_1.default.get("/api/testdata")
                        .then(function (response) { _this.gridRows = response.data; }).catch(function (error) { return console.log(error); });
                },
            }));
        }
    };
});
System.register("index", ["vue", "components/AppGrid"], function (exports_3, context_3) {
    "use strict";
    var vue_3, AppGrid_1, v;
    var __moduleName = context_3 && context_3.id;
    return {
        setters: [
            function (vue_3_1) {
                vue_3 = vue_3_1;
            },
            function (AppGrid_1_1) {
                AppGrid_1 = AppGrid_1_1;
            }
        ],
        execute: function () {
            v = new vue_3.default({
                el: "#app-root",
                render: function (h) { return h(AppGrid_1.default); },
                components: {
                    AppGrid: AppGrid_1.default
                }
            });
        }
    };
});
//# sourceMappingURL=main.js.map