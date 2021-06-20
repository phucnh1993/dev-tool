function GetList() {
	id = 'basic_type';
	urlPath = '/api/basicTypes';
	index = 1;
	size = 20;
	query = '';
	header = ['Id', 'Name', 'Description', 'Sort', 'Is Activated'];
	BuildTable(id, urlPath, index, size, query, header);
}

function CreateOne() {
	urlPath = '/api/basicTypes';
	data = {
		'name': document.getElementById('txtName').value,
		'description': document.getElementById('txtDescription').value,
		'sort': document.getElementById('txtSort').value,
		'isActivated': document.getElementById('isActivated').checked
	};
	CreateData(urlPath, data);
	var child = document.querySelectorAll('div.form-container input');
  	for(var i = 0; i < child.length; i++) {
		document.getElementById(child[i].id).value = "";
  	}
  	document.getElementById('data-table').innerHTML = "";
  	GetList();
  	document.getElementById("myForm").style.display = "none";
}

function UpdateOne() {
	urlPath = '/api/basicTypes';
	var idData = document.getElementById('txtId').value;
	if (idData != null && idData != 'undefined' && idData != "") {
		data = {
			'name': document.getElementById('txtName').value,
			'description': document.getElementById('txtDescription').value,
			'sort': document.getElementById('txtSort').value,
			'isActivated': document.getElementById('isActivated').checked
		};
		UpdateData(urlPath, idData, data);
		var child = document.querySelectorAll('div.form-container input');
  		for(var i = 0; i < child.length; i++) {
			document.getElementById(child[i].id).value = "";
  		}
  		document.getElementById('data-table').innerHTML = "";
  		GetList();
  		document.getElementById("myForm").style.display = "none";
  		return;
  	}
  	CreateOne();
}
