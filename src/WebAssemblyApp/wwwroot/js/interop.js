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
    let coin = document.getElementById("fc-coin").value;
    let currency = document.getElementById("fc-currency").value;

    return dotNetRef.invokeMethodAsync("GetMarketData", coin, currency)
}