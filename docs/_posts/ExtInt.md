---
title: ExtInt
author: 骆宏伟
date: 2021-01-01
category: DataType
layout: post
---

## Method

#### GetBool
0 convert to false ，others convert to true
```
int i = 0;
Console.WriteLine(i.GetBool());
int i2 = 123;
Console.WriteLine(i2.GetBool());
int? i3 = null;
Console.WriteLine(i3.GetBool());
```
output:
```
False
True
False
```

#### GetInt
convert nullable int to int
```
int? i2 = 123;
Console.WriteLine(i2.GetInt());
int? i3 = null;
Console.WriteLine(i3.GetInt());
Console.WriteLine(i3.GetInt(1));
```
output:
```
123
0
1
```