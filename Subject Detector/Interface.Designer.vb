<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterfaceWindow
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
        Me.ImageBox = New System.Windows.Forms.PictureBox()
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.FileMainMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenImageMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileMainMenuSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMainMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteImageMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMainMenuSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.HighlightColorMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.LineWidthMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMainMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformationMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpMainMenuSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpMenu = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.ImageBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageBox
        '
        Me.ImageBox.BackColor = System.Drawing.Color.White
        Me.ImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ImageBox.Location = New System.Drawing.Point(0, 27)
        Me.ImageBox.Name = "ImageBox"
        Me.ImageBox.Size = New System.Drawing.Size(591, 342)
        Me.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ImageBox.TabIndex = 0
        Me.ImageBox.TabStop = False
        '
        'MenuBar
        '
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMainMenu, Me.EditMainMenu, Me.HelpMainMenu})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(800, 24)
        Me.MenuBar.TabIndex = 2
        Me.MenuBar.Text = "MenuStrip2"
        '
        'FileMainMenu
        '
        Me.FileMainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenImageMenu, Me.FileMainMenuSeparator1, Me.ExitMenu})
        Me.FileMainMenu.Name = "FileMainMenu"
        Me.FileMainMenu.Size = New System.Drawing.Size(37, 20)
        Me.FileMainMenu.Text = "&File"
        '
        'OpenImageMenu
        '
        Me.OpenImageMenu.Name = "OpenImageMenu"
        Me.OpenImageMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenImageMenu.Size = New System.Drawing.Size(182, 22)
        Me.OpenImageMenu.Text = "&Open Image"
        '
        'FileMainMenuSeparator1
        '
        Me.FileMainMenuSeparator1.Name = "FileMainMenuSeparator1"
        Me.FileMainMenuSeparator1.Size = New System.Drawing.Size(179, 6)
        '
        'ExitMenu
        '
        Me.ExitMenu.Name = "ExitMenu"
        Me.ExitMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.ExitMenu.Size = New System.Drawing.Size(182, 22)
        Me.ExitMenu.Text = "&Exit"
        '
        'EditMainMenu
        '
        Me.EditMainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PasteImageMenu, Me.EditMainMenuSeparator1, Me.HighlightColorMenu, Me.LineWidthMenu})
        Me.EditMainMenu.Name = "EditMainMenu"
        Me.EditMainMenu.Size = New System.Drawing.Size(39, 20)
        Me.EditMainMenu.Text = "&Edit"
        '
        'PasteImageMenu
        '
        Me.PasteImageMenu.Name = "PasteImageMenu"
        Me.PasteImageMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteImageMenu.Size = New System.Drawing.Size(199, 22)
        Me.PasteImageMenu.Text = "&Paste Image"
        '
        'EditMainMenuSeparator1
        '
        Me.EditMainMenuSeparator1.Name = "EditMainMenuSeparator1"
        Me.EditMainMenuSeparator1.Size = New System.Drawing.Size(196, 6)
        '
        'HighlightColorMenu
        '
        Me.HighlightColorMenu.Name = "HighlightColorMenu"
        Me.HighlightColorMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.HighlightColorMenu.Size = New System.Drawing.Size(199, 22)
        Me.HighlightColorMenu.Text = "&Highlight Color"
        '
        'LineWidthMenu
        '
        Me.LineWidthMenu.Name = "LineWidthMenu"
        Me.LineWidthMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.LineWidthMenu.Size = New System.Drawing.Size(199, 22)
        Me.LineWidthMenu.Text = "&Line Width"
        '
        'HelpMainMenu
        '
        Me.HelpMainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InformationMenu, Me.HelpMainMenuSeparator1, Me.HelpMenu})
        Me.HelpMainMenu.Name = "HelpMainMenu"
        Me.HelpMainMenu.Size = New System.Drawing.Size(44, 20)
        Me.HelpMainMenu.Text = "&Help"
        '
        'InformationMenu
        '
        Me.InformationMenu.Name = "InformationMenu"
        Me.InformationMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.I), System.Windows.Forms.Keys)
        Me.InformationMenu.Size = New System.Drawing.Size(174, 22)
        Me.InformationMenu.Text = "&Information"
        '
        'HelpMainMenuSeparator1
        '
        Me.HelpMainMenuSeparator1.Name = "HelpMainMenuSeparator1"
        Me.HelpMainMenuSeparator1.Size = New System.Drawing.Size(171, 6)
        '
        'HelpMenu
        '
        Me.HelpMenu.Name = "HelpMenu"
        Me.HelpMenu.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.HelpMenu.Size = New System.Drawing.Size(174, 22)
        Me.HelpMenu.Text = "&Help"
        '
        'InterfaceWindow
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ImageBox)
        Me.Controls.Add(Me.MenuBar)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "InterfaceWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.ImageBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ImageBox As System.Windows.Forms.PictureBox
    Friend WithEvents MenuBar As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMainMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenImageMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMainMenuSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditMainMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMainMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformationMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpMainMenuSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HighlightColorMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LineWidthMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteImageMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditMainMenuSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
