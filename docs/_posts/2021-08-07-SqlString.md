---
title: SqlString
author: 骆宏伟
date: 2021-08-07
category: Common
layout: post
---

## Method

#### FilterSql
Filter sql injection.
```
string s="select * from user where name='nick';update user set name='tom'";
s.FilterSql()
```
output:
```
select* from user where name=nick;updateuser set name=tom
```

#### IsSafeSqlString
Check the sql string whether is safe.
```
s.IsSafeSqlString()
```
output:
```
False
```


#### addBeginEnd
Filter sql injection, add % and ' at start and end of string.
```
s.addBeginEnd()
```
output:
```
'%select* from user where name=nick;updateuser set n%'
```


#### addSplit
Filter sql injection
```
s.addSplit()
```
output:
```
%%s%e%l%e%c%t*%f%r%o%m%u%s%e%r%w%h%e%r%e%n%a%m%e=%n%i%c%k;%u%p%d%a%t%e%u%s%e%r%s%e%t%n%a%m%e=%t%o%
```
```
s.addSplit(true)
```
output:
```
'%s%e%l%e%c%t*%f%r%o%m%u%s%e%r%w%h%e%r%e%n%a%m%e=%n%i%c%k;%u%p%d%a%t%e%u%s%e%r%s%e%t%n%a%m%e=%t%o%'
```