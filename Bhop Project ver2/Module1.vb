Imports System
Imports System.IO
Imports System.Text


Module Module1
    Sub Main()

        Dim path As String = Application.StartupPath & "\Settings.ahk"

        ' Pravi fajl
        Dim fs As FileStream = File.Create(path)

        ' Dodaje text u fajl
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(Form1.ComboBox1.Text + ":: Hotkey, *~$Space, Toggle" & vbNewLine & vbNewLine & "End::" & vbNewLine & "ExitApp" & vbNewLine & vbNewLine & "*~$Space::" & vbNewLine & "Sleep 20" & vbNewLine & "Loop" & vbNewLine & "{" & vbNewLine & "GetKeyState, SpaceState, Space, P" & vbNewLine & "If SpaceState = U" & vbNewLine & "break" & vbNewLine & "Sleep 1" & vbNewLine & "Send, {Blind}{Space}" & vbNewLine & "}" & vbNewLine & "Return")


            fs.Write(info, 0, info.Length)
            fs.Close()

    End Sub

End Module