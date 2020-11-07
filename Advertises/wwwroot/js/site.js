// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "",
        data: "{}",
        success: function (data) {
            var s = '<option value="-1">Please Select a Department</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].DepartmentID + '">' + data[i].DepartmentName + '</option>';
            }
            $("#departmentsDropdown").html(s);
        }
    });
});  