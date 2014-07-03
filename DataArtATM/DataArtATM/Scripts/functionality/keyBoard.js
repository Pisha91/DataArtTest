function setKeyBoard(inputSelector, limit) {
    $('a.key').click(function () {
        var key = $(this).attr('data-value');
        var value = $(inputSelector).val();
        if (limit && !isNaN(limit)) {
            if (value.length < 4) {
                $(inputSelector).val(value + key);
            }
        } else {
            $(inputSelector).val(value + key);
        }
    });

    setClearButton(inputSelector);
}

function setCardKeyBoard(inputSelector) {
    $('a.key').click(function () {
        var key = $(this).attr('data-value');
        var value = $(inputSelector).val();
        var number = value.replace(/-/g, '');
        if (number.length < 16) {
            if (number.length != 0 && number.length % 4 == 0) {
                $(inputSelector).val(value + '-' + key);
            } else {
                $(inputSelector).val(value + key);
            }
        }
    });

    setClearButton(inputSelector);
}

function setClearButton(inputSelector) {
    $('a.clear').click(function () {
        $(inputSelector).val('');
    });
}