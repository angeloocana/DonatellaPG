using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Donatella.Helpers
{
    public class ImagemHelper : IDisposable
    {
        public Boolean Erro { get; set; }
        public String ErroDescricao { get; set; }
        private string ImagemOriginal = string.Empty;

        #region Metodos Privados
        private void FixedSize(string pathImagem, string pathDestino, int Width, int Height, int PercentQuality)
        {
            Bitmap myBitmap;
            ImageCodecInfo myImageCodecInfo;
            System.Drawing.Imaging.Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            Image imgPhoto = Image.FromFile(pathImagem);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
            }
            else
            {
                nPercent = nPercentW;
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            myBitmap = new Bitmap(imgPhoto, destWidth, destHeight);


            // Get an ImageCodecInfo object that represents the JPEG codec.
            myImageCodecInfo = GetEncoderInfo("image/jpeg");

            // Create an Encoder object based on the GUID

            // for the Quality parameter category.
            myEncoder = System.Drawing.Imaging.Encoder.Quality;

            // EncoderParameter object in the array.
            myEncoderParameters = new EncoderParameters(1);

            // Save the bitmap as a JPEG file with quality level 25.            
            myEncoderParameter = new EncoderParameter(myEncoder, PercentQuality);
            myEncoderParameters.Param[0] = myEncoderParameter;

            myBitmap.Save(pathDestino, myImageCodecInfo, myEncoderParameters);
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        private Image DownloadImage(string _URL)
        {
            Image _tmpImage = null;

            try
            {
                // Open a connection
                System.Net.HttpWebRequest _HttpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(_URL);

                _HttpWebRequest.AllowWriteStreamBuffering = true;

                // You can also specify additional header values like the user agent or the referer: (Optional)
                _HttpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                _HttpWebRequest.Referer = "http://www.google.com/";

                // set timeout for 20 seconds (Optional)
                _HttpWebRequest.Timeout = 20000;

                // Request response:
                System.Net.WebResponse _WebResponse = _HttpWebRequest.GetResponse();

                // Open data stream:
                System.IO.Stream _WebStream = _WebResponse.GetResponseStream();

                // convert webstream to image
                _tmpImage = Image.FromStream(_WebStream);

                // Cleanup
                _WebResponse.Close();
                _WebResponse.Close();
            }
            catch (Exception _Exception)
            {
                // Error
                Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
            }

            return _tmpImage;
        }
        #endregion

        #region Metodos Publicos

        public ImagemHelper(string EnderecoArquivo)
        {
            string extencao = EnderecoArquivo.Substring(EnderecoArquivo.LastIndexOf('.')).ToLower();

            #region Valida se o arquivo é uma imagem
            {
                if (extencao != ".png" && extencao != ".gif" && extencao != ".jpg" && extencao != ".bmp" && extencao != ".jpeg")
                {
                    Erro = true;
                    ErroDescricao = "O formato do arquivo não é aceito\\nFormatos aceitos: PNG, GIF, JPG, BMP, JPEG";
                    return;
                }
            }
            #endregion

            #region Valida se o arquivo enviado existe no servidor
            {
                if (EnderecoArquivo.ToLower().Substring(0, 4) == "http")
                {
                    string raiz = System.Web.HttpContext.Current.Server.MapPath("." + @"\temp\");
                    if (!System.IO.Directory.Exists(raiz))
                        System.IO.Directory.CreateDirectory(raiz);

                    ImagemOriginal = raiz + DateTime.Now.Ticks.ToString() + extencao;
                    DownloadImage(EnderecoArquivo).Save(ImagemOriginal);
                }
                else if (!File.Exists(EnderecoArquivo))
                {
                    Erro = true;
                    ErroDescricao = "Arquivo não encontrado no servidor.";
                    return;
                }
                else
                    ImagemOriginal = EnderecoArquivo;
            }
            #endregion

        }

        public ImagemHelper(System.Web.UI.WebControls.FileUpload ObjetoFileUpload)
        {
            #region Valida se o arquivo existe no servidor
            {
                if (!ObjetoFileUpload.HasFile)
                {
                    Erro = true;
                    ErroDescricao = "Arquivo não foi selecionado";
                    return;
                }
            }
            #endregion

            string extencao = ObjetoFileUpload.FileName.Substring(ObjetoFileUpload.FileName.LastIndexOf('.')).ToLower();

            #region Valida se o arquivo é uma imagem
            {
                if (extencao != ".png" && extencao != ".gif" && extencao != ".jpg" && extencao != ".bmp" && extencao != ".jpeg")
                {
                    Erro = true;
                    ErroDescricao = "O formato do arquivo não é aceito\\nFormatos aceitos: PNG, GIF, JPG, BMP, JPEG";
                    return;
                }
            }
            #endregion

            #region Grava no diretório temporário
            {
                string raiz = System.Web.HttpContext.Current.Server.MapPath("." + @"\temp\");
                if (!System.IO.Directory.Exists(raiz))
                    System.IO.Directory.CreateDirectory(raiz);

                ImagemOriginal = raiz + DateTime.Now.Ticks.ToString() + extencao;
                ObjetoFileUpload.SaveAs(ImagemOriginal);

            }
            #endregion

        }

        public void SaveImage(string DestinoArquivo)
        {
            Image.FromFile(ImagemOriginal).Save(DestinoArquivo);
        }

        public void SaveImage(string DestinoArquivo, int PercentQuality)
        {
            Image imgPhoto = Image.FromFile(ImagemOriginal);
            FixedSize(ImagemOriginal, DestinoArquivo, imgPhoto.Width, imgPhoto.Height, PercentQuality);
        }

        public void SaveImage(string DestinoArquivo, int Width, int Height)
        {
            FileInfo f = new FileInfo(ImagemOriginal);
            int PercentQuality = 50;
            FixedSize(ImagemOriginal, DestinoArquivo, Width, Height, PercentQuality);
        }

        public void SaveImage(string DestinoArquivo, int Width, int Height, int PercentQuality)
        {
            FixedSize(ImagemOriginal, DestinoArquivo, Width, Height, PercentQuality);
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            //throw new NotImplementedException();
        }

        #endregion

    }
}

