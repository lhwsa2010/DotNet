---
title: ExtObject
author: 骆宏伟
date: 9999-01-01
category: DataType
layout: post
---

## Method

#### GetString
convert object to string ,if object is null return string empty
```
object a=1;
Console.WriteLine(a.GetString());
a='c';
Console.WriteLine(a.GetString());
a=false;
Console.WriteLine(a.GetString());
```
output:
```
1
c
False
```

