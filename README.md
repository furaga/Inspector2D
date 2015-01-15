Inspector2D
===========================

デバッグ実行時にBitmapやList<Point>などを二次元キャンバス上に可視化できるVisual Studio拡張機能。クイックウォッチの二次元画像版のようなイメージ。 
内部ではFLib (https://github.com/furaga/FLib) の FLib.BitmapHandler.DrawAndSave() を使って画像や点群を描いて外部ファイルに書き出し、それを読み込むことでVisual StudioのUI上に結果画像を表示している。 
現状インタフェースはかなり適当。気が向けば随時改良する。

- 使い方  
1) 基本的にMethodRerunner (https://github.com/furaga/MethodRerunner )と同様。FLibをプロジェクトの参照に追加してプログラムのエントリポイント付近でFLib を初期化 (FLib.FLib.Initialize();)する。 
2) デバッグ実行時にVisual Studioの「表示 -> その他のウインドウ -> Inspector2DWindow」 。Inspector2Dのツールウインドウが表示される。　
3) 下の画像のように可視化したい変数と可視化の方法（「As Bitamp」「As Lines」「As Points」）を指定して「Refresh」ボタンを押すと指定した変数が可視化される。
