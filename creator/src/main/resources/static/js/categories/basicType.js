function GetCategoryBasicType(query) {
	var index = 1; size = 999999;
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
    	if (this.readyState == 4 && this.status == 200) {
			data = JSON.parse(xhttp.responseText);
			var select = document.getElementById("txtBasicTypeId");
			select.innerHTML = "";
			var temp = data.data;
			if (temp.length > 0 && data.total > 0) {
				var optionDefault = document.createElement("option");
				optionDefault.value = 0;
				optionDefault.innerText = "-- Chose a value --";
				select.appendChild(optionDefault);
				for (var i = 0; i < temp.length; i++) {
					var option = document.createElement("option");
					option.value = temp[i].id;
					option.innerText = temp[i].name;
					select.appendChild(option);
       			}
       		}
    	}
	};
	var url = "/api/categories/basicTypes" + '?pageIndex=' + index + '&pageSize=' + size + "&fieldSort=name&isDescSort=false";
	if (query != 'undefined' && query != null) url + query;
	xhttp.open("GET", url, true);
	xhttp.setRequestHeader("Content-type", "application/json");
	xhttp.send();
}