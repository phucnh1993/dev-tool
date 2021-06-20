function openCreateForm() {
  document.getElementById("myForm").style.display = "block";
  document.getElementById("txtId").style.display = "none";
  document.getElementById("lblId").style.display = "none";
}

function openUpdateForm() {
  document.getElementById("myForm").style.display = "block";
  document.getElementById("txtId").style.display = "block";
  document.getElementById("lblId").style.display = "block";
}

function closeForm() {
  	document.getElementById("myForm").style.display = "none";
  	var child = document.querySelectorAll('div.form-container input');
  	for(var i = 0; i < child.length; i++) {
		document.getElementById(child[i].id).value = "";
  	}
}
