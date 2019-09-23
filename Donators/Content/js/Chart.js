window.onload = function () {

    var chart = new CanvasJS.Chart("chartContainer", {
        animationEnabled: true,
        theme: "light2", // "light1", "dark1", "dark2"
        exportEnabled: true,
        title: {
            text: "Status krwii w banku"
        },
        data: [{
            type: "column",
            dataPoints:  @Html.Raw(ViewBag.DataPoints)
}]
});
chart.render();
 
}