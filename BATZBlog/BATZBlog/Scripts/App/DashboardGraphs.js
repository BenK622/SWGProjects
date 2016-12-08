//var dataArray = Object.keys(dataObject).map(val => dataObject[val]);

$(document).ready(function () {
    
    $.ajax({
        url: '/api/SalesByProduct',
        type: 'GET',
        success: function (result) {
            var keys = $.map(result, function (item, key) {
                return key;
            });
            var dataArray = Object.keys(result).map(val => result[val]);

    var ctx = document.getElementById("myChart");
    var myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: keys,
            datasets: [{
                label: 'Total Sales',
                data: dataArray,
                backgroundColor:  [
                    '#FF33D1',
                    '#FE0001 ',
                    '#FF4105',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderColor: [
                    '#FF33D1',
                    '#FE0001 ',
                    '#FF4105',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            responsive: false,
            maintainAspectRatio: false,
            defaultFontColor: '#ffffff',
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero:true
                    }
                }]
            }
        }
    });
        }
    });
});

$(document).ready(function () {

    $.ajax({
        url: '/api/SalesByCategory',
        type: 'GET',
        success: function (result) {
            var keys = $.map(result, function (item, key) {
                return key;
            });
            var dataArray = Object.keys(result).map(val => result[val]);

            var ctx = document.getElementById("salesByCategory");
            var myChart = new Chart(ctx, {
                type: 'pie',
                data: {
                    labels: keys,
                    datasets: [{
                        label: 'Total Sales',
                        data: dataArray,
                        backgroundColor: [
                            '#FF33D1',
                            '#FE0001 ',
                            '#FF4105 ',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderColor: [
                            '#FF33D1',
                            '#FE0001 ',
                            '#FF4105',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    maintainAspectRatio: false,
                    responsive: true,
                }
            });
        }
    });
});
$(document).ready(function () {
    $.ajax({
        url: '/api/SalesByMonthYear',
        type: 'GET',
        success: function (result) {
            var keys = $.map(result, function (item, key) {
                return key;
            });
            var dataArray = Object.keys(result).map(val => result[val]);

            var ctx = document.getElementById("salesByMonthYear");
            var myChart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: keys,
                    datasets: [{
                        label: 'Total Sales',
                        data: dataArray,
                        borderColor: [
                            '#FF33D1',
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    maintainAspectRatio: false,
                    responsive: true,
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        }
    });
});