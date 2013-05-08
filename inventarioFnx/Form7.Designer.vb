<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7))
        Me.razonsocial = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.linea1 = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.linea2 = New System.Windows.Forms.MaskedTextBox()
        Me.linea3 = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rfc = New System.Windows.Forms.MaskedTextBox()
        Me.suc3 = New System.Windows.Forms.MaskedTextBox()
        Me.suc2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.suc1 = New System.Windows.Forms.MaskedTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'razonsocial
        '
        Me.razonsocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.razonsocial.Location = New System.Drawing.Point(12, 70)
        Me.razonsocial.Mask = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
        Me.razonsocial.Name = "razonsocial"
        Me.razonsocial.Size = New System.Drawing.Size(474, 26)
        Me.razonsocial.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Razón social"
        '
        'linea1
        '
        Me.linea1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linea1.Location = New System.Drawing.Point(12, 143)
        Me.linea1.Mask = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
        Me.linea1.Name = "linea1"
        Me.linea1.Size = New System.Drawing.Size(474, 26)
        Me.linea1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Domicilio fiscal"
        '
        'linea2
        '
        Me.linea2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linea2.Location = New System.Drawing.Point(12, 175)
        Me.linea2.Mask = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
        Me.linea2.Name = "linea2"
        Me.linea2.Size = New System.Drawing.Size(474, 26)
        Me.linea2.TabIndex = 4
        '
        'linea3
        '
        Me.linea3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linea3.Location = New System.Drawing.Point(12, 207)
        Me.linea3.Mask = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
        Me.linea3.Name = "linea3"
        Me.linea3.Size = New System.Drawing.Size(474, 26)
        Me.linea3.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "R. F. C."
        '
        'rfc
        '
        Me.rfc.BeepOnError = True
        Me.rfc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rfc.Location = New System.Drawing.Point(12, 25)
        Me.rfc.Mask = "&&&&&&&&&&&&"
        Me.rfc.Name = "rfc"
        Me.rfc.Size = New System.Drawing.Size(130, 26)
        Me.rfc.TabIndex = 7
        '
        'suc3
        '
        Me.suc3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.suc3.Location = New System.Drawing.Point(12, 333)
        Me.suc3.Mask = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
        Me.suc3.Name = "suc3"
        Me.suc3.Size = New System.Drawing.Size(474, 26)
        Me.suc3.TabIndex = 11
        '
        'suc2
        '
        Me.suc2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.suc2.Location = New System.Drawing.Point(12, 301)
        Me.suc2.Mask = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
        Me.suc2.Name = "suc2"
        Me.suc2.Size = New System.Drawing.Size(474, 26)
        Me.suc2.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 253)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Domicilio de la sucursal"
        '
        'suc1
        '
        Me.suc1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.suc1.Location = New System.Drawing.Point(12, 269)
        Me.suc1.Mask = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA"
        Me.suc1.Name = "suc1"
        Me.suc1.Size = New System.Drawing.Size(474, 26)
        Me.suc1.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(411, 370)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form7
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 405)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.suc3)
        Me.Controls.Add(Me.suc2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.suc1)
        Me.Controls.Add(Me.rfc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.linea3)
        Me.Controls.Add(Me.linea2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.linea1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.razonsocial)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form7"
        Me.Text = "Datos del ticket"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents razonsocial As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents linea1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents linea2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents linea3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rfc As System.Windows.Forms.MaskedTextBox
    Friend WithEvents suc3 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents suc2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents suc1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
