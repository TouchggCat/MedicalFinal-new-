"use strict";

var client = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();

$(function () {
	client.start().then(function () {

		InvokeProducts()
		
    }).catch(function () {
		return console.error(err.toString());
	});

});

function InvokeProducts() {
	client.invoke("SendRooomNo").catch(function (err) {
		return console.error(err.toString());
	});
}

client.on("ReceivedProducts", function (products) {
	BindProductsToGrid(products);
});

function BindProductsToGrid(products) {
	$('#tblProduct tbody').empty();

	var tr;
	$.each(products, function (index, product) {
		tr = $('<tr/>');
		tr.append(`<td>${(index + 1)}</td>`);
		tr.append(`<td>${product.productName}</td>`);
		tr.append(`<td>${product.stock}</td>`);
		tr.append(`<td>${product.productName}</td>`);
		$('#tblProduct').append(tr);
	});
}