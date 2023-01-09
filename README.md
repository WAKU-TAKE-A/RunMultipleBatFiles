# RunMultipleBatFiles

複数のバッチファイルを実行するアプリケーションです。

Windows10 64bit .NET Framework4.8.1で作成されています。

実行方法は、Listタブにバッチファイル名（もしくは1行コマンド）を1行ごとに記述し、
[Run]ボタンを押すと実行できます。標準出力はStdOutタブに表示されます。

Listタブの記述例：

```
A.bat
B.bat
C.bat
```

上の例では、A.bat⇒B.bat⇒C.batの順番で実行されます。

本アプリケーションのポイントとしては、

1. 1行実行するごとに、システム環境変数Pathとユーザー環境変数Pathをプロセス環境変数Pathに更新します。これにより、A.batでのPathの変更がB.batに反映されます。<br><br>
1. 全てのバッチ処理で扱える環境変数をSettingsタブで10個まで設定することができます。http_proxyやhttps_proxyなどの環境変数をここで設定しておけば全てのバッチ処理で使えます。しかも、本アプリケーションが終了すれば消えます。<br><br>
1. RunMultipleBatFiles.exeと同じフォルダにあるList_Bat.txtに例のような記述を行っておけば、起動時にListタブに読み込んでくれます。<br><br>
1. RunMultipleBatFiles.exeと同じフォルダにあるRunMultipleBatFiles.xmlを適切に記述すれば、起動時にSettingsタブに環境変数を読み込んでくれます。

## __注意点__

非同期実行がうまく実装できていません。`Application.DoEvents()`でごまかしていますが、時間のかかる処理だと`txtStdOut.Text += proc.StandardOutput.ReadToEnd()`で固まったように見えます。処理が完了するまでお待ちください。
