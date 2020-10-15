$.validator.addMethod('test', function (value, element, params) {
    var str = value;
    var num = params[0];
    for (var i = 0, len = str.length, count = 0, ch; i < len; ++i) {
        ch = str.charAt(i);
        if (ch >= 'A' && ch <= 'Z') ++count;
    }

    return count >=num;
});

$.validator.unobtrusive.adapters.add('test',['num'], function (options) {
    options.rules['test'] = [parseInt(options.params['num'])];
    options.messages['test'] = options.message;
});