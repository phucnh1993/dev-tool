function openCreateForm() {
  document.getElementById("myForm").style.display = "block";
  document.getElementById("txtId").style.display = "none";
  document.getElementById("lblId").style.display = "none";
  var children = document.querySelectorAll('div.form-container input, div.form-container select');
  for(var i = 0; i < children.length; i++) {
	if (children[i].id.includes('txt')) {
		document.getElementById(children[i].id).value = '';
		continue;
	}
	if (children[i].id.includes('com')) {
	  var options = document.getElementById(children[i].id).children;
	  for (var j = 1; j < options.length; j++) {
	  	options[j].removeAttribute('selected');
	  }
	  var att = document.createAttribute("selected");
	  document.getElementById(children[i].id).children[0].setAttributeNode(att);
	  continue;
	}
	document.getElementById(children[i].id).checked = true;
  }
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
