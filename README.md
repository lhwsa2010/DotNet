# DotNetFool ![Build Status](https://github.com/lhwsa2010/DotNet/actions/workflows/build.yml/badge.svg)

[![license](http://img.shields.io/badge/license-MIT-green.svg)](https://github.com/lhwsa2010/DotNet/blob/main/LICENSE)
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/lhwsa2010/dotnet)](https://github.com/lhwsa2010/dotnet/releases)
[![Nuget](https://img.shields.io/nuget/v/dotnetfool)](https://www.nuget.org/packages/DotNetFool)

这是一个.net公共类库，提供了各种常用操作，如：常用类型变量之间互转等



## Installation
*DotNetFool* is available as NuGet Package. Type the following command into NuGet Package Manager Console window to install it:
```
Install-Package DotNetFool
```
## Dependencies
+ *System.Configuration.ConfigurationManager*:
> The tool *Cfg* depends on it.
+ *System.Drawing.Common*:
> The tool *ProcessImage* depends on it.

## Docs

[Goto](https://lhwsa2010.github.io/DotNet)

## Usage i.e

#### GetInt Method
+ bool convert to int
```
var b = true;
Console.WriteLine(b.GetInt());
var b2 = false;
Console.WriteLine(b2.GetInt());
```
output:
```
1
0
```
+ string convert to int
```
var s = "123.222";
Console.WriteLine(s.GetInt());
var s2 = "thankyou";
Console.WriteLine(s2.GetInt());
var s3 = "1233";
Console.WriteLine(s3.GetInt());
```
output:
```
0
0
123
```
#### GetString Method
+ object convert to string
if object is null,the default method ToString ,will throw exception,broke the program,but GetString will return string empty,is friendly.
```
var i = 0;
Console.WriteLine(i.GetString());
var b = false;
Console.WriteLine(b.GetString());
var f = 0.5f;
Console.WriteLine(f.GetString());
var d = 0.58989898m;
Console.WriteLine(d.GetString());
```
output:
```
0
False
0.5
0.58989898
```
+ DateTime convert to string
DateTime convert to string,if datetime is null,return string empty.
*format* ie:yyyy-MM-dd
```
DateTime? d = DateTime.Now;
Console.WriteLine(d.GetString("yyyy-MM-dd"));
```
output:
```
2021-07-23
```