# ExcelCellFinder
## 開発環境
- Visual Studio 2022
- .NET 8.0

## Build
- `ExcelCellFinder.sln`を開いてビルドしてください。

## Publish
以下のいずれかで発行できます

### Visual Studio 2022で発行
`ExcelCellFinder.Desktop`を右クリックして`発行`

### dotnetコマンドで発行
``` cmd
> cd ./ExcelCellFinder.Desktop
> dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -o ../.tmp/Release/bin
```

## Release
GitHub Actionsでワークフローを作成しています。
`.github/workflows/release-workflow.yaml`

`release/<バージョン>`ブランチにpushされるとワークフローにてリリースがdraft作成されます。
リリースノートを編集して公開してください。

`test-release/<バージョン>`ブランチにpushしてテストすることもできます。
テストが終了したらReleaseから削除してください。