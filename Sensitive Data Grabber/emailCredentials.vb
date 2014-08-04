Public Class emailCredentials

    Dim SMTPServer As String
    Dim SMTPPort As Integer
    Dim senderEmail As String
    Dim senderPassword As String
    Dim recieverEmail As String
    Dim emailSubject As String

    Private Sub emailCredentials_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("outlook.com")
        ComboBox1.Items.Add("hotmail.com")
        ComboBox1.Items.Add("live.com")
        ComboBox1.Items.Add("gmail.com")
        ComboBox1.Items.Add("mail.ru")
        ComboBox1.Items.Add("Other")

        TextBox1.Visible = False
        TextBox2.Visible = False
        Label1.Visible = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
      
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 3 Then
            TextBox1.Visible = True
            TextBox2.Visible = True
            Label1.Visible = True
        End If
    End Sub
End Class