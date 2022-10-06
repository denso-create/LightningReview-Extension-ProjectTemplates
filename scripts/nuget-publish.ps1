# ビルドを実行してnugetに公開するスクリプトです

#############################################################
# ここの設定を変更してください
#############################################################
$SolutionFolder = "src"

# 公開するnugetのソース名を指定します。
# "github"を指定するとプライベートの "github"と設定したプライベートパッケージに公開します。
# 詳細はこちらを参照して下さい
# https://docs.github.com/ja/packages/guides/configuring-dotnet-cli-for-use-with-github-packages
#
# APIキーを設定しておいて下さい
# nuget SetApiKey (TOKEN) -source https://nuget.pkg.github.com/miles-team/index.json
$NugetSource  = "github" 

# "nuget.org"にするとnuget.orgに公開します（謝って公開しないように注意して下さい）。
#$NugetSource  = "nuget.org" 
#############################################################

# Build Solution
dotnet build $SolutionFolder  --configuration release

# Pack Nuget Packages
dotnet pack $SolutionFolder  --configuration release

# Publish nupkg Files
# ソリューションフォルダにあるすべてのnupkgをpublishします
$nugetFiles = Get-ChildItem -Path $SolutionFolder -Recurse -File -Include *.nupkg 

foreach ( $file in $nugetFiles)
{
    $fullPath = $file.FullName

    # テスト関連のフォルダは対象外
    if ( $fullPath.Contains("TestData") -or $fullPath.Contains("Tests")) {
        continue
    }

    # nugetに公開
    if ( $NugetSource -eq "nuget.org")
    {
        dotnet nuget push $fullPath --source "https://api.nuget.org/v3/index.json" --skip-duplicate

    } else {
        dotnet nuget push $fullPath --source $NugetSource --skip-duplicate
    }
}


Write-Output "Finished"


