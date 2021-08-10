---
title: ExtDatetime
author: 骆宏伟
date: 2021-07-30
category: DataType
layout: post
---

## Method

#### GetDateTime
convert nullable DateTime to DateTime
```
DateTime? d=null;
Console.WriteLine(d.GetDateTime());
```
output:
```
2021/7/30 1:33:16
```

#### GetString
convert nullable DateTime to string(format：i.e：yyyy-MM-dd hh:mm:ss)
```
DateTime? d=DateTime.Now;
Console.WriteLine(d.GetString("yyyy-MM-dd hh:mm:ss"));
```
output:
```
2021-07-30 01:33:16
```

#### FormatCN(bool)
将日期转换成`日期+汉字`格式 (格式：2009-09-09 12:30 星期三)
```
DateTime d=DateTime.Now;
Console.WriteLine(d.FormatCN());
Console.WriteLine(d.FormatCN(true));
d=DateTime.Now.AddDays(-1);
Console.WriteLine(d.FormatCN());
Console.WriteLine(d.FormatCN(true));
d=DateTime.Now.AddDays(1);
Console.WriteLine(d.FormatCN());
Console.WriteLine(d.FormatCN(true));
```
output:
```
2021-07-30 01:36 <span style='color:red;'>今天</span>
2021-07-30<br>01:36 <span style='color:red;'>今天</span>
2021-07-29 01:36 昨天
2021-07-29<br>01:36 昨天
2021-07-31 01:36 明天
2021-07-31<br>01:36 明天
```

#### FirstDayOfMonth
Get first day of month.
```
d.FirstDayOfMonth()
```
output:
```
2021-08-01 00:00:00Z
```

#### LastDayOfMonth
Get last day of month.
```
d.LastDayOfMonth()
```
output:
```
2021-08-31 00:00:00Z
```

#### DaysInMonth
Get days in month.
```
d.DaysInMonth()
```
output:
```
31
```

#### DayOfWeekToCN
返回日期几
```
d.DayOfWeekToCN()
```
output:
```
三
```