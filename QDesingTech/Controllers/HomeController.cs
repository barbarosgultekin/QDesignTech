using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing;
using System.Drawing.Imaging;

namespace QDesingTech.Controllers
{
    public class HomeController : Controller
    {
        QRCodeEncoder encoder = new QRCodeEncoder();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {

            if (Request.Form.Count > 0)
            {

                string ssid = Request.Form["ssid"];
                string pass = Request.Form["pass"];
                string wpa = Request.Form["wpa"];


                string wifi = "WIFI:S:" + ssid + ";T:" + wpa + ";P:" + pass + ";;";


                QRCodeEncoder cnv = new QRCodeEncoder();

                //encoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                //encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;


                cnv.QRCodeScale = 5;
                cnv.QRCodeVersion = 6;
                cnv.QRCodeBackgroundColor = Color.White;
                cnv.QRCodeForegroundColor = Color.Black;

                Bitmap bmp = cnv.Encode(wifi);

                //bmp.Save("C:\\FiX\\MVC\\QRGenerator\\QR.jpeg", ImageFormat.Jpeg);

                Response.ContentType = "image/jpeg";
                bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
                bmp.Dispose();
                Response.Flush();

            }

            return View();
        }

        public ActionResult Contact()
        {
            if (Request.Form.Count > 0)
            {
                //string tel = Request.Form["tel"];
                //string tele = "tel:" + tel;

                string text1 = Request.Form["text"];
                //string text2 = "https://" + "docs.google.com/" + "document/d/" + text1 +"/edit?usp=sharing";
                // string zz = "URLTO:" + text1;

                //docs.google.com/document/d/1ivfjjb0-YyMgl63bl7Ev99TFBvAyGqCHggdwH6542D8/edit?usp=sharing
                QRCodeEncoder karekod = new QRCodeEncoder();

                //QRCodeDecoder dc = new QRCodeDecoder();

                //Barcode[] barcodes = BarcodeReader.ReadBarcodes(settings, bmp);
                karekod.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
                karekod.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                karekod.QRCodeScale = 15;
                karekod.QRCodeVersion = 4;
                karekod.QRCodeBackgroundColor = Color.White;
                karekod.QRCodeForegroundColor = Color.Black;

                //tele = "http://qdesing.tech/Home/ABCD";

                Bitmap resim = karekod.Encode(text1);
                resim.Save(Response.OutputStream, ImageFormat.Png);
                Response.ContentType = "image/jpeg";
                ViewBag.karekodresim = resim;

                //System.Drawing.Image im = cnv.Encode(text1);

                ////bmp.Dispose();      

                //Response.Flush();
            }

            return View();
        }

        public ActionResult ABC()
        {
            return View();
        }

        public ActionResult XX()
        {
            return View();
        }

        public ActionResult ABCD()
        {
            return View();
        }
    }
}