$(function () {
    $('#search-form').submit(function () {
        if ($("#s").val().trim())
            return true;
        return false;
    });
});

$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})