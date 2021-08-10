---
title: ExtDouble
author: 骆宏伟
date: 2021-07-30
category: DataType
layout: post
---

## Method

#### GetDouble
convert nullable double to double
```
double? d=null;
Console.WriteLine(d.GetDouble());
d=0.1D;
Console.WriteLine(d.GetDouble());
```
output:
```
0
0.1
```