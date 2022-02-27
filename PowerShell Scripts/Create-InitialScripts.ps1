function Create-InitialSqlScripts() {
    $inetloc = "C:\inetpub\redhen\SqlScriptsInit"
    Set-Location $inetloc

    $arrayOfUrls = @(
        "https://raw.githubusercontent.com/TylerBuese/RedHenAPI/master/SqlScripts/CreateAccountTable.sql",
        "https://raw.githubusercontent.com/TylerBuese/RedHenAPI/master/SqlScripts/SeedAccountTable.sql",
        "https://raw.githubusercontent.com/TylerBuese/RedHenAPI/master/SqlScripts/CreateKidTable.sql",
        "https://raw.githubusercontent.com/TylerBuese/RedHenAPI/master/SqlScripts/CreateAccountTable.sql"

    )

    foreach ($url in $arrayOfUrls){
        $splitUrl = $url.split("/")
        Invoke-WebRequest -Uri $url -OutFile ".\$($splitUrl[-1])"
    }
}