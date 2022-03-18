let chart;
window.displayChart = (canvas, prices, days) => {
    if(chart) {
        chart.destroy();
    }

    let context = canvas.getContext('2d');
    chart = new Chart(context, {
        type: 'line',
        data: {
            labels: days,
            datasets: [{
                label: 'Price',
                data: prices,
                backgroundColor: 'rgba(0, 102, 204, 0.85)',
                borderColor: 'rgba(0, 102, 204, 0.85)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                y: {
                    beginAtZero: false
                }
            }
        }
    });
}

window.callCoinGeckoApi = (dotNetRef) => {
    let coin = $("#fc-coin").val();
    let currency = $("#fc-currency").val();

    return dotNetRef.invokeMethodAsync("GetMarketData", coin, currency)
}