---
title: HtmlString
author: 骆宏伟
date: 2021-07-26
category: Common
layout: post
---

## Method


#### ToEncode
HtmlEncode
```
string s="http://localhost:90/api/docs/1?name=LA&age=12";
s.ToEncode()
```
output:
```
http://localhost:90/api/docs/1?name=LA&amp;age=12
```
#### ToDecode
HtmlDecode
```
string s="http://localhost:90/api/docs/1?name=LA&age=12";
s.ToDecode()
```
output:
```
http://localhost:90/api/docs/1?name=LA&age=12
```

#### DeleteHMTL
delete html code,reserve content
```
string s="<span>this is a span lable</span>";
s.DeleteHMTL()
```
output:
```
this is a span lable
```