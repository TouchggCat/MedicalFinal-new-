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
    client.invoke("GetAllProducts").catch(function (err) {
		return console.error(err.toString());
	});
}

client.on("refreshProducts", function (products) {
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
		tr.append(`<td>${product.shelfdate}</td>`);
		$('#tblProduct').append(tr);
	});
}



function loadData() {
    var tr = ''

    $.ajax({
        url: '/Admin/Home/GetEmployees',
        method: 'GET',
        success: (result) => {
            $.each(result, (k, v) => {
                tr = tr + `<tr>
                        <td>${v.productName}</td>
                        <td>${v.stock}</td>
                        <td>${v.shelfdate}</td>
                    </tr>`
            })

            $("#tblProduct").html(tr)
        },
        error: (error) => {
            console.log(error)
        }
    })
}