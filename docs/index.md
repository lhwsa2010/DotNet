---
# Feel free to add content and custom Front Matter to this file.
# To modify the layout, see https://jekyllrb.com/docs/themes/#overriding-theme-defaults

layout: post
---


# DotNetFool ![Build Status](https://github.com/lhwsa2010/DotNet/actions/workflows/build.yml/badge.svg)
---
[![license](http://img.shields.io/badge/license-MIT-green.svg)](https://github.com/lhwsa2010/DotNet/blob/main/LICENSE)
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/lhwsa2010/dotnet)](https://github.com/lhwsa2010/dotnet/releases)
[![Nuget](https://img.shields.io/nuget/v/dotnetfool)](https://www.nuget.org/packages/DotNetFool)

<div align=center>
<img src="{{site.baseurl}}/gitbook/images/logo.png">
</div>

This is a C# library for common operating extensions.i.e:convert int to string、convert string to bool,etc.    
这是一个.net公共类库，提供了各种常用操作，如：常用类型变量之间互转等



## Installation
---
***DotNetFool*** is available as NuGet Package. Type the following command into NuGet Package Manager Console window to install it:
```
Install-Package DotNetFool
```
## Dependencies
+ *System.Configuration.ConfigurationManager*:
> The tool *Cfg* depends on it.
+ *System.Drawing.Common*:
> The tool *ProcessImage* depends on it.


## About
---
这是一个从2012年开始使用的.net类库，最近把它移植到.net core，因为每次引用需要来回复制，不方便管理，遂决定发布成NuGet包，于己方便，与人方便。
##### DotNetFool 是什么
这是一个.net公共类库，提供了各种常用操作，如：字符串转数字、数字转布尔型等。
##### 为什么叫DotNetFool
一直叫的名称是DotNet,因为发布NuGet包时无法使用DotNet,就随便改了一个可以验证通过的名称，于是DotNetFool诞生了。

## Contributors
钱豹(原项目拥有者)、夏延成、[骆宏伟](https://github.com/lhwsa2010)