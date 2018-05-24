<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActionVessel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ActionVessel))
        Me.lblVesselTitle = New System.Windows.Forms.Label()
        Me.txtmph = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtdesc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pbDelete = New System.Windows.Forms.PictureBox()
        Me.pbSave = New System.Windows.Forms.PictureBox()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.lblusername = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.pbDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblVesselTitle
        '
        Me.lblVesselTitle.AutoSize = True
        Me.lblVesselTitle.Font = New System.Drawing.Font("Verdana", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVesselTitle.Location = New System.Drawing.Point(177, 69)
        Me.lblVesselTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVesselTitle.Name = "lblVesselTitle"
        Me.lblVesselTitle.Size = New System.Drawing.Size(0, 16)
        Me.lblVesselTitle.TabIndex = 39
        '
        'txtmph
        '
        Me.txtmph.Location = New System.Drawing.Point(194, 156)
        Me.txtmph.Margin = New System.Windows.Forms.Padding(4)
        Me.txtmph.MaxLength = 6
        Me.txtmph.Name = "txtmph"
        Me.txtmph.Size = New System.Drawing.Size(116, 23)
        Me.txtmph.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(76, 159)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Move Per Hour"
        '
        'txtdesc
        '
        Me.txtdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdesc.Location = New System.Drawing.Point(194, 69)
        Me.txtdesc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtdesc.MaxLength = 50
        Me.txtdesc.Multiline = True
        Me.txtdesc.Name = "txtdesc"
        Me.txtdesc.Size = New System.Drawing.Size(236, 67)
        Me.txtdesc.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(99, 72)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 16)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Description"
        '
        'txtcode
        '
        Me.txtcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcode.Enabled = False
        Me.txtcode.Location = New System.Drawing.Point(194, 28)
        Me.txtcode.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcode.MaxLength = 10
        Me.txtcode.Name = "txtcode"
        Me.txtcode.Size = New System.Drawing.Size(236, 23)
        Me.txtcode.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(136, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Code"
        '
        'ToolTip1
        '
        '
        'pbDelete
        '
        Me.pbDelete.BackgroundImage = CType(resources.GetObject("pbDelete.BackgroundImage"), System.Drawing.Image)
        Me.pbDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbDelete.Location = New System.Drawing.Point(268, 208)
        Me.pbDelete.Name = "pbDelete"
        Me.pbDelete.Size = New System.Drawing.Size(33, 35)
        Me.pbDelete.TabIndex = 43
        Me.pbDelete.TabStop = False
        '
        'pbSave
        '
        Me.pbSave.BackgroundImage = CType(resources.GetObject("pbSave.BackgroundImage"), System.Drawing.Image)
        Me.pbSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbSave.Location = New System.Drawing.Point(194, 208)
        Me.pbSave.Name = "pbSave"
        Me.pbSave.Size = New System.Drawing.Size(30, 35)
        Me.pbSave.TabIndex = 42
        Me.pbSave.TabStop = False
        '
        'lbldate
        '
        Me.lbldate.AutoSize = True
        Me.lbldate.Location = New System.Drawing.Point(437, 39)
        Me.lbldate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(38, 16)
        Me.lbldate.TabIndex = 41
        Me.lbldate.Text = "date"
        Me.lbldate.Visible = False
        '
        'lbltime
        '
        Me.lbltime.AutoSize = True
        Me.lbltime.Location = New System.Drawing.Point(439, 10)
        Me.lbltime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(36, 16)
        Me.lbltime.TabIndex = 40
        Me.lbltime.Text = "time"
        Me.lbltime.Visible = False
        '
        'lblusername
        '
        Me.lblusername.AutoSize = True
        Me.lblusername.Location = New System.Drawing.Point(402, 69)
        Me.lblusername.Name = "lblusername"
        Me.lblusername.Size = New System.Drawing.Size(73, 16)
        Me.lblusername.TabIndex = 44
        Me.lblusername.Text = "UserName"
        Me.lblusername.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(177, 72)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(15, 20)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(177, 31)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 20)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "*"
        '
        'ActionVessel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 283)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblusername)
        Me.Controls.Add(Me.lblVesselTitle)
        Me.Controls.Add(Me.txtmph)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtdesc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtcode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbDelete)
        Me.Controls.Add(Me.pbSave)
        Me.Controls.Add(Me.lbldate)
        Me.Controls.Add(Me.lbltime)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ActionVessel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit / Delete Vessel"
        CType(Me.pbDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblVesselTitle As Label
    Friend WithEvents txtmph As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtdesc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtcode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents pbDelete As PictureBox
    Friend WithEvents pbSave As PictureBox
    Friend WithEvents lbldate As Label
    Friend WithEvents lbltime As Label
    Friend WithEvents lblusername As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
