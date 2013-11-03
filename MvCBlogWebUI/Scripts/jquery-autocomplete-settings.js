$(document).ready(function() {
    $("#Categories").autocomplete({
        source: function(request, response) {
            $.ajax({
                url: "/Home/AutoCompleteCategory",
                type: "POST",
                dataType: "json",
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

