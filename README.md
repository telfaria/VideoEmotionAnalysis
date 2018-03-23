# VideoEmotionAnalysis
Cognitive Service API Sample

## What's this.
動画ファイルから約1秒ごとに静止画を切り出し、Emothin APIに渡して、表情の感情値を取得しCSVに出力するソフト。

## 何が出来るのか
Emotion API 使って表情分析
結果はCSVで出力されます

## 利用方法
OpenCVで処理出来そうな動画ファイル（例えば .MPG, .MP4 など）を指定し、解析ボタンを押すだけ。全フレーム解析後に、実行フォルダ上にCSVファイルができあがります。後の処理は煮るなり焼くなりご自由に。
APIキーは、上部メニューバーの[Options] → [API Key] から入力できます。

## 注意点
Emotion APIのレベルによっては、1分間、あるいは一日におけるAPIの呼び出し制限があります。（例えばFreeレベルだと1分間に20回まで）
エラーになったAPI呼び出しはスキップされます。
また、APIには顔の座標を渡す呼び出しがありますが（RecognizeAsync メソッドのオーバライドの一つ）、Freeレベルは顔の座標を指定しなくていいので、顔の座標は渡してません。

## 言語
C# (.NET Framework 4.5.2 or higher) w/z Visual Studio Community 2015/2017

## ビルド時に必要なもの
* Microsoft.ProjectOxford.Emotion
* OpenCVSharp 
NuGetから入手してください
```
Install-Package OpenCvSharp-AnyCPU -Version 2.4.10.20170306
Install-Package Microsoft.ProjectOxford.Emotion
```

また、Cognitive Service の、Emotion API のAPIキーが別途必要になります。
[Emotion API](https://azure.microsoft.com/ja-jp/services/cognitive-services/emotion/)
たぶん Free レベルでいいと思います

## 作ったひと
@telfaria
http://d.hatena.ne.jp/elfaria/

## ライセンス
MIT License 
