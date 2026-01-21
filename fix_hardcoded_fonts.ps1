# Script để thay thế hardcoded fonts bằng UIHelper.Fonts

# Danh sách các thay thế font
$fontReplacements = @{
    'new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold)' = 'UIHelper.Fonts.Title'
    'new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold)' = 'UIHelper.Fonts.TitleMedium'
    'new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold)' = 'UIHelper.Fonts.TitleSmall'
    'new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold)' = 'UIHelper.Fonts.Header'
    'new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold)' = 'UIHelper.Fonts.Button'
    'new System.Drawing.Font("Times New Roman", 10F)' = 'UIHelper.Fonts.Default'
    'new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular)' = 'UIHelper.Fonts.Default'
    'new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold)' = 'UIHelper.Fonts.LabelBold'
    'new System.Drawing.Font("Times New Roman", 9F)' = 'UIHelper.Fonts.LabelSmall'
    'new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Bold)' = 'UIHelper.Fonts.ValueLarge'
}

# Tìm tất cả file Designer.cs
$files = Get-ChildItem -Path "QuanLyNhaTro/Forms" -Filter "*Designer.cs" -Recurse

foreach ($file in $files) {
    $content = Get-Content $file.FullName -Encoding UTF8 -Raw
    $modified = $false
    
    foreach ($oldFont in $fontReplacements.Keys) {
        $newFont = $fontReplacements[$oldFont]
        if ($content.Contains($oldFont)) {
            $content = $content.Replace($oldFont, $newFont)
            $modified = $true
            Write-Host "Fixed font in $($file.Name): '$oldFont' -> '$newFont'"
        }
    }
    
    if ($modified) {
        Set-Content -Path $file.FullName -Value $content -Encoding UTF8
        Write-Host "Updated file: $($file.FullName)"
    }
}

Write-Host "Font replacement completed!"