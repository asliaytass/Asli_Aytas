$("#1").click(function () {
    $("#1").css("background", "red");
    $("#2").css("background", "");
    $("#3").css("background", "");
    event.preventDefault();
})
$("#2").click(function () {
    $("#1").css("background", "");
    $("#2").css("background", "red");
    $("#3").css("background", "");
    event.preventDefault();
})
$("#3").click(function () {
    $("#1").css("background", "");
    $("#2").css("background", "");
    $("#3").css("background", "red");
    event.preventDefault();
})