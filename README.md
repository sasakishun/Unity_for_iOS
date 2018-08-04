## sourcetree使用の注意点
- 空のレポジトリに初めてcommitするには、terminalから$git initをしなくてはならない。
- ローカルレポジトリとリモートレポジトリは、最初は紐づいていないので、
% git merge --allow-unrelated-histories origin/master
を実行して関連付けなくてはならない。
