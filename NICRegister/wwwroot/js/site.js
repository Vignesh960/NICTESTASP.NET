// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var districts = {
    "Warangal": "Chityal;gangpur",
    "Hyd": "Kukatpally;KPHB"
};
function populateOptions() {
    var districtDropdown = document.getElementById("exampleFormControlSelect1");
    var areaDropdown = document.getElementById("areaDropdown");
    var selectedDistrict = districtDropdown.options[districtDropdown.selectedIndex].value;

    // Clear the area dropdown
    areaDropdown.innerHTML = "";

    if (districts[selectedDistrict]) {
        var areas = districts[selectedDistrict].split(';');
        for (var i = 0; i < areas.length; i++) {
            var option = document.createElement("option");
            option.text = areas[i];
            option.value = areas[i];
            areaDropdown.add(option);
        }
    }
}