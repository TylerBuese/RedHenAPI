function Initialize-RedHen {
    $url = "http:192.168.1.10/backend"
    $result = Invoke-RestMethod -Uri $url -Method GET
    if ($result.result) {
        Write-Host("RedHen initialized!") -BackgroundColor Green
    } else {
        Write-Host("Redhen not initialized! Error: " + $result.result) -BackgroundColor Red
    }
}

Initialize-RedHen