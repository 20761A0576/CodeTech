document.addEventListener("DOMContentLoaded", () => {
    const fetchMetrics = async () => {
        try {
            const response = await fetch("/api/metrics");
            const data = await response.json();
            updateMetricsTable(data);
        } catch (error) {
            console.error("Error fetching metrics:", error);
        }
    };

    const updateMetricsTable = (metrics) => {
        const tableBody = document.getElementById("metricsTable").querySelector("tbody");
        tableBody.innerHTML = ""; // Clear existing rows
        metrics.forEach(metric => {
            const row = document.createElement("tr");
            row.innerHTML = `
                <td>${metric.metricName}</td>
                <td>${metric.value}</td>
                <td>${new Date(metric.timestamp).toLocaleString()}</td>
            `;
            tableBody.appendChild(row);
        });
    };

    // Fetch metrics on page load
    fetchMetrics();
});
