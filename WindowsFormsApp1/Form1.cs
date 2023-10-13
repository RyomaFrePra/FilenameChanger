using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            // OpenFileDialogを設定
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "ファイルを選択";
            openFileDialog.Filter = "すべてのファイル|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // ユーザーがファイルを選択した場合
                string selectedFilePath = openFileDialog.FileName;

                // 新しいファイル名をテキストボックスから取得
                string newFileNameCompany = textBoxCompany.Text;
                string newFileNameAmount = textBoxAmount.Text;

                if (!string.IsNullOrEmpty(newFileNameCompany) && !string.IsNullOrEmpty(newFileNameAmount))
                {
                    try
                    {
                        // オリジナルのファイル名から拡張子を抽出
                        string originalExtension = Path.GetExtension(selectedFilePath);

                        // 現在の日付を取得
                        DateTime currentDate = monthCalendar1.SelectionStart;
                        string datePart = currentDate.ToString("yyyy_MM_dd");

                        // 新しいファイル名を生成（日付を含む）
                        string newFileName = datePart + "_" + newFileNameCompany + "_" + newFileNameAmount + originalExtension;

                        // ファイル名を変更
                        string newFilePath = Path.Combine(Path.GetDirectoryName(selectedFilePath), newFileName);
                        File.Move(selectedFilePath, newFilePath);

                        // 成功メッセージを表示
                        MessageBox.Show("ファイル名が変更されました。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ファイル名の変更に失敗しました。\nエラーメッセージ: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("新しいファイル名、会社名、金額を入力してください。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
