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

上記の例では、A.bat⇒B.bat⇒C.batの順番で実行されます。

さらに詳細に言えば、以下のようになります。

システム環境変数Pathとユーザー環境変数Pathを反映<br>
↓<br>
Settingsタブの環境変数を設定<br>
↓<br>
A.bat<br>
↓<br>
システム環境変数Pathとユーザー環境変数Pathを反映<br>
↓<br>
B.bat<br>
↓<br>
システム環境変数Pathとユーザー環境変数Pathを反映<br>
↓<br>
C.bat

本アプリケーションのポイントとしては、

1. 1行実行するごとに、システム環境変数Pathとユーザー環境変数Pathをプロセス環境変数Path（実行しているbat処理のPath）に反映します。例えば、A.batでPythonやRubyのインストールが行われシステム環境変数Pathが変更された場合、B.batでも更新された環境変数Pathを利用できます。<br><br>
1. 標準エラーが出力された場合、例外が発生し、それ以降のbat処理は行われません。（XMLでこの機能を無視することも可能です）<br><br>
1. 全てのbat処理で扱える環境変数をSettingsタブで10個まで設定することができます。http_proxyやhttps_proxyなどの環境変数をここで設定しておけば全てのbat処理で利用できます。bat処理内で変更することは可能ですが、次のbat処理内では再度Settingsタブの設定が有効になります。<br><br>
1. カレントディレクトリをSettingsタブで指定することができます。これにより全てのbat処理で同一のカレントディレクトリで作業することが可能です。bat処理内で変更することは可能ですが、次のbat処理内では再度Settingsタブの設定が有効になります。<br><br>
1. RunMultipleBatFiles.exeと同じフォルダにあるList_Bat.txtに上記の例のようなbatファイルの記述を書いておけば、起動時にListタブに読み込んでくれます。<br><br>
1. RunMultipleBatFiles.exeと同じフォルダにあるRunMultipleBatFiles.xmlを適切に記述すれば、起動時にSettingsタブに環境変数を読み込んでくれます。<br><br>
1. 設定用XMLやコマンドリストTXTをD&Dできるようにしました。（0.9.4.0以降）
1. DOSコマンドには標準出力がSIft-JISのものやUTF-8のものがあります。手動での切り替えが可能です。（0.9.8.0以降）

## __ひとこと__

非同期実行がうまく実装できていません。`Application.DoEvents()`でごまかしていますが、時間のかかる処理だと`txtStdOut.Text += proc.StandardOutput.ReadToEnd()`で固まったように見えます。処理が完了するまでお待ちください。

本アプリケーションを作った理由は、Pathの変更をした際に起動中のDOSプロンプトには反映されないので、いちいち再起動しなくてはいけません。そんな不便さを解消したかったからです。