'This class's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Environment
Imports System.Linq
Imports System.Math
Imports System.Windows.Forms

'This class contains this program's main interface window.
Public Class InterfaceWindow
   Private LineWidth As Integer = 2                      'Contains the line width used to highlight the image's detected subject.
   Private Selection As Rectangle? = Nothing             'Contains the selected image selection to be searched for a subject.
   Private SelectionStart As Point = Nothing             'Contains the start of the user's selection.
   Private SubjectO As List(Of Point) = Nothing          'Contains the detected image subject location.

   Private ReadOnly ColorDialogO As New ColorDialog                                                           'Contains the color dialog.
   Private ReadOnly FileDialogO As New OpenFileDialog                                                         'Contains the open file dialog.
   Private ReadOnly SelectionPen As New Pen(Color.Black, 1) With {.DashStyle = Drawing2D.DashStyle.DashDot}   'Contains the pen used to draw the selection rectangle.
   Private ReadOnly ToolTipO As New ToolTip                                                                   'Contains this window's tooltip.

   'This procedure initializes this windows.
   Public Sub New()
      Try
         InitializeComponent()

         With My.Application.Info
            Me.Text = $"{ .Title} v{ .Version} - by: { .CompanyName}"
         End With

         With My.Computer.Screen.WorkingArea
            Me.Size = New Size(CInt(.Width / 1.1), CInt(.Height / 1.1))
         End With

         ImageBox.Size = New Size(0, 0)

         ToolTipO.SetToolTip(ImageBox, "Press F1 for help.")
         ToolTipO.SetToolTip(Me, "Press F1 for help.")
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure closes this window.
   Private Sub ExitMenu_Click(sender As Object, e As EventArgs) Handles ExitMenu.Click
      Try
         Me.Close()
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure displays the help.
   Private Sub HelpMenu_Click(sender As Object, e As EventArgs) Handles HelpMenu.Click
      Try
         MessageBox.Show(My.Resources.Help, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure displays the highlight color dialog.
   Private Sub HighlightColorMenu_Click(sender As Object, e As EventArgs) Handles HighlightColorMenu.Click
      Try
         ColorDialogO.ShowDialog()
         Me.Invalidate()
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure handles the user's mouse clicks.
   Private Sub ImageBox_MouseDown(sender As Object, e As MouseEventArgs) Handles ImageBox.MouseDown
      Try
         If e.Button = MouseButtons.Left Then
            Subject = Nothing
            Selection = New Rectangle(e.X, e.Y, 0, 0)
            SelectionStart = New Point(e.X, e.Y)
         End If
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure handles the user's mouse movement.
   Private Sub ImageBox_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove, ImageBox.MouseMove
      Try
         If e.Button = MouseButtons.Left AndAlso Selection IsNot Nothing Then
            Dim x1 As Integer = If(e.X < ImageBox.Width, Min(e.X, SelectionStart.X), SelectionStart.X)
            Dim y1 As Integer = If(e.Y < ImageBox.Height, Min(e.Y, SelectionStart.Y), SelectionStart.Y)
            Dim x2 As Integer = If(e.X < ImageBox.Width, Max(e.X, SelectionStart.X), ImageBox.Width - 1)
            Dim y2 As Integer = If(e.Y < ImageBox.Height, Max(e.Y, SelectionStart.Y), ImageBox.Height - 1)

            If x1 > x2 Then Swap(x1, x2)
            If y1 > y2 Then Swap(y1, y2)

            Selection = New Rectangle(x1, y1, x2 - x1, y2 - y1)

            ImageBox.Invalidate()
         End If
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure handles the user's mouse clicks.
   Private Sub ImageBox_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp, ImageBox.MouseUp
      Try
         If e.Button = MouseButtons.Left AndAlso Selection IsNot Nothing AndAlso Selection.Value.Width > 0 AndAlso Selection.Value.Height > 0 Then GetSubject()
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure handles the user's double mouse clicks.
   Private Sub ImageBox_DoubleClick(sender As Object, e As EventArgs) Handles ImageBox.DoubleClick
      Try
         Selection = New Rectangle(0, 0, ImageBox.Image.Width - 1, ImageBox.Image.Height - 1)
         GetSubject()
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure draws this window's graphics.
   Private Sub ImageBox_Paint(sender As Object, e As PaintEventArgs) Handles ImageBox.Paint
      Try
         If Selection IsNot Nothing Then
            e.Graphics.DrawRectangle(New Pen(Color.White), Selection.Value)
            e.Graphics.DrawRectangle(SelectionPen, Selection.Value)
         ElseIf Subject IsNot Nothing Then
            e.Graphics.DrawPolygon(New Pen(ColorDialogO.Color, LineWidth), Subject.ToArray())
         End If
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure displays information about this program.
   Private Sub InformationMenu_Click(sender As Object, e As EventArgs) Handles InformationMenu.Click
      Try
         With My.Application.Info
            MessageBox.Show($"{ .Title} v{ .Version.ToString()} - by: { .CompanyName}, ***{ .Copyright}***{NewLine}{ .Description}", .Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End With
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to load the file dropped into the window.
   Private Sub InterfaceWindow_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
      Try
         If e.Data.GetDataPresent(DataFormats.FileDrop) Then ImageBox.Image = New Bitmap(DirectCast(e.Data.GetData(DataFormats.FileDrop), String()).First)
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure handles objects being dragged into the window.
   Private Sub InterfaceWindow_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
      Try
         If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.All
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure requests the user to specify a line width.
   Private Sub LineWidthMenu_Click(sender As Object, e As EventArgs) Handles LineWidthMenu.Click
      Try
         Dim NewLineWidth As Integer = Nothing

         Integer.TryParse(InputBox("Line width:",, LineWidth.ToString()), NewLineWidth)
         If Not NewLineWidth = Nothing Then
            LineWidth = NewLineWidth
            Me.Invalidate()
         End If
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to display the dialog to allow the user to open an image.
   Private Sub OpenImageMenu_Click(sender As Object, e As EventArgs) Handles OpenImageMenu.Click
      Try
         With FileDialogO
            If .ShowDialog() = DialogResult.OK Then ImageBox.Image = New Bitmap(.FileName)
         End With
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure pastes an image from the clipboard into the highlighting window.
   Private Sub PasteImageMenu_Click(sender As Object, e As EventArgs) Handles PasteImageMenu.Click
      Try
         ImageBox.Image = My.Computer.Clipboard.GetImage()
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to extract the image subject's location.
   Private Sub GetSubject()
      Try
         If ImageBox.Image IsNot Nothing Then
            ImageBox.UseWaitCursor = True
            ImageBox.Cursor = Cursors.WaitCursor

            If My.Computer.Keyboard.ShiftKeyDown Then
               Subject = GetSubjectArea(DirectCast(ImageBox.Image, Bitmap), Selection.Value)
            Else
               Subject = GetSubjectRectangle(DirectCast(ImageBox.Image, Bitmap), Selection.Value)
            End If
         End If

         Selection = Nothing

         Me.Invalidate()
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure manage the detected image subject's location.
   Private Property Subject() As List(Of Point)
      Get
         Try
            Return SubjectO
         Catch ExceptionO As Exception
            HandleError(ExceptionO)
         End Try

         Return New List(Of Point)({})
      End Get
      Set(NewSubject As List(Of Point))
         Try
            SubjectO = NewSubject
            ImageBox.Invalidate()
            ImageBox.UseWaitCursor = False
            ImageBox.Cursor = Cursors.Default
         Catch ExceptionO As Exception
            HandleError(ExceptionO)
         End Try
      End Set
   End Property
End Class
