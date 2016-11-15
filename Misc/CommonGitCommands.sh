# To initialize a git subfolder in a local repo
	git init --bare XXX.git
# To create copy of repository <path> in local dir	
	git clone <path> # <path> can be an ssh url, http url or local path
# To view branches
	git branch # -d = delete
	git checkout # -b = create and switch to new branch
# To check local status vs. master (remote) status for branch
	git show # Details each commit not pulled to local branch
	git status # Details each commit not pushed to remote repo and currently staged files
# To push local edits to master (remote) branch
	git add <filename> # 1) stages <filename> to be committed
	git commit -m '<message>' # 2) commits all currently staged files
	git reset HEAD <filename> # 3) unstages any added file
	git push <repo> # 4) pushes all currently committed files to <repo>
# To see repo URLs
	git remote show origin # details fetch/push URLs and Branch rules
# To visualize branch/commit history
	git log --graph --full-history --all --color --pretty=format:"%x1b[31m%h%x09%x1b[32m%d%x1b[0m%x20%s"
# To revert to previous commit
	git reset $SHA # $SHA is first 9 digits of commit hash