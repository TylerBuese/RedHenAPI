function Initialize-RedHen {
    $url = "http://localhost:5000/backend"
    $result = Invoke-RestMethod -Uri $url -Method GET
    if ($result.result) {
        Write-Host("RedHen initialized!") -BackgroundColor Green
    } else {
        Write-Host("Redhen not initialized! Error: " + $result.result) -BackgroundColor Red
    }
}

Initialize-RedHen