<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
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
        Me.btnOnePlayer = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optHard = New System.Windows.Forms.RadioButton()
        Me.optMedium = New System.Windows.Forms.RadioButton()
        Me.optEasy = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOnePlayer
        '
        Me.btnOnePlayer.Location = New System.Drawing.Point(28, 38)
        Me.btnOnePlayer.Name = "btnOnePlayer"
        Me.btnOnePlayer.Size = New System.Drawing.Size(75, 23)
        Me.btnOnePlayer.TabIndex = 0
        Me.btnOnePlayer.Text = "One Player"
        Me.btnOnePlayer.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(28, 67)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Two Players"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optHard)
        Me.GroupBox1.Controls.Add(Me.optMedium)
        Me.GroupBox1.Controls.Add(Me.optEasy)
        Me.GroupBox1.Location = New System.Drawing.Point(160, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(112, 100)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Difficulty"
        '
        'optHard
        '
        Me.optHard.AutoSize = True
        Me.optHard.Location = New System.Drawing.Point(7, 66)
        Me.optHard.Name = "optHard"
        Me.optHard.Size = New System.Drawing.Size(48, 17)
        Me.optHard.TabIndex = 2
        Me.optHard.Text = "Hard"
        Me.optHard.UseVisualStyleBackColor = True
        '
        'optMedium
        '
        Me.optMedium.AutoSize = True
        Me.optMedium.Location = New System.Drawing.Point(7, 43)
        Me.optMedium.Name = "optMedium"
        Me.optMedium.Size = New System.Drawing.Size(62, 17)
        Me.optMedium.TabIndex = 1
        Me.optMedium.Text = "Medium"
        Me.optMedium.UseVisualStyleBackColor = True
        '
        'optEasy
        '
        Me.optEasy.AutoSize = True
        Me.optEasy.Checked = True
        Me.optEasy.Location = New System.Drawing.Point(7, 20)
        Me.optEasy.Name = "optEasy"
        Me.optEasy.Size = New System.Drawing.Size(48, 17)
        Me.optEasy.TabIndex = 0
        Me.optEasy.TabStop = True
        Me.optEasy.Text = "Easy"
        Me.optEasy.UseVisualStyleBackColor = True
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 142)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnOnePlayer)
        Me.Name = "Menu"
        Me.Text = "Menu"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOnePlayer As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optHard As System.Windows.Forms.RadioButton
    Friend WithEvents optMedium As System.Windows.Forms.RadioButton
    Friend WithEvents optEasy As System.Windows.Forms.RadioButton
End Class
