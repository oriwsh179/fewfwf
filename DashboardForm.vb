Imports System.Drawing.Drawing2D
Imports Guna.UI2.WinForms
Imports DevExpress.XtraEditors

Public Class DashboardForm
    Inherits XtraForm

    Private InfoTechCard As Panel

    Public Sub New()
        InitializeComponent()
        Me.DoubleBuffered = True
        Me.AutoScaleMode = AutoScaleMode.Dpi
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuildUI()
    End Sub

    Private Sub BuildUI()
        ' الحاوية الرئيسية
        Dim mainPanel As New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = Color.FromArgb(245, 245, 245),
            .Padding = New Padding(40)
        }
        Controls.Add(mainPanel)

        ' كارت المعلوماتية
        InfoTechCard = New Panel With {
            .Size = New Size(900, 600),
            .Location = New Point(50, 50), ' ✅ ضروري لعرض الكارت
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.None
        }

        Dim path As New GraphicsPath()
        path.AddRectangle(New Rectangle(0, 0, InfoTechCard.Width, InfoTechCard.Height))
        InfoTechCard.Region = New Region(path)

        mainPanel.Controls.Add(InfoTechCard)

        ' عنوان الكارت
        Dim title As New Label With {
            .Text = "قسم المعلوماتية",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.FromArgb(50, 50, 50),
            .Location = New Point(30, 20),
            .AutoSize = True
        }
        InfoTechCard.Controls.Add(title)

        ' خط فاصل
        Dim line1 As New Label With {
            .BackColor = Color.LightGray,
            .Size = New Size(800, 2),
            .Location = New Point(30, 60)
        }
        InfoTechCard.Controls.Add(line1)

        ' الدوائر الثلاث
        Dim circleTypes = {"أصولي", "حكومي", "حسب الدائرة"}
        For i = 0 To 2
            Dim circle As New Guna2CircleProgressBar With {
                .Size = New Size(150, 150),
                .Location = New Point(50 + i * 250, 100),
                .Value = 75,
                .FillThickness = 10,
                .ProgressThickness = 10,
                .ProgressColor = Color.FromArgb(0, 192, 192),
                .Minimum = 0,
                .Maximum = 100
            }
            Dim label As New Label With {
                .Text = circleTypes(i),
                .Font = New Font("Segoe UI", 10, FontStyle.Bold),
                .ForeColor = Color.Black,
                .Location = New Point(circle.Left + 30, circle.Bottom + 10),
                .AutoSize = True
            }
            InfoTechCard.Controls.Add(circle)
            InfoTechCard.Controls.Add(label)
        Next

        ' زر التفاصيل
        Dim detailsBtn As New Guna2Button With {
            .Text = "تفاصيل المعلوماتية",
            .Size = New Size(200, 45),
            .Location = New Point(InfoTechCard.Width - 230, InfoTechCard.Height - 70),
            .FillColor = Color.FromArgb(60, 120, 250),
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .ForeColor = Color.White,
            .BorderRadius = 10
        }
        AddHandler detailsBtn.Click, Sub() MessageBox.Show("فتح نافذة التفاصيل")
        InfoTechCard.Controls.Add(detailsBtn)

        ' أنميشن دخول
        FadeIn(InfoTechCard)
    End Sub

    Private Async Sub FadeIn(ctrl As Control)
        ctrl.Visible = False
        Await Task.Delay(200)
        ctrl.Visible = True
        ctrl.BringToFront() ' ✅ تأكد من الظهور
        ctrl.BackColor = Color.Transparent
        For i = 0 To 255 Step 20
            ctrl.BackColor = Color.FromArgb(i, 255, 255, 255)
            Await Task.Delay(15)
        Next
    End Sub

    Private Sub TileControl1_Click(sender As Object, e As EventArgs) Handles TileControl1.Click

    End Sub
End Class
