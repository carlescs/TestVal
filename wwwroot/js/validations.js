$.validator.addMethod('test', function (value, element, params) {
    var str = value;
    for (var i = 0, len = str.length, count = 0, ch; i < len; ++i) {
        ch = str.charAt(i);
        if (ch >= 'A' && ch <= 'Z') ++count;
    }

    return count > 3;
});

$.validator.unobtrusive.adapters.add('test', function (options) {
    options.rules['test'] = [];
    options.messages['test'] = options.message;
});