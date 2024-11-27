# ExcelCellFinder
## �J����
- Visual Studio 2022
- .NET 8.0

## Build
- `ExcelCellFinder.sln`���J���ăr���h���Ă��������B

## Publish
�ȉ��̂����ꂩ�Ŕ��s�ł��܂�

### Visual Studio 2022�Ŕ��s
`ExcelCellFinder.Desktop`���E�N���b�N����`���s`

### dotnet�R�}���h�Ŕ��s
``` cmd
> cd ./ExcelCellFinder.Desktop
> dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true -o ../.tmp/Release/bin
```

## Release
GitHub Actions�Ń��[�N�t���[���쐬���Ă��܂��B
`.github/workflows/release-workflow.yaml`

`release/<�o�[�W����>`�u�����`��push�����ƃ��[�N�t���[�ɂă����[�X��draft�쐬����܂��B
�����[�X�m�[�g��ҏW���Č��J���Ă��������B

`test-release/<�o�[�W����>`�u�����`��push���ăe�X�g���邱�Ƃ��ł��܂��B
�e�X�g���I��������Release����폜���Ă��������B