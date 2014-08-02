SensitiveDataGrabber
====================

Visual Basic .NET program that when executes sends sensitive data to your mail (cookies.sqlite, addons.json and stuff like that).

The program is not even in alpha stage right now. All it does for now is grabs the addons.json from my computer and sends them to a specified email. Works for now. Testing it on Windows 8.1 using Firefox as my default browser.

NOTE: The program will (for now) work only on my computer because it grabs the data using my directory. Checking for a directory will soon be implemented.


Plans for pre-alpha release:
* Checks for default directories using Firefox as a default browser.
* Adds addons.json and cookies.sqlite to an email attachment and sends them to a specified email using the form.
 

Feature list to be implemented:
* Works on Chrome, Firefox and Opera as default browsers.
* Works on Windows 7, Windows 8 and Windows 8.1.
* Adds cookie file and a list of addons to email attachments.
* Adds a file with some basic information about computers (system, RAM, CPU, GPU).
* Grabs passwords from Thunderbird and Steam.
* Grabs some interesting data from Steam.
* Installs a keylogger.
* Sends emails periodically every hour.
* The application will be hidden from task manager and minimized once opened and users will have to enter some complicated keys to restore the application.
