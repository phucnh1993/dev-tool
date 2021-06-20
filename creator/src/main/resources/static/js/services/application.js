function GetList() {
	id = 'application';
	urlPath = '/api/applications';
	index = 1;
	size = 20;
	query = '';
	header = ['Id', 'Name', 'Description', 'Is Activated', 'Basic Type Id', 'Basic Type Name', 'Database DEV Id', 'Database UAT Id'];
	BuildTable(id, urlPath, index, size, query, header);
}

function CreateOne() {
	urlPath = '/api/applications';
	data = {
		'name': document.getElementById('txtName').value,
		'description': document.getElementById('txtDescription').value,
		'isActivated': document.getElementById('isActivated').checked,
		'basicTypeId': document.getElementById('txtBasicTypeId').value,
		'databaseDevId': document.getElementById('txtDatabaseDevId').value,
		'databaseUatId': document.getElementById('txtDatabaseDevId').value
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
	urlPath = '/api/applications';
	var idData = document.getElementById('txtId').value;
	if (idData != null && idData != 'undefined') {
		data = {
			'name': document.getElementById('txtName').value,
			'description': document.getElementById('txtDescription').value,
			'isActivated': document.getElementById('isActivated').checked,
			'basicTypeId': document.getElementById('txtBasicTypeId').value,
			'databaseDevId': document.getElementById('txtDatabaseDevId').value,
			'databaseUatId': document.getElementById('txtDatabaseDevId').value
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
