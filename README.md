Sensitive Data Grabber
====================

Visual Basic .NET program that when executes sends sensitive data to your email or saves them on a removable drive.

The program is not even in alpha stage right now and you should not execute it unless you know what you're doing! If you know what you're doing, read the rest of this document. Otherwise, GTFO!

What works for now:
* Check if programs are installed. If not, their checkbox should not be enabled.
* "Other emails" functionality.
* Basic "send by email" option (works for files, not for directories).
* Save to a removable drive works perfectly.
* Applications supported: Evernote, Google Chrome, Microsoft OneNote, Mozilla Firefox, Mozilla Thunderbird, Pidgin, Steam and World of Tanks. If you want to know about what data does it steal, check out this article on my blog: http://aleksandartodorovic.wordpress.com/2014/08/03/sensitive-data-grabber-project/

To do:
* Fully implement "send by email" option.
* Copy files before managing them (might get can't use it while the program is running error)
* Implement "save to a specific location" option.
* Support for Evernote copy database.
* Error messages if email configuration is wrong.
* Re-writing the program as a console application and supporting some older version of .NET framework. Re-written, the program will not ask for any interaction and will work out-of-the-box.

Features planned for 2.0 version:
* Works also as a keylogger.
* Sends emails periodically every hour.

If you want to try it out right now, there's a couple of requirements you need to satisfy:
* Works with 4.5 .NET framework for now. If you don't have it installed, you won't be able to run the program.
* Works only with 64bit system. You will need a 64 bit system.

Things you shouldn't do ATM:
* You shouldn't expect "send by email" option to save everything that "save to a removable drive" option does.
* You shouldn't check an application if you have it installed in a different than default directory.

If you still want to execute the program:
* Download the project.
* Navigate to Sensitive Data Grabbber\Bin\Debug folder.
* Execute Sensitive Data Grabber.exe
