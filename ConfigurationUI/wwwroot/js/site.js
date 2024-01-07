// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    loadData();
});

var itemList = [];
var filteredItemList = [];

$('#searchTextBox').on('input', function (e) {
    filterList();
});

function fillTableRows() {
    var html = '';
    $.each(filteredItemList, function (key, item) {
        html += '<tr>';
        html += '<td>' + item.id + '</td>';
        html += '<td>' + item.name + '</td>';
        html += '<td>' + item.type + '</td>';
        html += '<td>' + item.value + '</td>';
        html += '<td>' + item.isActive + '</td>';
        html += '<td>' + item.applicationName + '</td>';
        html += '<td><a href="#" onclick="return getConfigurationById(' + item.id + ')">Edit</a> | <a href="#" onclick="deleteConfiguration(' + item.id + ',\'' + item.rowVersion + '\')">Delete</a></td>';
        html += '</tr>';
    });
    $('.tbody').html(html);
}

function filterList() {
    var searchText = $('#searchTextBox').val().toLowerCase();
    if (isEmptyOrSpaces(searchText)) {
        filteredItemList = itemList;
    } else {
        searchText = $.trim(searchText);
        filteredItemList = $.grep(itemList, function (elem) {
            return elem.name.toLowerCase().indexOf(searchText) > -1;
        });
    }
    fillTableRows();
}

function isEmptyOrSpaces(str) {
    return str === null || str.match(/^ *$/) !== null;
}

// Load Data function
function loadData() {
    $.ajax({
        url: "/Home/Configurations",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            itemList = result;
            filterList();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

// Add Data Function
function addConfiguration() {
    var confObj = {
        Name: $('#Name').val(),
        Type: $('#Type').val(),
        Value: $('#Value').val(),
        IsActive: $('#IsActive').val(),
        ApplicationName: $('#ApplicationName').val()
    };
    $.ajax({
        url: "/Home/AddConfiguration",
        data: JSON.stringify(confObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#AddUpdateModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function updateConfiguration() {
    var confObj = {
        ID: $('#ID').val(),
        Name: $('#Name').val(),
        Type: $('#Type').val(),
        Value: $('#Value').val(),
        IsActive: $('#IsActive').val(),
        ApplicationName: $('#ApplicationName').val(),
        RowVersion: $("#RowVersion").val()  
    };

    $.ajax({
        url: "/Home/UpdateConfiguration",
        data: JSON.stringify(confObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#AddUpdateModal').modal('hide');
            $('#ID').val("");
            $('#Name').val("");
            $('#Type').val("");
            $('#Value').val("");
            $('#IsActive').val("");
            $('#ApplicationName').val("");
            $('#RowVersion').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function getConfigurationById(ConfID) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Type').css('border-color', 'lightgrey');
    $('#Value').css('border-color', 'lightgrey');
    $('#IsActive').css('border-color', 'lightgrey');
    $('#ApplicationName').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/GetConfigurationById/" + ConfID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.id);
            $('#Name').val(result.name);
            $('#Type').val(result.type);
            $('#Value').val(result.value);
            $('#IsActive').val(result.isActive);
            $('#ApplicationName').val(result.applicationName); 
            $('#RowVersion').val(result.rowVersion);

            $('#AddUpdateModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


function deleteConfiguration(ID, rowVersion) {
    var versionEncoded = encodeURIComponent(rowVersion);
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Home/DeleteConfiguration?id=" + ID + "&rowVersion=" + versionEncoded,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
                alert("Configuration has been deleted!");
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

// Function for clearing the textboxes
function clearTextBox() {

    $('#btnUpdate').hide();
    $('#btnAdd').show();

    $('#ID').val("");
    $('#Name').val("");
    $('#Type').val("");
    $('#Value').val("");
    $('#IsActive').val("");
    $('#ApplicationName').val("");
    $('#RowVersion').val("");

    $('#Name').css('border-color', 'lightgrey');
    $('#Type').css('border-color', 'lightgrey');
    $('#Value').css('border-color', 'lightgrey');
    $('#IsActive').css('border-color', 'lightgrey');
    $('#ApplicationName').css('border-color', 'lightgrey');
}