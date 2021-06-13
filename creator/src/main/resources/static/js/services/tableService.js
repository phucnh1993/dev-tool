// Tạo header cho table
function CreateHeader(header) {
	var tr = document.createElement("tr");
	for (var i = 0; i < header.length; i++) {
		var th = document.createElement("th");
		th.innerText = header[i];
		tr.appendChild(th);
	}
	var ec = document.createElement("thead");
	ec.appendChild(tr);
	return ec;
}

// Tạo button sang trái về 1
function CreateMultiLeftButton(query) {
	var btnMulLeft = document.createElement('button');
	btnMulLeft.setAttribute('onclick', 'JumpPage('+ 1 +','+ 20 +','+ query +')');
	btnMulLeft.innerText = '&lt;&lt;&lt;';
	btnMulLeft.setAttribute('class', 'btn-normal btn-accept');
	return btnMulLeft;
}

// Tạo button sang trái 1 đơn vị
function CreateLeftButton(nowPage, query) {
	var btnLeft = document.createElement('button');
	var leftPage = 1;
	if (nowPage > leftPage) leftPage = nowPage - 1;
	btnLeft.setAttribute('onclick', 'JumpPage('+ leftPage +','+ 20 +','+ query +')');
	btnLeft.innerText = '&lt;';
	btnLeft.setAttribute('class', 'btn-normal btn-accept');
	return btnLeft;
}

// Tạo button sang phải 1 đơn vị
function CreateRightButton(numRow, query) {
	var rightPage = numRow / 20;
	if (rightPage > nowPage) rightPage = nowPage + 1;
	var btnRight = document.createElement('button');
	btnRight.setAttribute('onclick', 'JumpPage('+ rightPage +','+ 20 +','+ query +')');
	btnRight.innerText = '&gt;';
	btnRight.setAttribute('class', 'btn-normal btn-accept');
	return btnRight;
}

// Tạo button sang phải về trang cuối cùng
function CreateMultiRightButton(numRow, query) {
	var numPage = numRow / 20;
	var btnMulRight = document.createElement('button');
	btnMulRight.setAttribute('onclick', 'JumpPage('+ numPage +','+ 20 +','+ query +')');
	btnMulRight.innerText = '&gt;&gt;&gt;';
	btnMulRight.setAttribute('class', 'btn-normal btn-accept');
	return btnMulRight;
}

// Tạo button footer cho mỗi một trang, giới hạn trong vòng 5 trang
function CreateFooterPage(numRow, nowPage, query) {
	var div = document.createElement('div');
	var numPage = numRow / 20;
	if (numPage > 5) {
		for (var i = 1; i <= numPage; i++) {
			if ((nowPage - 2 >= i) && (nowPage + 2 <= i)) {
				if (nowPage === i) {
					var btn = document.createElement('button');
					btn.setAttribute('onclick', 'JumpPage('+ i +','+ 20 +','+ query +')');
					btn.setAttribute('class', 'btn-normal btn-success');	
				} else {
					btn.setAttribute('class', 'btn-normal btn-accept');
				}
				btn.innerText = i;
				div.appendChild(btn);
			}
		}
	} else {
		for (var i = 1; i <= numPage; i++) {
			var btn = document.createElement('button');
			btn.setAttribute('onclick', 'JumpPage('+ i +','+ 20 +','+ query +')');
			if (nowPage === i) {
				btn.setAttribute('class', 'btn-normal btn-success');	
			} else {
				btn.setAttribute('class', 'btn-normal btn-accept');
			}
			btn.innerText = i;
			div.appendChild(btn);
		}
	}
	return div;
}

// Tạo footer cho table
function CreateFooter(numColumn, numRow, nowPage, query) {
	var tr = document.createElement("tr");
	var td = document.createElement("td");
	td.setAttribute('class', 'table-footer');
	td.setAttribute('colspan', numColumn);
	
	if (numPage > nowPage && nowPage > 1) {
		td.appendChild(CreateMultiLeftButton(query));
		td.appendChild(CreateLeftButton(nowPage, query));
		td.appendChild(CreateFooterPage(numRow, nowPage, query));
		td.appendChild(CreateRightButton(numRow, query));
		td.appendChild(CreateMultiRightButton(numRow, query));		
	} else {
		if (nowPage === 1) {
			td.appendChild(CreateMultiLeftButton(query));
			td.appendChild(CreateLeftButton(nowPage, query));
			td.appendChild(CreateFooterPage(numRow, nowPage, query));
		}
		if (numPage === nowPage) {
			td.appendChild(CreateFooterPage(numRow, nowPage, query));
			td.appendChild(CreateRightButton(numRow, query));
			td.appendChild(CreateMultiRightButton(numRow, query));
		}
	}
	tr.appendChild(td);
	var ec = document.createElement("tfoot");
	ec.appendChild(tr);
	return ec
}

function JumpPage(index, size, query) {
	BuildTable(idGlobal, urlGlobal, index, size, query, headerGlobal);
}

var urlGlobal;
var idGlobal;
var headerGlobal;

// Tạo table
function BuildTable(id, urlPath, index, size, query, header) {
	urlGlobal = urlPath;
	idGlobal = id;
	headerGlobal = header;
	var xhttp = new XMLHttpRequest();
	xhttp.onreadystatechange = function() {
    	if (this.readyState == 4 && this.status == 200) {
			data = JSON.parse(xhttp.responseText);
			document.getElementById("data-table").innerHTML = "";
			var temp = data.data;
			document.getElementById("data-table").innerHTML = '<table id="t_' + id + '"></table>';
			var table = document.getElementById("t_" + id);
			table.appendChild(CreateHeader(header));
			if (temp.length > 0 && data.total > 0) {
				var tbody = document.createElement('tbody');
				for (var i = 0; i < temp.length; i++) {
					var obj = temp[i];
					var tempItem = Object.keys(obj).map((key) => [key, obj[key]]);
					var row = document.createElement('tr');
					for (var j = 0; j < tempItem.length; j++) {
						var cell = document.createElement('td');
						cell.innerText = tempItem[j][1];
						row.appendChild(cell);
					}
       				tbody.appendChild(row);
       			}
       			table.appendChild(tbody);
       			table.appendChild(CreateFooter(numColumn, data.total, nowPage, query));
       		}
    	}
	};
	var url = urlPath + '?pageIndex=' + index + '&pageSize=' + size + query;
	xhttp.open("GET", url, true);
	xhttp.setRequestHeader("Content-type", "application/json");
	xhttp.send();
}