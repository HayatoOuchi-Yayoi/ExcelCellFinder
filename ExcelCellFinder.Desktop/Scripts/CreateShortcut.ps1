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

$shortcut = (New-Object -ComObject WScript.Shell).CreateShortcut($createShortcutTo)
$shortcut.TargetPath = $exePath
$shortcut.IconLocation = $exePath

$shortcut.Save()

Write-Host "Shortcut is created Successfully!"