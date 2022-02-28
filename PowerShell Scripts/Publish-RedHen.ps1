function Publish-RedHen() {
    Set-Location "C:\inetpub\redhen"
    $gci = gci .
    foreach ($item in $gci.FullName) {
        Remove-Item $item -Force -ErrorAction Continue
    }

    Set-Location -Path "$env:USERPROFILE\source\repos\RedHenAPI"
    dotnet publish -o C:\inetpub\redhen\
    
}

Publish-RedHen