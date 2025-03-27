using System.Speech.Synthesis;
using NAudio.Wave;
using NAudio.Lame;

namespace SpeakText;

public partial class Form1 : Form
{
    private SpeechSynthesizer synthesizer;
    private MemoryStream audioStream;

    public Form1()
    {
        InitializeComponent();
        InitializeSpeechSynthesizer();
    }

    private void InitializeSpeechSynthesizer()
    {
        synthesizer = new SpeechSynthesizer();
        synthesizer.SetOutputToNull(); // 初始时设置为不输出
    }

    private void btnSpeak_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtInput.Text))
        {
            MessageBox.Show("请输入要转换的文本", "提示");
            return;
        }

        try
        {
            audioStream = new MemoryStream();
            synthesizer.SetOutputToWaveStream(audioStream);
            synthesizer.Speak(txtInput.Text);

            // 重置流位置以便播放
            audioStream.Position = 0;
            using (var waveOut = new WaveOut())
            using (var waveStream = new WaveFileReader(audioStream))
            {
                waveOut.Init(waveStream);
                waveOut.Play();
                while (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    Application.DoEvents();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"播放时发生错误：{ex.Message}", "错误");
        }
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        if (audioStream == null || audioStream.Length == 0)
        {
            MessageBox.Show("请先转换文本为语音", "提示");
            return;
        }

        using (SaveFileDialog saveDialog = new SaveFileDialog()
        {
            Filter = "MP3文件|*.mp3",
            Title = "保存MP3文件"
        })
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    audioStream.Position = 0;
                    using (var reader = new WaveFileReader(audioStream))
                    using (var writer = new LameMP3FileWriter(saveDialog.FileName, reader.WaveFormat, LAMEPreset.STANDARD))
                    {
                        reader.CopyTo(writer);
                    }
                    MessageBox.Show("MP3文件导出成功！", "成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出MP3文件时发生错误：{ex.Message}", "错误");
                }
            }
        }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        synthesizer?.Dispose();
        audioStream?.Dispose();
    }
}
