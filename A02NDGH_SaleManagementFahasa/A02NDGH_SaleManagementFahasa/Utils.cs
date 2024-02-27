using Fahasa.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahasa
{
    public static class Utils
    {
        public static bool IsFullInformation(StaffInformation staff)
        {
            if (staff.BranchName == null
                || staff.PositionName == null
                || staff.Name == null
                || staff.BranchId == null
                || staff.PositionId == null
                || staff.Name == ""
                || staff.Username == null
                )
            {
                return false;
            }

            return true;
        }
        public static StaffInformation GetInformation(string path)
        {
            //Tach thanh tung dong
            //Name: values
            //tach name theo array --> doc value
            //Vay chuyen thanh dang JSON co de doc hon khong? - Duoc --> Ez hon nua

            StaffInformation staff = new StaffInformation();
            try
            {
                string jsonString = File.ReadAllText(path);
                staff = JsonSerializer.Deserialize<StaffInformation>(jsonString);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return staff;

        }

        public static void SaveInformation(string path, StaffInformation staff)
        {
            string jsonString = JsonSerializer.Serialize(staff);
            File.WriteAllText(path, jsonString);
        }
        public static string getPath()
        {
            //Get path file staff information
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = @"Resources\LoginInformation\information.txt";
            string path = Path.Combine(projectPath, filePath);

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            return path;
        }
        public static void loadImage(string nameImg, PictureBox thumbnail)
        {
            try
            {
                var request = WebRequest.Create(nameImg);

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    thumbnail.Image = Bitmap.FromStream(stream);
                    thumbnail.SizeMode = PictureBoxSizeMode.Zoom; // Có thể thay đổi chế độ hiển thị ảnh

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải ảnh: " + ex.Message);
            }
        }

    }
}
