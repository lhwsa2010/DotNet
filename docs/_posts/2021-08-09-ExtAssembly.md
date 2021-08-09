---
title: ExtAssembly
author: 骆宏伟
date: 2021-08-09
category: Common
layout: post
---

## Method

#### GetAssemblyAttribute<T>
Get assembly attribute value.
```
Assembly.GetExecutingAssembly().GetAssemblyAttribute<AssemblyCompanyAttribute>()
Assembly.GetExecutingAssembly().GetAssemblyAttribute<AssemblyTitleAttribute>()
Assembly.GetExecutingAssembly().GetAssemblyAttribute<AssemblyCopyrightAttribute>()
```