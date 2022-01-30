'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Environment
Imports System.Linq
Imports System.Math
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

'This module contains this program's core procedures.
Public Module CoreModule

   Private Const DEGREES_PER_RADIAN As Double = 180 / PI   'Defines the number of degrees per radian.

   'This procedure scans the specified part of the specified image and returns a line with an above average level of detail.
   Private Function AboveAverageLine(ImageO As Bitmap, IsHorizontal As Boolean, StartLine As Integer, EndLine As Integer, Selection As Rectangle) As Integer
      Try
         Dim Direction As Integer = Sign(EndLine - StartLine)
         Dim Threshold As Integer = AverageDetailLevelPerLine(ImageO, IsHorizontal, StartLine, EndLine, Direction, Selection)

         If Not Direction = 0 Then
            For xy As Integer = StartLine To EndLine Step Direction
               If GetDetailLevel(ImageO, xy, IsHorizontal, Direction, Selection) > Threshold Then Return xy
            Next xy
         End If

         Return StartLine
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure scans the specified radial and returns the average detail level.
   Private Function AboveAverageRadialDetailLevel(ImageO As Bitmap, Center As Point, Radius As Integer, Degree As Double, Threshold As Integer) As Integer
      Try
         Dim xy1 As Point = Nothing
         Dim xy2 As Point = Nothing

         For ScanRadius As Integer = Radius To 0 Step -1
            xy1 = New Point(CInt(Sin(Degree.ToRadians()) * ScanRadius) + Center.X, CInt(Cos(Degree.ToRadians()) * ScanRadius) + Center.Y)
            xy2 = New Point(CInt(Sin(Degree.ToRadians()) * (ScanRadius - 1)) + Center.X, CInt(Cos(Degree.ToRadians()) * (ScanRadius - 1)) + Center.Y)

            If xy1.X >= 0 AndAlso xy1.Y >= 0 AndAlso xy2.X >= 0 AndAlso xy2.Y >= 0 AndAlso xy1.X < ImageO.Width AndAlso xy1.Y < ImageO.Height AndAlso xy2.X < ImageO.Width AndAlso xy2.Y < ImageO.Height Then
               If ColorDifference(ImageO.GetPixel(xy1.X, xy1.Y), ImageO.GetPixel(xy2.X, xy2.Y)) > Threshold Then Return ScanRadius
            End If
         Next ScanRadius

         Return 0
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure scans the specified part of the specified image line by line and returns the average detail level.
   Private Function AverageDetailLevelPerLine(ImageO As Bitmap, IsHorizontal As Boolean, StartLine As Integer, EndLine As Integer, Direction As Integer, Selection As Rectangle) As Integer
      Try
         Dim DetailLevels As New List(Of Integer)

         If Direction = 0 Then
            DetailLevels.Add(0)
         Else
            For xy As Integer = StartLine To EndLine Step Direction
               If xy + Direction >= 0 AndAlso xy + Direction < If(IsHorizontal, ImageO.Height, ImageO.Width) - 1 Then DetailLevels.Add(GetDetailLevel(ImageO, xy, IsHorizontal, Direction, Selection))
            Next xy
         End If

         Return CInt(DetailLevels.Average)
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure scans the specified radial and returns the average detail level.
   Private Function AverageRadialDetailLevel(ImageO As Bitmap, Center As Point, Radius As Integer, Degree As Double) As Integer
      Try
         Dim DetailLevels As New List(Of Integer)
         Dim xy1 As Point = Nothing
         Dim xy2 As Point = Nothing

         For ScanRadius As Integer = Radius To 0 Step -1
            xy1 = New Point(CInt(Sin(Degree.ToRadians()) * ScanRadius) + Center.X, CInt(Cos(Degree.ToRadians()) * ScanRadius) + Center.Y)
            xy2 = New Point(CInt(Sin(Degree.ToRadians()) * (ScanRadius - 1)) + Center.X, CInt(Cos(Degree.ToRadians()) * (ScanRadius - 1)) + Center.Y)

            If xy1.X >= 0 AndAlso xy1.Y >= 0 AndAlso xy2.X >= 0 AndAlso xy2.Y >= 0 AndAlso xy1.X < ImageO.Width AndAlso xy1.Y < ImageO.Height AndAlso xy2.X < ImageO.Width AndAlso xy2.Y < ImageO.Height Then
               DetailLevels.Add(ColorDifference(ImageO.GetPixel(xy1.X, xy1.Y), ImageO.GetPixel(xy2.X, xy2.Y)))
            End If
         Next ScanRadius

         Return CInt(DetailLevels.Average)
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure returns the difference between two colors.
   Private Function ColorDifference(ColorO As Color, OtherColor As Color) As Integer
      Try
         Return CInt(Sqrt((Abs(CInt(ColorO.R) - CInt(OtherColor.R)) ^ 2) + (Abs(CInt(ColorO.G) - CInt(OtherColor.G)) ^ 2) + (Abs(CInt(ColorO.B) - CInt(OtherColor.B)) ^ 2)))
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure returns the specified image line's detail level.
   Private Function GetDetailLevel(ImageO As Bitmap, Line As Integer, IsHorizontal As Boolean, Direction As Integer, Selection As Rectangle) As Integer
      Try
         Dim DetailLevels As New List(Of Integer)

         If IsHorizontal Then
            For x As Integer = Selection.X To Selection.X + Selection.Width - 1
               DetailLevels.Add(ColorDifference(ImageO.GetPixel(x, Line), ImageO.GetPixel(x, Line + Direction)))
            Next x
         Else
            For y As Integer = Selection.Y To Selection.Y + Selection.Height - 1
               DetailLevels.Add(ColorDifference(ImageO.GetPixel(Line, y), ImageO.GetPixel(Line + Direction, y)))
            Next y
         End If

         Return CInt(DetailLevels.Average)
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure gives the command to scan the specified part of an image for lines with above average detail levels forming the image subject's area.
   Public Function GetSubjectArea(ImageO As Bitmap, Selection As Rectangle) As List(Of Point)
      Try
         Dim AverageDetailLevel As Integer = Nothing
         Dim Center As New Point(Selection.X + CInt(Selection.Width / 2), Selection.Y + CInt(Selection.Height / 2))
         Dim NewRadius As Integer = Nothing
         Dim Radius As Integer = CInt(Max(Selection.Width / 2, Selection.Height / 2))
         Dim Circumference As Integer = CInt((Radius * 2) * PI)
         Dim SubjectArea As New List(Of Point)

         For Degree As Double = 0 To 359 Step 360 / Circumference
            AverageDetailLevel = AverageRadialDetailLevel(ImageO, Center, Radius, Degree)
            NewRadius = AboveAverageRadialDetailLevel(ImageO, Center, Radius, Degree, AverageDetailLevel)
            SubjectArea.Add(New Point(CInt(Sin(Degree.ToRadians()) * NewRadius) + Center.X, CInt(Cos(Degree.ToRadians()) * NewRadius) + Center.Y))
         Next Degree

         Return SubjectArea
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return New List(Of Point)({})
   End Function

   'This procedure gives the command to scan the specified part of an image for lines with above average detail levels forming the image subject's rectangle.
   Public Function GetSubjectRectangle(ImageO As Bitmap, Selection As Rectangle) As List(Of Point)
      Try
         Dim Left As Integer = AboveAverageLine(ImageO, IsHorizontal:=False, Selection.Left, Selection.Right - 1, Selection)
         Dim Right As Integer = AboveAverageLine(ImageO, IsHorizontal:=False, Selection.Right, Left, Selection)
         Dim Top As Integer = AboveAverageLine(ImageO, IsHorizontal:=True, Selection.Top, Selection.Bottom - 1, Selection)
         Dim Bottom As Integer = AboveAverageLine(ImageO, IsHorizontal:=True, Selection.Bottom, Top, Selection)
         Dim SubjectArea As New List(Of Point)

         SubjectArea.Add(New Point(Left, Top))
         SubjectArea.Add(New Point(Right, Top))
         SubjectArea.Add(New Point(Right, Bottom))
         SubjectArea.Add(New Point(Left, Bottom))

         Return SubjectArea
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return New List(Of Point)({})
   End Function

   'This procedure handles any errors that occur.
   Public Sub HandleError(ExceptionO As Exception)
      Try
         If MessageBox.Show(ExceptionO.Message, My.Application.Info.Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Error) = DialogResult.Cancel Then [Exit](0)
      Catch
         [Exit](0)
      End Try
   End Sub

   'This procedure swaps the two specified variables with each other.
   Public Sub Swap(Of TypeV)(Variable1 As TypeV, Variable2 As TypeV)
      Try
         Dim Variable3 As TypeV = Variable1

         Variable1 = Variable2
         Variable2 = Variable3
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try
   End Sub

   'This procedure converts the specified value measured in degrees to radians.
   <Extension>
   Private Function ToRadians(Degrees As Double) As Double
      Try
         Return Degrees / DEGREES_PER_RADIAN
      Catch ExceptionO As Exception
         HandleError(ExceptionO)
      End Try

      Return Nothing
   End Function
End Module
