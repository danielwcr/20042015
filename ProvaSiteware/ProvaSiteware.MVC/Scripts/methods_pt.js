﻿jQuery.validator.methods.number = function (value, element) {
    var val = Globalize.parseFloat(value);
    return this.optional(element) ||
        (val);
}

jQuery.validator.methods.date = function (value, element) {
    var val = Globalize.parseDate(value);
    return this.optional(element) ||
        (val);
}

$(function () {

    Globalize.culture('pt-BR');

    jQuery.extend(jQuery.validator.methods, {
        range: function (value, element, param) {
            //Use the Globalization plugin to parse the value
            var val = Globalize.parseFloat(value);
            return this.optional(element) || (
                val >= param[0] && val <= param[1]);
        }
    });

});