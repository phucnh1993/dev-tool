function GetCategoryDatabaseForApplication(query) {
	var index = 1; size = 999999;
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
    	if (this.readyState == 4 && this.status == 200) {
			data = JSON.parse(xhttp.responseText);
			var selectDev = document.getElementById("txtDatabaseDevId");
			var selectUat = document.getElementById("txtDatabaseUatId");
			selectDev.innerHTML = "";
			selectUat.innerHTML = "";
			var temp = data.data;
			if (temp.length > 0 && data.total > 0) {
				var optionDefaultDev = document.createElement("option");
				optionDefaultDev.value = 0;
				optionDefaultDev.innerText = "-- Chose a value --";
				selectDev.appendChild(optionDefaultDev);
				var optionDefaultUat = document.createElement("option");
				optionDefaultUat.value = 0;
				optionDefaultUat.innerText = "-- Chose a value --";
				selectUat.appendChild(optionDefaultUat);
				for (var i = 0; i < temp.length; i++) {
					var optionDev = document.createElement("option");
					optionDev.value = temp[i].id;
					optionDev.innerText = temp[i].name;
					selectDev.appendChild(optionDev);
					var optionUat = document.createElement("option");
					optionUat.value = temp[i].id;
					optionUat.innerText = temp[i].name;
					selectUat.appendChild(optionUat);
       			}
       		}
    	}
	};
	var url = "/api/categories/databases" + '?pageIndex=' + index + '&pageSize=' + size + "&fieldSort=name&isDescSort=false";
	if (query != 'undefined' && query != null) url + query;
	xhttp.open("GET", url, true);
	xhttp.setRequestHeader("Content-type", "application/json");
	xhttp.send();
}