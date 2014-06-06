$(document).ready(function () {
    $("input[data-val-length-max]").each(function () {
        var $this = $(this);
        var data = $this.data();
        $this.attr("maxlength", data.valLengthMax);
    });
});