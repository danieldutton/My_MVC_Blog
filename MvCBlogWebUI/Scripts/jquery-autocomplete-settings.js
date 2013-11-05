$(document).ready(function() {
    $("#Categories").bind("keydown", function(event) {
        if (event.keyCode === $.ui.keyCode.TAB && $(this).data("ui-autocomplete-input").menu.active) {
            event.preventDefault();
        }
    })

        .autocomplete({
            minLength: 0,
        source: function(request, response) {
            $.ajax({
                url: "/Admin/AutoCompleteCategory",
                type: "POST",
                dataType: "json",
                multiple: true,
                data: { term: request.term, maxRows: 12 },
                success: function(data) {
                    response($.map(data, function(item) {
                        return { label: item, value: item };
                    }));

                }
            });
        },
    });
});

function split(val) {
    return val.split(/,\s*/);
}

function extractLast(term) {
    return split(term).pop();
}

