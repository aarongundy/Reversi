Public Class Menu

    Private Sub btnOnePlayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOnePlayer.Click
        playercount = 1

        If optEasy.Checked = True Then
            difficulty = 1
        ElseIf optMedium.Checked = True Then
            difficulty = 2
        ElseIf optHard.Checked = True Then
            difficulty = 3
        End If

        Dim Form1 As New Form1
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        playercount = 2
        Dim Form1 As New Form1
        Me.Hide()
        Form1.Show()
    End Sub
End Class