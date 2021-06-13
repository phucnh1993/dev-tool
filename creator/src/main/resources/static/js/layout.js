function LoadLayout() {
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
    	if (this.readyState == 4 && this.status == 200) {
       		document.getElementById("layout").innerHTML = xhttp.responseText;
    	}
	};
	xhttp.open("GET", "/html/layout/header.html", true);
	xhttp.setRequestHeader("Content-type", "text/html; charset=UTF-8");
	xhttp.send();
}