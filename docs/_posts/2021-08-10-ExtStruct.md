---
title: ExtStruct
author: 骆宏伟
date: 2021-08-07
category: DataType
layout: post
---

## Method

#### Serialize
Serializes the struct to a byte array.
```
tStruct.Serialize()
tStruct.Serialize<TStruct>()
```

#### Deserialize
Deserializes the byte array to a struct.
```
bytes.Deserialize<TStruct>()
```