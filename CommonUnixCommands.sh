# To login to gateway, determine IP address from Windows PuTTy login
ssh root@10.42.0.179
# To determine IP address from default gateway if ethernet connection
route -n
# To determine Process ID 
top
# To log out of Wind River Stack
exit
# To stop processID
kill processID
# To activate/deactive WiFi process
wifi up/down
# To show "wlan0 associate with MAC attempts"
dmesg
# To show connection status of wlan0 link
iw wlan0 link
# To reach Python libraries on gateway
cd /usr/lib/python2.7/
# To access USB Port
cd /media/sda1/
# To send four_twentypy to library
cp four_twenty.py /usr/lib/python2.7
# To copy a folder
cp -R destination/ source/
# To edit the text in a file (press i to edit, Ctrl+C to stop editing, :wq to save & quit)
vim four_twenty.py # yyp - copy line below, dd - delete line, cc - copy line, pp - paste line
	:set fileformat=unix # fixes "bad interpreter" error for python file copied from Windows
# To show all running processes, and single out just those with python in the name
ps -ef |grep python
# To type out environment variable $PATH
echo $PATH
# To transfer file from Windows to gateway
pscp -scp ./list-modules.py root@10.34.244.68:/home
# To give yourself execute permission for the file containing the script use the command
chmod u+rwx filename.py # go+rx gives other users permissions to read/execture, but not alter shell script

