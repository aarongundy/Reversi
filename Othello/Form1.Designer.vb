<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Tile_Master = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.Lbl_Master = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ovalTurn = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.OvalShape2 = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.OvalShape1 = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.lblTurn = New System.Windows.Forms.Label()
        Me.btnNewGame = New System.Windows.Forms.Button()
        Me.lblWhiteCount = New System.Windows.Forms.Label()
        Me.lblBlackCount = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Controls.Add(Me.Lbl_Master)
        Me.Panel1.Location = New System.Drawing.Point(71, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(580, 580)
        Me.Panel1.TabIndex = 7
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Tile_Master})
        Me.ShapeContainer1.Size = New System.Drawing.Size(580, 580)
        Me.ShapeContainer1.TabIndex = 8
        Me.ShapeContainer1.TabStop = False
        '
        'Tile_Master
        '
        Me.Tile_Master.BackColor = System.Drawing.Color.Black
        Me.Tile_Master.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.Tile_Master.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.Tile_Master.Location = New System.Drawing.Point(55, 55)
        Me.Tile_Master.Name = "Tile_Master"
        Me.Tile_Master.SelectionColor = System.Drawing.Color.Black
        Me.Tile_Master.Size = New System.Drawing.Size(46, 46)
        Me.Tile_Master.Visible = False
        '
        'Lbl_Master
        '
        Me.Lbl_Master.BackColor = System.Drawing.Color.Green
        Me.Lbl_Master.Location = New System.Drawing.Point(50, 50)
        Me.Lbl_Master.Name = "Lbl_Master"
        Me.Lbl_Master.Size = New System.Drawing.Size(56, 56)
        Me.Lbl_Master.TabIndex = 7
        Me.Lbl_Master.Text = "Label1"
        Me.Lbl_Master.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(598, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Label1"
        '
        'ovalTurn
        '
        Me.ovalTurn.BackColor = System.Drawing.Color.Black
        Me.ovalTurn.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.ovalTurn.FillColor = System.Drawing.Color.Black
        Me.ovalTurn.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.ovalTurn.Location = New System.Drawing.Point(49, 3)
        Me.ovalTurn.Name = "ovalTurn"
        Me.ovalTurn.Size = New System.Drawing.Size(46, 46)
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.OvalShape2, Me.OvalShape1, Me.ovalTurn})
        Me.ShapeContainer2.Size = New System.Drawing.Size(742, 723)
        Me.ShapeContainer2.TabIndex = 9
        Me.ShapeContainer2.TabStop = False
        '
        'OvalShape2
        '
        Me.OvalShape2.BackColor = System.Drawing.Color.Black
        Me.OvalShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.OvalShape2.FillColor = System.Drawing.Color.White
        Me.OvalShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.OvalShape2.Location = New System.Drawing.Point(525, 650)
        Me.OvalShape2.Name = "OvalShape2"
        Me.OvalShape2.Size = New System.Drawing.Size(46, 46)
        '
        'OvalShape1
        '
        Me.OvalShape1.BackColor = System.Drawing.Color.Black
        Me.OvalShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.OvalShape1.FillColor = System.Drawing.Color.Black
        Me.OvalShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.OvalShape1.Location = New System.Drawing.Point(600, 650)
        Me.OvalShape1.Name = "OvalShape1"
        Me.OvalShape1.Size = New System.Drawing.Size(46, 46)
        '
        'lblTurn
        '
        Me.lblTurn.AutoSize = True
        Me.lblTurn.Location = New System.Drawing.Point(109, 26)
        Me.lblTurn.Name = "lblTurn"
        Me.lblTurn.Size = New System.Drawing.Size(0, 13)
        Me.lblTurn.TabIndex = 10
        '
        'btnNewGame
        '
        Me.btnNewGame.Location = New System.Drawing.Point(20, 666)
        Me.btnNewGame.Name = "btnNewGame"
        Me.btnNewGame.Size = New System.Drawing.Size(75, 23)
        Me.btnNewGame.TabIndex = 11
        Me.btnNewGame.Text = "New Game"
        Me.btnNewGame.UseVisualStyleBackColor = True
        '
        'lblWhiteCount
        '
        Me.lblWhiteCount.AutoSize = True
        Me.lblWhiteCount.BackColor = System.Drawing.Color.White
        Me.lblWhiteCount.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhiteCount.Location = New System.Drawing.Point(536, 662)
        Me.lblWhiteCount.Name = "lblWhiteCount"
        Me.lblWhiteCount.Size = New System.Drawing.Size(21, 23)
        Me.lblWhiteCount.TabIndex = 12
        Me.lblWhiteCount.Text = "0"
        Me.lblWhiteCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBlackCount
        '
        Me.lblBlackCount.AutoSize = True
        Me.lblBlackCount.BackColor = System.Drawing.Color.Black
        Me.lblBlackCount.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlackCount.ForeColor = System.Drawing.Color.White
        Me.lblBlackCount.Location = New System.Drawing.Point(611, 662)
        Me.lblBlackCount.Name = "lblBlackCount"
        Me.lblBlackCount.Size = New System.Drawing.Size(21, 23)
        Me.lblBlackCount.TabIndex = 13
        Me.lblBlackCount.Text = "0"
        Me.lblBlackCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Location = New System.Drawing.Point(233, 27)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(0, 13)
        Me.lblMessage.TabIndex = 14
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 723)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.lblBlackCount)
        Me.Controls.Add(Me.lblWhiteCount)
        Me.Controls.Add(Me.btnNewGame)
        Me.Controls.Add(Me.lblTurn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ShapeContainer2)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Othello"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Lbl_Master As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Tile_Master As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ovalTurn As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents lblTurn As System.Windows.Forms.Label
    Friend WithEvents btnNewGame As System.Windows.Forms.Button
    Friend WithEvents OvalShape2 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents OvalShape1 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents lblWhiteCount As System.Windows.Forms.Label
    Friend WithEvents lblBlackCount As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label

End Class
