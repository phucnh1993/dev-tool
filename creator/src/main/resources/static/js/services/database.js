function GetList() {
	id = 'basic_type';
	urlPath = '/api/databases';
	index = 1;
	size = 20;
	query = '';
	header = ['Id', 'Name', 'Description', 'Is Activated', 'Id Type', 'Type', 'IP Address V4', 'IP Address V6', 'Port', 'Username', 'Password'];
	BuildTable(id, urlPath, index, size, query, header);
}

function CreateOne() {
	urlPath = '/api/databases';
	data = {
		'basicTypeId': document.getElementById('txtBasicTypeId').value,
		'name': document.getElementById('txtName').value,
		'description': document.getElementById('txtDescription').value,
		'ipAddressV4': document.getElementById('txtIpAddressV4').value,
		'ipAddressV6': document.getElementById('txtIpAddressV6').value,
		'port': document.getElementById('txtPort').value,
		'username': document.getElementById('txtUsername').value,
		'password': document.getElementById('txtPassword').value,
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
	urlPath = '/api/databases';
	var idData = document.getElementById('txtId').value;
	if (idData != null && idData != 'undefined' && idData != "") {
		data = {
			'basicTypeId': document.getElementById('txtBasicTypeId').value,
			'name': document.getElementById('txtName').value,
			'description': document.getElementById('txtDescription').value,
			'ipAddressV4': document.getElementById('txtIpAddressV4').value,
			'ipAddressV6': document.getElementById('txtIpAddressV6').value,
			'port': document.getElementById('txtPort').value,
			'username': document.getElementById('txtUsername').value,
			'password': document.getElementById('txtPassword').value,
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