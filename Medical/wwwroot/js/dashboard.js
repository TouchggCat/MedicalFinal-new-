"use strict";

var client = new signalR.HubConnectionBuilder().withUrl("/dashboardHub").build();

$(function () {
    client.start().then(function () {
        window.setInterval((() => InvokeProducts()), 1000);	
    }).catch(function () {
		return console.error(err.toString());
	});
});

function InvokeProducts() {
    client.invoke("GetAll").catch(function (err) {
        return console.error(err.toString());
    });
}

client.on("refreshProducts", function (products) {
	BindProductsToGrid(products);
});

client.on("ReceivedAll", function (data, order, reserve, rating, products, charts) {
    $('#user').find('h3').html(`${data}`);
    $('#order').find('h3').html(`${order}`);
    $('#reserve').find('h3').html(`${reserve}`);
    $('#rating').find('h3').html(`${rating}<sup style="font-size: 20px">%</sup>`);
    BindProductsToGrid(products);
    BindProductsToChart(charts);
});


function BindProductsToGrid(products) {
	$('#tblProduct tbody').empty();

	var tr;
	$.each(products, function (index, product) {
		tr = $('<tr/>');
		tr.append(`<td>${(index + 1)}</td>`);
		tr.append(`<td>${product.productName}</td>`);
		tr.append(`<td>${product.stock}</td>`);
		$('#tblProduct').append(tr);
	});
}


function BindProductsToChart(chart) {
    const MONTHS = [
        'January',
        'February',
        'March',
        'April',
        'May',
        'June',
        'July',
        'August',
        'September',
        'October',
        'November',
        'December'
    ];

    /*var currentMonth = new Date().getMonth() + 1;*/
    var currentMonth = new Date(2022, 4, 22);

    function months(config) {
        var cfg = config || {};
        var section = cfg.section;
        var values = [];
        var i, value;

        for (i = currentMonth-6; i <= currentMonth; i++) {
            value = MONTHS[Math.ceil(Math.abs(i)) % 12];
            values.push(value.substring(0, section));
        }
        return values;
    }

    var $Chart = $('#myChart');
    var labels = months({ count: 6 });
    var data = {
        labels: labels,
        datasets: [
            {
                data: chart,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(255, 159, 64, 0.2)',
                    'rgba(255, 205, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(201, 203, 207, 0.2)', 'rgba(201, 203, 207, 0.2)'
                ],
                borderColor: [
                    'rgb(255, 99, 132)',
                    'rgb(255, 159, 64)',
                    'rgb(255, 205, 86)',
                    'rgb(75, 192, 192)',
                    'rgb(54, 162, 235)',
                    'rgb(153, 102, 255)',
                    'rgb(201, 203, 207)', 'rgb(201, 203, 207)'
                ],
                borderWidth: 1
            }]
    };

    var salesChart = new Chart($Chart, {
        type: 'bar',
        data: data,
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    })
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