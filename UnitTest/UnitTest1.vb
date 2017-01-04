Imports System.IO
Imports dupkiller

<TestClass()>
Public Class UnitTest1
    <TestMethod()>
    Public Sub EmptyDirDelete()
        Const path As String = "F:\Empty\"
        RecursiveDirCreate(path)

        DeleteEmptyDirectories(path)
        If Directory.Exists(path) Then
            Debug.Fail("Empty Directorie(s) not deleted.")
        End If
    End Sub

    Private Sub RecursiveDirCreate(path)
        Try
            Dim rng = New Random()
            For i = 0 To 9
                Dim rndName = IO.Path.GetRandomFileName()
                Directory.CreateDirectory(path + rndName)
                If rng.Next() Mod 10 = 0 Then
                    RecursiveDirCreate(path + rndName + "\")
                End If
                Debug.Print(path + rndName)
            Next
        Catch ex As Exception
            ' pass
        End Try
    End Sub

    <TestMethod()>
    Public Sub GetDuplicates()
        Dim filePaths = GetFiles("E:\LEARNTEMP\")
        Dim dups = GetDuplicatesDictionary(filePaths, {SortCat.FileType, SortCat.FileSize, SortCat.ContentHash})
        For Each kvp In dups
            Debug.Print(kvp.Key)
            For Each v In kvp.Value
                Debug.Print(ControlChars.Tab + v.FullName)
            Next
        Next
        Debug.Flush()
    End Sub
End Class