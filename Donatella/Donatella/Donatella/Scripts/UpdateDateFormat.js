function getDateFormat(formatString) {
    var separator = formatString.match(/[.\/\-\s].*?/);
    var parts = formatString.split(/\W+/);
    if (!separator || !parts || parts.length === 0) {
        throw new Error("Invalid date format.");
    }
    return { separator: separator, parts: parts };
}

function MyParseDate(value, format) {
    var parts = value.split(format.separator);

    //NEVER use Date(0), this is locale specific! 
    // * en-GB: 1970-JAN-01
    // * pt-BR: 1969-DEC-31
    //var date = new Date(0);

    //An arbitrary date 1970-DEC-15
    var date = new Date(1970, 11, 15);

    var year = -1;
    var month = -1;
    var day = -1;

    if (parts.length === format.parts.length) {
        for (var i = 0, cnt = format.parts.length; i < cnt; i++) {
            var val = parseInt(parts[i], 10) || 1;

            switch (format.parts[i]) {
                case 'dd':
                case 'd':
                    day = val;
                    break;
                case 'mm':
                case 'm':
                    month = val - 1; // month is zero-based
                    break;
                case 'yyyy':
                    year = val;
                    //console.log(val);
                    break;
            }
        }
    }

    // must be in this particular order, otherwise 29th of Feb in leap year would not validate
    date.setFullYear(year);
    date.setMonth(month);
    date.setDate(day);

    //console.log("Date validated to " + date.toString());
    //console.log(date.getFullYear());
    //console.log(year);

    // we can't rely on setDay(), setMonth(), setYear() because if value passed in is greater than allowed, it just ticks over
    // to the next month/year. But we can compare if it was ticked over or not. 
    // If numbers provided are the same as resulting number, then date is fine.
    return date.getDate() === day && date.getMonth() === month && date.getFullYear() === year;
}

jQuery.validator.addMethod('date',
    function (value, element, params) {
        if (this.optional(element)) {
            return true;
        }
        try {
            var format = getDateFormat('dd/mm/yyyy');
            var result = MyParseDate(value, format);
            return result;
        } catch (err) {
            console.log(err);
            return false;
        }
    });