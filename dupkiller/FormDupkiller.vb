Imports System.IO

Public Class FormDupKiller
    Private Sub buttonFolders_Click(sender As Object, e As EventArgs) Handles buttonFolders.Click
        If fbd.ShowDialog(Me) = DialogResult.OK Then
            textFolders.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub MoveItems(source As ListBox, destination As ListBox, Optional allItems As Boolean = False)

        If allItems Then
            destination.Items.AddRange(source.Items)
            source.Items.Clear()
        Else
            If Not source.SelectedItems.Count < 1 Then
                Dim selected = Aggregate item In source.SelectedItems Select item Into ToList()

                destination.Items.AddRange(selected.ToArray())
                Call selected.ToList().ForEach(Sub(item) source.Items.Remove(item))
            End If
        End If
    End Sub

    Private Sub buttonAdd_Click(sender As Object, e As EventArgs) Handles buttonAdd.Click
        MoveItems(listAllSettings, listAppliedSettings)
    End Sub

    Private Sub buttonRem_Click(sender As Object, e As EventArgs) Handles buttonRem.Click
        MoveItems(listAppliedSettings, listAllSettings)
    End Sub

    Private Sub buttonAddAll_Click(sender As Object, e As EventArgs) Handles buttonAddAll.Click
        MoveItems(listAllSettings, listAppliedSettings, True)
    End Sub

    Private Sub buttonRemAll_Click(sender As Object, e As EventArgs) Handles buttonRemAll.Click
        MoveItems(listAppliedSettings, listAllSettings, True)
    End Sub

    Private Sub buttonDemote_Click(sender As Object, e As EventArgs) Handles buttonDemote.Click
        Dropmote(listAppliedSettings, True)
    End Sub

    Private Sub buttonPromote_Click(sender As Object, e As EventArgs) Handles buttonPromote.Click
        Dropmote(listAppliedSettings)
    End Sub

    Private Sub Dropmote(listBox As ListBox, Optional demote As Boolean = False)
        If listBox.SelectedIndices.Count = 0 Then
            Return
        End If

        Dim selected = (From item In listBox.SelectedItems Select item).ToList()
        Dim notSelected = (From item In listBox.Items Where Not selected.Contains(item) Select item).ToList()

        listBox.Items.Clear()
        listBox.Items.AddRange(If(demote, notSelected.Concat(selected), selected.Concat(notSelected)).ToArray())
    End Sub

    Private ReadOnly _table As New Dictionary(Of String, SortCat) From {
        {"File Type (Extension)", SortCat.FileType},
        {"File Size", SortCat.FileSize},
        {"Content Hash", SortCat.ContentHash},
        {"File Name", SortCat.FileName},
        {"Created Time", SortCat.CreatedTime},
        {"Modified Time", SortCat.ModifiedTime},
        {"Accessed Time", SortCat.AccessedTime}
        }

    Private Async Sub buttonScan_Click(sender As Object, e As EventArgs) Handles buttonScan.Click
        groupFolders.Enabled = False

        Dim sortOrder = (From li In listAppliedSettings.Items Select _table(CStr(li))).ToList()
        Dim dfTask = New Task(Of Dictionary(Of String, IEnumerable(Of FileInfo)))(
            Function() GetDuplicatesDictionary(GetFiles(textFolders.Text, checkSubDir.Checked), sortOrder))
        dfTask.Start()
        listResults.Items.Clear()
        checkListResults.Items.Clear()
        Dim duplicates = Await dfTask

        duplicates.ToList().ForEach(Sub(pair) listResults.Items.Add(pair.Key))
        _duplicates = duplicates
        Dim selected = From kvp In duplicates
                Select New KeyValuePair(Of String, IEnumerable(Of Boolean))(
                    kvp.Key, Enumerable.Repeat(False, kvp.Value.Count()).ToList())
        _selected = selected.ToList().ToDictionary(Function(pair) pair.Key, Function(pair) pair.Value)

        groupResults.Enabled = True
        groupDelete.Enabled = True

        MessageBox.Show("Scanning Complete.", "Scan", MessageBoxButtons.OK, MessageBoxIcon.Information)

        groupFolders.Enabled = True
    End Sub

    Private _duplicates As New Dictionary(Of String, IEnumerable(Of FileInfo))
    Private _selected As New Dictionary(Of String, IEnumerable(Of Boolean))

    Private Sub listResults_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles listResults.SelectedIndexChanged
        If listResults.SelectedItems.Count > 0 Then
            checkListResults.Items.Clear()
            checkListResults.Items.AddRange(Aggregate fi In _duplicates(listResults.SelectedItem)
                                               Select fi.FullName Into ToArray())

            Enumerable.Range(0, _selected(listResults.SelectedItem).Count()).ToList().ForEach(
                Sub(i) checkListResults.SetItemChecked(i, _selected(listResults.SelectedItem)(i)))
        End If
    End Sub

    Private Sub checkListResults_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles checkListResults.ItemCheck
        CType(_selected(listResults.SelectedItem), List(Of Boolean))(e.Index) = e.NewValue
    End Sub

    Private Sub buttonAutoSelect_Click(sender As Object, e As EventArgs) Handles buttonAutoSelect.Click
        _selected.Keys.ToList().ForEach(Sub(key)
                                            Dim checkItems = CType(_selected(key), List(Of Boolean))
                                            checkItems(0) = False
                                            Enumerable.Range(1, checkItems.Count - 1).ToList().ForEach(Sub(i) checkItems(i) = True)
                                        End Sub)
    End Sub

    Private Sub buttonDelete_Click(sender As Object, e As EventArgs) Handles buttonDelete.Click

        If MessageBox.Show("Are you sure you want to perform cleaning?",
                           "Delete?",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Dim toDelete =
                    Aggregate kvp In _selected
                    From ix In Enumerable.Range(0, kvp.Value.Count())
                    Where kvp.Value.ElementAt(ix) = True
                    Select _duplicates(kvp.Key).ElementAt(ix).FullName Into ToList()

            'Debug.Write(String.Join(Environment.NewLine, toDelete))

            Delete(toDelete, Not _checkNoRecycle.Checked)
            If checkEmptyDir.Checked Then
                DeleteEmptyDirectories(textFolders.Text)
            End If

            MessageBox.Show("Cleaning Complete.", "Cleaning", MessageBoxButtons.OK, MessageBoxIcon.Information)
            textFolders.Text = ""
            ResetUi()
        End If
    End Sub

    Private Sub ResetUi()
        groupFolders.Enabled = True
        groupScan.Enabled = False
        groupResults.Enabled = False
        groupDelete.Enabled = False
    End Sub

    Private Sub textFolders_TextChanged(sender As Object, e As EventArgs) Handles textFolders.TextChanged
        ResetUi()
        If Directory.Exists(textFolders.Text) Then
            groupScan.Enabled = True
        End If
    End Sub

    Private Sub FormDupKiller_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ResetUi()
    End Sub
End Class
