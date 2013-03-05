' 0 = Invisible
' 1 = White
' 2 = Black
'
' Black's Turn is all even numbers
' White goes on odd numbers
'

Imports Microsoft.VisualBasic.PowerPacks

Public Class Form1
    Public Lbl_Array As Label() = New Label(64) {}
    Public Tile_Array As OvalShape() = New OvalShape(64) {}
    Public SContainer As ShapeContainer = New ShapeContainer
    Public Board(8, 8) As Integer
    'Dim TileVisible(64) As Boolean
    Dim color1 As Color = Color.White
    Dim color2 As Color = Color.Black
    Dim turn As Integer
    Dim possible As Boolean
    Dim skipturn As Boolean

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim CNT As Integer

        Dim X As Integer
        Dim Y As Integer
        Dim H As Integer
        Dim W As Integer
        Dim r, c, r1, c1 As Integer

        Y = Lbl_Master.Location.Y
        H = Lbl_Master.Height
        W = Lbl_Master.Width

        CNT = 1
        For c = 1 To 8
            X = Lbl_Master.Location.X
            For r = 1 To 8
                Lbl_Array(CNT) = New Label
                Lbl_Array(CNT).Location = New System.Drawing.Point(X, Y)
                Lbl_Array(CNT).Size = New System.Drawing.Size(W, H)
                Lbl_Array(CNT).AutoSize = Lbl_Master.AutoSize
                Lbl_Array(CNT).BackColor = Lbl_Master.BackColor
                Lbl_Array(CNT).BorderStyle = Lbl_Master.BorderStyle
                Lbl_Array(CNT).TextAlign = Lbl_Master.TextAlign
                Lbl_Array(CNT).ForeColor = Lbl_Master.ForeColor
                Lbl_Array(CNT).Font = Lbl_Master.Font
                'Lbl_Array(CNT).Text = CNT
                Lbl_Array(CNT).Tag = CNT ' This is the clever bit so that we can find the index!
                Lbl_Array(CNT).Visible = True
                Lbl_Array(CNT).SendToBack()
                AddHandler Lbl_Array(CNT).Click, AddressOf lblArray_click
                Panel1.Controls.Add(Lbl_Array(CNT))
                X = (X + W) + 4
                CNT += 1
            Next
            Y = (Y + H) + 4
        Next

        SContainer = New ShapeContainer
        SContainer.Location = New System.Drawing.Point(X, Y)
        'SContainer.Size = Me.ClientSize
        Panel1.Controls.Add(SContainer)
        'Dim circle As OvalShape = New OvalShape

        CNT = 1

        Y = Tile_Master.Location.Y
        H = Tile_Master.Height
        W = Tile_Master.Width

        For c1 = 1 To 8
            X = Tile_Master.Location.X
            For r1 = 1 To 8
                Tile_Array(CNT) = New OvalShape
                Tile_Array(CNT).Location = New System.Drawing.Point(X, Y)
                Tile_Array(CNT).Size = New System.Drawing.Size(W, H)
                'Tile_Array(CNT).AutoSize = Lbl_Master.AutoSize
                Tile_Array(CNT).BackColor = Tile_Master.BackColor
                Tile_Array(CNT).BorderStyle = Tile_Master.BorderStyle
                Tile_Array(CNT).BorderColor = Tile_Master.BorderColor
                Tile_Array(CNT).BackStyle = Tile_Master.BackStyle
                'Tile_Array(CNT).TextAlign = Lbl_Master.TextAlign
                Tile_Array(CNT).FillColor = Tile_Master.FillColor
                'Tile_Array(CNT).Font = Lbl_Master.Font
                'Tile_Array(CNT).Text = CNT
                Tile_Array(CNT).Tag = CNT ' This is the clever bit so that we can find the index!
                Tile_Array(CNT).Visible = True
                Tile_Array(CNT).BringToFront()
                AddHandler Tile_Array(CNT).Click, AddressOf Tile_Array_click
                'Panel1.Controls.Add(Tile_Array(CNT))
                SContainer.Shapes.Add(Tile_Array(CNT))
                Panel1.Controls.Add(SContainer)
                X = (X + W) + 14
                CNT += 1
            Next
            Y = (Y + H) + 14
        Next
        SContainer.BringToFront()

        Board(4, 4) = 1
        Board(4, 5) = 2
        Board(5, 4) = 2
        Board(5, 5) = 1

        lblTurn.Text = "Black's Turn"

        'Board(6, 5) = 1
        refreshTiles()
    End Sub

    Private Sub lblArray_click(sender As Object, e As EventArgs)
        Dim square, x, y As Integer
        square = Val(sender.tag)

        If square Mod 8 <> 0 Then
            x = square Mod 8
            y = square \ 8 + 1
        Else
            x = 8
            y = square \ 8
        End If

        check(x, y)

        If Board(x, y) = 0 And possible = True Then
            If turn Mod 2 = 1 Then ' White's Turn
                Board(x, y) = 1
            Else ' Black's Turn
                Board(x, y) = 2
            End If

            makeTurn()

            possible = False
            refreshTiles()
            count()
        End If
    End Sub

    Private Sub Tile_Array_click(sender As Object, e As EventArgs)
        Label1.Text = sender.tag

    End Sub

    Private Sub refreshTiles()
        For r = 1 To 8
            For c = 1 To 8
                If Board(c, r) = 1 Then
                    Tile_Array(r * 8 - (8 - c)).BackColor = color1
                    Tile_Array(r * 8 - (8 - c)).Visible = True
                ElseIf Board(c, r) = 2 Then
                    Tile_Array(r * 8 - (8 - c)).BackColor = color2
                    Tile_Array(r * 8 - (8 - c)).Visible = True
                Else
                    Tile_Array(r * 8 - (8 - c)).Visible = False
                End If
            Next
        Next
    End Sub

    Private Sub check(ByVal x, ByVal y)
        Dim x1, y1, x2, y2 As Integer
        x1 = 1
        y1 = 1

        If turn Mod 2 = 0 Then                          ' if black's turn
            x1 = 1
            y1 = 1

            If x - x1 > 0 Then
                x2 = x - x1
            End If

            If Board(x2, y) = 1 Then                    ' To the Left
                Do Until Board(x2, y) = 2
                    If x - x1 > 0 Then
                        x1 += 1
                        x2 = x - x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y) = 0 Then            ' If tile is blank exit
                        Exit Do
                    End If

                    If Board(x2, y) = 2 Then
                        For i = 1 To x1
                            x2 = x - i
                            Board(x2, y) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1
            If x + x1 < 8 Then
                x2 = x + x1
            End If
            If Board(x2, y) = 1 Then                    ' To the Right
                Do Until Board(x2, y) = 2
                    If x + x1 < 8 Then
                        x1 += 1
                        x2 = x + x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y) = 0 Then            ' If tile is blank exit
                        Exit Do
                    End If

                    If Board(x2, y) = 2 Then
                        For i = 1 To x1
                            x2 = x + i
                            Board(x2, y) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1
            If y + y1 < 8 Then
                y2 = y + y1
            End If

            If Board(x, y2) = 1 Then                    ' Below
                Do Until Board(x, y2) = 2
                    If y + y1 < 8 Then
                        y1 += 1
                        y2 = y + y1
                    Else
                        Exit Do
                    End If

                    If Board(x, y2) = 0 Then            ' if tile is blank
                        Exit Do
                    End If

                    If Board(x, y2) = 2 Then
                        For i = 1 To y1
                            y2 = y + i
                            Board(x, y2) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1
            If y - y1 > 0 Then
                y2 = y - y1
            End If
            If Board(x, y2) = 1 Then                    ' Above
                Do Until Board(x, y2) = 2
                    If y - y1 > 0 Then
                        y1 += 1
                        y2 = y - y1
                    Else
                        Exit Do
                    End If

                    If Board(x, y2) = 0 Then            ' if tile is blank
                        Exit Do
                    End If

                    If Board(x, y2) = 2 Then
                        For i = 1 To y1
                            y2 = y - i
                            Board(x, y2) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x - x1 > 0 Then
                x2 = x - x1
            End If


            If y - y1 > 0 Then
                y2 = y - y1
            End If

            If Board(x2, y2) = 1 Then                    ' Top Left
                Do Until Board(x2, y2) = 2
                    If y - y1 > 0 Then
                        y1 += 1
                        y2 = y - y1
                    Else
                        Exit Do
                    End If

                    If x - x1 > 0 Then
                        x1 += 1
                        x2 = x - x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 2 Then
                        For i = 1 To x1
                            x2 = x - i
                            y2 = y - i
                            Board(x2, y2) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x + x1 < 8 Then
                x2 = x + x1
            End If

            If y - y1 > 0 Then
                y2 = y - y1
            End If

            If Board(x2, y2) = 1 Then                    ' Top Right
                Do Until Board(x2, y2) = 2
                    If y - y1 > 0 Then
                        y1 += 1
                        y2 = y - y1
                    Else
                        Exit Do
                    End If

                    If x + x1 < 8 Then
                        x1 += 1
                        x2 = x + x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 2 Then
                        For i = 1 To x1
                            x2 = x + i
                            y2 = y - i
                            Board(x2, y2) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x + x1 < 8 Then
                x2 = x + x1
            End If

            If y + y1 < 8 Then
                y2 = y + y1
            End If

            If Board(x2, y2) = 1 Then                    ' Bottom Right
                Do Until Board(x2, y2) = 2
                    If y + y1 < 8 Then
                        y1 += 1
                        y2 = y + y1
                    Else
                        Exit Do
                    End If

                    If x + x1 < 8 Then
                        x1 += 1
                        x2 = x + x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 2 Then
                        For i = 1 To x1
                            x2 = x + i
                            y2 = y + i
                            Board(x2, y2) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x - x1 > 0 Then
                x2 = x - x1
            End If

            If y + y1 < 8 Then
                y2 = y + y1
            End If

            If Board(x2, y2) = 1 Then                    ' Bottom Left
                Do Until Board(x2, y2) = 2
                    If y + y1 < 8 Then
                        y1 += 1
                        y2 = y + y1
                    Else
                        Exit Do
                    End If

                    If x - x1 > 0 Then
                        x1 += 1
                        x2 = x - x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 2 Then
                        For i = 1 To x1
                            x2 = x - i
                            y2 = y + i
                            Board(x2, y2) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If
        Else                                            ' white's turn
            x2 = x - x1
            If Board(x2, y) = 2 Then                    ' To the Left
                Do Until Board(x2, y) = 1
                    If x - x1 > 0 Then
                        x1 += 1
                        x2 = x - x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y) = 1 Then
                        For i = 1 To x1
                            x2 = x - i
                            Board(x2, y) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If


            x1 = 1
            y1 = 1

            If x + x1 < 8 Then
                x2 = x + x1
            End If

            If Board(x2, y) = 2 Then                    ' To the right
                Do Until Board(x2, y) = 1
                    If x + x1 < 8 Then
                        x1 += 1
                        x2 = x + x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y) = 1 Then
                        For i = 1 To x1
                            x2 = x + i
                            Board(x2, y) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If


            x1 = 1
            y1 = 1
            If y + y1 < 8 Then
                y2 = y + y1
            End If

            If Board(x, y2) = 2 Then                    ' Below
                Do Until Board(x, y2) = 1
                    If y + y1 < 8 Then
                        y1 += 1
                        y2 = y + y1
                    Else
                        Exit Do
                    End If

                    If Board(x, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x, y2) = 1 Then
                        For i = 1 To y1
                            y2 = y + i
                            Board(x, y2) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1
            y2 = y - y1
            If Board(x, y2) = 2 Then                    ' Above
                Do Until Board(x, y2) = 1
                    If y - y1 > 0 Then
                        y1 += 1
                        y2 = y - y1
                    Else
                        Exit Do
                    End If

                    If Board(x, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x, y2) = 1 Then
                        For i = 1 To y1
                            y2 = y - i
                            Board(x, y2) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x - x1 > 0 Then
                x2 = x - x1
            End If


            If y - y1 > 0 Then
                y2 = y - y1
            End If

            If Board(x2, y2) = 2 Then                    ' Top Left
                Do Until Board(x2, y2) = 1
                    If y - y1 > 0 Then
                        y1 += 1
                        y2 = y - y1
                    Else
                        Exit Do
                    End If

                    If x - x1 > 0 Then
                        x1 += 1
                        x2 = x - x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 1 Then
                        For i = 1 To x1
                            x2 = x - i
                            y2 = y - i
                            Board(x2, y2) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x + x1 < 8 Then
                x2 = x + x1
            End If

            If y - y1 > 0 Then
                y2 = y - y1
            End If

            If Board(x2, y2) = 2 Then                    ' Top Right
                Do Until Board(x2, y2) = 1
                    If y - y1 > 0 Then
                        y1 += 1
                        y2 = y - y1
                    Else
                        Exit Do
                    End If

                    If x + x1 < 8 Then
                        x1 += 1
                        x2 = x + x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 1 Then
                        For i = 1 To x1
                            x2 = x + i
                            y2 = y - i
                            Board(x2, y2) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x + x1 < 8 Then
                x2 = x + x1
            End If

            If y + y1 < 8 Then
                y2 = y + y1
            End If

            If Board(x2, y2) = 2 Then                    ' Bottom Right
                Do Until Board(x2, y2) = 1
                    If y + y1 < 8 Then
                        y1 += 1
                        y2 = y + y1
                    Else
                        Exit Do
                    End If

                    If x + x1 < 8 Then
                        x1 += 1
                        x2 = x + x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 1 Then
                        For i = 1 To x1
                            x2 = x + i
                            y2 = y + i
                            Board(x2, y2) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x - x1 > 0 Then
                x2 = x - x1
            End If

            If y + y1 < 8 Then
                y2 = y + y1
            End If

            If Board(x2, y2) = 2 Then                    ' Bottom Left
                Do Until Board(x2, y2) = 1
                    If y + y1 < 8 Then
                        y1 += 1
                        y2 = y + y1
                    Else
                        Exit Do
                    End If

                    If x - x1 > 0 Then
                        x1 += 1
                        x2 = x - x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 1 Then
                        For i = 1 To x1
                            x2 = x - i
                            y2 = y + i
                            Board(x2, y2) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If
        End If
    End Sub

    Private Sub count()
        Dim white, black As Integer

        For r = 1 To 8
            For c = 1 To 8
                If Board(c, r) = 1 Then
                    white += 1
                ElseIf Board(c, r) = 2 Then
                    black += 1
                End If
            Next
        Next

        If white + black = 64 Then
            win(white, black)
        End If

        lblWhiteCount.Text = white
        lblBlackCount.Text = black
    End Sub

    Private Sub possibleCheck(ByVal x, ByVal y)
        Dim x1, y1, x2, y2 As Integer
        x1 = 1
        y1 = 1

        If turn Mod 2 = 0 Then                          ' if black's turn
            x1 = 1
            y1 = 1

            If x - x1 > 0 Then
                x2 = x - x1
            End If

            If Board(x2, y) = 1 Then                    ' To the Left
                Do Until Board(x2, y) = 2
                    If x - x1 > 0 Then
                        x1 += 1
                        x2 = x - x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y) = 0 Then            ' If tile is blank exit
                        Exit Do
                    End If

                    If Board(x2, y) = 2 Then
                        For i = 1 To x1
                            x2 = x - i
                            'Board(x2, y) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1
            If x + x1 < 8 Then
                x2 = x + x1
            End If
            If Board(x2, y) = 1 Then                    ' To the Right
                Do Until Board(x2, y) = 2
                    If x + x1 < 8 Then
                        x1 += 1
                        x2 = x + x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y) = 0 Then            ' If tile is blank exit
                        Exit Do
                    End If

                    If Board(x2, y) = 2 Then
                        For i = 1 To x1
                            x2 = x + i
                            'Board(x2, y) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1
            If y + y1 < 8 Then
                y2 = y + y1
            End If

            If Board(x, y2) = 1 Then                    ' Below
                Do Until Board(x, y2) = 2
                    If y + y1 < 8 Then
                        y1 += 1
                        y2 = y + y1
                    Else
                        Exit Do
                    End If

                    If Board(x, y2) = 0 Then            ' if tile is blank
                        Exit Do
                    End If

                    If Board(x, y2) = 2 Then
                        For i = 1 To y1
                            y2 = y + i
                            'Board(x, y2) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1
            If y - y1 > 0 Then
                y2 = y - y1
            End If
            If Board(x, y2) = 1 Then                    ' Above
                Do Until Board(x, y2) = 2
                    If y - y1 > 0 Then
                        y1 += 1
                        y2 = y - y1
                    Else
                        Exit Do
                    End If

                    If Board(x, y2) = 0 Then            ' if tile is blank
                        Exit Do
                    End If

                    If Board(x, y2) = 2 Then
                        For i = 1 To y1
                            y2 = y - i
                            'Board(x, y2) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x - x1 > 0 Then
                x2 = x - x1
            End If


            If y - y1 > 0 Then
                y2 = y - y1
            End If

            If Board(x2, y2) = 1 Then                    ' Top Left
                Do Until Board(x2, y2) = 2
                    If y - y1 > 0 Then
                        y1 += 1
                        y2 = y - y1
                    Else
                        Exit Do
                    End If

                    If x - x1 > 0 Then
                        x1 += 1
                        x2 = x - x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 2 Then
                        For i = 1 To x1
                            x2 = x - i
                            y2 = y - i
                            'Board(x2, y2) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x + x1 < 8 Then
                x2 = x + x1
            End If

            If y - y1 > 0 Then
                y2 = y - y1
            End If

            If Board(x2, y2) = 1 Then                    ' Top Right
                Do Until Board(x2, y2) = 2
                    If y - y1 > 0 Then
                        y1 += 1
                        y2 = y - y1
                    Else
                        Exit Do
                    End If

                    If x + x1 < 8 Then
                        x1 += 1
                        x2 = x + x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 2 Then
                        For i = 1 To x1
                            x2 = x + i
                            y2 = y - i
                            'Board(x2, y2) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x + x1 < 8 Then
                x2 = x + x1
            End If

            If y + y1 < 8 Then
                y2 = y + y1
            End If

            If Board(x2, y2) = 1 Then                    ' Bottom Right
                Do Until Board(x2, y2) = 2
                    If y + y1 < 8 Then
                        y1 += 1
                        y2 = y + y1
                    Else
                        Exit Do
                    End If

                    If x + x1 < 8 Then
                        x1 += 1
                        x2 = x + x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 2 Then
                        For i = 1 To x1
                            x2 = x + i
                            y2 = y + i
                            'Board(x2, y2) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x - x1 > 0 Then
                x2 = x - x1
            End If

            If y + y1 < 8 Then
                y2 = y + y1
            End If

            If Board(x2, y2) = 1 Then                    ' Bottom Left
                Do Until Board(x2, y2) = 2
                    If y + y1 < 8 Then
                        y1 += 1
                        y2 = y + y1
                    Else
                        Exit Do
                    End If

                    If x - x1 > 0 Then
                        x1 += 1
                        x2 = x - x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 2 Then
                        For i = 1 To x1
                            x2 = x - i
                            y2 = y + i
                            'Board(x2, y2) = 2
                        Next
                        possible = True
                    End If
                Loop
            End If
        Else                                            ' white's turn
            x2 = x - x1
            If Board(x2, y) = 2 Then                    ' To the Left
                Do Until Board(x2, y) = 1
                    If x - x1 > 0 Then
                        x1 += 1
                        x2 = x - x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y) = 1 Then
                        For i = 1 To x1
                            x2 = x - i
                            'Board(x2, y) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If


            x1 = 1
            y1 = 1

            If x + x1 < 8 Then
                x2 = x + x1
            End If

            If Board(x2, y) = 2 Then                    ' To the right
                Do Until Board(x2, y) = 1
                    If x + x1 < 8 Then
                        x1 += 1
                        x2 = x + x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y) = 1 Then
                        For i = 1 To x1
                            x2 = x + i
                            'Board(x2, y) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If


            x1 = 1
            y1 = 1
            If y + y1 < 8 Then
                y2 = y + y1
            End If

            If Board(x, y2) = 2 Then                    ' Below
                Do Until Board(x, y2) = 1
                    If y + y1 < 8 Then
                        y1 += 1
                        y2 = y + y1
                    Else
                        Exit Do
                    End If

                    If Board(x, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x, y2) = 1 Then
                        For i = 1 To y1
                            y2 = y + i
                            'Board(x, y2) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1
            y2 = y - y1
            If Board(x, y2) = 2 Then                    ' Above
                Do Until Board(x, y2) = 1
                    If y - y1 > 0 Then
                        y1 += 1
                        y2 = y - y1
                    Else
                        Exit Do
                    End If

                    If Board(x, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x, y2) = 1 Then
                        For i = 1 To y1
                            y2 = y - i
                            'Board(x, y2) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x - x1 > 0 Then
                x2 = x - x1
            End If


            If y - y1 > 0 Then
                y2 = y - y1
            End If

            If Board(x2, y2) = 2 Then                    ' Top Left
                Do Until Board(x2, y2) = 1
                    If y - y1 > 0 Then
                        y1 += 1
                        y2 = y - y1
                    Else
                        Exit Do
                    End If

                    If x - x1 > 0 Then
                        x1 += 1
                        x2 = x - x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 1 Then
                        For i = 1 To x1
                            x2 = x - i
                            y2 = y - i
                            'Board(x2, y2) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x + x1 < 8 Then
                x2 = x + x1
            End If

            If y - y1 > 0 Then
                y2 = y - y1
            End If

            If Board(x2, y2) = 2 Then                    ' Top Right
                Do Until Board(x2, y2) = 1
                    If y - y1 > 0 Then
                        y1 += 1
                        y2 = y - y1
                    Else
                        Exit Do
                    End If

                    If x + x1 < 8 Then
                        x1 += 1
                        x2 = x + x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 1 Then
                        For i = 1 To x1
                            x2 = x + i
                            y2 = y - i
                            'Board(x2, y2) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x + x1 < 8 Then
                x2 = x + x1
            End If

            If y + y1 < 8 Then
                y2 = y + y1
            End If

            If Board(x2, y2) = 2 Then                    ' Bottom Right
                Do Until Board(x2, y2) = 1
                    If y + y1 < 8 Then
                        y1 += 1
                        y2 = y + y1
                    Else
                        Exit Do
                    End If

                    If x + x1 < 8 Then
                        x1 += 1
                        x2 = x + x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 1 Then
                        For i = 1 To x1
                            x2 = x + i
                            y2 = y + i
                            'Board(x2, y2) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If

            x1 = 1
            y1 = 1

            If x - x1 > 0 Then
                x2 = x - x1
            End If

            If y + y1 < 8 Then
                y2 = y + y1
            End If

            If Board(x2, y2) = 2 Then                    ' Bottom Left
                Do Until Board(x2, y2) = 1
                    If y + y1 < 8 Then
                        y1 += 1
                        y2 = y + y1
                    Else
                        Exit Do
                    End If

                    If x - x1 > 0 Then
                        x1 += 1
                        x2 = x - x1
                    Else
                        Exit Do
                    End If

                    If Board(x2, y2) = 0 Then
                        Exit Do
                    End If

                    If Board(x2, y2) = 1 Then
                        For i = 1 To x1
                            x2 = x - i
                            y2 = y + i
                            'Board(x2, y2) = 1
                        Next
                        possible = True
                    End If
                Loop
            End If
        End If
    End Sub

    Private Sub turnCalc()
        For r = 1 To 8
            For c = 1 To 8
                If Board(c, r) = 0 Then
                    possibleCheck(c, r)
                End If

                If possible = True Then
                    skipturn = False
                    Exit For
                End If
            Next
            If possible = True Then Exit For
        Next
        If possible = False And skipturn = True Then
            Dim white, black As Integer
            count()

            white = Val(lblWhiteCount.Text)
            black = Val(lblBlackCount.Text)

            win(white, black)
        ElseIf possible = False Then
            lblMessage.Text = "Player could not mover skipped turn."
            turn += 1
            skipturn = True
            makeTurn()
        End If
    End Sub

    Private Sub btnNewGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGame.Click
        Dim Form1 As New Form1
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub win(ByVal white, ByVal black)
        If white > black Then
            MessageBox.Show("White won! \n Black:" & black & " White:" & white, "White Wins!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        ElseIf white < black Then
            MessageBox.Show("Black won! \n Black:" & black & " White:" & white, "Black Wins!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub makeTurn()
        If turn Mod 2 = 1 Then ' White's Turn
            ovalTurn.FillColor = color2
            lblTurn.Text = "Black's Turn"
            'Board(x, y) = 1
            turn += 1
        Else ' Black's Turn
            ovalTurn.FillColor = color1
            lblTurn.Text = "White's Turn"
            'Board(x, y) = 2
            turn += 1
        End If
        turnCalc()
    End Sub
End Class