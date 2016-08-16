$(document).ready(function () {
    $(".client").on("click", function () {
        var data = $(this).data("client");
        window.location.href = '/Home/DeleteClient/' + data;
    });
});