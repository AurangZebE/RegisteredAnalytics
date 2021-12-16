// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#btnLogin").on("click", function () {
    $.ajax({
        url: '/Account/VerifyUser',
        type: 'POST',
        data: { username: $("#txtUsername").val(), password: $("#textPassword").val()},
        success: function (data) {
            console.log("YAY!" + data);
            if (data) {
                window.location.href = window.location.origin + "/Dashboard/Index";
            }
            else {
                alert("Wrong credentials!");
            }
        }
    });
});
$("#btnClosePopUp").on("click", function () {
    $(this).parents(".popUp-overlay").hide();
});
$(window).on("load", function () {
    $("#tblAnalytics").fancyTable({
        pagination: true,
        perPage: 5,
        sortable: true
    });
    $("#tblAnalytics thead th:first-child").hide();
    $("#tblAnalytics tbody td:first-child").hide();
    $("table#tblAnalytics .fancySearchRow th:last-child input").hide();
    $("#tblAnalytics").show();
});
$("#btnLogOut").on("click", function () {
    $.ajax({
        url: '/Account/LogOut',
        type: 'GET',
        success: function (data) {
            console.log("YAY!" + data);
            if (data) {
                window.location.href = window.location.origin + "/Dashboard/Index";
            }
            else {
                alert("Wrong credentials!");
            }
        }
    });
});
$(".btnEdit").on("click", function () {
    $(".popUp-overlay .popup-title h3").html("Edit Details");
    var htmlContent = "<table>";
    $($(this).parent("td").siblings("td")).each(function (i) {
        var n = i + 1;
        if (n !== 1)
            htmlContent += "<tr><th>" + $("thead th:nth-child(" + n + ")").text() + ": </th><td><input type='text' value='" + $(this).html() + "' id='" + $.trim($("thead th:nth-child(" + n + ")").text().toLowerCase().replace(" ","")) + "' /></td></tr>";
    });
    htmlContent += "</table>";
    $(".popUp-overlay .popup-body").html(htmlContent);
    $(".popUp-overlay .popup-footer").html("<a href='javascript:;' class='btnAction' id='btnUpdateDetails'>Update</a><a href='javascript:;' class='btnAction' style='margin-left:10px;background:#000' id='btnClosePopup'>Cancel</a>");
    $(".popUp-overlay").css("display","block");
});
$(document).on("click", "#btnUpdateDetails", function () {
    var onjUserDetails = {
        Id: $(".popUp-overlay #id").val(),
        ListOfUsers: null,
        Password: $(".popUp-overlay #analyticstype").val(),
        UserName: $(".popUp-overlay #analyticsname").val()
        
    };
    $.ajax({
        type: "POST",
        url: "/Account/Edit",
        data: {
            Id: $(".popUp-overlay #id").val(),
            ListOfUsers: null,
            Password: $(".popUp-overlay #analyticstype").val(),
            UserName: $(".popUp-overlay #analyticsname").val()

        },
        success: function (msg) {
            alert(msg);
        }
    });
});
$(".btnView").on("click", function () {
    $(".popUp-overlay .popup-title h3").html("");
    var htmlContent = "<table>";
    $($(this).parent("td").siblings("td")).each(function (i) {
        var n = i + 1;
        if (n == 1)
            htmlContent += "<tr style='display:none'><th>" + $("thead th:nth-child(" + n + ")").text() + ": </th><td><span>" + $(this).html() + "' id='" + $.trim($("thead th:nth-child(" + n + ")").text().toLowerCase().replace(" ", "")) + "</span></td></tr>";
        else
            htmlContent += "<tr><th>" + $("thead th:nth-child(" + n + ")").text() + ": </th><td><span>" + $(this).html() + "' id='" + $.trim($("thead th:nth-child(" + n + ")").text().toLowerCase().replace(" ", "")) + "</span></td></tr>";
    });
    htmlContent += "</table>";
    $(".popUp-overlay .popup-body").html(htmlContent);
    $(".popUp-overlay").css("display", "block");
});