---
title: ExtDecimal
author: 骆宏伟
date: 2021-07-30
category: DataType
layout: post
---

## Method

#### GetDecimal
convert nullable decimal to decimal
```
decimal? d=null;
Console.WriteLine(d.GetDecimal());
d=0.1M;
Console.WriteLine(d.GetDecimal());
```
output:
```
0
0.1
```