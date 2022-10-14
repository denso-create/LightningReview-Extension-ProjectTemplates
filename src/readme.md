## 概要

*   Lightning Reviewのエクステンション開発のためのプロジェクトテンプレートです。
*   dotnetのCLIおよび、Visual Studioで利用できます。

> **Notice:**  
> 本ライブラリはLightning Review V2.0.0以降が対象のプロジェクトテンプレートです。Lightning Review V1.Xでは利用できません。

プロジェクトテンプレートのインストール方法、利用方法について説明した動画は[こちら](https://www.lightning-review.com/support/help/extension/visualstudio-template.mp4)です。

## インストール方法

*   コマンドプロンプトより次のように実行して下さい。

```
> dotnet new --install LightningReview.Extension.ProjectTemplates
```

正常にインストールが完了している場合は次のコマンドを実行すると

```
> dotnet new --list
```

このように表示されます。

```
Templates                                     Short Name           Language    Tags
--------------------------------------------  -------------------  ----------  ----------------------
Console Application                           console              [C#],F#,VB  Common/Console
...
Lightning Review Extension                    lrext                [C#]        Lightning Review
...
```

## 利用方法

*   次のように実行するとエクステンションのプロジェクトを作成できます。

```
> dotnet new lrext -n MyExt1
```

*   また、Visual Studioの新規プロジェクト作成のダイアログでも作成可能です。

## パッケージのアンインストール方法

次のコマンドを実行して下さい。

```
> dotnet new --uninstall LightningReview.Extension.ProjectTemplates
```

## ライセンス

本ライブラリはMITライセンスです。詳細は[LICENSE](https://github.com/denso-create/LightningReview-Extension-ProjectTemplates/blob/main/LICENSE) を確認してください。
