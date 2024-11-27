param (
    [string]$exePath
)

$exePath = (Resolve-Path $exePath).Path

Write-Host "Paramter(exePath): $exePath"

$publishPath = [System.IO.Path]::GetDirectoryName($exePath)

$createShortcutTo = [System.IO.Path]::Combine([System.IO.Path]::GetDirectoryName($publishPath), "ExcelCellFinder.lnk")

Write-Host "Create Shortcut at: $createShortcutTo"

if(Test-Path $createShortcutTo) {
	Remove-Item $createShortcutTo
}

# ショートカットを作成するパスに移動して相対パスを処理
Push-Location ([System.IO.Path]::GetDirectoryName($createShortcutTo))
    $TargetPathRelative = Resolve-Path $exePath -Relative
    echo $TargetPathRelative
    
    $shortcut = (New-Object -ComObject WScript.Shell).CreateShortcut($createShortcutTo)
    $shortcut.TargetPath = '%windir%\explorer.exe'
    $shortcut.Arguments = "$TargetPathRelative"
    $shortcut.IconLocation = $exePath
    $shortcut.Save()
Pop-Location