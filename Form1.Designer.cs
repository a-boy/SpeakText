namespace SpeakText;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtInput;
    private Button btnSpeak;
    private Button btnExport;
    private string txt = """
我已经成功创建了一个功能完整的文本转语音工具，具有以下特点:
1. 界面设计
- 创建了简洁直观的用户界面
- 添加了多行文本输入框用于输入要转换的文本
- 设计了两个功能按钮："播放语音"和"导出MP3"
- 窗口大小固定，布局合理
2. 核心功能实现
- 使用System.Speech.Synthesis实现文本到语音的转换
- 集成NAudio库实现音频播放功能
- 通过NAudio.Lame实现MP3格式导出
- 添加了错误处理和用户提示
3. 技术特点
- 使用MemoryStream处理音频数据
- 实现了资源的正确释放
- 添加了适当的错误处理机制
- 支持实时语音预览和MP3文件导出
所有功能都已经实现完成，用户可以输入文本，预览语音效果，并将语音导出为MP3文件。程序界面采用中文，操作简单直观。
""";

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        txtInput = new TextBox();
        btnSpeak = new Button();
        btnExport = new Button();
        SuspendLayout();

        // txtInput
        txtInput.Location = new Point(12, 12);
        txtInput.Multiline = true;
        txtInput.Name = "txtInput";
        txtInput.Size = new Size(460, 200);
        txtInput.TabIndex = 0;
        txtInput.Text = txt;

        // btnSpeak
        btnSpeak.Location = new Point(12, 218);
        btnSpeak.Name = "btnSpeak";
        btnSpeak.Size = new Size(120, 30);
        btnSpeak.TabIndex = 1;
        btnSpeak.Text = "播放语音";
        btnSpeak.UseVisualStyleBackColor = true;
        btnSpeak.Click += btnSpeak_Click;

        // btnExport
        btnExport.Location = new Point(138, 218);
        btnExport.Name = "btnExport";
        btnExport.Size = new Size(120, 30);
        btnExport.TabIndex = 2;
        btnExport.Text = "导出MP3";
        btnExport.UseVisualStyleBackColor = true;
        btnExport.Click += btnExport_Click;

        // Form1
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(484, 261);
        Controls.Add(btnExport);
        Controls.Add(btnSpeak);
        Controls.Add(txtInput);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "文本转语音工具";
        FormClosing += Form1_FormClosing;
        ResumeLayout(false);
        PerformLayout();
    }
}
