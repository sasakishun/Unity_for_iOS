## sourcetree使用の注意点
- 空のレポジトリに初めてcommitするには、terminalから$git initをしなくてはならない。
- ローカルレポジトリとリモートレポジトリは、最初は紐づいていないので、
`% git merge --allow-unrelated-histories origin/master`
を実行して関連付けなくてはならない。

## Unityの注意点
- GUI上のボタンを押すと、その後のspaceキー押下し時にも、GUIイベントが発生する。
これを回避するには、ボタン選択後に別の場所をクリックする。
- 衝突判定の注意
	- 衝突させたいオブジェクトの両方にrigidbodyとcolliderを持たせる。
	- 動かしたくないオブジェクトは、rigidbodyのBody typeをstaticにすればよい。
	- OnCollisionEnter()はオブジェクト同士がぶつかるが、OnTriggerEnter()は通り抜ける。
	- OnTriggerEnter()を使用するには、動く方の物体のColliderのisTriggerにチェックを入れなくてはならない。
	- GUIを使うにはGameObjectでUI->EventSystemを追加しなくてはならない
(Hierarchyにただ追加するだけで後は自動で処理してくれる)
	-Rigidbody2Dのistriggerにチェックを入れると、衝突判定はするが、する抜けるようになる。
文字通り衝突イベント発生トリガーになるということ。
	-UIとタップ位置がずれてしまう問題がある時は、Canbas ScalarのReference Scalarの値が
Gameで指定したものから、ずれている可能性がある。一致させると直る。-->Joustickも問題なく動くようになった。
	- マテリアルの作り方（https://book.mynavi.jp/manatee/detail/id=59718）
	- Animationの作り方（https://qiita.com/SatoruNoda/items/8a52d656f95ff38c0d26）
	- Awake()とStart()の違い->Awakeの方が先に実行される、値の取得にはStart()を使うべき
	- uGUIのすぐできる工夫（http://chungames.hateblo.jp/entry/2015/11/14/193547）:拡大、点滅