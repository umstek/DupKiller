Imports System.IO
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic.FileIO

Public Module CoreFunction
    Public Function GetFiles(root As String, Optional subDirs As Boolean = True) As IEnumerable(Of String)
        If subDirs Then
            Return RecurseFiles(root)
        Else
            Return Directory.EnumerateFiles(root)
        End If
    End Function

    Private Function RecurseFiles(path As String) As IEnumerable(Of String)
        Try
            Return Directory.EnumerateFiles(path).Concat(
                From dir In Directory.EnumerateDirectories(path)
                                                            From file In RecurseFiles(dir) Select file)
        Catch ex As Exception
            Return New List(Of String)
        End Try
    End Function

    Public Sub DeleteEmptyDirectories(path As String)
        Try
            Directory.EnumerateDirectories(path).ToList().ForEach(AddressOf DeleteEmptyDirectories)

            If New DirectoryInfo(path).EnumerateFileSystemInfos().Count() = 0 Then Directory.Delete(path)
        Catch ex As Exception
            Return
        End Try
    End Sub

    Public Enum SortCat
        FileType
        FileSize
        FileName
        CreatedTime
        ModifiedTime
        AccessedTime
        ContentHash
    End Enum

    Public Function GetDuplicatesDictionary(filePaths As IEnumerable(Of String),
                                            sortOrder As IEnumerable(Of SortCat)) _
        As IDictionary(Of String, IEnumerable(Of FileInfo))
        Dim fileGroups = From fp In filePaths
                Let fi = New FileInfo(fp)
                Group fi By param = GroupCode(fi, sortOrder)
                Into record = Group
                Where record.Count > 1
                Select New KeyValuePair(Of String, IEnumerable(Of FileInfo))(
                    record.FirstOrDefault().Name + ":" + record.GetHashCode.ToString(), record)

        Return fileGroups.ToDictionary(Function(p) p.Key, Function(p) p.Value)
    End Function

    Private Function ContentHash(fileInfo As FileInfo) As String
        Dim hash = ""

        Using stream = New BufferedStream(File.OpenRead(fileInfo.FullName), (2 ^ 20) * 10)
            Using ha = MD5CryptoServiceProvider.Create()
                hash = Convert.ToBase64String(ha.ComputeHash(stream))
            End Using
        End Using

        Return hash
    End Function

    Private ReadOnly Table As New Dictionary(Of SortCat, Func(Of FileInfo, String)) From {
        {SortCat.FileType, (Function(fi As FileInfo) fi.Extension)},
        {SortCat.FileSize, (Function(fi As FileInfo) fi.Length.ToString())},
        {SortCat.FileName, (Function(fi As FileInfo) fi.Name)},
        {SortCat.CreatedTime, (Function(fi As FileInfo) fi.CreationTime.ToString())},
        {SortCat.ModifiedTime, (Function(fi As FileInfo) fi.LastWriteTime.ToString())},
        {SortCat.AccessedTime, (Function(fi As FileInfo) fi.LastAccessTime.ToString())},
        {SortCat.ContentHash, (Function(fi As FileInfo) ContentHash(fi))}
        }

    Private Function GroupCode(fi As FileInfo, sortOrder As IEnumerable(Of SortCat)) As String
        Return String.Join(separator:=" ", values:=From sc In sortOrder _
    Select Table(sc)(fi))
    End Function

    Public Sub Delete(filePaths As IEnumerable(Of String), Optional recycle As Boolean = True)
        filePaths.ToList().ForEach(
            Sub(fp) My.Computer.FileSystem.DeleteFile(fp, UIOption.AllDialogs,
                                                      If(recycle,
                                                         RecycleOption.SendToRecycleBin,
                                                         RecycleOption.DeletePermanently)))
    End Sub
End Module
