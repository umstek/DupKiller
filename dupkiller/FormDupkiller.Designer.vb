<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDupKiller
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
        Me.textFolders = New System.Windows.Forms.TextBox()
        Me.labelFolders = New System.Windows.Forms.Label()
        Me.buttonFolders = New System.Windows.Forms.Button()
        Me.checkSubDir = New System.Windows.Forms.CheckBox()
        Me.buttonScan = New System.Windows.Forms.Button()
        Me.listResults = New System.Windows.Forms.ListBox()
        Me.groupFolders = New System.Windows.Forms.GroupBox()
        Me.groupResults = New System.Windows.Forms.GroupBox()
        Me.buttonAutoSelect = New System.Windows.Forms.Button()
        Me.checkListResults = New System.Windows.Forms.CheckedListBox()
        Me.groupScan = New System.Windows.Forms.GroupBox()
        Me.buttonRemAll = New System.Windows.Forms.Button()
        Me.buttonDemote = New System.Windows.Forms.Button()
        Me.buttonPromote = New System.Windows.Forms.Button()
        Me.buttonRem = New System.Windows.Forms.Button()
        Me.buttonAddAll = New System.Windows.Forms.Button()
        Me.buttonAdd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.labelAllSettings = New System.Windows.Forms.Label()
        Me.listAppliedSettings = New System.Windows.Forms.ListBox()
        Me.listAllSettings = New System.Windows.Forms.ListBox()
        Me.groupDelete = New System.Windows.Forms.GroupBox()
        Me.buttonDelete = New System.Windows.Forms.Button()
        Me.checkEmptyDir = New System.Windows.Forms.CheckBox()
        Me.checkNoRecycle = New System.Windows.Forms.CheckBox()
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog()
        Me.tt = New System.Windows.Forms.ToolTip(Me.components)
        Me.labelScanDesc = New System.Windows.Forms.Label()
        Me.groupFolders.SuspendLayout()
        Me.groupResults.SuspendLayout()
        Me.groupScan.SuspendLayout()
        Me.groupDelete.SuspendLayout()
        Me.SuspendLayout()
        '
        'textFolders
        '
        Me.textFolders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textFolders.Location = New System.Drawing.Point(108, 22)
        Me.textFolders.Name = "textFolders"
        Me.textFolders.Size = New System.Drawing.Size(405, 23)
        Me.textFolders.TabIndex = 1
        Me.tt.SetToolTip(Me.textFolders, "The Folder to Scan for Duplicates.")
        '
        'labelFolders
        '
        Me.labelFolders.Location = New System.Drawing.Point(6, 26)
        Me.labelFolders.Name = "labelFolders"
        Me.labelFolders.Size = New System.Drawing.Size(96, 15)
        Me.labelFolders.TabIndex = 0
        Me.labelFolders.Text = "Folder to Scan"
        '
        'buttonFolders
        '
        Me.buttonFolders.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonFolders.Location = New System.Drawing.Point(519, 22)
        Me.buttonFolders.Name = "buttonFolders"
        Me.buttonFolders.Size = New System.Drawing.Size(75, 23)
        Me.buttonFolders.TabIndex = 3
        Me.buttonFolders.Text = "Browse"
        Me.tt.SetToolTip(Me.buttonFolders, "Browse for a Folder.")
        Me.buttonFolders.UseVisualStyleBackColor = True
        '
        'checkSubDir
        '
        Me.checkSubDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.checkSubDir.Checked = True
        Me.checkSubDir.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkSubDir.Location = New System.Drawing.Point(389, 51)
        Me.checkSubDir.Name = "checkSubDir"
        Me.checkSubDir.Size = New System.Drawing.Size(124, 17)
        Me.checkSubDir.TabIndex = 2
        Me.checkSubDir.Text = "Include Subfolders"
        Me.tt.SetToolTip(Me.checkSubDir, "Recursively Search All Subfolders.")
        Me.checkSubDir.UseVisualStyleBackColor = True
        '
        'buttonScan
        '
        Me.buttonScan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonScan.Location = New System.Drawing.Point(519, 107)
        Me.buttonScan.Name = "buttonScan"
        Me.buttonScan.Size = New System.Drawing.Size(75, 23)
        Me.buttonScan.TabIndex = 10
        Me.buttonScan.Text = "Scan"
        Me.tt.SetToolTip(Me.buttonScan, "Scan Directories for Duplicate Files.")
        Me.buttonScan.UseVisualStyleBackColor = True
        '
        'listResults
        '
        Me.listResults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listResults.FormattingEnabled = True
        Me.listResults.ItemHeight = 15
        Me.listResults.Location = New System.Drawing.Point(6, 22)
        Me.listResults.Name = "listResults"
        Me.listResults.Size = New System.Drawing.Size(170, 109)
        Me.listResults.TabIndex = 0
        Me.tt.SetToolTip(Me.listResults, "Files with Duplicate Copies.")
        '
        'groupFolders
        '
        Me.groupFolders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupFolders.Controls.Add(Me.labelFolders)
        Me.groupFolders.Controls.Add(Me.textFolders)
        Me.groupFolders.Controls.Add(Me.checkSubDir)
        Me.groupFolders.Controls.Add(Me.buttonFolders)
        Me.groupFolders.Location = New System.Drawing.Point(12, 12)
        Me.groupFolders.Name = "groupFolders"
        Me.groupFolders.Size = New System.Drawing.Size(600, 74)
        Me.groupFolders.TabIndex = 0
        Me.groupFolders.TabStop = False
        Me.groupFolders.Text = "Folders"
        '
        'groupResults
        '
        Me.groupResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupResults.Controls.Add(Me.buttonAutoSelect)
        Me.groupResults.Controls.Add(Me.checkListResults)
        Me.groupResults.Controls.Add(Me.listResults)
        Me.groupResults.Location = New System.Drawing.Point(12, 234)
        Me.groupResults.Name = "groupResults"
        Me.groupResults.Size = New System.Drawing.Size(600, 136)
        Me.groupResults.TabIndex = 2
        Me.groupResults.TabStop = False
        Me.groupResults.Text = "Duplicate File Search Results"
        '
        'buttonAutoSelect
        '
        Me.buttonAutoSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonAutoSelect.Location = New System.Drawing.Point(519, 107)
        Me.buttonAutoSelect.Name = "buttonAutoSelect"
        Me.buttonAutoSelect.Size = New System.Drawing.Size(75, 23)
        Me.buttonAutoSelect.TabIndex = 2
        Me.buttonAutoSelect.Text = "Auto Select"
        Me.tt.SetToolTip(Me.buttonAutoSelect, "Select All Except the First Instance for All Files.")
        Me.buttonAutoSelect.UseVisualStyleBackColor = True
        '
        'checkListResults
        '
        Me.checkListResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.checkListResults.FormattingEnabled = True
        Me.checkListResults.Location = New System.Drawing.Point(182, 22)
        Me.checkListResults.Name = "checkListResults"
        Me.checkListResults.Size = New System.Drawing.Size(412, 76)
        Me.checkListResults.TabIndex = 1
        Me.tt.SetToolTip(Me.checkListResults, "Duplicates Instances of File Selected.")
        '
        'groupScan
        '
        Me.groupScan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupScan.Controls.Add(Me.labelScanDesc)
        Me.groupScan.Controls.Add(Me.buttonRemAll)
        Me.groupScan.Controls.Add(Me.buttonDemote)
        Me.groupScan.Controls.Add(Me.buttonPromote)
        Me.groupScan.Controls.Add(Me.buttonRem)
        Me.groupScan.Controls.Add(Me.buttonAddAll)
        Me.groupScan.Controls.Add(Me.buttonAdd)
        Me.groupScan.Controls.Add(Me.Label1)
        Me.groupScan.Controls.Add(Me.labelAllSettings)
        Me.groupScan.Controls.Add(Me.listAppliedSettings)
        Me.groupScan.Controls.Add(Me.listAllSettings)
        Me.groupScan.Controls.Add(Me.buttonScan)
        Me.groupScan.Location = New System.Drawing.Point(12, 92)
        Me.groupScan.Name = "groupScan"
        Me.groupScan.Size = New System.Drawing.Size(600, 136)
        Me.groupScan.TabIndex = 1
        Me.groupScan.TabStop = False
        Me.groupScan.Text = "Scan Settings"
        '
        'buttonRemAll
        '
        Me.buttonRemAll.Location = New System.Drawing.Point(414, 66)
        Me.buttonRemAll.Name = "buttonRemAll"
        Me.buttonRemAll.Size = New System.Drawing.Size(50, 23)
        Me.buttonRemAll.TabIndex = 7
        Me.buttonRemAll.Text = "<<<"
        Me.tt.SetToolTip(Me.buttonRemAll, "Unapply All.")
        Me.buttonRemAll.UseVisualStyleBackColor = True
        '
        'buttonDemote
        '
        Me.buttonDemote.Enabled = False
        Me.buttonDemote.Location = New System.Drawing.Point(414, 107)
        Me.buttonDemote.Name = "buttonDemote"
        Me.buttonDemote.Size = New System.Drawing.Size(25, 23)
        Me.buttonDemote.TabIndex = 8
        Me.buttonDemote.Text = "\/"
        Me.buttonDemote.UseVisualStyleBackColor = True
        '
        'buttonPromote
        '
        Me.buttonPromote.Enabled = False
        Me.buttonPromote.Location = New System.Drawing.Point(439, 107)
        Me.buttonPromote.Name = "buttonPromote"
        Me.buttonPromote.Size = New System.Drawing.Size(25, 23)
        Me.buttonPromote.TabIndex = 9
        Me.buttonPromote.Text = "/\"
        Me.buttonPromote.UseVisualStyleBackColor = True
        '
        'buttonRem
        '
        Me.buttonRem.Location = New System.Drawing.Point(414, 37)
        Me.buttonRem.Name = "buttonRem"
        Me.buttonRem.Size = New System.Drawing.Size(50, 23)
        Me.buttonRem.TabIndex = 6
        Me.buttonRem.Text = "<<"
        Me.tt.SetToolTip(Me.buttonRem, "Unapply Selected. ")
        Me.buttonRem.UseVisualStyleBackColor = True
        '
        'buttonAddAll
        '
        Me.buttonAddAll.Location = New System.Drawing.Point(182, 66)
        Me.buttonAddAll.Name = "buttonAddAll"
        Me.buttonAddAll.Size = New System.Drawing.Size(50, 23)
        Me.buttonAddAll.TabIndex = 3
        Me.buttonAddAll.Text = ">>>"
        Me.tt.SetToolTip(Me.buttonAddAll, "Apply All.")
        Me.buttonAddAll.UseVisualStyleBackColor = True
        '
        'buttonAdd
        '
        Me.buttonAdd.Location = New System.Drawing.Point(182, 37)
        Me.buttonAdd.Name = "buttonAdd"
        Me.buttonAdd.Size = New System.Drawing.Size(50, 23)
        Me.buttonAdd.TabIndex = 2
        Me.buttonAdd.Text = ">>"
        Me.tt.SetToolTip(Me.buttonAdd, "Apply Selected.")
        Me.buttonAdd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(238, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Selected Comparisons Order"
        '
        'labelAllSettings
        '
        Me.labelAllSettings.Location = New System.Drawing.Point(6, 19)
        Me.labelAllSettings.Name = "labelAllSettings"
        Me.labelAllSettings.Size = New System.Drawing.Size(170, 15)
        Me.labelAllSettings.TabIndex = 0
        Me.labelAllSettings.Text = "Available Comparisons"
        '
        'listAppliedSettings
        '
        Me.listAppliedSettings.FormattingEnabled = True
        Me.listAppliedSettings.ItemHeight = 15
        Me.listAppliedSettings.Items.AddRange(New Object() {"File Type (Extension)", "File Size", "Content Hash"})
        Me.listAppliedSettings.Location = New System.Drawing.Point(238, 37)
        Me.listAppliedSettings.Name = "listAppliedSettings"
        Me.listAppliedSettings.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.listAppliedSettings.Size = New System.Drawing.Size(170, 94)
        Me.listAppliedSettings.TabIndex = 5
        Me.tt.SetToolTip(Me.listAppliedSettings, "File Identity Measures Applied for Scanning.")
        '
        'listAllSettings
        '
        Me.listAllSettings.FormattingEnabled = True
        Me.listAllSettings.ItemHeight = 15
        Me.listAllSettings.Items.AddRange(New Object() {"File Name", "Created Time", "Modified Time", "Accessed Time"})
        Me.listAllSettings.Location = New System.Drawing.Point(6, 37)
        Me.listAllSettings.Name = "listAllSettings"
        Me.listAllSettings.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.listAllSettings.Size = New System.Drawing.Size(170, 94)
        Me.listAllSettings.TabIndex = 1
        Me.tt.SetToolTip(Me.listAllSettings, "File Identity Measures.")
        '
        'groupDelete
        '
        Me.groupDelete.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupDelete.Controls.Add(Me.buttonDelete)
        Me.groupDelete.Controls.Add(Me.checkEmptyDir)
        Me.groupDelete.Controls.Add(Me.checkNoRecycle)
        Me.groupDelete.Location = New System.Drawing.Point(12, 376)
        Me.groupDelete.Name = "groupDelete"
        Me.groupDelete.Size = New System.Drawing.Size(600, 53)
        Me.groupDelete.TabIndex = 3
        Me.groupDelete.TabStop = False
        Me.groupDelete.Text = "Clean"
        '
        'buttonDelete
        '
        Me.buttonDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonDelete.Location = New System.Drawing.Point(519, 22)
        Me.buttonDelete.Name = "buttonDelete"
        Me.buttonDelete.Size = New System.Drawing.Size(75, 23)
        Me.buttonDelete.TabIndex = 2
        Me.buttonDelete.Text = "Clean"
        Me.tt.SetToolTip(Me.buttonDelete, "Perform Selected Operations.")
        Me.buttonDelete.UseVisualStyleBackColor = True
        '
        'checkEmptyDir
        '
        Me.checkEmptyDir.AutoSize = True
        Me.checkEmptyDir.Location = New System.Drawing.Point(141, 25)
        Me.checkEmptyDir.Name = "checkEmptyDir"
        Me.checkEmptyDir.Size = New System.Drawing.Size(137, 19)
        Me.checkEmptyDir.TabIndex = 1
        Me.checkEmptyDir.Text = "Delete Empty Folders"
        Me.tt.SetToolTip(Me.checkEmptyDir, "Delete Empty Folders After Cleaning Duplicates.")
        Me.checkEmptyDir.UseVisualStyleBackColor = True
        '
        'checkNoRecycle
        '
        Me.checkNoRecycle.AutoSize = True
        Me.checkNoRecycle.Location = New System.Drawing.Point(6, 25)
        Me.checkNoRecycle.Name = "checkNoRecycle"
        Me.checkNoRecycle.Size = New System.Drawing.Size(129, 19)
        Me.checkNoRecycle.TabIndex = 0
        Me.checkNoRecycle.Text = "Delete Permanently"
        Me.tt.SetToolTip(Me.checkNoRecycle, "Do NOT Move into Recycle Bin.")
        Me.checkNoRecycle.UseVisualStyleBackColor = True
        '
        'fbd
        '
        Me.fbd.RootFolder = System.Environment.SpecialFolder.MyComputer
        Me.fbd.ShowNewFolderButton = False
        '
        'labelScanDesc
        '
        Me.labelScanDesc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelScanDesc.Location = New System.Drawing.Point(470, 19)
        Me.labelScanDesc.Name = "labelScanDesc"
        Me.labelScanDesc.Size = New System.Drawing.Size(124, 85)
        Me.labelScanDesc.TabIndex = 11
        Me.labelScanDesc.Text = "Depending on the files and the settings used, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Scanning may take as much as 1 ho" & _
    "ur to complete." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "So feel free to minimize this window and do your work. We will " & _
    "notify when done."
        Me.tt.SetToolTip(Me.labelScanDesc, "Depending on the files and the settings used, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Scanning may take as much as 1 ho" & _
        "ur to complete." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "So feel free to minimize this window and do your work. We will " & _
        "notify when done.")
        '
        'FormDupKiller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 441)
        Me.Controls.Add(Me.groupDelete)
        Me.Controls.Add(Me.groupScan)
        Me.Controls.Add(Me.groupResults)
        Me.Controls.Add(Me.groupFolders)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "FormDupKiller"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Duplicates cleaner"
        Me.groupFolders.ResumeLayout(False)
        Me.groupFolders.PerformLayout()
        Me.groupResults.ResumeLayout(False)
        Me.groupScan.ResumeLayout(False)
        Me.groupDelete.ResumeLayout(False)
        Me.groupDelete.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents textFolders As System.Windows.Forms.TextBox
    Friend WithEvents labelFolders As System.Windows.Forms.Label
    Friend WithEvents buttonFolders As System.Windows.Forms.Button
    Friend WithEvents checkSubDir As System.Windows.Forms.CheckBox
    Friend WithEvents buttonScan As System.Windows.Forms.Button
    Friend WithEvents listResults As System.Windows.Forms.ListBox
    Friend WithEvents groupFolders As System.Windows.Forms.GroupBox
    Friend WithEvents groupResults As System.Windows.Forms.GroupBox
    Friend WithEvents groupScan As System.Windows.Forms.GroupBox
    Friend WithEvents labelAllSettings As System.Windows.Forms.Label
    Friend WithEvents listAllSettings As System.Windows.Forms.ListBox
    Friend WithEvents listAppliedSettings As System.Windows.Forms.ListBox
    Friend WithEvents buttonRem As System.Windows.Forms.Button
    Friend WithEvents buttonAdd As System.Windows.Forms.Button
    Friend WithEvents buttonRemAll As System.Windows.Forms.Button
    Friend WithEvents buttonAddAll As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents buttonDemote As System.Windows.Forms.Button
    Friend WithEvents buttonPromote As System.Windows.Forms.Button
    Friend WithEvents checkListResults As System.Windows.Forms.CheckedListBox
    Friend WithEvents groupDelete As System.Windows.Forms.GroupBox
    Friend WithEvents checkNoRecycle As System.Windows.Forms.CheckBox
    Friend WithEvents checkEmptyDir As System.Windows.Forms.CheckBox
    Friend WithEvents buttonAutoSelect As System.Windows.Forms.Button
    Friend WithEvents buttonDelete As System.Windows.Forms.Button
    Friend WithEvents fbd As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Friend WithEvents labelScanDesc As System.Windows.Forms.Label

End Class
