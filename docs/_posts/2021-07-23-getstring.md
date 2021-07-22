---
title: GetString
author: 骆宏伟
date: 2021-07-23
category: datatype
layout: post
---

### GetString Method
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