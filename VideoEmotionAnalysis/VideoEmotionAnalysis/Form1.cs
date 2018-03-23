using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.ProjectOxford.Emotion;
using Microsoft.ProjectOxford.Emotion.Contract;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace VideoEmotionAnalysis
{
    public partial class Form1 : Form
    {

        private string csvExportHeader_JP =
            "時間,フレーム数,怒り,軽蔑,ムカつき,恐れ,喜び,悲しみ,驚き,無表情\r\n";

        private string csvExportHeader_US =
            "Time,Frame,Anger,Contempt,Disgust,Fear,Happiness,Sadness,Surprise,Neutral\r\n";


        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Multiselect = false;
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                txtFileName.Text = ofd.FileName;
            }

        }

        private async void VideoAnalysis(string filename)
        {
            btnAnalysis.Enabled = false;
            chkSaveFrame.Enabled = false;

            //Emotion API KEY
            string EmotionAPIKEY = Properties.Settings.Default.emotionAPIKEY;

            if (txtFileName.Text == "" )
            {
                MessageBox.Show("ファイル名を入力してください", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAnalysis.Enabled = true;
                chkSaveFrame.Enabled = true;
                return;
            }

            if (!System.IO.File.Exists(txtFileName.Text))
            {
                MessageBox.Show("ファイルが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAnalysis.Enabled = true;
                chkSaveFrame.Enabled = true;
                return;
            }

            if (EmotionAPIKEY == "")
            {
                MessageBox.Show("Emotion API KEY が設定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAnalysis.Enabled = true;
                chkSaveFrame.Enabled = true;
                return;
            }

            //ビデオの読み込み
            OpenCvSharp.CvCapture capture;
            try
            {
                capture = new CvCapture(@filename);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "エラー", MessageBoxButtons.OK ,MessageBoxIcon.Error);
                return;
            }
            

            //ビデオをフレームか秒単位に画像を分割
            // 
            int interval = (int) (1000 / capture.Fps);

            int TotalFrame = capture.FrameCount;

            txtInfo.AppendText("総フレーム数：" + TotalFrame + " \r\n");
            txtInfo.AppendText("予想解析フレーム数：" + (int)(TotalFrame / capture.Fps) + " \r\n");

            //int totalframe = capture.
            string fullResult = "";

            pbProgress.Maximum = TotalFrame;
            pbProgress.Minimum = 0;
            pbProgress.Value = 0;

            while (true)
            {
                // フレーム画像を非同期に取得
                var image = await QueryFrameAsync(capture);
                if (image == null) break;

                if (capture.PosFrames % interval == 0)
                { 
                    //処理時のフレームと時間を保存
                    int currenFrame = capture.PosFrames;
                    TimeSpan fpstime = TimeSpan.FromMilliseconds(capture.PosMsec);


                    //EmothinAPIにかける
                    var eClient = new EmotionServiceClient(EmotionAPIKEY);
                    Emotion[] eResult = null;

                    string tempfile = System.IO.Path.GetFileNameWithoutExtension(filename) + "_Captured.jpg";
                    string savefile = System.IO.Path.GetFileNameWithoutExtension(filename) + "_" +  currenFrame + "_Captured.jpg";
                    image.SaveImage(tempfile);

                    try
                    {
                        eResult = await  eClient.RecognizeAsync(new System.IO.FileStream(tempfile, System.IO.FileMode.Open));

                    }
                    catch (Microsoft.ProjectOxford.Common.ClientException e)
                    {
                        txtInfo.AppendText("フレーム：" + currenFrame + " / ");
                        txtInfo.AppendText(e.Error.Code + " / " + e.Error.Message + "\r\n");
                        //throw e; //the debug.
                        eResult = null;

                    }

                    if (eResult != null)
                    {
                        if (eResult.Length >= 1)
                        {
                            string result = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}\r\n",
                                fpstime.ToString("c"),
                                currenFrame,
                                eResult[0].Scores.Anger,
                                eResult[0].Scores.Contempt,
                                eResult[0].Scores.Disgust,
                                eResult[0].Scores.Fear,
                                eResult[0].Scores.Happiness,
                                eResult[0].Scores.Sadness,
                                eResult[0].Scores.Surprise,
                                eResult[0].Scores.Neutral);

                            fullResult += result;

                            if (chkSaveFrame.Checked)
                                System.IO.File.Copy(tempfile, savefile);

                        }
                        else
                        {
                            string result = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}\r\n",
                                fpstime.ToString("c"), currenFrame, 0, 0, 0, 0, 0, 0, 0, 0);
                            fullResult += result;

                        }

                    }
                    else
                    {
                        string result = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}\r\n",
                            fpstime.ToString("c"), currenFrame, 0,0,0,0,0,0,0,0);
                        fullResult += result;
                    }

                    lblProgress.Text = currenFrame + " / " + TotalFrame;
                }
       
                //WriteableBitmapConverter.ToWriteableBitmap(image, wb);
                //imgResult.Source = wb;
                await Task.Delay(interval);
                pbProgress.Value = capture.PosFrames;
            }



            //分割したものをEmotionAPIにかける

            //結果をCSVで出力

            string outcsv = System.IO.Path.GetFileNameWithoutExtension(filename) + "_Result.csv";

            System.IO.File.WriteAllText(outcsv, csvExportHeader_JP + fullResult,System.Text.Encoding.GetEncoding("Shift-JIS"));

            MessageBox.Show("処理が完了しました");
            pbProgress.Value = pbProgress.Maximum;
            lblProgress.Text = "処理が完了しました";
            btnAnalysis.Enabled = true;
            chkSaveFrame.Enabled = true;


        }


        private async Task<IplImage> QueryFrameAsync(CvCapture capture)
        {
            // awaitできる形で、非同期にフレームの取得を行います。
            return await Task.Run(() =>
            {
                return capture.QueryFrame();
            });
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            VideoAnalysis(txtFileName.Text);
        }

        private void aPIKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var o = new OptionDialog())
            {
                o.ShowDialog();
            }
        }

        private void quitQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}
