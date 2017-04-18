function checkConnection(customer, index, arr) {
    for (i = 0; i < customer.OwnedVehicles.length; i++) {

        var currentVehicle = customer.OwnedVehicles[i];

        currentVehicle.Status = isVehicleConnected(currentVehicle);

        updateStatusOnDashboard(currentVehicle.id, currentVehicle.Status);
    }
}

function isVehicleConnected(vehicle) {
    // Generate random status to simulate the connection to the actual vehicles
    var randomNumber = Math.floor((Math.random() * 10) + 1);
    var randomStatus = (randomNumber % 2) == 0;
    return randomStatus;
}

function updateStatusOnDashboard(vehicleId, status) {
    var vehicleStatusCellId = '#' + vehicleId;
    $(vehicleStatusCellId)[0].className = status ? 'glyphicon glyphicon-ok' : 'glyphicon glyphicon-remove';
    $(vehicleStatusCellId)[0].setAttribute("data-status", status);
}

function filterCustomers() {
    // Declare variables
    var input, namefilter, statusFilter, nameCell, statusCell,
        customersRows, currentCustomerRow, vehiclesRows, currentVehicleRow, isRowEmpty;

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

    function hide(item) {
        item.style.display = "none";
    }

    function show(item) {
        item.style.display = "";
    }

    function stringContains(string, filter) {
        return nameCell.innerHTML.toUpperCase().indexOf(namefilter) > -1;
    }
}