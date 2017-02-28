F6:: Hotkey, *~$Space, Toggle

End::
ExitApp

*~$Space::
Sleep 20
Loop
{
GetKeyState, SpaceState, Space, P
If SpaceState = U
break
Sleep 1
Send, {Blind}{Space}
}
Return