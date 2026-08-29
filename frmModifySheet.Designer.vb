<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModifySheet
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbMB = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbMT = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbMR = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbML = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbAngle = New System.Windows.Forms.CheckBox()
        Me.btPick = New System.Windows.Forms.Button()
        Me.lbAngle = New System.Windows.Forms.Label()
        Me.tbAngle = New System.Windows.Forms.TextBox()
        Me.tbY = New System.Windows.Forms.TextBox()
        Me.lbY = New System.Windows.Forms.Label()
        Me.cbIP = New System.Windows.Forms.CheckBox()
        Me.tbX = New System.Windows.Forms.TextBox()
        Me.lbX = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(290, 211)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbMB)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.tbMT)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.tbMR)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.tbML)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(235, 193)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sheet Dimensions"
        '
        'tbMB
        '
        Me.tbMB.Location = New System.Drawing.Point(95, 97)
        Me.tbMB.Name = "tbMB"
        Me.tbMB.Size = New System.Drawing.Size(123, 20)
        Me.tbMB.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Margin Bottom"
        '
        'tbMT
        '
        Me.tbMT.Location = New System.Drawing.Point(95, 71)
        Me.tbMT.Name = "tbMT"
        Me.tbMT.Size = New System.Drawing.Size(123, 20)
        Me.tbMT.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Margin Top"
        '
        'tbMR
        '
        Me.tbMR.Location = New System.Drawing.Point(95, 45)
        Me.tbMR.Name = "tbMR"
        Me.tbMR.Size = New System.Drawing.Size(123, 20)
        Me.tbMR.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Margin Right"
        '
        'tbML
        '
        Me.tbML.Location = New System.Drawing.Point(95, 19)
        Me.tbML.Name = "tbML"
        Me.tbML.Size = New System.Drawing.Size(123, 20)
        Me.tbML.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Margin Left"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbAngle)
        Me.GroupBox1.Controls.Add(Me.btPick)
        Me.GroupBox1.Controls.Add(Me.lbAngle)
        Me.GroupBox1.Controls.Add(Me.tbAngle)
        Me.GroupBox1.Controls.Add(Me.tbY)
        Me.GroupBox1.Controls.Add(Me.lbY)
        Me.GroupBox1.Controls.Add(Me.cbIP)
        Me.GroupBox1.Controls.Add(Me.tbX)
        Me.GroupBox1.Controls.Add(Me.lbX)
        Me.GroupBox1.Location = New System.Drawing.Point(253, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(185, 193)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Insertion Point"
        '
        'cbAngle
        '
        Me.cbAngle.AutoSize = True
        Me.cbAngle.Checked = True
        Me.cbAngle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAngle.Location = New System.Drawing.Point(6, 100)
        Me.cbAngle.Name = "cbAngle"
        Me.cbAngle.Size = New System.Drawing.Size(113, 17)
        Me.cbAngle.TabIndex = 11
        Me.cbAngle.Text = "Specify On-screen"
        Me.cbAngle.UseVisualStyleBackColor = True
        '
        'btPick
        '
        Me.btPick.Image = My.Resources.Resources.pick
        Me.btPick.Location = New System.Drawing.Point(46, 149)
        Me.btPick.Name = "btPick"
        Me.btPick.Size = New System.Drawing.Size(42, 34)
        Me.btPick.TabIndex = 10
        Me.btPick.UseVisualStyleBackColor = True
        '
        'lbAngle
        '
        Me.lbAngle.AutoSize = True
        Me.lbAngle.Location = New System.Drawing.Point(6, 126)
        Me.lbAngle.Name = "lbAngle"
        Me.lbAngle.Size = New System.Drawing.Size(34, 13)
        Me.lbAngle.TabIndex = 2
        Me.lbAngle.Text = "Angle"
        '
        'tbAngle
        '
        Me.tbAngle.Location = New System.Drawing.Point(46, 123)
        Me.tbAngle.Name = "tbAngle"
        Me.tbAngle.Size = New System.Drawing.Size(123, 20)
        Me.tbAngle.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.tbAngle, "Angle expressed in WCB (decimal degrees)")
        '
        'tbY
        '
        Me.tbY.Location = New System.Drawing.Point(46, 73)
        Me.tbY.Name = "tbY"
        Me.tbY.Size = New System.Drawing.Size(123, 20)
        Me.tbY.TabIndex = 8
        '
        'lbY
        '
        Me.lbY.AutoSize = True
        Me.lbY.Location = New System.Drawing.Point(6, 76)
        Me.lbY.Name = "lbY"
        Me.lbY.Size = New System.Drawing.Size(14, 13)
        Me.lbY.TabIndex = 4
        Me.lbY.Text = "Y"
        '
        'cbIP
        '
        Me.cbIP.AutoSize = True
        Me.cbIP.Checked = True
        Me.cbIP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbIP.Location = New System.Drawing.Point(6, 19)
        Me.cbIP.Name = "cbIP"
        Me.cbIP.Size = New System.Drawing.Size(113, 17)
        Me.cbIP.TabIndex = 6
        Me.cbIP.Text = "Specify On-screen"
        Me.cbIP.UseVisualStyleBackColor = True
        '
        'tbX
        '
        Me.tbX.Location = New System.Drawing.Point(46, 47)
        Me.tbX.Name = "tbX"
        Me.tbX.Size = New System.Drawing.Size(123, 20)
        Me.tbX.TabIndex = 7
        '
        'lbX
        '
        Me.lbX.AutoSize = True
        Me.lbX.Location = New System.Drawing.Point(6, 50)
        Me.lbX.Name = "lbX"
        Me.lbX.Size = New System.Drawing.Size(17, 13)
        Me.lbX.TabIndex = 2
        Me.lbX.Text = "X:"
        '
        'frmModifySheet
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(448, 252)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmModifySheet"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modify Sheet"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbMB As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbMT As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbMR As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbML As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btPick As System.Windows.Forms.Button
    Friend WithEvents lbAngle As System.Windows.Forms.Label
    Friend WithEvents tbAngle As System.Windows.Forms.TextBox
    Friend WithEvents tbY As System.Windows.Forms.TextBox
    Friend WithEvents lbY As System.Windows.Forms.Label
    Friend WithEvents cbIP As System.Windows.Forms.CheckBox
    Friend WithEvents tbX As System.Windows.Forms.TextBox
    Friend WithEvents lbX As System.Windows.Forms.Label
    Friend WithEvents cbAngle As System.Windows.Forms.CheckBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
