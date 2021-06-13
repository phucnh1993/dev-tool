function GetList() {
	id = 'basic-type';
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
}