$(document).ready(function () {
    $('#donors').DataTable(
        {
            "columnDefs": [{
                className: "dt-center"
            }],
            "paging": true,
            "iDisplayLength": 25,
            "ordering": true,
            "info": true,
            "searching": true
        }
    );
});


//new Chart(document.getElementById("horizontalBar"), {
//    "type": "horizontalBar",
//    "data": {
//        "labels": ["A Rh+", "0 Rh+", "B Rh+", "AB Rh+", "0 Rh-", "A Rh-", "B Rh-", "AB Rh-"],
//        "datasets": [{
//            "label": "Grupa Krwi",
//            "data": [32, 31, 15, 7, 6, 6, 2, 1],
//            "fill": false,
//            "backgroundColor":
//                //["#E60000", "#BF0413", "#BF0413", "#BF0000", "#9B0000", "#7F0000", "#650000", "#400000"],
//                ["#400000", "#650000", "#7F0000", "#9B0000", "#BF0000", "", "#D90404", "#E60000"],
//            "borderColor": ["transparent"
//            ],
//            "borderWidth": 0
//        }]
//    },
//    "options": {
//        "scales": {
//            "xAxes": [{
//                "ticks": {
//                    "beginAtZero": true
//                }
//            }]
//        }
//    }
//});


//var ctxD = document.getElementById("doughnutChart").getContext('2d');
//var myLineChart = new Chart(ctxD, {
//    type: 'doughnut',
//    data: {

//        datasets: [{
//            data: [32, 31, 15, 7, 6, 6, 2, 1],
//            backgroundColor:
//            //["#400000", "#650000", "#7F0000", "#9B0000", "#BF0000", "", "#D90404", "#F27179"],
//                ["#E60000", "#BF0413", "#BF0413", "#BF0000", "#9B0000", "#7F0000", "#650000","#400000"],
//            hoverBackgroundColor: []
//        }],
//        labels: ["A Rh+", "0 Rh+", "B Rh+", "AB Rh+", "0 Rh-", "A Rh-", "B Rh-", "AB Rh-"]
//    },
//    options: {
//        responsive: true
//    }
//});
