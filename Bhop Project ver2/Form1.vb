Imports System
Imports System.IO
Imports System.Text
Imports System.Windows

Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BackgroundWorker1.RunWorkerAsync()
        Control.CheckForIllegalCrossThreadCalls = False


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.Text = "" Then
            MsgBox("Please select a hotkey.", MsgBoxStyle.OkOnly, "No Hotkey selected!")
        Else

            If IO.File.Exists(Application.StartupPath & "\Settings.ahk") Then


                Dim sb As New StringBuilder

                IO.File.WriteAllBytes(IO.Path.Combine(Application.StartupPath, "Ahk2exe.exe"), My.Resources.Resource1.Ahk2Exe) 'Kopira fajlove is Resources
                IO.File.WriteAllBytes(IO.Path.Combine(Application.StartupPath, "AutoHotkeySC.bin"), My.Resources.Resource2.AutoHotkeySC)
                Using fs As New IO.FileStream(Application.StartupPath & "\BhopIcon.ico", IO.FileMode.Create) 'Kopira ikonu iz Resources
                    My.Resources.Resource3.BhopIcon.Save(fs)


                End Using


                sb.AppendLine("Ahk2exe.exe /in Settings.ahk /out Bhop.exe /icon BhopIcon.ico")

                IO.File.WriteAllText("execute.bat", sb.ToString()) 'Pravi .bat fajl
                System.Diagnostics.Process.Start(Application.StartupPath & "\execute.bat") 'Execute .bat fajl
                MsgBox("File succesfully saved.", MsgBoxStyle.OkOnly, "File saved!") 'Msgbox da je zavrsen fajl

                Dim FileToDelete As String

                FileToDelete = Application.StartupPath & "\execute.bat"

                If System.IO.File.Exists(FileToDelete) = True Then

                    System.IO.File.Delete(FileToDelete)


                End If

                FileToDelete = Application.StartupPath & "\Settings.ahk"

                If System.IO.File.Exists(FileToDelete) = True Then

                    System.IO.File.Delete(FileToDelete)


                End If

                FileToDelete = Application.StartupPath & "\Ahk2exe.exe"

                If System.IO.File.Exists(FileToDelete) = True Then

                    System.IO.File.Delete(FileToDelete)


                End If
                FileToDelete = Application.StartupPath & "\AutoHotkeySC.bin"

                If System.IO.File.Exists(FileToDelete) = True Then

                    System.IO.File.Delete(FileToDelete)

                    FileToDelete = Application.StartupPath & "\BhopIcon.ico"

                    If System.IO.File.Exists(FileToDelete) = True Then
                        System.IO.File.Delete(FileToDelete)
                    End If

                    Threading.Thread.Sleep(500)
                    System.Diagnostics.Process.Start(Application.StartupPath)
                End If
            Else
                MsgBox("Settings files is missing!", MsgBoxStyle.OkOnly, "File missing!")
            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = "Settings file saved!"


        Module1.Main()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            MsgBox("Please select a hotkey.", MsgBoxStyle.OkOnly, "No Hotkey selected!")
        Else
            MsgBox("Hotkey successfully set.", MsgBoxStyle.OkOnly, "Success!")
        End If



    End Sub
    Private Sub CheckForUpdates()
        If tstb.Value = 100 Then
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://pastebin.com/raw/C0GbZJ4r")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion
            If newestversion.Contains(currentversion) Then
                tslbl.Text = ("You are up to date!              ")

            Else
                tslbl.Text = ("Update available!")
            End If
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        System.Threading.Thread.Sleep(10000)
        For i = 0 To 100
            tslbl.Text = "Checking for updates..."
            BackgroundWorker1.ReportProgress(i)
            System.Threading.Thread.Sleep(60)

        Next

    End Sub
    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        tstb.Value = e.ProgressPercentage()



    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        CheckForUpdates()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ogpath As String = Application.StartupPath & "\Bhop.exe"
        Dim temp As String = "C:\Temp"
        Dim rtrn As String = Application.StartupPath & "\Can't Stop the Bhop.exe"
        Dim name As String = "Can't Stop the Bhop.exe"
        Dim file As String = Application.StartupPath & "\Bhop.exe"

        With OpenFileDialog1
            OpenFileDialog1.Filter = "Icon (*.ico)|*.ico"
            OpenFileDialog1.ShowDialog()


        End With
        If IO.File.Exists(file) Then
            Iconchanger.InjectIcon(Application.StartupPath & "\Bhop.exe", OpenFileDialog1.FileName)
            My.Computer.FileSystem.RenameFile(ogpath, name)
        Else
            MsgBox("Bhop.exe is missing. Please build the .exe again.", MsgBoxStyle.OkOnly, ".exe is missing!")
            System.Diagnostics.Process.Start(Application.StartupPath)
        End If


    End Sub

    Private Sub DownloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DownloadToolStripMenuItem.Click
        System.Diagnostics.Process.Start("https://drive.google.com/uc?export=download&id=0B0n8XAuviQKCeEgxNFhmUXNsVmM")
    End Sub
End Class
