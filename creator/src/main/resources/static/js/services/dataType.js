function GetList() {
	id = 'basic_type';
	urlPath = '/api/dataTypes';
	index = 1;
	size = 20;
	query = '';
	header = ['Id', 'Name', 'Description', 'Sort', 'Is Activated', 'GroupId', 'GroupName', 'CodeId', 'CodeName'];
	column = ['txtId', 'txtName', 'txtDescription', 'txtSort', 'isActivated', 'comGroupTypeId', '', 'comCodeTypeId', ''];
	BuildTable(id, urlPath, index, size, query, header, column);
}

function CreateOne() {
	urlPath = '/api/dataTypes';
	data = {
		'name': document.getElementById('txtName').value,
		'description': document.getElementById('txtDescription').value,
		'groupTypeId': document.getElementById('comGroupTypeId').value,
		'codeTypeId': document.getElementById('comCodeTypeId').value,
		'sort': document.getElementById('txtSort').value,
		'activated': document.getElementById('isActivated').checked
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
	urlPath = '/api/dataTypes';
	var idData = document.getElementById('txtId').value;
	if (idData != null && idData != 'undefined' && idData != "") {
		data = {
			'name': document.getElementById('txtName').value,
			'description': document.getElementById('txtDescription').value,
			'groupTypeId': document.getElementById('comGroupTypeId').value,
			'codeTypeId': document.getElementById('comCodeTypeId').value,
			'sort': document.getElementById('txtSort').value,
			'activated': document.getElementById('isActivated').checked
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
