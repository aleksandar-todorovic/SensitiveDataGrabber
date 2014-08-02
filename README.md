SensitiveDataGrabber
====================

Visual Basic .NET program that when executes sends sensitive data to your mail (cookies.sqlite, addons.json and stuff like that).

The program is not even in alpha stage right now!

What works for now:
* The program checks for the Firefox directory where cookies and addons are stored.
* The program adds those files as email attachments.
* The program sends an email containing those two files to the address specified inside the program code.

To do:
* The program will need to copy cookies.sqlite to some directory because it can't be used as an attachment while Firefox is running.

Feature list to be implemented:
* It should work on Chrome, Firefox and Opera as default browsers.
* It should work on Windows 7, Windows 8 and Windows 8.1. Maybe even Vista, huh? I don't plan to support XP right now.
* Adds cookie file and a list of addons to email attachments.
* Adds a file with some basic information about computers (system, RAM, CPU, GPU).
* Grabs passwords from Thunderbird and Pidgin (if installed).
* Grabs some interesting data from Steam maybe? Maybe some other programs will be implemented, out of ideas for now.

Features planned for 2.0 version:
* Works also as a keylogger.
* Sends emails periodically every hour.
* The application will be hidden from task manager and minimized once opened and users will have to enter some complicated key combination to access the running application.
