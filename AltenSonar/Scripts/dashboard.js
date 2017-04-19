// Connects to the connection checking wep api to check the status of each vehicle
function checkVehiclesConnectionStatus(customers) {
    jQuery.support.cors = true;
    $.ajax({
        url: '/api/ConnectionChecker',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(customers),
        success: function (data) {
            updateStatusOnDashboard(data);
        },
        error: function (x, y, z) {
            console.log(x + '\n' + y + '\n' + z);
        }
    });
}

// Loop on the vehicles and update their statuses on the dashboard
function updateStatusOnDashboard(customers) {
    var currentVehicle;
    for (var i = 0; i < customers.length; i++) {
        for (var j = 0; j < customers[i].OwnedVehicles.length; j++) {
            currentVehicle = customers[i].OwnedVehicles[j];
            updateVehicleStatusOnDashboard(currentVehicle.id, currentVehicle.Status);
        }
    }
    showLastRefreshTime();
}

// Updates the last refresh time label (hh:mm)
function showLastRefreshTime() {
    var date = new Date();
    document.getElementById('lblLastRefresh').innerHTML = 'Last refresh ( ' + ("0" + (date.getHours() % 12)).slice(-2) + ' : ' + date.getMinutes() + ' )';
}

// Updates the status of each vehicle on the dashboard
function updateVehicleStatusOnDashboard(vehicleId, status) {
    var vehicleStatusCellId = '#' + vehicleId;
    $(vehicleStatusCellId)[0].className = status ? 'glyphicon glyphicon-ok vehicle-td' : 'glyphicon glyphicon-remove vehicle-td';
    $(vehicleStatusCellId)[0].setAttribute("data-status", status);
}

// Filter the documents according to the user selection in the dashboard filters
function filterCustomers() {
    // Declare variables
    var input, namefilter, statusFilter, nameCell, statusCell, customersRows, currentCustomerRow, vehiclesRows, currentVehicleRow, isRowEmpty;

    input = document.getElementById("txtCustomerNameSearch");
    namefilter = input.value.toUpperCase();
    input = document.getElementById("optVehicleStatus");
    statusFilter = input.value.toUpperCase();

    // Loop through all table rows, and hide those who don't match the search query        
    customersRows = $('.customerRow');
    for (var i = 0; i < customersRows.length; i++) {

        currentCustomerRow = customersRows[i];
        nameCell = currentCustomerRow.getElementsByTagName("td")[0];
        vehiclesRows = currentCustomerRow.getElementsByTagName("tr");
        isRowEmpty = true;

        // Check if the customer name cell contains the filtered name text
        if (stringContains(nameCell, namefilter)) {
            for (var j = 0; j < vehiclesRows.length; j++) {

                currentVehicleRow = vehiclesRows[j];
                statusCell = currentVehicleRow.getElementsByTagName("td")[2];

                if (statusCell) {
                    var status = statusCell.getAttribute("data-status");
                    if (status) {
                        // Check if the vehicle status is the same as the filtered choice
                        if (status.toUpperCase() == statusFilter || statusFilter == "") {
                            show(currentVehicleRow);
                            // At least one vehicle is connected
                            isRowEmpty = false;
                        } else {
                            hide(currentVehicleRow);
                        }
                    }
                }
            }
            // Hide customers who have no connected cars
            if (isRowEmpty) {
                hide(currentCustomerRow);
            }
            else {
                show(currentCustomerRow);
            }
        }
        else {
            hide(currentCustomerRow);
        }
    }
}

// Hide control
function hide(item) {
    item.style.display = "none";
}

// Show control
function show(item) {
    item.style.display = "";
}

// Check if a string contains another string
function stringContains(string, filter) {
    return string.innerHTML.toUpperCase().indexOf(filter) > - 1;
}