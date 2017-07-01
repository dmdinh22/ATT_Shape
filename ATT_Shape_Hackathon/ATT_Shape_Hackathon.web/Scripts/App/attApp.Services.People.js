attApp.services.people = attApp.services.people || {};

attApp.services.people.selectAll = function(onSuccess, onError){
	var url = '/api/people';
	var settings = {
		cache: false,
		dataType: "json",
		success: onSuccess,
		error: onError,
		type: 'GET'
	};
	$.ajax(url, settings);
};

attApp.services.people.save = function (data, onSuccess, onError) {
	var url = '/api/people';
	var settings = {
		cache: false,
		contentType: "application/x-www-form-urlencoded; charset=UTF-8",
		dataType:"json",
		type: 'POST',
		data: data,
		success: onSuccess,
		error: onError
	};
	$.ajax(url, settings);
};

attApp.services.people.update = function (data, onSuccess, onError) {
	var url = '/api/people';
	var settings = {
		cache: false,
		contentType: "application/x-www-form-urlencoded; charset=UTF-8",
		dataType: "json",
		type: 'PUT',
		data: data,
		success: onSuccess,
		error: onError
	};
	$.ajax(url, settings);
};

attApp.services.people.delete = function (data, onSuccess, onError) {
	var url = '/api/people?id=' + data;
	var settings = {
		cache: false,
		contentType: "application/x-www-form-urlencoded; charset=UTF-8",
		dataType: "json",
		type: 'DELETE',
		success: onSuccess,
		error: onError
	};
	$.ajax(url, settings);
};