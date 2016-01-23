<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblStr = New System.Windows.Forms.Label()
        Me.lblDex = New System.Windows.Forms.Label()
        Me.lblCon = New System.Windows.Forms.Label()
        Me.lblInt = New System.Windows.Forms.Label()
        Me.lblWis = New System.Windows.Forms.Label()
        Me.lblCha = New System.Windows.Forms.Label()
        Me.btnStatroll = New System.Windows.Forms.Button()
        Me.radHuman = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.radDwarf = New System.Windows.Forms.RadioButton()
        Me.radElf = New System.Windows.Forms.RadioButton()
        Me.radHalfElf = New System.Windows.Forms.RadioButton()
        Me.radHalfling = New System.Windows.Forms.RadioButton()
        Me.radGnome = New System.Windows.Forms.RadioButton()
        Me.lstClasses = New System.Windows.Forms.ListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnHProll = New System.Windows.Forms.Button()
        Me.lblHP = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.txtClassInfo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Strength"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(106, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Dexterity"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(204, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Constitution"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Intelligence"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(107, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Wisdom"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(204, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Charisma"
        '
        'lblStr
        '
        Me.lblStr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStr.Location = New System.Drawing.Point(11, 28)
        Me.lblStr.Name = "lblStr"
        Me.lblStr.Size = New System.Drawing.Size(49, 16)
        Me.lblStr.TabIndex = 1
        '
        'lblDex
        '
        Me.lblDex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDex.Location = New System.Drawing.Point(109, 28)
        Me.lblDex.Name = "lblDex"
        Me.lblDex.Size = New System.Drawing.Size(49, 16)
        Me.lblDex.TabIndex = 3
        '
        'lblCon
        '
        Me.lblCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCon.Location = New System.Drawing.Point(207, 28)
        Me.lblCon.Name = "lblCon"
        Me.lblCon.Size = New System.Drawing.Size(49, 16)
        Me.lblCon.TabIndex = 5
        '
        'lblInt
        '
        Me.lblInt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInt.Location = New System.Drawing.Point(11, 78)
        Me.lblInt.Name = "lblInt"
        Me.lblInt.Size = New System.Drawing.Size(49, 16)
        Me.lblInt.TabIndex = 7
        '
        'lblWis
        '
        Me.lblWis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWis.Location = New System.Drawing.Point(109, 78)
        Me.lblWis.Name = "lblWis"
        Me.lblWis.Size = New System.Drawing.Size(49, 16)
        Me.lblWis.TabIndex = 9
        '
        'lblCha
        '
        Me.lblCha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCha.Location = New System.Drawing.Point(207, 78)
        Me.lblCha.Name = "lblCha"
        Me.lblCha.Size = New System.Drawing.Size(49, 16)
        Me.lblCha.TabIndex = 11
        '
        'btnStatroll
        '
        Me.btnStatroll.Location = New System.Drawing.Point(181, 106)
        Me.btnStatroll.Name = "btnStatroll"
        Me.btnStatroll.Size = New System.Drawing.Size(75, 23)
        Me.btnStatroll.TabIndex = 12
        Me.btnStatroll.Text = "Roll Stats"
        Me.btnStatroll.UseVisualStyleBackColor = True
        '
        'radHuman
        '
        Me.radHuman.AutoSize = True
        Me.radHuman.Checked = True
        Me.radHuman.Enabled = False
        Me.radHuman.Location = New System.Drawing.Point(15, 124)
        Me.radHuman.Name = "radHuman"
        Me.radHuman.Size = New System.Drawing.Size(65, 19)
        Me.radHuman.TabIndex = 14
        Me.radHuman.TabStop = True
        Me.radHuman.Text = "Human"
        Me.radHuman.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 106)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 15)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Race:"
        '
        'radDwarf
        '
        Me.radDwarf.AutoSize = True
        Me.radDwarf.Enabled = False
        Me.radDwarf.Location = New System.Drawing.Point(15, 149)
        Me.radDwarf.Name = "radDwarf"
        Me.radDwarf.Size = New System.Drawing.Size(56, 19)
        Me.radDwarf.TabIndex = 15
        Me.radDwarf.Text = "Dwarf"
        Me.radDwarf.UseVisualStyleBackColor = True
        '
        'radElf
        '
        Me.radElf.AutoSize = True
        Me.radElf.Enabled = False
        Me.radElf.Location = New System.Drawing.Point(15, 174)
        Me.radElf.Name = "radElf"
        Me.radElf.Size = New System.Drawing.Size(38, 19)
        Me.radElf.TabIndex = 16
        Me.radElf.Text = "Elf"
        Me.radElf.UseVisualStyleBackColor = True
        '
        'radHalfElf
        '
        Me.radHalfElf.AutoSize = True
        Me.radHalfElf.Enabled = False
        Me.radHalfElf.Location = New System.Drawing.Point(15, 199)
        Me.radHalfElf.Name = "radHalfElf"
        Me.radHalfElf.Size = New System.Drawing.Size(65, 19)
        Me.radHalfElf.TabIndex = 17
        Me.radHalfElf.Text = "Half-Elf"
        Me.radHalfElf.UseVisualStyleBackColor = True
        '
        'radHalfling
        '
        Me.radHalfling.AutoSize = True
        Me.radHalfling.Enabled = False
        Me.radHalfling.Location = New System.Drawing.Point(15, 224)
        Me.radHalfling.Name = "radHalfling"
        Me.radHalfling.Size = New System.Drawing.Size(67, 19)
        Me.radHalfling.TabIndex = 18
        Me.radHalfling.Text = "Halfling"
        Me.radHalfling.UseVisualStyleBackColor = True
        '
        'radGnome
        '
        Me.radGnome.AutoSize = True
        Me.radGnome.Enabled = False
        Me.radGnome.Location = New System.Drawing.Point(15, 249)
        Me.radGnome.Name = "radGnome"
        Me.radGnome.Size = New System.Drawing.Size(64, 19)
        Me.radGnome.TabIndex = 19
        Me.radGnome.Text = "Gnome"
        Me.radGnome.UseVisualStyleBackColor = True
        '
        'lstClasses
        '
        Me.lstClasses.FormattingEnabled = True
        Me.lstClasses.ItemHeight = 15
        Me.lstClasses.Location = New System.Drawing.Point(105, 135)
        Me.lstClasses.Name = "lstClasses"
        Me.lstClasses.Size = New System.Drawing.Size(156, 109)
        Me.lstClasses.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(107, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 15)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Class:"
        '
        'btnHProll
        '
        Me.btnHProll.Enabled = False
        Me.btnHProll.Location = New System.Drawing.Point(105, 247)
        Me.btnHProll.Name = "btnHProll"
        Me.btnHProll.Size = New System.Drawing.Size(89, 23)
        Me.btnHProll.TabIndex = 22
        Me.btnHProll.Text = "Roll Base HP"
        Me.btnHProll.UseVisualStyleBackColor = True
        '
        'lblHP
        '
        Me.lblHP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHP.Location = New System.Drawing.Point(200, 252)
        Me.lblHP.Name = "lblHP"
        Me.lblHP.Size = New System.Drawing.Size(61, 16)
        Me.lblHP.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(391, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 15)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Basic Statistics"
        '
        'txtInfo
        '
        Me.txtInfo.BackColor = System.Drawing.SystemColors.Control
        Me.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtInfo.Location = New System.Drawing.Point(293, 28)
        Me.txtInfo.Multiline = True
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.ReadOnly = True
        Me.txtInfo.Size = New System.Drawing.Size(279, 497)
        Me.txtInfo.TabIndex = 25
        '
        'txtClassInfo
        '
        Me.txtClassInfo.BackColor = System.Drawing.SystemColors.Control
        Me.txtClassInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClassInfo.Location = New System.Drawing.Point(8, 296)
        Me.txtClassInfo.Multiline = True
        Me.txtClassInfo.Name = "txtClassInfo"
        Me.txtClassInfo.ReadOnly = True
        Me.txtClassInfo.Size = New System.Drawing.Size(279, 229)
        Me.txtClassInfo.TabIndex = 26
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(106, 278)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 15)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Class Statistics"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 539)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtClassInfo)
        Me.Controls.Add(Me.txtInfo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblHP)
        Me.Controls.Add(Me.btnHProll)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lstClasses)
        Me.Controls.Add(Me.radGnome)
        Me.Controls.Add(Me.radHalfling)
        Me.Controls.Add(Me.radHalfElf)
        Me.Controls.Add(Me.radElf)
        Me.Controls.Add(Me.radDwarf)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.radHuman)
        Me.Controls.Add(Me.btnStatroll)
        Me.Controls.Add(Me.lblCha)
        Me.Controls.Add(Me.lblWis)
        Me.Controls.Add(Me.lblInt)
        Me.Controls.Add(Me.lblCon)
        Me.Controls.Add(Me.lblDex)
        Me.Controls.Add(Me.lblStr)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMain"
        Me.Text = "AD&D Character Creator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblStr As System.Windows.Forms.Label
    Friend WithEvents lblDex As System.Windows.Forms.Label
    Friend WithEvents lblCon As System.Windows.Forms.Label
    Friend WithEvents lblInt As System.Windows.Forms.Label
    Friend WithEvents lblWis As System.Windows.Forms.Label
    Friend WithEvents lblCha As System.Windows.Forms.Label
    Friend WithEvents btnStatroll As System.Windows.Forms.Button
    Friend WithEvents radHuman As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents radDwarf As System.Windows.Forms.RadioButton
    Friend WithEvents radElf As System.Windows.Forms.RadioButton
    Friend WithEvents radHalfElf As System.Windows.Forms.RadioButton
    Friend WithEvents radHalfling As System.Windows.Forms.RadioButton
    Friend WithEvents radGnome As System.Windows.Forms.RadioButton
    Friend WithEvents lstClasses As System.Windows.Forms.ListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnHProll As System.Windows.Forms.Button
    Friend WithEvents lblHP As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtInfo As System.Windows.Forms.TextBox
    Friend WithEvents txtClassInfo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label

End Class
