function UpdateData(urlPath, id, data) {
	urlGlobal = urlPath;
	idGlobal = id;
	headerGlobal = header;
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
    	if (this.readyState == 4 && this.status == 200) {
			data = JSON.parse(xhttp.responseText);
			if (data.errorCode === 0) {
				console.log("Update data ["+ data.data.id +"] at "+ data.data.actionOn +" in "+ data.data.runtime +" ms");
			}
			else {
				console.log("Create data error with code ["+ data.errorCode +"] and message ["+ data.message +"]");
			}
    	}
	};
	xhttp.open("PUT", urlPath + "/" + id, true);
	xhttp.setRequestHeader("Content-type", "application/json;charset=UTF-8");
	xhttp.send(JSON.stringify(data));
}