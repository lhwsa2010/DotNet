---
title: UrlEncoder
author: 骆宏伟
date: 2021-08-07
category: Tool
layout: post
---

## Method

#### Encode
Encode url.
```
string url="http://localhost:90/api/user?name=la&age=12";
UrlEncoder.Encode(url)
```
output:
```
http%3A%2F%2Flocalhost%3A90%2Fapi%2Fuser%3Fname%3Dla%26age%3D12
```

#### Decode
Decode url.
```
string url="http%3A%2F%2Flocalhost%3A90%2Fapi%2Fuser%3Fname%3Dla%26age%3D12";
UrlEncoder.Decode(url)
```
output:
```
http://localhost:90/api/user?name=la&age=12
```