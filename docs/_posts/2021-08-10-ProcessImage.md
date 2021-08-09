---
title: ProcessImage
author: 骆宏伟
date: 2021-08-10
category: Tool
layout: post
---

## Method

#### CreateThumbnail
Create thumbnail image has the same width and height like the original image.  
+ stream:
image stream.
+ savepath:
save file path

#### CreateThumbnail
Create thumbnail image with the width and height. 
+ stream:
image stream.
+ savepath:
save file path.
+ createwidth:
thumbnail image width.
+ createheight:
thumbnail image height.
+ addwhite:
whether add white background around image,if the thumbnail image is smaller than original image.

#### CreateThumbnail
Create thumbnail image has the same width and height like the original image.
+ readpath:
original image path.
+ savepath:
save image path.

#### CreateThumbnail
Create thumbnail image with the width and height. 
+ readpath:
original image path.
+ savepath:
save image path.
+ createwidth:
thumbnail image width.
+ createheight:
thumbnail image height.
+ addwhite:
whether add white background around image,if the thumbnail image is smaller than original image.

#### AddWaterText
Add water mark with text.(Do not support *.gif).
+ readpath:
original image path.
+ savepath:
save image path.
+ watermarkText:
water mark text.
+ position:
position.
+ font:
font.
+ size:
font size.
+ color:
color.

#### AddWaterMark
Add water mark with the mark image.(Do not support *.gif).
+ readpath:
original image path.
+ watermarkpath:
water mark image path.
+ transparence:
transparence between 0.0f and 1.0f.
+ position:
position.
+ margin:
margin.
+ savepath:
save image path.
+ global:
add the whole iamge or the size with water mark image.

#### AddWaterMark
Add water mark with the mark image.(Do not support *.gif).
+ readpath:
original image path.
+ watermarkpath:
water mark image path.
+ transparence:
transparence between 0.0f and 1.0f.
+ position:
position.
+ margin:
margin.
+ savepath:
save image path.
+ createwidth:
the thumbnail image width.
+ createheight:
the thumbnail iamge height.
+ global:
add the whole iamge or the size with water mark image.

#### enum WatermarkPosition
The water mark iamge position on image.
```
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
```
