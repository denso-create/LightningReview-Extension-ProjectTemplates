@echo off

rem どのフォルダからでも実行できるようこのファイルのあるフォルダの親フォルダを起点とします。
echo ルートフォルダに移動します。
set SCRIPT_FOLDER=%~dp0
cd %SCRIPT_FOLDER%\..

echo 全てのbin/objフォルダを削除します。
for /d /r . %%d in (bin,obj) do @if exist "%%d" rd /s/q "%%d"

echo bin,objフォルダを削除しました。ウィンドウを閉じて下さい。
pause > nul
