"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// ClientApp/components/Hello.ts
var vue_1 = require("vue");
exports.default = vue_1.default.extend({
    props: ['name', 'initialEnthusiasm'],
    data: function () {
        return {
            enthusiasm: this.initialEnthusiasm
        };
    },
    methods: {
        increment: function () { this.enthusiasm++; },
        decrement: function () {
            if (this.enthusiasm > 1) {
                this.enthusiasm--;
            }
        },
    },
    computed: {
        exclamationMarks: function () {
            return Array(this.enthusiasm + 1).join('!');
        }
    }
});
//# sourceMappingURL=Hello.js.map