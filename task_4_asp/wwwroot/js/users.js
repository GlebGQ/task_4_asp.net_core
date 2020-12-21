$("#selectAll").on("click", function () {
    if ($(this).prop("checked") == true) {
        $("#unSelectAll").prop("checked", false);
        $(".userCheckBox").prop("checked", true);
    }
})

$("#unSelectAll").on("click", function () {
    if ($(this).prop("checked") == true) {
        $("#selectAll").prop("checked", false);
        $(".userCheckBox").prop("checked", false);
    }
})