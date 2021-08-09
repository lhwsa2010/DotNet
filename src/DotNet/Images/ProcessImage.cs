using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace DotNet.Tool
{
    /// <summary>
    /// Process image.
    /// </summary>
    public class ProcessImage
    {
        /// <summary>
        /// Create thumbnail image has the same width and height like the original image.  
        /// </summary>
        /// <param name="stream">image stream</param>
        /// <param name="savepath">save file path</param>
        /// <returns></returns>
        public (bool isSuccess, string message) CreateThumbnail(Stream stream, string savepath)
        {
            try
            {
                Image image = Image.FromStream(stream);
                return CreateThumbnail(image, savepath, image.Width, image.Height, false);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        /// <summary>
        /// Create thumbnail image with the width and height. 
        /// </summary>
        /// <param name="stream">image stream</param>
        /// <param name="savepath">save file path</param>
        /// <param name="createwidth">thumbnail image width</param>
        /// <param name="createheight">thumbnail image height</param>
        /// <param name="addwhite">whether add white background around image,if the thumbnail image is smaller than original image.</param>
        /// <returns></returns>
        public (bool isSuccess, string message) CreateThumbnail(Stream stream, string savepath, int createwidth, int createheight, bool addwhite = default)
        {
            try
            {
                Image image = Image.FromStream(stream);
                return CreateThumbnail(image, savepath, createwidth, createheight, addwhite);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        /// <summary>
        /// Create thumbnail image has the same width and height like the original image.  
        /// </summary>
        /// <param name="readpath">original image path</param>
        /// <param name="savepath">save image path</param>
        /// <returns></returns>
        public (bool isSuccess, string message) CreateThumbnail(string readpath, string savepath)
        {
            try
            {
                Image image = Image.FromFile(readpath);
                return CreateThumbnail(image, savepath, image.Width, image.Height, false);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        /// <summary>
        /// Create thumbnail image with the width and height. 
        /// </summary>
        /// <param name="readpath">original image path</param>
        /// <param name="savepath">save image path</param>
        /// <param name="createwidth">thumbnail image width</param>
        /// <param name="createheight">thumbnail image height</param>
        /// <param name="addwhite">whether add white background around image,if the thumbnail image is smaller than original image.</param>
        /// <returns></returns>
        public (bool isSuccess, string message) CreateThumbnail(string readpath, string savepath, int createwidth, int createheight, bool addwhite = default)
        {
            try
            {
                Image image = Image.FromFile(readpath);
                return CreateThumbnail(image, savepath, createwidth, createheight, addwhite);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        /// <summary>
        /// 创建缩略图
        /// </summary>
        /// <param name="original_image">Image 对象</param>
        /// <param name="savepath">完成保存地址,需要server.mappath</param>
        /// <param name="createwidth">生成图片的宽度</param>
        /// <param name="createheight">生成图片的高度</param>
        /// <param name="addwhite">是否填充白色（如果高度和宽度达不到生成图片的比例时，会自动在宽或者高处填充白色）</param>
        /// <returns>0:创建缩略图失败，1：传入的文件格式错误，2：创建成功</returns>
        private (bool isSuccess, string message) CreateThumbnail(Image image, string savepath, int createwidth, int createheight, bool addwhite)
        {
            bool isSuccess = false;
            string message = "";
            try
            {
                if (createheight == 0)
                {
                    createheight = image.Height;
                }
                if (createwidth == 0)
                {
                    createwidth = image.Width;
                }
                Bitmap final_image = null;
                Graphics graphic = null;
                int width = image.Width;
                int height = image.Height;
                int target_width = createwidth;
                int target_height = createheight;
                int new_width, new_height;

                float target_ratio = (float)target_width / (float)target_height;
                float image_ratio = (float)width / (float)height;

                if (target_ratio > image_ratio)
                {
                    new_height = target_height;
                    new_width = (int)Math.Floor(image_ratio * (float)target_height);
                }
                else
                {
                    new_height = (int)Math.Floor((float)target_width / image_ratio);
                    new_width = target_width;
                }

                if (addwhite)
                {
                    //传入的图片过小时，直接生成，四周加白色
                    if (width < target_width && height < target_height)
                    {
                        new_height = height;
                        new_width = width;
                    }

                    //不要出现黑边
                    final_image = new System.Drawing.Bitmap(target_width, target_height);
                    graphic = System.Drawing.Graphics.FromImage(final_image);
                    graphic.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), new System.Drawing.Rectangle(0, 0, target_width, target_height));

                    int paste_x = (target_width - new_width) / 2;
                    int paste_y = (target_height - new_height) / 2;
                    graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graphic.DrawImage(image, paste_x, paste_y, new_width, new_height);
                    final_image.Save(savepath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    final_image = new System.Drawing.Bitmap(new_width, new_height);
                    graphic = System.Drawing.Graphics.FromImage(final_image);
                    graphic.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), new System.Drawing.Rectangle(0, 0, new_width, new_height));
                    int paste_x = 0;
                    int paste_y = 0;
                    graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graphic.DrawImage(image, paste_x, paste_y, new_width, new_height);
                    final_image.Save(savepath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }

                image.Dispose();
                final_image.Dispose();
                graphic.Dispose();

                isSuccess = true;
                message = "Success";
            }
            catch (Exception ex)
            {
                isSuccess = false;
                message = ex.Message;
            }
            return (isSuccess, message);
        }

        /// <summary>
        /// Add water mark with text.(Do not support *.gif)
        /// </summary>
        /// <param name="readpath">original image path</param>
        /// <param name="savepath">save image path</param>
        /// <param name="watermarkText">water mark text</param>
        /// <param name="position">position</param>
        /// <param name="font">font</param>
        /// <param name="size">font size</param>
        /// <param name="color">color</param>
        /// <returns></returns>
        public (bool isSuccess, string message) AddWaterText(string readpath, string savepath, string watermarkText, WatermarkPosition position, string font, int size, Color color)
        {
            try
            {

                Image img = Image.FromFile(readpath);

                Graphics graphic = Graphics.FromImage(img);
                Font f = new Font(font, size);
                Brush b = new SolidBrush(color);

                float xpos = 0;
                float ypos = 0;

                SizeF crSize = graphic.MeasureString(watermarkText, f);

                switch (position)
                {
                    case WatermarkPosition.LeftTop:
                        xpos = (float)img.Width * (float).01;
                        ypos = (float)img.Height * (float).01;
                        break;
                    case WatermarkPosition.Top:
                        xpos = ((float)img.Width * (float).50) - (crSize.Width / 2);
                        ypos = (float)img.Height * (float).01;
                        break;
                    case WatermarkPosition.RightTop:
                        xpos = ((float)img.Width * (float).99) - crSize.Width;
                        ypos = (float)img.Height * (float).01;
                        break;
                    case WatermarkPosition.Left:
                        xpos = (float)img.Width * (float).01;
                        ypos = ((float)img.Height * (float).50) - (crSize.Height / 2);
                        break;
                    case WatermarkPosition.Center:
                        xpos = ((float)img.Width * (float).50) - (crSize.Width / 2);
                        ypos = ((float)img.Height * (float).50) - (crSize.Height / 2);
                        break;
                    case WatermarkPosition.RightCenter:
                        xpos = ((float)img.Width * (float).99) - crSize.Width;
                        ypos = ((float)img.Height * (float).50) - (crSize.Height / 2);
                        break;
                    case WatermarkPosition.LeftBottom:
                        xpos = (float)img.Width * (float).01;
                        ypos = ((float)img.Height * (float).99) - crSize.Height;
                        break;
                    case WatermarkPosition.Bottom:
                        xpos = ((float)img.Width * (float).50) - (crSize.Width / 2);
                        ypos = ((float)img.Height * (float).99) - crSize.Height;
                        break;
                    default:
                        xpos = ((float)img.Width * (float).99) - crSize.Width;
                        ypos = ((float)img.Height * (float).99) - crSize.Height;
                        break;
                }

                graphic.DrawString(watermarkText, f, b, xpos, ypos);
                img.Save(savepath);
                graphic.Dispose();
                img.Dispose();

                return (true, "Success");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        /// <summary>
        /// Add water mark with the mark image.(Do not support *.gif)
        /// </summary>
        /// <param name="readpath">original image path</param>
        /// <param name="watermarkpath">water mark image path</param>
        /// <param name="transparence">transparence between 0.0f and 1.0f</param>
        /// <param name="position">position</param>
        /// <param name="margin">margin</param>
        /// <param name="savepath">save image path</param>
        /// <param name="global">add the whole iamge or the size with water mark image</param>
        /// <returns></returns>
        public (bool isSuccess, string message) AddWaterMark(string readpath, string watermarkpath, float transparence, WatermarkPosition position, int margin, string savepath, bool global = default)
        {
            if (string.Compare(readpath, savepath) == 0)
                throw new ArgumentException("The source and destination cannot be the same.");

            Bitmap b = null;
            try
            {
                b = new Bitmap(readpath);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
            if (transparence == 0.0f)
                return Save(readpath, savepath);
            else if (transparence == 1.0f)
                return SaveWatermark(b, new Bitmap(watermarkpath), position, margin, savepath, global);
            else
                return SaveWatermark(b, SetTransparence(watermarkpath, transparence), position, margin, savepath, global);
        }

        /// <summary>
        /// Add water mark with the mark image.(Do not support *.gif)
        /// </summary>
        /// <param name="readpath">original image path</param>
        /// <param name="watermarkpath">water mark image path</param>
        /// <param name="transparence">transparence between 0.0f and 1.0f</param>
        /// <param name="position">position</param>
        /// <param name="margin">margin</param>
        /// <param name="savepath">save image path</param>
        /// <param name="createwidth">the thumbnail image width</param>
        /// <param name="createheight">the thumbnail iamge height</param>
        /// <param name="global">add the whole iamge or the size with water mark image</param>
        /// <returns></returns>
        public (bool isSuccess, string message) AddWaterMark(string readpath, string watermarkpath, float transparence, WatermarkPosition position, int margin, string savepath, int createwidth, int createheight, bool global = default)
        {
            string spath = Regex.Replace(readpath, ".jpg", "--.jpg", RegexOptions.IgnoreCase);

            (bool isSuccess, string message) = CreateThumbnail(readpath, spath, createwidth, createheight);
            if (isSuccess)
            {
                (bool b, string s) r = AddWaterMark(spath, watermarkpath, transparence, position, margin, savepath, global);
                try
                {
                    File.Delete(spath);
                }
                catch { }
                return r;
            }
            return (isSuccess, message);
        }

        /// <summary>
        /// 获取: 图片去扩展名(包含完整路径及其文件名)小写字符串
        /// </summary>
        /// <param name="path">图片路径(包含完整路径,文件名及其扩展名): string</param>
        /// <returns>返回: 图片去扩展名(包含完整路径及其文件名)小写字符串: string</returns>
        private string GetFileName(string path)
        {
            return path.Remove(path.LastIndexOf('.')).ToLower();
        }

        /// <summary>
        /// 获取: 图片以'.'开头的小写字符串扩展名
        /// </summary>
        /// <param name="path">图片路径(包含完整路径,文件名及其扩展名): string</param>
        /// <returns>返回: 图片以'.'开头的小写字符串扩展名: string</returns>
        private string GetExtension(string path)
        {
            return path.Remove(0, path.LastIndexOf('.')).ToLower();
        }

        /// <summary>
        /// 获取: 图片以 '.' 开头的小写字符串扩展名对应的 System.Drawing.Imaging.ImageFormat 对象
        /// </summary>
        /// <param name="format">以 '. '开头的小写字符串扩展名: string</param>
        /// <returns>返回: 图片以 '.' 开头的小写字符串扩展名对应的 System.Drawing.Imaging.ImageFormat 对象: System.Drawing.Imaging.ImageFormat</returns>
        private ImageFormat GetImageFormat(string format)
        {
            switch (format)
            {
                case ".bmp":
                    return ImageFormat.Bmp;
                case ".emf":
                    return ImageFormat.Emf;
                case ".exif":
                    return ImageFormat.Exif;
                case ".gif":
                    return ImageFormat.Gif;
                case ".ico":
                    return ImageFormat.Icon;
                case ".png":
                    return ImageFormat.Png;
                case ".tif":
                    return ImageFormat.Tiff;
                case ".tiff":
                    return ImageFormat.Tiff;
                case ".wmf":
                    return ImageFormat.Wmf;
                default:
                    return ImageFormat.Jpeg;
            }
        }

        /// <summary>
        /// 获取: 枚举 ImageManager.WatermarkPosition 对应的 System.Drawing.Rectangle 对象
        /// </summary>
        /// <param name="positon">枚举 ImageManager.WatermarkPosition: ImageManager.WatermarkPosition</param>
        /// <param name="X">原图宽度: int</param>
        /// <param name="Y">原图高度: int</param>
        /// <param name="x">水印宽度: int</param>
        /// <param name="y">水印高度: int</param>
        /// <param name="i">边距: int</param>
        /// <returns>返回: 枚举 ImageManager.WatermarkPosition 对应的 System.Drawing.Rectangle 对象: System.Drawing.Rectangle</returns>
        private Rectangle GetWatermarkRectangle(WatermarkPosition positon, int X, int Y, int x, int y, int i)
        {
            switch (positon)
            {
                case WatermarkPosition.LeftTop:
                    return new Rectangle(i, i, x, y);
                case WatermarkPosition.Left:
                    return new Rectangle(i, (Y - y) / 2, x, y);
                case WatermarkPosition.LeftBottom:
                    return new Rectangle(i, Y - y - i, x, y);
                case WatermarkPosition.Top:
                    return new Rectangle((X - x) / 2, i, x, y);
                case WatermarkPosition.Center:
                    return new Rectangle((X - x) / 2, (Y - y) / 2, x, y);
                case WatermarkPosition.Bottom:
                    return new Rectangle((X - x) / 2, Y - y - i, x, y);
                case WatermarkPosition.RightTop:
                    return new Rectangle(X - x - i, i, x, y);
                case WatermarkPosition.RightCenter:
                    return new Rectangle(X - x - i, (Y - y) / 2, x, y);
                default:
                    return new Rectangle(X - x - i, Y - y - i, x, y);
            }
        }

        /// <summary>
        /// 设置: 图片 System.Drawing.Bitmap 对象透明度
        /// </summary>
        /// <param name="sBitmap">图片 System.Drawing.Bitmap 对象: System.Drawing.Bitmap</param>
        /// <param name="transparence">水印透明度(值越高透明度越低,范围在0.0f~1.0f之间): float</param>
        /// <returns>图片 System.Drawing.Bitmap: System.Drawing.Bitmap</returns>
        private Bitmap SetTransparence(Bitmap bm, float transparence)
        {
            if (transparence == 0.0f || transparence == 1.0f)
                throw new ArgumentException("transparence value must between 0.0f and 1.0f.");
            float[][] floatArray =
            {
                new float[] { 1.0f, 0.0f, 0.0f, 0.0f, 0.0f },
                new float[] { 0.0f, 1.0f, 0.0f, 0.0f, 0.0f },
                new float[] { 0.0f, 0.0f, 1.0f, 0.0f, 0.0f },
                new float[] { 0.0f, 0.0f, 0.0f, transparence, 0.0f },
                new float[] { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f }
            };
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(new ColorMatrix(floatArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Bitmap bitmap = new Bitmap(bm.Width, bm.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(bm, new Rectangle(0, 0, bm.Width, bm.Height), 0, 0, bm.Width, bm.Height, GraphicsUnit.Pixel, imageAttributes);
            graphics.Dispose();
            imageAttributes.Dispose();
            bm.Dispose();
            return bitmap;
        }

        /// <summary>
        ///  设置: 图片 System.Drawing.Bitmap 对象透明度
        /// </summary>
        /// <param name="readpath">图片路径(包含完整路径,文件名及其扩展名): string</param>
        /// <param name="transparence">水印透明度(值越高透明度越低,范围在0.0f~1.0f之间): float</param>
        /// <returns>图片 System.Drawing.Bitmap: System.Drawing.Bitmap</returns>
        private Bitmap SetTransparence(string readpath, float transparence)
        {
            return SetTransparence(new Bitmap(readpath), transparence);
        }

        /// <summary>
        /// 生成: 原图绘制水印的 System.Drawing.Bitmap 对象
        /// </summary>
        /// <param name="sBitmap">原图 System.Drawing.Bitmap 对象: System.Drawing.Bitmap</param>
        /// <param name="wBitmap">水印 System.Drawing.Bitmap 对象: System.Drawing.Bitmap</param>
        /// <param name="position">枚举 ImageManager.WatermarkPosition : ImageManager.WatermarkPosition</param>
        /// <param name="margin">水印边距: int</param>
        /// <returns>返回: 原图绘制水印的 System.Drawing.Bitmap 对象 System.Drawing.Bitmap</returns>
        /// <param name="quanju">全局打水印,true：是 false:否</param>
        private Bitmap CreateWatermark(Bitmap sBitmap, Bitmap wBitmap, WatermarkPosition position, int margin, bool global = default)
        {
            Graphics graphics = Graphics.FromImage(sBitmap);
            if (global)
            {
                int w = (int)Math.Ceiling(((double)sBitmap.Width) / ((double)wBitmap.Width));
                int h = (int)Math.Ceiling(((double)sBitmap.Height) / ((double)wBitmap.Height));
                int x = 0;
                int y = 0;
                Rectangle r;
                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {
                        x = j * wBitmap.Width + 1;
                        y = i * wBitmap.Height + 1;
                        r = new Rectangle(x, y, wBitmap.Width, wBitmap.Height);
                        graphics.DrawImage(wBitmap, r);
                    }
                }
            }
            else
            {
                graphics.DrawImage(wBitmap, GetWatermarkRectangle(position, sBitmap.Width, sBitmap.Height, wBitmap.Width, wBitmap.Height, margin));
            }
            graphics.Dispose();
            wBitmap.Dispose();
            return sBitmap;
        }

        /// <summary>
        /// 保存: System.Drawing.Bitmap 对象到图片文件
        /// </summary>
        /// <param name="bitmap">System.Drawing.Bitmap 对象: System.Drawing.Bitmap</param>
        /// <param name="writepath">保存路径(包含完整路径,文件名及其扩展名): string</param>
        private (bool isSuccess, string message) Save(Bitmap bitmap, string writepath)
        {
            try
            {
                bitmap.Save(writepath, GetImageFormat(GetExtension(writepath)));
                bitmap.Dispose();
                return (true, "Success");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        /// <summary>
        /// 保存: 对象到图片文件
        /// </summary>
        /// <param name="readpath">原图路径(包含完整路径,文件名及其扩展名): string</param>
        /// <param name="writepath">保存路径(包含完整路径,文件名及其扩展名): string</param>
        private (bool isSuccess, string message) Save(string readpath, string writepath)
        {
            if (string.Compare(readpath, writepath) == 0)
                throw new ArgumentException("The source and destination cannot be the same.");
            try
            {
                return Save(new Bitmap(readpath), writepath);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        /// <summary>
        /// 保存: 设置透明度的对象到图片文件
        /// </summary>
        /// <param name="sBitmap">图片 System.Drawing.Bitmap 对象: System.Drawing.Bitmap</param>
        /// <param name="transparence">水印透明度(值越高透明度越低,范围在0.0f~1.0f之间): float</param>
        /// <param name="writepath">保存路径(包含完整路径,文件名及其扩展名): string</param>
        private void SaveTransparence(Bitmap bitmap, float transparence, string writepath)
        {
            Save(SetTransparence(bitmap, transparence), writepath);
        }

        /// <summary>
        /// 保存: 设置透明度的象到图片文件
        /// </summary>
        /// <param name="readpath">原图路径(包含完整路径,文件名及其扩展名): string</param>
        /// <param name="transparence">水印透明度(值越高透明度越低,范围在0.0f~1.0f之间): float</param>
        /// <param name="writepath">保存路径(包含完整路径,文件名及其扩展名): string</param>
        private void SaveTransparence(string readpath, float transparence, string writepath)
        {
            Save(SetTransparence(readpath, transparence), writepath);
        }

        /// <summary>
        /// 保存: 绘制水印的对象到图片文件
        /// </summary>
        /// <param name="sBitmap">原图 System.Drawing.Bitmap 对象: System.Drawing.Bitmap</param>
        /// <param name="wBitmap">水印 System.Drawing.Bitmap 对象: System.Drawing.Bitmap</param>
        /// <param name="position">枚举 ImageManager.WatermarkPosition : ImageManager.WatermarkPosition</param>
        /// <param name="margin">水印边距: int</param>
        /// <param name="writepath">保存路径(包含完整路径,文件名及其扩展名): string</param>
        /// <param name="quanju">全局打水印,true：是 false:否</param>
        private (bool isSuccess, string message) SaveWatermark(Bitmap sBitmap, Bitmap wBitmap, WatermarkPosition position, int margin, string writepath, bool global = default)
        {
            return Save(CreateWatermark(sBitmap, wBitmap, position, margin, global), writepath);
        }

        /// <summary>
        /// The water mark iamge position on image.
        /// </summary>
        public enum WatermarkPosition
        {
            /// <summary>
            /// 左上
            /// </summary>
            LeftTop,
            /// <summary>
            /// 左中
            /// </summary>
            Left,
            /// <summary>
            /// 左下
            /// </summary>
            LeftBottom,
            /// <summary>
            /// 正上
            /// </summary>
            Top,
            /// <summary>
            /// 正中
            /// </summary>
            Center,
            /// <summary>
            /// 正下
            /// </summary>
            Bottom,
            /// <summary>
            /// 右上
            /// </summary>
            RightTop,
            /// <summary>
            /// 右中
            /// </summary>
            RightCenter,
            /// <summary>
            /// 右下
            /// </summary>
            RigthBottom
        }


        //Bitmap destBitmap = new Bitmap(width, height);
        //Graphics g = Graphics.FromImage(destBitmap);
        //g.Clear(Color.Transparent);
        //        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        //        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        //        g.DrawImage(sourImage, new Rectangle(0, 0, width, height), 0, 0, sourImage.Width, sourImage.Height, GraphicsUnit.Pixel);
        //        g.Dispose();

        //        //压缩    
        //        System.Drawing.Imaging.EncoderParam


    }
}
